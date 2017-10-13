unit mObjeto;

interface

uses
  Classes, SysUtils, StrUtils, TypInfo, Math, DB,
  mLogger, mValue;

type
  TmObjeto = class(TObject)
  public
    procedure ResetValues();
    function GetValues(): TmValueList;
    procedure SetValues(AValues: TmValueList);
    procedure ToObjeto(AObjectTo: TObject);
    function GetValuesObjeto(AInherited : TClass) : TStringList;
  end;

implementation

const
  cTipoBaseSet : Set Of TFieldType =
    [ftBoolean, ftDateTime, ftFloat, ftInteger, ftString];

  cTipoBase : Array [0..4] Of String =
    ('boolean', 'tdatetime', 'float', 'integer', 'string');

  function IsTipoBase(ATipo : String) : Boolean;
  var
    I: Integer;
  begin
    Result := False;
    for I := 0 to High(cTipoBase) do
      if ATipo = cTipoBase[I] then begin
        Result := True;
        Exit;
      end;
  end;

{ TmObjeto }

procedure TmObjeto.ResetValues;
const
  cDS_METHOD = 'TmObjeto.ResetValues';
var
  Count, I : Integer;
  vTipoBase : String;
  vPropInfo : PPropInfo;
  vPropList : PPropList;
begin
  Count := GetPropList(Self.ClassInfo, tkProperties, nil, False);
  GetMem(vPropList, Count * SizeOf(Pointer));

  try
    GetPropList(Self.ClassInfo, tkProperties, vPropList, False);

    for I := 0 to Count - 1 do begin
      vPropInfo := vPropList^[I];

      //-- read-only
      if vPropInfo^.SetProc = nil then
        Continue;

      vTipoBase := LowerCase(vPropInfo^.PropType^.Name);
      case StrToTipoValue(vTipoBase) of
        tvBoolean :
          SetOrdProp(Self, vPropInfo, 0);
        tvDateTime :
          SetFloatProp(Self, vPropInfo, 0);
        tvFloat :
          SetFloatProp(Self, vPropInfo, 0);
        tvInteger :
          SetOrdProp(Self, vPropInfo, 0);
        tvString :
          SetStrProp(Self, vPropInfo, '');
      end;    
    end;
  finally
    FreeMem(vPropList);
  end;
end;

//--

function TmObjeto.GetValues;
var
  Count, I : Integer;
  vPropInfo : PPropInfo;
  vPropList : PPropList;
  vNome, vTipoBase : String;
  vTipoField : TTipoField;
begin
  Result := TmValueList.Create;

  Count := GetPropList(Self.ClassInfo, tkProperties, nil, False);
  GetMem(vPropList, Count * SizeOf(Pointer));

  try
    GetPropList(Self.ClassInfo, tkProperties, vPropList, False);

    vTipoField := tfKey;
    
    for I := 0 to Count - 1 do begin
      vPropInfo := vPropList^[I];
      vNome := vPropInfo^.Name;

      //-- read-only
      if vPropInfo^.SetProc = nil then
        Continue;

      if LowerCase(vNome) = 'u_version' then
        vTipoField := tfNul;

      vTipoBase := LowerCase(vPropInfo^.PropType^.Name);
      case StrToTipoValue(vTipoBase) of
        tvBoolean :
          Result.AddB(vNome, (GetOrdProp(Self, vPropInfo) = 1), vTipoField);
        tvDateTime :
          Result.AddD(vNome, GetFloatProp(Self, vPropInfo), vTipoField);
        tvFloat :
          Result.AddF(vNome, GetFloatProp(Self, vPropInfo), vTipoField);
        tvInteger :
          Result.AddI(vNome, GetOrdProp(Self, vPropInfo), vTipoField);
        tvString :
          Result.AddS(vNome, GetStrProp(Self, vPropInfo), vTipoField);
      end;
    end;
  finally
    FreeMem(vPropList);
  end;
end;

procedure TmObjeto.SetValues;
var
  vPropInfo : PPropInfo;
  vNome, vTipoBase : String;
  I : Integer;
begin
  with AValues do
    for I := 0 to Count - 1 do begin
      vNome := Items[I].Nome;
      vPropInfo := GetPropInfo(Self, vNome);

      //-- read-only
      if vPropInfo^.SetProc = nil then
        Continue;

      vTipoBase := LowerCase(vPropInfo^.PropType^.Name);
      case StrToTipoValue(vTipoBase) of
        tvBoolean :
          SetOrdProp(Self, vNome, IfThen(ItemsB[I].Value, 1, 0));
        tvDateTime :
          SetFloatProp(Self, vNome, ItemsD[I].Value);
        tvFloat :
          SetFloatProp(Self, vNome, ItemsF[I].Value);
        tvInteger :
          SetOrdProp(Self, vNome, ItemsI[I].Value);
        tvString :
          SetStrProp(Self, vNome, ItemsS[I].Value);
      end;    
    end;
end;

//--

procedure TmObjeto.ToObjeto;
begin
  TmObjeto(AObjectTo).SetValues(GetValues());
end;

//-

function TmObjeto.GetValuesObjeto;
var
  vPropInfo : PPropInfo;
  vPropList : PPropList;
  Count, I : Integer;
  vNome, vTipoBase : String;
  vObject : TObject;
begin
  Result := TStringList.Create;

  Count := GetPropList(Self.ClassInfo, tkProperties, nil, False);
  GetMem(vPropList, Count * SizeOf(Pointer));

  try
    GetPropList(Self.ClassInfo, tkProperties, vPropList, False);

    for I := 0 to Count - 1 do begin
      vPropInfo := vPropList^[I];

      //-- read-only
      if vPropInfo^.SetProc = nil then
        Continue;

      vNome := vPropInfo^.Name;
      vTipoBase := LowerCase(vPropInfo^.PropType^.Name);
      if IsTipoBase(vTipoBase) then
        Continue;

      vObject := GetObjectProp(Self, vNome);
      if Assigned(vObject) and vObject.InheritsFrom(AInherited) then
        Result.AddObject(vNome, vObject);
    end;
  finally
    FreeMem(vPropList);
  end;
end;

//--

end.
