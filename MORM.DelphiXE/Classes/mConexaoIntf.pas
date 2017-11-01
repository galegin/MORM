unit mConexaoIntf;

interface

uses
  Classes, DB;

type
  IConexao = interface
    ['{1D2748AA-19B2-46E6-A924-E48CEB23458C}']

    procedure ExecComando(ACmd : String);
    function GetConsulta(ASql : String) : TDataSet;

    procedure Transaction();
    procedure Commit();
    procedure Rollback();
  end;

implementation

end.