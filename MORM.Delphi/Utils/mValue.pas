unit mValue; // mValue

interface

uses
  Classes, SysUtils, StrUtils;

type
  TTipoField = (
    tfKey,
    tfReq,
    tfNul);

  TTipoValue = (
    tvBoolean,
    tvDateTime,
    tvFloat,
    tvInteger,
    tvString);

  TmValue = class;
  TmValueClass = class of TmValue;

  TmValue = class
  private
    fNome : String;
    fTipoField : TTipoField;
    function GetTipo: TTipoValue;
  protected
    function GetValueBase() : String; virtual; abstract;
    function GetValueInt() : String; virtual; abstract;
    function GetValueStr() : String; virtual; abstract;
    procedure SetValueStr(const Value : String); virtual; abstract;
  public
  published
    property Nome : String read fNome write fNome;
    property Tipo : TTipoValue read GetTipo;
    property TipoField : TTipoField read fTipoField write fTipoField;
    property ValueInt : String read GetValueInt;
    property ValueStr : String read GetValueStr write SetValueStr;
  end;

  //-- database

  TmValueBool = class(TmValue)
  private
    fValue : Boolean;
  protected
    function GetValueBase() : String; override;
    function GetValueInt() : String; override;
    function GetValueStr() : String; override;
    procedure SetValueStr(const Value : String); override;
  public
    constructor Create(const ANome : String; AValue : Boolean; ATipo : TTipoField = tfNul);
  published
    property Value : Boolean read fValue write fValue;
  end;

  TmValueDate = class(TmValue)
  private
    fValue : TDateTime;
  protected
    function GetValueBase() : String; override;
    function GetValueInt() : String; override;
    function GetValueStr() : String; override;
    procedure SetValueStr(const Value : String); override;
  public
    constructor Create(const ANome : String; AValue : TDateTime; ATipo : TTipoField = tfNul);
  published
    property Value : TDateTime read fValue write fValue;
  end;

  TmValueFloat = class(TmValue)
  private
    fValue : Real;
  protected
    function GetValueBase() : String; override;
    function GetValueInt() : String; override;
    function GetValueStr() : String; override;
    procedure SetValueStr(const Value : String); override;
  public
    constructor Create(const ANome : String; AValue : Real; ATipo : TTipoField = tfNul);
  published
    property Value : Real read fValue write fValue;
  end;

  TmValueInt = class(TmValue)
  private
    fValue : Integer;
  protected
    function GetValueBase() : String; override;
    function GetValueInt() : String; override;
    function GetValueStr() : String; override;
    procedure SetValueStr(const Value : String); override;
  public
    constructor Create(const ANome : String; AValue : Integer; ATipo : TTipoField = tfNul);
  published
    property Value : Integer read fValue write fValue;
  end;

  TmValueStr = class(TmValue)
  private
    fValue : String;
  protected
    function GetValueBase() : String; override;
    function GetValueInt() : String; override;
    function GetValueStr() : String; override;
    procedure SetValueStr(const Value : String); override;
  public
    constructor Create(const ANome : String; AValue : String; ATipo : TTipoField = tfNul);
  published
    property Value : String read fValue write fValue;
  end;

  //-- lista

  TmValueList = class(TList)
  private
    function GetItem(Index: Integer): TmValue;
    procedure SetItem(Index: Integer; const AValue: TmValue);
    function GetItemB(Index: Integer): TmValueBool;
    function GetItemD(Index: Integer): TmValueDate;
    function GetItemF(Index: Integer): TmValueFloat;
    function GetItemI(Index: Integer): TmValueInt;
    function GetItemS(Index: Integer): TmValueStr;
  public
    function AddB(const ANome : String; AValue : Boolean; ATipo : TTipoField = tfNul) : TmValue;
    function AddD(const ANome : String; AValue : TDateTime; ATipo : TTipoField = tfNul) : TmValue;
    function AddF(const ANome : String; AValue : Real; ATipo : TTipoField = tfNul) : TmValue;
    function AddI(const ANome : String; AValue : Integer; ATipo : TTipoField = tfNul) : TmValue;
    function AddS(const ANome : String; AValue : String; ATipo : TTipoField = tfNul) : TmValue;
    function IndexOf(ANome : String) : TmValue;
    property Items[Index : Integer] : TmValue read GetItem write SetItem;
    property ItemsB[Index : Integer] : TmValueBool read GetItemB;
    property ItemsD[Index : Integer] : TmValueDate read GetItemD;
    property ItemsF[Index : Integer] : TmValueFloat read GetItemF;
    property ItemsI[Index : Integer] : TmValueInt read GetItemI;
    property ItemsS[Index : Integer] : TmValueStr read GetItemS;
  end;

  function StrToTipoValue(pStr : String) : TTipoValue;
  function TipoValueToStr(pTip : TTipoValue) : String;

implementation

const
  LTipoValue : Array [TTipoValue] Of TmValueClass = (
    TmValueBool,
    TmValueDate,
    TmValueFloat,
    TmValueInt,
    TmValueStr);

  STipoValue : Array [TTipoValue] Of String = (
    'boolean',
    'tdatetime',
    'float',
    'integer',
    'string');

  function StrToTipoValue(pStr : String) : TTipoValue;
  var
    I: Integer;
  begin
    Result := TTipoValue(Ord(-1));
    for I := 0 to Ord(High(TTipoValue)) do
      if STipoValue[TTipoValue(I)] = pStr then begin
        Result := TTipoValue(I);
        Exit;
      end;
  end;

  function TipoValueToStr(pTip : TTipoValue) : String;
  begin
    Result := STipoValue[pTip];
  end;

{ TmValue }

function TmValue.GetTipo: TTipoValue;
var
  I : Integer;
begin
  Result := TTipoValue(Ord(-1));
  for I := Ord(Low(TTipoValue)) to Ord(High(TTipoValue)) do
    if ClassType = LTipoValue[TTipoValue(I)] then
      Result := TTipoValue(I);
end;

{ TmValueBool }

constructor TmValueBool.Create(const ANome: String; AValue: Boolean; ATipo : TTipoField);
begin
  fNome := ANome;
  fValue := AValue;
  fTipoField := ATipo;
end;

function TmValueBool.GetValueBase: String;
begin
  Result := '''' + IfThen(fValue, 'T', 'F') + '''';
end;

function TmValueBool.GetValueInt: String;
begin
  Result := IfThen(fValue, 'T', 'F');
end;

function TmValueBool.GetValueStr: String;
begin
  Result := IfThen(fValue, 'T', 'F');
end;

procedure TmValueBool.SetValueStr(const Value: String);
begin
  fValue := (Value = 'T');
end;

{ TmValueDate }

constructor TmValueDate.Create(const ANome: String; AValue: TDateTime; ATipo : TTipoField);
begin
  fNome := ANome;
  fValue := AValue;
  fTipoField := ATipo;
end;

function TmValueDate.GetValueBase: String;
begin
  Result := '''' + FormatDateTime('dd/mm/yyyy hh:nn:ss', fValue) + '''';
end;

function TmValueDate.GetValueInt: String;
begin
  Result := FormatDateTime('yyyymmdd_hhnnss', fValue);
end;

function TmValueDate.GetValueStr: String;
begin
  Result := FormatDateTime('dd/mm/yyyy hh:nn:ss', fValue);
end;

procedure TmValueDate.SetValueStr(const Value: String);
begin
  fValue := StrToDateTimeDef(Value, 0);
end;

{ TmValueFloat }

constructor TmValueFloat.Create(const ANome: String; AValue: Real; ATipo : TTipoField);
begin
  fNome := ANome;
  fValue := AValue;
  fTipoField := ATipo;
end;

function TmValueFloat.GetValueBase: String;
begin
  Result := AnsiReplaceStr(FloatToStr(fValue), ',', '.');
end;

function TmValueFloat.GetValueInt: String;
begin
  Result := FormatFloat('0000000000', fValue * 100);
end;

function TmValueFloat.GetValueStr: String;
begin
  Result := FloatToStr(fValue);
end;

procedure TmValueFloat.SetValueStr(const Value: String);
begin
  fValue := StrToFloatDef(Value, 0);
end;

{ TmValueInt }

constructor TmValueInt.Create(const ANome: String; AValue: Integer; ATipo : TTipoField);
begin
  fNome := ANome;
  fValue := AValue;
  fTipoField := ATipo;
end;

function TmValueInt.GetValueBase: String;
begin
  Result := IntToStr(fValue);
end;

function TmValueInt.GetValueInt: String;
begin
  Result := FormatFloat('000000', fValue);
end;

function TmValueInt.GetValueStr: String;
begin
  Result := IntToStr(fValue);
end;

procedure TmValueInt.SetValueStr(const Value: String);
begin
  fValue := StrToIntDef(Value, 0);
end;

{ TmValueStr }

constructor TmValueStr.Create(const ANome: String; AValue: String; ATipo : TTipoField);
begin
  fNome := ANome;
  fValue := AValue;
  fTipoField := ATipo;
end;

function TmValueStr.GetValueBase: String;
begin
  Result := '''' + AnsiReplaceStr(fValue, '''', '''''') + '''';
end;

function TmValueStr.GetValueInt: String;
begin
  Result := Trim(fValue);
end;

function TmValueStr.GetValueStr: String;
begin
  Result := fValue;
end;

procedure TmValueStr.SetValueStr(const Value: String);
begin
  fValue := Value;
end;

{ TmValueList }

function TmValueList.AddB(const ANome : String; AValue : Boolean; ATipo : TTipoField) : TmValue;
begin
  Result := TmValueBool.Create(ANome, AValue, ATipo);
  Self.Add(Result);
end;

function TmValueList.AddD(const ANome : String; AValue : TDateTime; ATipo : TTipoField) : TmValue;
begin
  Result := TmValueDate.Create(ANome, AValue, ATipo);
  Self.Add(Result);
end;

function TmValueList.AddF(const ANome : String; AValue : Real; ATipo : TTipoField) : TmValue;
begin
  Result := TmValueFloat.Create(ANome, AValue, ATipo);
  Self.Add(Result);
end;

function TmValueList.AddI(const ANome : String; AValue : Integer; ATipo : TTipoField) : TmValue;
begin
  Result := TmValueInt.Create(ANome, AValue, ATipo);
  Self.Add(Result);
end;

function TmValueList.AddS(const ANome : String; AValue : String; ATipo : TTipoField) : TmValue;
begin
  Result := TmValueStr.Create(ANome, AValue, ATipo);
  Self.Add(Result);
end;

function TmValueList.GetItem(Index: Integer): TmValue;
begin
  Result := TmValue(Self[Index]);
end;

procedure TmValueList.SetItem(Index: Integer; const AValue: TmValue);
begin
  Self[Index] := AValue;
end;

function TmValueList.IndexOf(ANome: String): TmValue;
var
  I : Integer;
begin
  Result := nil;
  for I := 0 to Count - 1 do
    with TmValue(Self[I]) do
      if LowerCase(Nome) = LowerCase(ANome) then begin
        Result := TmValue(Self[I]);
        Exit;
      end;
end;

function TmValueList.GetItemB(Index: Integer): TmValueBool;
begin
  Result := TmValueBool(Self[Index]);
end;

function TmValueList.GetItemD(Index: Integer): TmValueDate;
begin
  Result := TmValueDate(Self[Index]);
end;

function TmValueList.GetItemF(Index: Integer): TmValueFloat;
begin
  Result := TmValueFloat(Self[Index]);
end;

function TmValueList.GetItemI(Index: Integer): TmValueInt;
begin
  Result := TmValueInt(Self[Index]);
end;

function TmValueList.GetItemS(Index: Integer): TmValueStr;
begin
  Result := TmValueStr(Self[Index]);
end;

end.
