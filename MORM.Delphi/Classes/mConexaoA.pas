unit mConexaoA;

{
    ConexaoADO: TADOConnection;
    QueryADO: TADOQuery;
    TableADO: TADOTable;
}

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mConexao, mString, mTipoDatabase,
  ADODB;

type
  TrConexaoA = record
    ConnectionString : String;
  end;

  TmConexaoA = class(TmConexao)
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
  RegisterComponents('Comps MIGUEL', [TmConexaoA]);
end;

  function GetConexaoA(ATipoDatabase : TTipoDatabase) : TrConexaoA;
  begin
    with Result do begin
      case ATipoDatabase of
        tpdMsAccess :
          ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Cd_Conexao};Jet OLEDB:Conexao Password={Cd_Password}';

        tpdSqlServer :
          ConnectionString := 'Driver=Firebird/InterBase(r) driver;Uid={Cd_Username};Pwd={Cd_Password};DBName={Cd_Hostname}:{Cd_Conexao}';
      end;
    end;
  end;

  procedure TmConexaoA._BeforeConnect(Sender: TObject);
  var
    vConexaoA : TrConexaoA;
    vConnectionString : String;
  begin
    inherited;

    vConexaoA := GetConexaoA(Parametro.Tp_Database);

    vConnectionString := vConexaoA.ConnectionString;
    vConnectionString := AnsiReplaceStr(vConnectionString, '{Cd_Database}', Parametro.Cd_Database);
    vConnectionString := AnsiReplaceStr(vConnectionString, '{Cd_Username}', Parametro.Cd_Username);
    vConnectionString := AnsiReplaceStr(vConnectionString, '{Cd_Password}', Parametro.Cd_Password);
    vConnectionString := AnsiReplaceStr(vConnectionString, '{Cd_Hostname}', Parametro.Cd_Hostname);
    vConnectionString := AnsiReplaceStr(vConnectionString, '{Cd_Hostport}', Parametro.Cd_Hostport);

    with TADOConnection(fConnection) do begin
      Connected := False;
      ConnectionString := vConnectionString;
      Connected := True;
    end;
  end;

  procedure TmConexaoA._AfterConnect(Sender: TObject);
  begin
  end;

{ TmConexaoA }

constructor TmConexaoA.create(Aowner: TComponent);
begin
  inherited;
  fConnection := TADOConnection.Create(Self);
  with TADOConnection(fConnection) do begin
    LoginPrompt := False;
    AfterConnect := _AfterConnect;
    BeforeConnect := _BeforeConnect;
  end;
end;

procedure TmConexaoA.ExecComando(ACmd: String);
const
  cMETHOD = 'TmConexaoA.ExecComando()';
begin
  if ACmd = '' then
    raise Exception.Create('Comando deve ser informado! / ' + cMETHOD);

  TADOConnection(fConnection).Execute(ACmd);
end;

function TmConexaoA.GetConsulta(ASql: String): TDataSet;
const
  cMETHOD = 'TmConexaoA.GetConsulta()';
var
  vQuery : TADOQuery;
begin
  if ASql = '' then
    raise Exception.Create('SQL deve ser informado! / ' + cMETHOD);

  vQuery := TADOQuery.create(Self);
  vQuery.Connection := TADOConnection(fConnection);
  vQuery.SQL.Text := ASql;
  vQuery.Open;

  Result := vQuery;
end;

procedure TmConexaoA.Transaction;
begin
  TADOConnection(fConnection).BeginTrans();
end;

procedure TmConexaoA.Commit;
begin
  TADOConnection(fConnection).CommitTrans();
end;

procedure TmConexaoA.Rollback;
begin
  TADOConnection(fConnection).RollbackTrans();
end;

(*
ADO Connection Strings Examples

Contents Index Previous Next
	These connection strings contain only parameters, which are required for opening the data sources, and mainly does not contain optional parameters. May be, you will need to modify them to adapt for your needs or depending on version of Microsoft Data Access Components (MDAC) installed.
	There are many connection string examples are available in Internet, so if you cannot find the corresponding example for your Conexao type, please try to search there.

XLS files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;excel 8.0;Conexao=C:\MyExcelData.xls;
       ACE
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\MyExcelFile.xls;Extended Properties="Excel 8.0;HDR=YES";   (Microsoft ACE must be installed)
       ODBC
              Provider=MSDASQL.1;Extended Properties="DBQ=C:\MyExcelFile.xls;DefaultDir=C:\;Driver={Microsoft Excel Driver (*.xls)};DriverId=790;"

MDB files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyConexaoFile.mdb;
       ODBC
              Provider=MSDASQL.1;Extended Properties="DBQ=MyConexaoFile.mdb;Driver={Microsoft Access Driver (*.mdb)};DriverId=25;"

XLSX, XLSB, XLSM files
       ACE
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\MyData\myExcel2007file.xlsx;Extended Properties="Excel 12.0;HDR=YES";   (Microsoft ACE must be installed; use it for Excel 2007 files)
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\MyData\myExcel2010file.xlsx;Extended Properties="Excel 14.0;HDR=NO";   (Microsoft ACE must be installed; use it for Excel 2010 files)
       ODBC
              Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=C:\MyExcelFile.xlsx;   (Microsoft Excel 2007 ODBC Driver must be installed)

ACCDB files
       ACE
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\MyData\myAccess2007file.accdb;Persist Security Info=False;   (Microsoft ACE must be installed)
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\MyData\myAccess2007file.accdb;Jet OLEDB:Conexao Password=MyDbPassword;   (Microsoft ACE must be installed)
       ODBC
              Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\MyAccessDB.accdb;   (Microsoft Access accdb ODBC Driver must be installed)
              Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\MyAccessDB.accdb;SystemDB=C:\MyAccessDB.mdw;   (Microsoft Access accdb ODBC Driver must be installed)

Interbase (GDB), FireBird (FDB) files
       OLE DB
              provider=sibprovider;location=localhost:;data source=C:\My_db.gdb;user id=SYSDBA;Password=masterkey;   (SIBPROvider Interbase OLE DB Provider must be installed)
       ODBC
              Driver={INTERSOLV InterBase ODBC Driver (*.gdb)};Server=localhost;Conexao=localhost:C:\My_db.gdb;Uid=myUsername;Pwd=myPassword;   (Intersolv InterBase ODBC Driver must be installed)
              Driver={Easysoft IB6 ODBC};Server=localhost;Conexao=localhost:C:\My_db.gdb;Uid=myUsername;Pwd=myPassword;   (Easysoft ODBC Driver must be installed)
              Driver=Firebird/InterBase(r) driver;Uid=myUsername;Pwd=myPassword;DBNAME=C:\My_db.gdb;   (IBPhoenix Open Source ODBC Driver must be installed)
              
HTML (HTM) files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties="HTML Import;Conexao=C:\MyHTMLFile.html";Visual FoxPro (DBC) files
       OLE DB
              Provider=vfpoledb;Data Source=C:\MyData\MyVFPDbFile.dbc;Collating Sequence=machine;   (VFP OLE DB Provider must be installed)
       ODBC
              Driver={Microsoft Visual FoxPro Driver};SourceType=DBC;SourceDB=C:\MyData\MyVFPDbFile.dbc;   (Microsoft Visual FoxPro ODBC Driver must be installed)

Folder with Lotus (WJ2, WK1) files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties="Lotus WJ2;Conexao=C:\MyLotusFolder";
              Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties="Lotus WK1;Conexao=C:\MyLotusFolder";

Folder with dBase (DBF) files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;dBase 5.0;Conexao=C:\MyDBaseFolder;
              Provider=Microsoft.Jet.OLEDB.4.0;dBase IV;Conexao=C:\MyDBaseFolder;
       ACE
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\MyDBaseFolder;Extended Properties=dBASE IV;   (Microsoft ACE must be installed)
       ODBC
              Provider=MSDASQL.1;Extended Properties="DefaultDir=C:\MyDBaseFolder;Driver={Microsoft dBase Driver (*.dbf)};DriverId=277;"

Folder with FoxPro (DBF) files
       OLE DB
              Provider=VFPOLEDB.1;Data Source=D:\MyFoxProFolder;Collating Sequence=MACHINE   (VFP OLE DB Provider must be installed)

Folder with Paradox (DB) files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;Paradox 4.X;Conexao=C:\MyParadoxFolder;
       ACE
              Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\MyParadoxFolder;Extended Properties=dBASE IV;   (Microsoft ACE must be installed)
       ODBC
              Provider=MSDASQL.1;Extended Properties="DefaultDir=C:\MyParadoxFolder;Driver={Microsoft Paradox Driver (*.db )};DriverId=26;"

Folder with TXT, CSV, ASC, TAB files
       Jet
              Provider=Microsoft.Jet.OLEDB.4.0;TEXT;Conexao=C:\MyCSVFolder;
       ODBC
              Provider=MSDASQL.1;Extended Properties="DefaultDir=C:\MyCSVFolder;Driver={Microsoft Text Driver (*.txt; *.csv)};DriverId=27;Extensions=asc,csv,tab,txt;"

UDL files
FILE NAME=c:\MyDataLinkFile.udl;
Adaptive Server Anywhere Conexaos
       OLE DB
              Provider=ASAProv;Data source=myASAConexao;   (Adaptive Server Anywhere OLE DB Provider must be installed)
       ODBC
              Driver=Adaptive Server Anywhere 7.0;ENG=server.Conexao_name;UID=myUsername;PWD=myPassword;DBN=myConexao;LINKS=TCPIP(HOST=serverNameOrAddress);   (Adaptive Server Anywhere ODBC Driver must be installed)

DB2 Conexaos
       OLE DB
              Provider=DB2OLEDB;Network Transport Library=TCPIP;Network Address=xxx.xxx.xxx.xxx;Initial Catalog=MyCatalog;Package Collection=MyPkgCol;Default Schema=mySchema;User ID=myUsername;Password=myPassword;   (Microsoft OLE DB Provider for DB2 must be installed)
              Provider=IBMDADB2;Conexao=myConexao;Hostname=myServerAddress;Protocol=TCPIP;Port=50000;Uid=myUsername;Pwd=myPassword;   (IBM OLE DB Provider for DB2 must be installed)
       ODBC
              Driver={IBM DB2 ODBC DRIVER};Conexao=myDbName;Hostname=myServerAddress;Port=myPortNum;Protocol=TCPIP;Uid=myUserName;Pwd=myPwd   (IBM DB2 Driver for ODBC must be installed)

Informix Conexaos
       OLE DB
              Provider=Ifxoledbc;Data Source=dbName@serverName;User ID=myUsername;Password=myPassword;   (IBM Informix OLE DB Provider must be installed)

Ingres Conexaos
       ODBC
              Provider=MSDASQL;DRIVER=Ingres;SRVR=xxxxx;DB=xxxxx;Uid=myUsername;Pwd=myPassword;Extended Properties="SERVER=xxxxx;Conexao=xxxxx;SERVERTYPE=INGRES";   (ODBC Driver for Ingres must be installed)

SQL Server Conexaos
       OLE DB
              Provider=sqloledb;Data Source=myServerAddress;Initial Catalog=myConexao;User Id=myUsername;Password=myPassword;   (Microsoft OLE DB Provider for SQL Server must be installed)
              Provider=SQLNCLI;Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (SQL Native Client 9.0 OLE DB provider must be installed; use it for SQL Server 2005)
              Provider=SQLNCLI10;Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (SQL Server Native Client 10.0 OLE DB Provider must be installed; use it for SQL Server 2008)
              Provider=SQLNCLI11;Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (SQL Server Native Client 11.0 OLE DB Provider must be installed; use it for SQL Server 2012)
       ODBC
              Driver={SQL Server};Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (Microsoft SQL Server ODBC Driver must be installed)
              Driver={SQL Native Client};Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (SQL Native Client 9.0 ODBC Driver must be installed; use it for SQL Server 2005)
              Driver={SQL Server Native Client 10.0};Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (SQL Server Native Client 10.0 ODBC Driver must be installed; use it for SQL Server 2008)
              Driver={SQL Server Native Client 11.0};Server=myServerAddress;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (SQL Server Native Client 11.0 ODBC Driver must be installed; use it for SQL Server 2012)

MySQL Conexaos
       OLE DB
              Provider=MySQLProv;Data Source=mydb;User Id=myUsername;Password=myPassword;   (MySQL OLEDB Provider must be installed)

Oracle Conexaos
       OLE DB
              Provider=msdaora;Data Source=MyOracleDB;User Id=myUsername;Password=myPassword;   (Microsoft OLE DB Provider for Oracle must be installed)
              Provider=OraOLEDB.Oracle;Data Source=MyOracleDB;User Id=myUsername;Password=myPassword;   (Oracle Provider for OLE DB must be installed)
       ODBC
              Driver={Microsoft ODBC Driver for Oracle};ConnectString=OracleServer.world;Uid=myUsername;Pwd=myPassword;   (Microsoft ODBC Driver for Oracle must be installed)

Pervasive PSQL Conexaos
       OLE DB
              Provider=PervasiveOLEDB;Data Source=myServerAddress;   (Pervasive OLE DB Provider must be installed)
       ODBC
              Driver={Pervasive ODBC Client Interface};ServerName=myServerAddress;dbq=@dbname;   (Pervasive ODBC Client Interface must be installed)

PostgreSQL Conexaos
       OLE DB
              Provider=PostgreSQL OLE DB Provider;Data Source=myServerAddress;location=myConexao;User ID=myUsername;password=myPassword;   (PostgreSQL OLE DB Provider must be installed)
       ODBC
              Driver={PostgreSQL};Server=IP address;Port=5432;Conexao=myConexao;Uid=myUsername;Pwd=myPassword;   (PostgreSQL ODBC Driver must be installed)

SQLite Conexaos
       ODBC
              Driver=SQLite3 ODBC Driver;Conexao=C:\MyData\My_db.db;   (SQLite3 ODBC Driver must be installed)

SQLBase Conexaos
       OLE DB
              Provider=SQLBaseOLEDB;Data source=myServerAddress;Location=myConexao;User Id=myUsername;Password=myPassword;   (SQLBase OLE DB Data Provider must be installed)

ODBC DSN
       1. Provider=MSDASQL.1;Extended Properties="DSN=IBLOCAL_ADO_EMP;UID=sysdba;PWD=masterkey"
       2. MYDSN;
       3. Provider=MSDASQL.1;Extended Properties="DSN=ORACLE_DB;UID=ADM;PWD=freedom;"
       4. Provider=MSDASQL.1;Data Source=DBF_DATA;Extended Properties="DSN=DBF_DATA;DriverId=533;FIL=dBase 5.0;"

*)

end.