unit mServiceUnf;

interface

uses
  Classes, Variants, SysUtils,
  mDataSetUnf, mContexto;

type
  TmServiceUnf = class(TComponent)
  private
    FNmComponente : String;
    FInstance : Boolean;
    FContexto : TmContexto;
  protected
    function criarEntidade(pParams : String = '') : String; virtual;
    function setEntidade(pParams : String = '') : String; virtual;
    function getParam(pParams : String = '') : String; virtual;
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
  published
  end;

procedure Register;

implementation

uses
  mException, mComponenteUnf, mString, mLogger;

{- Register -------------------------------------------------------------------}
procedure Register;
begin
  RegisterComponents('Comps', [TmServiceUnf]);
end;

{- Contructor -----------------------------------------------------------------}
constructor TmServiceUnf.Create(AOwner: TComponent);
begin
  inherited;

  FNmComponente := TmString.RightStr(ClassName, 'T_');
  FInstance := (GetInstanceCmp(FNmComponente + 'X') <> '');

  if FInstance then
    FContexto := TmContexto.Create(nil)
  else
    FContexto := mContexto.Instance;

  criarEntidade();
  setEntidade();
  getParam();
end;

{- Destructor -----------------------------------------------------------------}
destructor TmServiceUnf.Destroy;
begin
  if FInstance then
    FreeAndNil(FContexto);

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
