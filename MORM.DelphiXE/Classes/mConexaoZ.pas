unit mConexaoZ;

{
    ConexaoZEO: TZConnection;
    QueryZEO: TZQuery;
    TableZEO: TZTable;
}

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mConexao, mString, mTipoDatabase,
  ZConnection, ZDataset;

type
  TmConexaoZ = class(TmConexao)
  private
    procedure _BeforeConnect(Sender: TObject);
    procedure _AfterConnect(Sender: TObject);
  protected
  public
    constructor create(Aowner : TComponent); override;

    procedure ExecComando(ACmd : String); override;
    function GetConsulta(ASql : String) : TDataSet; override;

    procedure Transaction(); override;
    procedure Commit(); override;
    procedure Rollback(); override;
  published
  end;

  procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Comps MIGUEL', [TmConexaoZ]);
end;

  procedure TmConexaoZ._BeforeConnect(Sender: TObject);
  begin
    with TZConnection(fConnection) do begin
      Connected := False;
      Protocol := Parametro.Cd_Protocol;
      HostName := Parametro.Cd_Hostname;
      Database := Parametro.Cd_Database;
      User := Parametro.Cd_Username;
      Password := Parametro.Cd_Password;
      Port := StrToIntDef(Parametro.Cd_Hostport, 0);
      Connected := True;
    end;
  end;

  procedure TmConexaoZ._AfterConnect(Sender: TObject);
  begin
  end;

{ TmConexaoZ }

constructor TmConexaoZ.create(Aowner: TComponent);
begin
  inherited;
  fConnection := TZConnection.Create(Self);
  with TZConnection(fConnection) do begin
    LoginPrompt := False;
    AfterConnect := _AfterConnect;
    BeforeConnect := _BeforeConnect;
  end;
end;

procedure TmConexaoZ.ExecComando(ACmd: String);
const
  cMETHOD = 'TmConexaoZ.ExecComando()';
begin
  if ACmd = '' then
    raise Exception.Create('Comando deve ser informado! / ' + cMETHOD);

  TZConnection(fConnection).ExecuteDirect(ACmd);
end;

function TmConexaoZ.GetConsulta(ASql: String): TDataSet;
const
  cMETHOD = 'TmConexaoZ.GetConsulta()';
var
  vQuery : TZQuery;
begin
  if ASql = '' then
    raise Exception.Create('SQL deve ser informado! / ' + cMETHOD);

  vQuery := TZQuery.create(Self);
  vQuery.Connection := TZConnection(fConnection);
  vQuery.SQL.Text := ASql;
  vQuery.Open;

  Result := vQuery;
end;

procedure TmConexaoZ.Transaction;
begin
  TZConnection(fConnection).StartTransaction();
end;

procedure TmConexaoZ.Commit;
begin
  TZConnection(fConnection).Commit();
end;

procedure TmConexaoZ.Rollback;
begin
  TZConnection(fConnection).Rollback();
end;

{
ADO
  ZDbcAdo
    TZAdo
ASA
  ZDbcASA
    TZASA7 / TZASA8 / TZASA9 / TZASA12
DBLIB
  ZDbcDbLib
    TZDBLibMSSQL7
    TZDBLibSybaseASE125
    TZFreeTDS42MsSQL
    TZFreeTDS42Sybase
    TZFreeTDS50
    TZFreeTDS70
    TZFreeTDS71
    TZFreeTDS72
FIREBIRD
  ZDbcInterbase6
    TZFirebird10 / TZFirebird15 / TZFirebird20 / TZFirebird21 / TZFirebird25
    // embedded drivers
    TZFirebirdD15 / TZFirebirdD20 / TZFirebirdD21 / TZFirebirdD25
INTERBASE
  ZDbcInterbase6
    TZInterbase6
MYSQL
  ZDbcMySql
    TZMySQL / TZMySQL41 / TZMySQL5 / TZMySQLD41 / TZMySQLD5
ORACLE
  ZDbcOracle
    TZOracle / TZOracle9i
POSTGRESQL
  ZDbcPostgreSql
    TZPostgreSQL / TZPostgreSQL7 / TZPostgreSQL8 / TZPostgreSQL9
SQLITE
  ZDbcSqLite
    TZSQLite / TZSQLite3
}

end.