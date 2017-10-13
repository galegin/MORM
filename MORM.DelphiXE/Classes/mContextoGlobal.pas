unit mContextoGlobal;

(* mContextoGlobal *)

interface

uses
  Classes, SysUtils, StrUtils,
  mContexto;

type
  TmContextoGlobal = class(TmContexto)
  private
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
  published
  end;

implementation

(* mContextoGlobal *)

constructor TmContextoGlobal.Create(AOwner : TComponent);
begin
  inherited;

  Parametro.Cd_Username := 'uv3dadglb';
  Parametro.Cd_Password := 'uv3dadglb';
end;

destructor TmContextoGlobal.Destroy;
begin

  inherited;
end;

end.