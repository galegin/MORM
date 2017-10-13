unit mTipoDatabase;

interface

uses
  Classes, SysUtils, TypInfo;

type
  TTipoDatabase = (tpdFirebird,
                   tpdMySql,
                   tpdOracle,
                   tpdPostgre,
                   tpdSqlServer,
                   tpdDB2,
                   tpdDBase,
                   tpdParadox,
                   tpdMsAccess);

const
  TTipoDatabaseA = [tpdMsAccess, tpdSqlServer];

  TTipoDatabaseB = [tpdDBase, tpdParadox];

  TTipoDatabaseX = [tpdFirebird, tpdOracle, tpdPostgre];

  TTipoDatabaseZ = [tpdMySql, tpdPostgre];

  function GetLstTipoDatabase() : TStringList;
  function StrToTipoDatabase(AString : String) : TTipoDatabase;
  function TipoDatabaseToStr(ATipo : TTipoDatabase) : String;

implementation

function GetLstTipoDatabase() : TStringList;
var
  I : Integer;
begin
  Result := TStringList.Create;
  for I:=Ord(Low(TTipoDatabase)) to Ord(High(TTipoDatabase)) do
    Result.Add(GetEnumName(TypeInfo(TTipoDatabase), I));
end;

function StrToTipoDatabase(AString : String) : TTipoDatabase;
begin
  Result := TTipoDatabase(GetEnumValue(TypeInfo(TTipoDatabase), AString));
  if ord(Result) = -1 then
    Result := tpdFirebird;
end;

function TipoDatabaseToStr(ATipo : TTipoDatabase) : String;
begin
  Result := GetEnumName(TypeInfo(TTipoDatabase), Integer(ATipo));
end;

end.