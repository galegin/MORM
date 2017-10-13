unit mConexaoIntf;

interface

uses
  Classes, DB,
  mParametro;

type
  IConexao = interface
    ['{1D2748AA-19B2-46E6-A924-E48CEB23458C}']

    procedure ExecComando(ACmd : String);
    function GetConsulta(ASql : String) : TDataSet;

    procedure Transaction();
    procedure Commit();
    procedure Rollback();

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

    property Parametro : TmParametro read GetParametro write SetParametro;
  end;

implementation

end.