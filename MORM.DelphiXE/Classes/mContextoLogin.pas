unit mContextoLogin;

(* mContextoLogin *)

interface

uses
  Classes, SysUtils, StrUtils,
  mContexto;

type
  TmContextoLogin = class(TmContexto)
  private
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
  published
  end;

implementation

(* mContextoLogin *)

constructor TmContextoLogin.Create(AOwner : TComponent);
begin
  inherited;

  Parametro.Cd_Username := 'uloginp';
  Parametro.Cd_Password := 'uloginp';
end;

destructor TmContextoLogin.Destroy;
begin

  inherited;
end;

end.