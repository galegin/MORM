unit mDatabase;

(* mDatabase *)

interface

uses
  Classes, SysUtils, StrUtils,
  mConexaoIntf;

type
  TmDatabase = class(TComponent)
  private
    FConexao : IConexao;
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
  published
    property Conexao : IConexao read FConexao write FConexao;
  end;

implementation

uses
  //mConexaoA,
  //mConexaoB,
  mConexaoX {,
  mConexaoZ};

(* mDatabase *)

constructor TmDatabase.Create(AOwner : TComponent);
begin
  inherited;

  FConexao := TmConexaoX.Create(Self);
end;

destructor TmDatabase.Destroy;
begin

  inherited;
end;

end.
