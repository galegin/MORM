unit mConexaoX;

{
    ConexaoDBX: TSQLConnection;
    QueryDBX: TSQLQuery;
    TableDBX: TSQLTable;
}

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mConexaoIntf, mTipoDatabase, mParametro, mString,
  Data.DBXCommon, Data.DBXDb2, Data.DBXFirebird, Data.DBXOracle, Data.DBXMySql,
  SqlExpr, DBXpress;

type
  TrConexaoX = record
    ConnectionName : String;
    DriverName : String;
    GetDriverFunc : String;
    LibraryName : String;
    VendorLib : String;
    Parametro : String;
  end;

  TmConexaoX = class(TComponent, IConexao)
  private
    fParametro : TmParametro;
    fConnection : TSQLConnection;
    fTransaction : TDBXTransaction;
    procedure _BeforeConnect(Sender : TObject);
    procedure _AfterConnect(Sender : TObject);
  protected
  public
    constructor Create(AParametro : TmParametro); reintroduce;

    procedure ExecComando(ACmd : String);
    function GetConsulta(ASql : String) : TDataSet;

    procedure Transaction();
    procedure Commit();
    procedure Rollback();
  published
    property Parametro : TmParametro read fParametro;
  end;

  procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Comps MIGUEL', [TmConexaoX]);
end;

  function GetConexaoX(ATipoDatabase : TTipoDatabase) : TrConexaoX;
  begin
    with Result do begin
      case ATipoDatabase of
        tdFirebird : begin
          ConnectionName := '';
          DriverName := 'Firebird';
          GetDriverFunc := 'getSQLDriverINTERBASE';
          LibraryName := 'dbexpint.dll';
          VendorLib := 'fbclient.dll';
          Parametro :=
            'DataBase=@DataBase;User_Name=@User_Name;Password=@Password;' +
            'BlobSize=-1;CommitRetain=False;ServerCharSet=win1252;SQLDialect=3;' +
            'Interbase TransIsolation=ReadCommited;WaitOnLocks=True';
        end;

        tdMySql : begin
          ConnectionName := '';
          DriverName := '';
          GetDriverFunc := 'getSQLDriverMYSQL';
          LibraryName := 'dbexpmysql.dll';
          VendorLib := 'libmysql.dll';
          Parametro := '';
        end;

        tdOracle : begin
          ConnectionName := '';
          DriverName := 'Oracle';
          GetDriverFunc := 'getSQLDriverORACLE';
          LibraryName := 'dbexpora.dll';
          VendorLib := 'oci.dll';
          Parametro :=
            'DataBase=@DataBase;User_Name=@User_Name;Password=@Password;' +
            'BlobSize=-1;ErrorResourceFile=;LocaleCode=0000;RowsetSize=20;' +
            'Oracle TransIsolation=ReadCommited;RowsetSize=2;0Trim Char=False;' +
            'OS Authentication=False;Multiple Transaction=False';
        end;
      end;
    end;
  end;

  procedure TmConexaoX._BeforeConnect(Sender : TObject);
  var
    vConexaoX : TrConexaoX;
  begin
    vConexaoX := GetConexaoX(fParametro.TipoDatabase);

    with fConnection do begin
      ConnectionName := vConexaoX.ConnectionName;
      DriverName := vConexaoX.DriverName;
      GetDriverFunc := vConexaoX.GetDriverFunc;
      LibraryName := vConexaoX.LibraryName;
      VendorLib := vConexaoX.VendorLib;
      TableScope := [tsTable, tsView];

      Params.Text := AnsiReplaceStr(vConexaoX.Parametro, ';', sLineBreak);
      Params.Values['DataBase'] := fParametro.Database;
      Params.Values['User_Name'] := fParametro.Username;
      Params.Values['Password'] := fParametro.Password;
    end;
  end;

  procedure TmConexaoX._AfterConnect(Sender : TObject);
  begin
  end;

{ TmConexaoX }

constructor TmConexaoX.Create(AParametro : TmParametro);
begin
  fParametro := AParametro;
  fConnection := TSQLConnection.Create(Self);
  with fConnection do begin
    LoginPrompt := False;
    AfterConnect := _AfterConnect;
    BeforeConnect := _BeforeConnect;
  end;
end;

procedure TmConexaoX.ExecComando(ACmd: String);
const
  cMETHOD = 'TmConexaoX.ExecComando()';
begin
  if ACmd = '' then
    raise Exception.Create('Comando deve ser informado! / ' + cMETHOD);

  fConnection.ExecuteDirect(ACmd);
end;

function TmConexaoX.GetConsulta(ASql: String): TDataSet;
const
  cMETHOD = 'TmConexaoX.GetConsulta()';
var
  vQuery : TSQLQuery;
begin
  if ASql = '' then
    raise Exception.Create('SQL deve ser informado! / ' + cMETHOD);

  vQuery := TSQLQuery.create(Self);
  vQuery.SQLConnection := fConnection;
  vQuery.SQL.Text := ASql;
  vQuery.Open;

  Result := vQuery;
end;

procedure TmConexaoX.Transaction;
begin
  FTransaction := fConnection.BeginTransaction();
end;

procedure TmConexaoX.Commit;
begin
  fConnection.CommitFreeAndNil(FTransaction);
end;

procedure TmConexaoX.Rollback;
begin
  fConnection.RollbackFreeAndNil(FTransaction);
end;

end.
