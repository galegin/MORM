unit mProxy;

(* classe servico *)

interface

uses
  Classes, SysUtils, StrUtils;

type
  TmProxy = class(TComponent)
  private
    fHost : String;
    fPorta : String;
    fUser : String;
    fSenha : String;
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
  published
    property Host : String read fHost write fHost;
    property Porta : String read fPorta write fPorta;
    property User : String read fUser write fUser;
    property Senha : String read fSenha write fSenha;
  end;

  function Instance : TmProxy;
  procedure Destroy;

implementation

uses
  mIniFiles;

var
  _instance : TmProxy;

  function Instance : TmProxy;
  begin
    if not Assigned(_instance) then
      _instance := TmProxy.Create(nil);
    Result := _instance;
  end;

  procedure Destroy;
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

constructor TmProxy.Create(AOwner : TComponent);
begin
  inherited;

  fHost := TmIniFiles.PegarS('', 'PROXY', 'Host');
  fPorta := TmIniFiles.PegarS('', 'PROXY', 'Porta');
  fUser := TmIniFiles.PegarS('', 'PROXY', 'User');
  fSenha := TmIniFiles.PegarS('', 'PROXY', 'Senha');
end;

destructor TmProxy.Destroy;
begin

  inherited;
end;

initialization
  //Instance();

finalization
  Destroy();

end.