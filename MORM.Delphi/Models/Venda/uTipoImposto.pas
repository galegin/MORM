unit uTipoImposto;

interface

type
  TTipoImposto = (
    tpiNaoConfigurado,
    tpiICMS,
    tpiICMSST,
    tpiICMSUF,
    tpiIPI,
    tpiPIS,
    tpiPISST,
    tpiCOFINS,
    tpiCOFINSST,
    tpiISSQN,
    tpiII);

  function TipoImpostoToInt(const pTipo : TTipoImposto): integer;
  function IntToTipoImposto(const pCodigo : integer): TTipoImposto;
  function TipoImpostoToStr(const pTipo : TTipoImposto): string;
  function StrToTipoImposto(const pCodigo : string): TTipoImposto;

implementation

const
  TTipoImposto_Str : Array [TTipoImposto] of String = (
    '',
    'ICMS',
    'ICMSST',
    'ICMSUF',
    'IPI',
    'PIS',
    'PISST',
    'COFINS',
    'COFINSST',
    'ISSQN',
    'II');

  TTipoImposto_Int : Array [TTipoImposto] of Integer = (
    0,
    1,
    2,
    3,
    4,
    5,
    6,
    7,
    8,
    9,
    10);

function TipoImpostoToInt(const pTipo : TTipoImposto): integer;
begin
  Result := TTipoImposto_Int[pTipo];
end;

function IntToTipoImposto(const pCodigo : integer): TTipoImposto;
var
  I : Integer;
begin
  Result := TTipoImposto(-1);
  for I := Ord(Low(TTipoImposto)) to Ord(High(TTipoImposto)) do
    if TTipoImposto_Int[TTipoImposto(I)] = pCodigo then
      Result := TTipoImposto(I);
end;

function TipoImpostoToStr(const pTipo : TTipoImposto): string;
begin
  Result := TTipoImposto_Str[pTipo];
end;

function StrToTipoImposto(const pCodigo : string): TTipoImposto;
var
  I : Integer;
begin
  Result := TTipoImposto(-1);
  for I := Ord(Low(TTipoImposto)) to Ord(High(TTipoImposto)) do
    if TTipoImposto_Str[TTipoImposto(I)] = pCodigo then
      Result := TTipoImposto(I);
end;

end.