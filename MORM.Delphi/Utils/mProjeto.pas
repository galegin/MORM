unit mProjeto;

interface

uses
  Classes, SysUtils, StrUtils, Forms;
                             
type
  TmProjeto = class(TComponent)
  private
    fCodigo : String;
    fVersao : String;
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
  published
    property Codigo : String read fCodigo write fCodigo;
    property Versao : String read fVersao write fVersao;
  end;

  function Instance : TmProjeto;
  procedure Destroy;

implementation

uses
  mVersaoArquivo;

var
  _instance : TmProjeto;

  function Instance : TmProjeto;
  begin
    if not Assigned(_instance) then
      _instance := TmProjeto.Create(nil);
    Result := _instance;
  end;

  procedure Destroy;
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

constructor TmProjeto.Create(AOwner : TComponent);
begin
  inherited;

  fCodigo := TmVersaoArquivo.Codigo(Application.ExeName);
  fVersao := TmVersaoArquivo.Versao(Application.ExeName).Str;
end;

destructor TmProjeto.Destroy;
begin

  inherited;
end;

initialization
  //Instance();

finalization
  Destroy();

end.