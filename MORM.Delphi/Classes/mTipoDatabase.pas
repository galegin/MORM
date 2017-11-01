unit mTipoDatabase;

interface

uses
  Classes, SysUtils, TypInfo;

type
  TTipoDatabase = (
    tdFirebird,
    tdMySql,
    tdOracle,

    tdMsAccess,
    tdSqlServer,

    tdDBase,
    tdParadox
  );

  RTipoDatabase = record
    Tipo : TTipoDatabase;
    Codigo : String;
  end;

  function GetLstTipoDatabase() : TStringList;
  function GetTipoDatabase(ATipo : TTipoDatabase) : RTipoDatabase;
  function StrToTipoDatabase(ACodigo : String) : TTipoDatabase;
  function TipoDatabaseToStr(ATipo : TTipoDatabase) : String;

  function GetValueData(ATipo : TTipoDatabase; ADateTime : TDateTime) : String;

implementation

const
  RTipoDatabaseArray : Array [TTipoDatabase] of RTipoDatabase = (
    (Tipo: tdFirebird; Codigo: 'Firebird'),
    (Tipo: tdMySql; Codigo: 'MySql'),
    (Tipo: tdOracle; Codigo: 'Oracle'),

    (Tipo: tdMsAccess; Codigo: 'MsAccess'),
    (Tipo: tdSqlServer; Codigo: 'SqlServer'),

    (Tipo: tdDBase; Codigo: 'DBase'),
    (Tipo: tdParadox; Codigo: 'Paradox')
  );

function GetLstTipoDatabase() : TStringList;
var
  I : Integer;
begin
  Result := TStringList.Create;
  for I := Ord(Low(TTipoDatabase)) to Ord(High(TTipoDatabase)) do
    Result.Add(GetEnumName(TypeInfo(TTipoDatabase), I));
end;

function GetTipoDatabase(ATipo : TTipoDatabase) : RTipoDatabase;
begin
  Result := RTipoDatabaseArray[TTipoDatabase(ATipo)];
end;

function StrToTipoDatabase(ACodigo : String) : TTipoDatabase;
var
  I: Integer;
begin
  Result := tdFirebird;
  for I := 0 to Ord(High(TTipoDatabase)) do
    if RTipoDatabaseArray[TTipoDatabase(I)].Codigo = ACodigo then
      Result := TTipoDatabase(I);
end;

function TipoDatabaseToStr(ATipo : TTipoDatabase) : String;
begin
  Result := RTipoDatabaseArray[TTipoDatabase(ATipo)].Codigo;
end;

function GetValueData(ATipo : TTipoDatabase; ADateTime : TDateTime) : String;
begin
  case ATipo of
    tdFirebird :
      Result := '''' + FormatDateTime('dd.mm.yyyy hh:nn:ss', ADateTime) + '''';
    tdMySql :
      Result := '''' + FormatDateTime('yyyy/mm/dd hh:nn:ss', ADateTime) + '''';
    tdOracle :
      Result := 'to_date(''' + FormatDateTime('dd/mm/yyyy hh:nn:ss', ADateTime) + ''',''DD/MM/YYYY HH24:MI:SS'')';
  end;
end;

end.
