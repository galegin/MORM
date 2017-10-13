unit uMunicipio;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem,
  uEstado;

type
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
    fEstado: TEstado;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Municipio : Integer read fId_Municipio write fId_Municipio;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Cd_Municipio : Integer read fCd_Municipio write fCd_Municipio;
    property Ds_Municipio : String read fDs_Municipio write fDs_Municipio;
    property Ds_Sigla : String read fDs_Sigla write fDs_Sigla;
    property Id_Estado : Integer read fId_Estado write fId_Estado;
    property Estado : TEstado read fEstado write fEstado;
  end;

  TMunicipios = class(TmCollection)
  private
    function GetItem(Index: Integer): TMunicipio;
    procedure SetItem(Index: Integer; Value: TMunicipio);
  public
    constructor Create(AOwner: TCollection);
    function Add: TMunicipio;
    property Items[Index: Integer]: TMunicipio read GetItem write SetItem; default;
  end;

implementation

{ TMunicipio }

constructor TMunicipio.Create(ACollection: TCollection);
begin
  inherited;

  fEstado:= TEstado.Create(nil);
  fEstado.SetRelacao(Self, 'Id_Estado');
end;

destructor TMunicipio.Destroy;
begin
  FreeAndNil(fEstado);

  inherited;
end;

function TMunicipio.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'MUNICIPIO';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Municipio', 'ID_MUNICIPIO', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Cd_Municipio', 'CD_MUNICIPIO', tfReq);
    Add('Ds_Municipio', 'DS_MUNICIPIO', tfReq);
    Add('Ds_Sigla', 'DS_SIGLA', tfReq);
    Add('Id_Estado', 'ID_ESTADO', tfReq);
  end;
end;

{ TMunicipios }

constructor TMunicipios.Create(AOwner: TCollection);
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