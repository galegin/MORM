unit mConexaoB;

{
    ConexaoDBE: TConexao;
    QueryBDE: TQuery;
    TableBDE: TTable;
}

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mConexao, mString, mTipoDatabase,
  DBTables;

type
  TrConexaoB = record
    Driver : String;
    Caminho : String;
    Username : String;
    Password : String;
  end;

  TmConexaoB = class(TmConexao)
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

uses mParametro;

procedure Register;
begin
  RegisterComponents('Comps MIGUEL', [TmConexaoB]);
end;

  function GetConexaoB(ATipoDatabase : TTipoDatabase) : TrConexaoB;
  begin
    with Result do begin
      case ATipoDatabase of
        tpdDBase : begin
          Driver := 'DBASE';
        end;

        tpdParadox : begin
          Driver := 'PARADOX';
        end;
      end;
    end;
  end;

  procedure TmConexaoB._BeforeConnect(Sender: TObject);
  var
    vConexaoB : TrConexaoB;

    procedure createAlias();
    var
      vLstParam : TStrings;
    begin
      {
      Params:
        Session.GetAliasParams(AliasName, Lista);
      Exists:
        Session.IsAlias(eAlias.Text);
      Add:
        Session.AddStandardAlias(eAlias.Text, Edit1.Text, 'Paradox');
        Session.SaveConfigFile;
      }

      (* Session.GetDriverNames(vLstDriver);
      for I := 0 to vLstDriver.Count - 1 do begin
        Session.GetDriverParams(vLstDriver[I], vLstParam);
        vLstParam.SaveToFile('params.' + vLstDriver[I] + '.txt');
      end; *)

      vLstParam := TStringList.Create;

      if Session.IsAlias(Parametro.Cd_Ambiente) then begin
        Session.GetAliasParams(Parametro.Cd_Ambiente, vLstParam);
        if vLstParam.Values[vConexaoB.Caminho] <> Parametro.Cd_Database then
          Session.DeleteAlias(Parametro.Cd_Ambiente);
      end;

      if Parametro.Tp_Database in [tpdDBase, tpdParadox] then begin
        Session.AddStandardAlias(Parametro.Cd_Ambiente, Parametro.Cd_Database, vConexaoB.Driver);
      end else begin
        vLstParam.Clear();
        vLstParam.Values[vConexaoB.Caminho] := Parametro.Cd_Database;
        vLstParam.Values[vConexaoB.Username] := Parametro.Cd_Username;
        Session.AddAlias(Parametro.Cd_Ambiente, vConexaoB.Driver, vLstParam);
      end;

      Session.SaveConfigFile;
    end;

  begin
    inherited;

    vConexaoB := GetConexaoB(Parametro.Tp_Database);

    createAlias();

    with TDatabase(fConnection) do begin
      Connected := False;
      AliasName := Parametro.Cd_Ambiente;
      Params.Values[vConexaoB.Password] := Parametro.Cd_Password;
      Connected := True;
    end;
  end;

  procedure TmConexaoB._AfterConnect(Sender: TObject);
  begin
  end;

{ TmConexaoB }

constructor TmConexaoB.create(Aowner: TComponent);
begin
  inherited;
  fConnection := TDatabase.Create(Self);
  with TDatabase(fConnection) do begin
    DatabaseName := 'TmConexaoBAliasName';
    LoginPrompt := False;
    AfterConnect := _AfterConnect;
    BeforeConnect := _BeforeConnect;
  end;
end;

procedure TmConexaoB.ExecComando(ACmd: String);
const
  cMETHOD = 'TmConexaoB.ExecComando()';
begin
  if ACmd = '' then
    raise Exception.Create('Comando deve ser informado! / ' + cMETHOD);

  TDatabase(fConnection).Execute(ACmd);
end;

function TmConexaoB.GetConsulta(ASql: String): TDataSet;
const
  cMETHOD = 'TmConexaoB.GetConsulta()';
var
  vQuery : TQuery;
begin
  if ASql = '' then
    raise Exception.Create('SQL deve ser informado! / ' + cMETHOD);

  vQuery := TQuery.create(Self);
  vQuery.DatabaseName := TDatabase(fConnection).AliasName;
  vQuery.SQL.Text := ASql;
  vQuery.Open;

  Result := vQuery;
end;

procedure TmConexaoB.Transaction;
begin
  TDatabase(fConnection).StartTransaction();
end;

procedure TmConexaoB.Commit;
begin
  TDatabase(fConnection).Commit();
end;

procedure TmConexaoB.Rollback;
begin
  TDatabase(fConnection).Rollback();
end;

end.
