unit mComando;

(* mComando *)

interface

uses
  Classes, SysUtils, StrUtils, TypInfo, Rtti,
  mCollection, mCollectionItem, mMapping, mValue,
  System.Generics.Collections;

type
  TmComando = class(TObject)
  private
  protected
  public
    class function GetSelect(AClass : TClass; AWhere : String = '') : String; overload;
    function GetSelect() : String; overload;
    function GetInsert() : String;
    function GetUpdate() : String;
    function GetDelete() : String;
  published
  end;

  procedure AddString(var AString : String; AStr : String; ASep : String; AIni : String = '');
  function GetValueStr(AObject: TObject; ANome : String) : String;

implementation

  procedure AddString(var AString : String; AStr : String; ASep : String; AIni : String = '');
  begin
    AString := AString + IfThen(AString <> '', ASep, AIni) + AStr;
  end;

  function GetTabela(AClass: TClass) : TTabela;
  var
    vCollectionItem : TmCollectionItem;
  begin
    if AClass.InheritsFrom(TmCollectionItem) then begin
      vCollectionItem := TmCollectionItemClass(AClass).Create(nil);
      Result := vCollectionItem.GetTabela();
      vCollectionItem.Free;
    end else
      Result := nil;
  end;

  function GetCampos(AClass: TClass) : TCampos;
  var
    vCollectionItem : TmCollectionItem;
  begin
    if AClass.InheritsFrom(TmCollectionItem) then begin
      vCollectionItem := TmCollectionItemClass(AClass).Create(nil);
      Result := vCollectionItem.GetCampos();
      vCollectionItem.Free;
    end else
      Result := nil;
  end;

  function IsValueNull(AObject: TObject; ANome : String) : Boolean;
  var
    vPropInfo : PPropInfo;
    vTipoBase : String;
  begin
    Result := False;

    vPropInfo := GetPropInfo(AObject, ANome);
    vTipoBase := LowerCase(vPropInfo^.PropType^.Name);

    case StrToTipoValue(vTipoBase) of
      tvBoolean :
        Result := GetOrdProp(AObject, ANome) = 0;
      tvDateTime :
        Result := GetFloatProp(AObject, ANome) = 0;
      tvFloat :
        Result := GetFloatProp(AObject, ANome) = 0;
      tvInteger :
        Result := GetOrdProp(AObject, ANome) = 0;
      tvString :
        Result := GetStrProp(AObject, ANome) = '';
    end;
  end;

  function GetValueStr(AObject: TObject; ANome : String) : String;
  var
    vPropInfo : PPropInfo;
    vTipoBase : String;
  begin
    if IsValueNull(AObject, ANome) then begin
      Result := 'null';
      Exit;
    end;

    vPropInfo := GetPropInfo(AObject, ANome);
    vTipoBase := LowerCase(vPropInfo^.PropType^.Name);

    case StrToTipoValue(vTipoBase) of
      tvBoolean :
        Result := '''' + IfThen(GetOrdProp(AObject, ANome) = 1, 'T', 'F') + '''';
      tvDateTime :
        Result := '''' + FormatDateTime('dd.mm.yyyy hh:nn:ss', GetFloatProp(AObject, ANome)) + '''';
      tvFloat :
        Result := AnsiReplaceStr(FloatToStr(GetFloatProp(AObject, ANome)), ',', '.');
      tvInteger :
        Result := IntToStr(GetOrdProp(AObject, ANome));
      tvString :
        Result := '''' + AnsiReplaceStr(GetStrProp(AObject, ANome), '''', '''''') + '''';
    end;
  end;

{ TmComando }

class function TmComando.GetSelect(AClass: TClass; AWhere: String): String;
var
  vTabela : TTabela;
  vCampos : TCampos;
  vCampo : TCampo;
  vFieldsAtr, vFields : String;
begin
  vTabela := GetTabela(AClass);
  vCampos := GetCampos(AClass);
  vFieldsAtr := '';
  vFields := '';

  for vCampo in vCampos do
    with vCampo do begin
      AddString(vFieldsAtr, Atributo + ' as "' + Atributo + '"', ', ');
      AddString(vFields, Campo + ' as ' + Atributo, ', ');
    end;

  Result :=
    'select ' + vFieldsAtr + ' from (' +
      'select ' + vFields + ' from '+ vTabela.Nome +
    ')' + IfThen(AWhere <> '', ' where ' + AWhere);
end;

function TmComando.GetSelect(): String;
var
  vCampos : TCampos;
  vCampo : TCampo;
  vWhere : String;
  I : Integer;
begin
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  for vCampo in vCampos do
    with vCampo do
      if Tipo in [mMapping.tfKey] then
        AddString(vWhere, Atributo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result := GetSelect(Self.ClassType, vWhere);

  FreeAndNil(vCampos);
end;

function TmComando.GetInsert(): String;
var
  vTabela : TTabela;
  vCampos : TCampos;
  vCampo : TCampo;
  vFields, vValues : String;
  I : Integer;
begin
  vTabela := GetTabela(Self.ClassType);
  vCampos := GetCampos(Self.ClassType);

  vFields := '';
  vValues := '';
  for vCampo in vCampos do
    with vCampo do begin
      AddString(vFields, Campo, ', ');
      AddString(vValues, GetValueStr(Self, Atributo), ', ');
    end;

  Result :=
    'insert into ' + vTabela.Nome +
    ' (' + vFields +
    ') values (' + vValues +
    ')';

  FreeAndNil(vTabela);
  FreeAndNil(vCampos);
end;

function TmComando.GetUpdate(): String;
var
  vTabela : TTabela;
  vCampos : TCampos;
  vCampo : TCampo;
  vSets, vWhere : String;
  I : Integer;
begin
  vTabela := GetTabela(Self.ClassType);
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  vSets := '';
  for vCampo in vCampos do
    with vCampo do
      if Tipo in [mMapping.tfKey] then
        AddString(vWhere, Campo + ' = ' + GetValueStr(Self, Atributo), ' and ')
      else
        AddString(vSets, Campo + ' = ' + GetValueStr(Self, Atributo), ', ');

  Result :=
    'update ' + vTabela.Nome +
    ' set ' + vSets +
    ' where ' + vWhere;

  FreeAndNil(vTabela);
  FreeAndNil(vCampos);
end;

function TmComando.GetDelete(): String;
var
  vTabela : TTabela;
  vCampos : TCampos;
  vCampo : TCampo;
  vWhere : String;
  I : Integer;
begin
  vTabela := GetTabela(Self.ClassType);
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  for vCampo in vCampos do
    with vCampo do
      if Tipo in [mMapping.tfKey] then
        AddString(vWhere, Campo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result :=
    'delete from ' + vTabela.Nome +
    ' where ' + vWhere;

  FreeAndNil(vTabela);
  FreeAndNil(vCampos);
end;

end.
