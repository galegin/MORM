unit mComando;

(* mComando *)

interface

uses
  Classes, SysUtils, StrUtils, TypInfo, Rtti,
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

  function GetTabela(AType: TRttiType) : TTabela;
  var
    atrbRtti : TCustomAttribute;
  begin
    Result := nil;
    for atrbRtti in AType.GetAttributes do
      if atrbRtti is TTabela then
        Exit(atrbRtti as TTabela);
  end;

  function GetCampo(AType: TRttiType; ACampo: String) : TCampo;
  var
    propRtti : TRttiProperty;
    atrbRtti : TCustomAttribute;
  begin
    Result := nil;
    for propRtti in AType.GetProperties() do
      if propRtti.Name = ACampo then
        for atrbRtti in propRtti.GetAttributes do
          if atrbRtti is TCampo then
            Exit(atrbRtti as TCampo);
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
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  propRtti : TRttiProperty;
  vTabela : TTabela;
  vCampo : TCampo;
  vFieldsAtr, vFields : String;
begin
  ctxRtti := TRttiContext.Create;
  typeRtti := ctxRtti.GetType(AClass);
  vTabela := GetTabela(typeRtti);
  vFieldsAtr := '';
  vFields := '';

  for propRtti in typeRtti.GetProperties() do begin
    vCampo := GetCampo(typeRtti, propRtti.Name);
    if Assigned(vCampo) then
      with vCampo do begin
        AddString(vFieldsAtr, propRtti.Name + ' as "' + propRtti.Name + '"', ', ');
        AddString(vFields, Campo + ' as ' + propRtti.Name, ', ');
      end;
  end;

  Result :=
    'select ' + vFieldsAtr + ' from (' +
      'select ' + vFields + ' from '+ vTabela.Nome +
    ')' + IfThen(AWhere <> '', ' where ' + AWhere);

  ctxRtti.Free;
end;

function TmComando.GetSelect(): String;
var
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  propRtti : TRttiProperty;
  vTabela : TTabela;
  vCampo : TCampo;
  vWhere : String;
  I : Integer;
begin
  ctxRtti := TRttiContext.Create;
  typeRtti := ctxRtti.GetType(Self.ClassType);
  vTabela := GetTabela(typeRtti);

  vWhere := '';
  for propRtti in typeRtti.GetProperties() do begin
    vCampo := GetCampo(typeRtti, propRtti.Name);
    if Assigned(vCampo) then
      with vCampo do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, propRtti.Name + ' = ' + GetValueStr(Self, propRtti.Name), ' and ');
  end;

  Result := GetSelect(Self.ClassType, vWhere);

  ctxRtti.Free;
end;

function TmComando.GetInsert(): String;
var
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  propRtti : TRttiProperty;
  vTabela : TTabela;
  vCampo : TCampo;
  vFields, vValues : String;
  I : Integer;
begin
  ctxRtti := TRttiContext.Create;
  typeRtti := ctxRtti.GetType(Self.ClassType);
  vTabela := GetTabela(typeRtti);

  vFields := '';
  vValues := '';
  for propRtti in typeRtti.GetProperties() do begin
    vCampo := GetCampo(typeRtti, propRtti.Name);
    if Assigned(vCampo) then
      with vCampo do begin
        AddString(vFields, Campo, ', ');
        AddString(vValues, GetValueStr(Self, propRtti.Name), ', ');
      end;
  end;

  Result :=
    'insert into ' + vTabela.Nome +
    ' (' + vFields +
    ') values (' + vValues +
    ')';

  ctxRtti.Free;
end;

function TmComando.GetUpdate(): String;
var
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  propRtti : TRttiProperty;
  vTabela : TTabela;
  vCampo : TCampo;
  vSets, vWhere : String;
  I : Integer;
begin
  ctxRtti := TRttiContext.Create;
  typeRtti := ctxRtti.GetType(Self.ClassType);
  vTabela := GetTabela(typeRtti);

  vWhere := '';
  vSets := '';
  for propRtti in typeRtti.GetProperties() do begin
    vCampo := GetCampo(typeRtti, propRtti.Name);
    if Assigned(vCampo) then
      with vCampo do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, Campo + ' = ' + GetValueStr(Self, propRtti.Name), ' and ')
        else
          AddString(vSets, Campo + ' = ' + GetValueStr(Self, propRtti.Name), ', ');
  end;

  Result :=
    'update ' + vTabela.Nome +
    ' set ' + vSets +
    ' where ' + vWhere;

  ctxRtti.Free;
end;

function TmComando.GetDelete(): String;
var
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  propRtti : TRttiProperty;
  vTabela : TTabela;
  vCampo : TCampo;
  vWhere : String;
  I : Integer;
begin
  ctxRtti := TRttiContext.Create;
  typeRtti := ctxRtti.GetType(Self.ClassType);
  vTabela := GetTabela(typeRtti);

  vWhere := '';
  for propRtti in typeRtti.GetProperties() do begin
    vCampo := GetCampo(typeRtti, propRtti.Name);
    if Assigned(vCampo) then
      with vCampo do
        if Tipo in [mMapping.tfKey] then
          AddString(vWhere, Campo + ' = ' + GetValueStr(Self, propRtti.Name), ' and ');
  end;

  Result :=
    'delete from ' + vTabela.Nome +
    ' where ' + vWhere;

  ctxRtti.Free;
end;

end.
