unit mConexaoB;

{
    ConexaoDBE: TConexao;
    QueryBDE: TQuery;
    TableBDE: TTable;
}

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mConexaoIntf, mTipoDatabase, mParametro, mString,
  DBTables;

type
  TrConexaoB = record
    Driver : String;
    Caminho : String;
    Username : String;
    Password : String;
  end;

  TmConexaoB = class(TComponent, IConexao)
  private
    fParametro : TmParametro;
    fConnection : TDatabase;
    procedure _BeforeConnect(Sender: TObject);
    procedure _AfterConnect(Sender: TObject);
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
  RegisterComponents('Comps MIGUEL', [TmConexaoB]);
end;

  function GetConexaoB(ATipoDatabase : TTipoDatabase) : TrConexaoB;
  begin
    with Result do begin
      case ATipoDatabase of
        tdDBase : begin
          Driver := 'DBASE';
        end;

        tdParadox : begin
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

      if Session.IsAlias(fParametro.Ambiente) then begin
        Session.GetAliasParams(fParametro.Ambiente, vLstParam);
        if vLstParam.Values[vConexaoB.Caminho] <> fParametro.Database then
          Session.DeleteAlias(fParametro.Ambiente);
      end;

      if Parametro.TipoDatabase in [tdDBase, tdParadox] then begin
        Session.AddStandardAlias(fParametro.Ambiente, fParametro.Database, vConexaoB.Driver);
      end else begin
        vLstParam.Clear();
        vLstParam.Values[vConexaoB.Caminho] := fParametro.Database;
        vLstParam.Values[vConexaoB.Username] := fParametro.Username;
        Session.AddAlias(fParametro.Ambiente, vConexaoB.Driver, vLstParam);
      end;

      Session.SaveConfigFile;
    end;

  begin
    inherited;

    vConexaoB := GetConexaoB(fParametro.TipoDatabase);

    createAlias();

    with TDatabase(fConnection) do begin
      Connected := False;
      AliasName := fParametro.Ambiente;
      Params.Values[vConexaoB.Password] := fParametro.Password;
      Connected := True;
    end;
  end;

  procedure TmConexaoB._AfterConnect(Sender: TObject);
  begin
  end;

{ TmConexaoB }

constructor TmConexaoB.Create(AParametro : TmParametro);
begin
  fParametro := AParametro;
  fConnection := TDatabase.Create(Self);
  with fConnection do begin
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

  fConnection.Execute(ACmd);
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
  vQuery.DatabaseName := fConnection.AliasName;
  vQuery.SQL.Text := ASql;
  vQuery.Open;

  Result := vQuery;
end;

procedure TmConexaoB.Transaction;
begin
  fConnection.StartTransaction();
end;

procedure TmConexaoB.Commit;
begin
  fConnection.Commit();
end;

procedure TmConexaoB.Rollback;
begin
  fConnection.Rollback();
end;

end.
