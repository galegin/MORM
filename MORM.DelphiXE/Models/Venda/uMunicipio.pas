unit uMunicipio;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('MUNICIPIO')]
  TMunicipio = class(TmCollectionItem)
  private
    fId_Municipio: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Municipio: Integer;
    fDs_Municipio: String;
    fDs_Sigla: String;
    fId_Estado: Integer;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_MUNICIPIO', tfKey)]
    property Id_Municipio : Integer read fId_Municipio write fId_Municipio;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('CD_MUNICIPIO', tfReq)]
    property Cd_Municipio : Integer read fCd_Municipio write fCd_Municipio;
    [Campo('DS_MUNICIPIO', tfReq)]
    property Ds_Municipio : String read fDs_Municipio write fDs_Municipio;
    [Campo('DS_SIGLA', tfReq)]
    property Ds_Sigla : String read fDs_Sigla write fDs_Sigla;
    [Campo('ID_ESTADO', tfReq)]
    property Id_Estado : Integer read fId_Estado write fId_Estado;
  end;

  TMunicipios = class(TmCollection)
  private
    function GetItem(Index: Integer): TMunicipio;
    procedure SetItem(Index: Integer; Value: TMunicipio);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TMunicipio;
    property Items[Index: Integer]: TMunicipio read GetItem write SetItem; default;
  end;

implementation

{ TMunicipio }

constructor TMunicipio.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TMunicipio.Destroy;
begin

  inherited;
end;

{ TMunicipios }

constructor TMunicipios.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TMunicipio);
end;

function TMunicipios.Add: TMunicipio;
begin
  Result := TMunicipio(inherited Add);
end;

function TMunicipios.GetItem(Index: Integer): TMunicipio;
begin
  Result := TMunicipio(inherited GetItem(Index));
end;

procedure TMunicipios.SetItem(Index: Integer; Value: TMunicipio);
begin
  inherited SetItem(Index, Value);
end;

end.