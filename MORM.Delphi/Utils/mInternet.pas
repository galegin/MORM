unit mInternet;

(* classe *)

interface

uses
  Classes, SysUtils, StrUtils, WinInet; //, Winsock,;

type
  TmInternet = class(TComponent)
  public
    class function IsConectado() : Boolean;
  end;

implementation

uses
  mIniFiles;

{ TmInternet }

class function TmInternet.IsConectado: Boolean;
var
  vDsSiteConectado : String;
begin
  vDsSiteConectado := TmIniFiles.PegarS('', '', 'DS_SITE_CONECTADO', 'http://www.google.com.br');
  Result := InternetCheckConnection(PChar(vDsSiteConectado), 1, 0);
end;

initialization
  TmInternet.IsConectado;

end.