unit mComando;

(* mComando *)

interface

uses
  Classes, SysUtils, StrUtils, TypInfo,
  mCollection, mCollectionItem, mMapping, mValue;

type
  TmComando = class(TObject)
  private
  protected
  public
    function GetWhereKey() : String;
    function GetWhereAll() : String;

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

function TmComando.GetWhereKey() : String;
var
  vCampos : TCampos;
  vWhere : String;
  I : Integer;
begin
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  with vCampos do
    for I := 0 to Count - 1 do
      with TCampo(Items[I]) do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, Atributo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result := vWhere;

  FreeAndNil(vCampos);
end;

function TmComando.GetWhereAll() : String;
var
  vCampos : TCampos;
  vWhere : String;
  I : Integer;
begin
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  with vCampos do
    for I := 0 to Count - 1 do
      with TCampo(Items[I]) do
        if not IsValueNull(Self, Atributo) then
          AddString(vWhere, Atributo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result := vWhere;

  FreeAndNil(vCampos);
end;

//--

class function TmComando.GetSelect(AClass: TClass; AWhere: String): String;
var
  vTabela : TTabela;
  vCampos : TCampos;
  vFieldsAtr, vFields : String;
  I : Integer;
begin
  vTabela := GetTabela(AClass);
  vCampos := GetCampos(AClass);

  vFieldsAtr := '';
  vFields := '';

  with vCampos do
    for I := 0 to Count - 1 do
      with TCampo(Items[I]) do begin
        AddString(vFieldsAtr, Atributo + ' as "' + Atributo + '"', ', ');
        AddString(vFields, Campo + ' as ' + Atributo, ', ');
      end;

  Result :=
    'select ' + vFieldsAtr + ' from (' +
      'select ' + vFields + ' from '+ vTabela.Nome +
    ')' + IfThen(AWhere <> '', ' where ' + AWhere);

  FreeAndNil(vTabela);
  FreeAndNil(vCampos);
end;

function TmComando.GetSelect(): String;
var
  vWhere : String;
begin
  vWhere := GetWhereKey();
  Result := GetSelect(Self.ClassType, vWhere);
end;

//--

function TmComando.GetInsert(): String;
var
  vTabela : TTabela;
  vCampos : TCampos;
  vFields, vValues : String;
  I : Integer;
begin
  vTabela := GetTabela(Self.ClassType);
  vCampos := GetCampos(Self.ClassType);

  vFields := '';
  vValues := '';
  with vCampos do
    for I := 0 to Count - 1 do
      with TCampo(Items[I]) do begin
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
  vSets, vWhere : String;
  I : Integer;
begin
  vTabela := GetTabela(Self.ClassType);
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  vSets := '';
  with vCampos do
    for I := 0 to Count - 1 do
      with TCampo(Items[I]) do
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
  vWhere : String;
  I : Integer;
begin
  vTabela := GetTabela(Self.ClassType);
  vCampos := GetCampos(Self.ClassType);

  vWhere := '';
  with vCampos do
    for I := 0 to Count - 1 do
      with TCampo(Items[I]) do
        if not IsValueNull(Self, Atributo) then
          AddString(vWhere, Campo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result :=
    'delete from ' + vTabela.Nome +
    ' where ' + vWhere;

  FreeAndNil(vTabela);
  FreeAndNil(vCampos);
end;

end.
