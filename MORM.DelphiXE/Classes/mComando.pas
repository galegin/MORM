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

  function GetMappingObj(AObject: TObject) : PmMapping;
  begin
    Result := TmCollectionItem(AObject).GetMapping();
  end;

  function GetMappingClass(AClass: TClass) : PmMapping;
  var
    vMapping : TObject;
  begin
    vMapping := TmCollectionItemClass(AClass).Create(nil);
    Result := GetMappingObj(vMapping);
    FreeAndNil(vMapping);
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
  vMapping : PmMapping;
  vFieldsAtr, vFields : String;
  I : Integer;
begin
  vMapping := GetMappingClass(AClass);

  vFieldsAtr := '';
  vFields := '';

  with vMapping.Campos do
    for I := 0 to Count - 1 do
      with PmCampo(Items[I])^ do begin
        AddString(vFieldsAtr, Atributo + ' as "' + Atributo + '"', ', ');
        AddString(vFields, Campo + ' as ' + Atributo, ', ');
      end;

  Result :=
    'select ' + vFieldsAtr + ' from (' +
      'select ' + vFields + ' from '+ vMapping.Tabela.Nome +
    ')' + IfThen(AWhere <> '', ' where ' + AWhere);

  FreeMapping(vMapping);
end;

function TmComando.GetSelect(): String;
var
  vMapping : PmMapping;
  vWhere : String;
  I : Integer;
begin
  vMapping := GetMappingObj(Self);

  vWhere := '';
  with vMapping.Campos do
    for I := 0 to Count - 1 do
      with PmCampo(Items[I])^ do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, Atributo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result := GetSelect(Self.ClassType, vWhere);

  FreeMapping(vMapping);
end;

function TmComando.GetInsert(): String;
var
  vMapping : PmMapping;
  vFields, vValues : String;
  I : Integer;
begin
  vMapping := GetMappingObj(Self);

  vFields := '';
  vValues := '';
  with vMapping.Campos do
    for I := 0 to Count - 1 do
      with PmCampo(Items[I])^ do begin
        AddString(vFields, Campo, ', ');
        AddString(vValues, GetValueStr(Self, Atributo), ', ');
      end;

  Result :=
    'insert into ' + vMapping.Tabela.Nome +
    ' (' + vFields +
    ') values (' + vValues +
    ')';

  FreeMapping(vMapping);
end;

function TmComando.GetUpdate(): String;
var
  vMapping : PmMapping;
  vSets, vWhere : String;
  I : Integer;
begin
  vMapping := GetMappingObj(Self);

  vWhere := '';
  vSets := '';
  with vMapping.Campos do
    for I := 0 to Count - 1 do
      with PmCampo(Items[I])^ do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, Campo + ' = ' + GetValueStr(Self, Atributo), ' and ')
        else
          AddString(vSets, Campo + ' = ' + GetValueStr(Self, Atributo), ', ');

  Result :=
    'update ' + vMapping.Tabela.Nome +
    ' set ' + vSets +
    ' where ' + vWhere;

  FreeMapping(vMapping);
end;

function TmComando.GetDelete(): String;
var
  vMapping : PmMapping;
  vWhere : String;
  I : Integer;
begin
  vMapping := GetMappingObj(Self);

  vWhere := '';
  with vMapping.Campos do
    for I := 0 to Count - 1 do
      with PmCampo(Items[I])^ do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, Campo + ' = ' + GetValueStr(Self, Atributo), ' and ');

  Result :=
    'delete from ' + vMapping.Tabela.Nome +
    ' where ' + vWhere;

  FreeMapping(vMapping);
end;

end.
