unit mException;

interface

uses
  Classes, SysUtils;

type
  TmException = class(Exception)
  private
    fMetodo : String;
  public
    constructor Create(AMetodo, AMensagem : String);
  published
    property Metodo : String read fMetodo;
  end;

implementation

uses
  mLogger;

{ TmException }

constructor TmException.Create(AMetodo, AMensagem : String);
begin
  fMetodo := AMetodo;
  Message := AMensagem;
  mLogger.Instance.Erro(AMetodo, AMensagem);
end;

end.