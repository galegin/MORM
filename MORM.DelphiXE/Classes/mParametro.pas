unit mParametro;

interface

uses
  Classes, SysUtils,
  mTipoDatabase;

type
  TmParametro = class
  private
    fAmbiente : String;
    fTipoDatabase : TTipoDatabase;
    fDatabase : String;
    fUsername : String;
    fPassword : String;
    fHostname : String;
    fHostport : String;
    fProtocol : String;
  public
    constructor Create;
  published
    property Ambiente : String read fAmbiente write fAmbiente;
    property TipoDatabase : TTipoDatabase read fTipoDatabase write fTipoDatabase;
    property Database : String read fDatabase write fDatabase;
    property Username : String read fUsername write fUsername;
    property Password : String read fPassword write fPassword;
    property Hostname : String read fHostname write fHostname;
    property Hostport : String read fHostport write fHostport;
    property Protocol : String read fProtocol write fProtocol;
  end;

implementation

uses
  mIniFiles;

{ TmParametro }

constructor TmParametro.Create;
begin
  fAmbiente := TmIniFiles.PegarS('', '', 'Cd_Ambiente', '');
  fTipoDatabase := StrToTipoDatabase(TmIniFiles.PegarS('', '', 'Tp_Database', 'Firebird'));
  fDatabase := TmIniFiles.PegarS('', '', 'Cd_Database', '');
  fUsername := TmIniFiles.PegarS('', '', 'Cd_Username', '');
  fPassword := TmIniFiles.PegarS('', '', 'Cd_Password', '');
  fHostname := TmIniFiles.PegarS('', '', 'Cd_Hostname', '');
  fHostport := TmIniFiles.PegarS('', '', 'Cd_Hostport', '');
  fProtocol := TmIniFiles.PegarS('', '', 'Cd_Protocol', '');
end;

end.