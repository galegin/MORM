unit mServiceUnf;

interface

uses
  Classes, Variants, SysUtils,
  mDataSetUnf, mContexto;

type
  TmServiceUnf = class(TComponent)
  private
    FContexto : TmContexto;
    FInDropMemory : Boolean;
  protected
    function criarEntidade(pParams : String = '') : String; virtual;
    function setEntidade(pParams : String = '') : String; virtual;
    function getParam(pParams : String = '') : String; virtual;
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
  published
    property _InDropMemory : Boolean read FInDropMemory write FInDropMemory;
  end;

procedure Register;

implementation

uses
  mException, mLogger;

{- Register -------------------------------------------------------------------}
procedure Register;
begin
  RegisterComponents('Comps', [TmServiceUnf]);
end;

{- Contructor -----------------------------------------------------------------}
constructor TmServiceUnf.Create(AOwner: TComponent);
begin
  inherited;

  FContexto := mContexto.Instance;

  criarEntidade();
  setEntidade();
  getParam();
end;

{- Destructor -----------------------------------------------------------------}
destructor TmServiceUnf.Destroy;
begin
  inherited;
end;

{- Functions ------------------------------------------------------------------}
function TmServiceUnf.criarEntidade(pParams : String) : String;
begin
  { declarar na entidade filha }
end;

function TmServiceUnf.setEntidade(pParams : String) : String;
begin
  { declarar na entidade filha }
end;

function TmServiceUnf.getParam(pParams : String) : String;
begin
  { declarar na entidade filha }
end;

//initialization
//  RegisterClass(<NOME_DA_CLASSE>);

end.
