unit mParametro;

interface

uses
  Classes, SysUtils,
  mTipoDatabase;

type
  TmParametro = class
  private
    fCd_Ambiente : String;
    fTp_Database : TTipoDatabase;
    fCd_Database : String;
    fCd_Username : String;
    fCd_Password : String;
    fCd_Hostname : String;
    fCd_Hostport : String;
    fCd_Protocol : String;

    function GetFormatoDataHora: String;
  public
    constructor Create;
  published
    property Cd_Ambiente : String read fCd_Ambiente write fCd_Ambiente;
    property Tp_Database : TTipoDatabase read fTp_Database write fTp_Database;
    property Cd_Database : String read fCd_Database write fCd_Database;
    property Cd_Username : String read fCd_Username write fCd_Username;
    property Cd_Password : String read fCd_Password write fCd_Password;
    property Cd_Hostname : String read fCd_Hostname write fCd_Hostname;
    property Cd_Hostport : String read fCd_Hostport write fCd_Hostport;
    property Cd_Protocol : String read fCd_Protocol write fCd_Protocol;

    property FormatoDataHora : String read GetFormatoDataHora;
  end;

implementation

uses
  mIniFiles;

const
  FormatoDataHoraArray : Array [TTipoDatabase] of string = // mTipoDatabase
    ('dd.mm.yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss',
     'dd/mm/yyyy hh:nn:ss');

{ TmParametro }

constructor TmParametro.Create;
begin
  Cd_Ambiente := TmIniFiles.PegarS('', '', 'Cd_Ambiente', '');
  Tp_Database := StrToTipoDatabase(TmIniFiles.PegarS('', '', 'Tp_Database', 'tpdFirebird'));
  Cd_Database := TmIniFiles.PegarS('', '', 'Cd_Database', '');
  Cd_Username := TmIniFiles.PegarS('', '', 'Cd_Username', '');
  Cd_Password := TmIniFiles.PegarS('', '', 'Cd_Password', '');
  Cd_Hostname := TmIniFiles.PegarS('', '', 'Cd_Hostname', '');
  Cd_Hostport := TmIniFiles.PegarS('', '', 'Cd_Hostport', '');
end;

function TmParametro.GetFormatoDataHora: String;
begin
  Result := FormatoDataHoraArray[Tp_Database];
end;

end.