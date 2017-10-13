unit mConexao;

interface

uses
  Classes, SysUtils, StrUtils, TypInfo, DB,
  mConexaoIntf, mParametro, mTipoDatabase, mDataSet; // mValue

type
  TrDicionario_Sequence = record
    Create : String;
    Exists : String;
    Execute : String;
  end;

  TrDicionario = record
    Limits : String;
    Metadata : String;
    Sequences : TrDicionario_Sequence;
    Tables : String;
    Views : String;
    Constraints : String;
  end;

  TmConexao = class(TComponent, IConexao)
  private
    fParametro : TmParametro;
    fDicionario : TrDicionario;
  protected
    fConnection : TComponent;
    function GetListDicionario(ASql, AField, AWhere : String) : TStringList;
  public
    constructor create(Aowner : TComponent); override;

    procedure ExecComando(ACmd : String); virtual; abstract;
    function GetConsulta(ASql : String) : TDataSet; virtual; abstract;

    procedure Transaction(); virtual; abstract;
    procedure Commit(); virtual; abstract;
    procedure Rollback(); virtual; abstract;

    function GetParametro() : TmParametro;
    procedure SetParametro(const Value : TmParametro);

    function GetLimits(ASql : String; AQtde : Integer) : String;
    function GetMetadata(AEntidade : String) : TDataSet;
    function GetConstraints(AConstraint : String) : TStringList;
    function GetTables(ATable : String) : TStringList;
    function GetViews(AView : String) : TStringList;

    function GetSequence(ASequence : String) : Integer;

    function ConstraintExiste(AConstraint : String) : Boolean;
    function TableExiste(ATable : String) : Boolean;
    function ViewExiste(AView : String) : Boolean;
  published
    property Parametro : TmParametro read GetParametro write SetParametro;
    property Dicionario : TrDicionario read fDicionario;
  end;

implementation

{ TmConexao }

  function GetDicionario(ATipoDatabase : TTipoDatabase) : TrDicionario;
  begin
    with Result do begin
      case ATipoDatabase of
        tpdDB2, tpdOracle : begin
          Limits := 'select * from ({sql}) where ROWNUM <= {qtde}';
          Metadata := 'select * from {entidade} where 1<>1';
          Constraints := 'select CONSTRAINT_NAME from USER_CONSTRAINTS';
          Tables := 'select TABLE_NAME from USER_TABLES';
          Views := 'select VIEW_NAME from USER_VIEWS';
          with Sequences do begin
            Create := 'create sequence {sequence} start with 1 increment by 1 maxvalue 999999 cycle nocache';
            Execute := 'select {sequence}.NEXTVAL as PROXIMO from DUAL';
            Exists := 'select SEQUENCE_NAME from USER_SEQUENCES where SEQUENCE_NAME = ''{sequence}''';
          end;
        end;

        tpdFirebird : begin
          Limits := 'select FIRST {qtde} * from ({sql})';
          Metadata := 'select * from {entidade} where 1<>1';
          Constraints := 'select RDB$CONSTRAINT_NAME as CONSTRAINT_NAME from RDB$RELATION_CONSTRAINTS';
          Tables := 'select RDB$RELATION_NAME as TABLE_NAME from RDB$RELATIONS where RDB$SYSTEM_FLAG = 0 and RDB$VIEW_BLR is null';
          Views := 'select RDB$RELATION_NAME as VIEW_NAME from RDB$RELATIONS where RDB$SYSTEM_FLAG = 0 and RDB$VIEW_BLR is not null';
          with Sequences do begin
            Create := 'create sequence {sequence}';
            Execute := 'select GEN_ID({sequence}, 1) as PROXIMO from RDB$DATABASE';
            Exists := 'select RDB$GENERATOR_NAME as SEQUENCE_NAME from RDB$GENERATORS where RDB$GENERATOR_NAME = ''{sequence}'' and RDB$SYSTEM_FLAG = 0';
          end;
        end;

        tpdMySql, tpdPostgre : begin
          Limits := 'select * from ({sql}) LIMIT {qtde}';
          Metadata := 'select * from {entidade} where 1<>1';
          Constraints := 'select CONSTRAINT_NAME from INFORMATION_SCHEMA.CONSTRAINTS where TABLE_SCHEMA = database()';
          Tables := 'select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = database()';
          Views := 'select VIEW_NAME from INFORMATION_SCHEMA.VIEWS where TABLE_SCHEMA = database()';
        end;

      end;
    end;
  end;

  //--

  procedure AddWhere(var ASql : String; AWhere : String);
  begin
    ASql := ASql + IfThen(AWhere <> '', ' where ' + AWhere);
  end;

  function TmConexao.GetListDicionario(ASql, AField, AWhere : String) : TStringList;
  var
    vDataSet : TDataSet;
  begin
    Result := TStringList.Create;

    if AWhere <> '' then
      AddWhere(ASql, AField + ' = ''' + AWhere + '''');

    vDataSet := GetConsulta(ASql);
    with vDataSet do begin
      while not EOF do begin
        Result.Add(Trim(FieldByName(AField).AsString));
        Next;
      end;
      Free;
    end;
  end;

constructor TmConexao.create(Aowner: TComponent);
begin
  inherited;
end;

//--

function TmConexao.GetParametro: TmParametro;
begin
  Result := fParametro;
end;

procedure TmConexao.SetParametro(const Value: TmParametro);
begin
  fParametro := Value;
  fDicionario := GetDicionario(fParametro.Tp_Database);
end;

//--

function TmConexao.GetLimits(ASql : String; AQtde : Integer) : String;
begin
  Result := Dicionario.Limits;
  Result := AnsiReplaceStr(Result, '{sql}', ASql);
  Result := AnsiReplaceStr(Result, '{qtde}', IntToStr(AQtde));
end;

function TmConexao.GetMetadata(AEntidade : String) : TDataSet;
begin
  Result := GetConsulta(AnsiReplaceStr(Dicionario.Metadata, '{entidade}', AEntidade));
end;

function TmConexao.GetConstraints(AConstraint : String) : TStringList;
begin
  Result := GetListDicionario(Dicionario.Constraints, 'CONSTRAINT_NAME', AConstraint);
end;

function TmConexao.GetTables(ATable : String) : TStringList;
begin
  Result := GetListDicionario(Dicionario.Tables, 'TABLE_NAME', ATable);
end;

function TmConexao.GetViews(AView : String) : TStringList;
begin
  Result := GetListDicionario(Dicionario.Views, 'VIEW_NAME', AView);
end;

//--

function TmConexao.GetSequence(ASequence : String) : Integer;
var
  vSql : String;
  vDataSet : TDataSet;
begin
  vSql := Dicionario.Sequences.Exists;
  vSql := AnsiReplaceStr(vSql, '{sequence}', ASequence);
  vDataSet := GetConsulta(vSql);
  if TmDataSet(vDataSet).PegarS('SEQUENCE_NAME') = '' then begin
    vSql := Dicionario.Sequences.Create;
    vSql := AnsiReplaceStr(vSql, '{sequence}', ASequence);
    ExecComando(vSql);
  end;

  vSql := Dicionario.Sequences.Execute;
  vSql := AnsiReplaceStr(vSql, '{sequence}', ASequence);
  vDataSet := GetConsulta(vSql);
  Result := TmDataSet(vDataSet).PegarI('PROXIMO');
end;

//--

function TmConexao.ConstraintExiste(AConstraint : String) : Boolean;
begin
  Result := GetConstraints(AConstraint).IndexOf(AConstraint) > -1;
end;

function TmConexao.TableExiste(ATable : String) : Boolean;
begin
  Result := GetTables(ATable).IndexOf(ATable) > -1;
end;

function TmConexao.ViewExiste(AView : String) : Boolean;
begin
  Result := GetViews(AView).IndexOf(AView) > -1;
end;

//--

end.