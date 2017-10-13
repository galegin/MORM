unit mContextoAmbiente;

(* mContextoAmbiente *)

interface

uses
  Classes, SysUtils, StrUtils,
  mContexto;

type
  TmContextoAmbiente = class(TmContexto)
  private
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
  published
  end;

implementation

(* mContextoAmbiente *)

constructor TmContextoAmbiente.Create(AOwner : TComponent);
begin
  inherited;

end;

destructor TmContextoAmbiente.Destroy;
begin

  inherited;
end;

end.