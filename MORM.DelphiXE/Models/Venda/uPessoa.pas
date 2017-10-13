unit uPessoa;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('PESSOA')]
  TPessoa = class(TmCollectionItem)
  private
    fId_Pessoa: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Pessoa: Integer;
    fNm_Pessoa: String;
    fNr_Cpfcnpj: String;
    fNr_Rgie: String;
    fNm_Fantasia: String;
    fCd_Cep: Integer;
    fNm_Logradouro: String;
    fNr_Logradouro: String;
    fDs_Bairro: String;
    fDs_Complemento: String;
    fCd_Municipio: Integer;
    fDs_Municipio: String;
    fCd_Estado: Integer;
    fDs_Estado: String;
    fDs_Siglaestado: String;
    fCd_Pais: Integer;
    fDs_Pais: String;
    fDs_Fone: String;
    fDs_Celular: String;
    fDs_Email: String;
    fIn_Consumidorfinal: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_PESSOA', tfKey)]
    property Id_Pessoa : String read fId_Pessoa write fId_Pessoa;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('CD_PESSOA', tfReq)]
    property Cd_Pessoa : Integer read fCd_Pessoa write fCd_Pessoa;
    [Campo('NM_PESSOA', tfReq)]
    property Nm_Pessoa : String read fNm_Pessoa write fNm_Pessoa;
    [Campo('NR_CPFCNPJ', tfReq)]
    property Nr_Cpfcnpj : String read fNr_Cpfcnpj write fNr_Cpfcnpj;
    [Campo('NR_RGIE', tfReq)]
    property Nr_Rgie : String read fNr_Rgie write fNr_Rgie;
    [Campo('NM_FANTASIA', tfNul)]
    property Nm_Fantasia : String read fNm_Fantasia write fNm_Fantasia;
    [Campo('CD_CEP', tfReq)]
    property Cd_Cep : Integer read fCd_Cep write fCd_Cep;
    [Campo('NM_LOGRADOURO', tfReq)]
    property Nm_Logradouro : String read fNm_Logradouro write fNm_Logradouro;
    [Campo('NR_LOGRADOURO', tfReq)]
    property Nr_Logradouro : String read fNr_Logradouro write fNr_Logradouro;
    [Campo('DS_BAIRRO', tfReq)]
    property Ds_Bairro : String read fDs_Bairro write fDs_Bairro;
    [Campo('DS_COMPLEMENTO', tfNul)]
    property Ds_Complemento : String read fDs_Complemento write fDs_Complemento;
    [Campo('CD_MUNICIPIO', tfReq)]
    property Cd_Municipio : Integer read fCd_Municipio write fCd_Municipio;
    [Campo('DS_MUNICIPIO', tfReq)]
    property Ds_Municipio : String read fDs_Municipio write fDs_Municipio;
    [Campo('CD_ESTADO', tfReq)]
    property Cd_Estado : Integer read fCd_Estado write fCd_Estado;
    [Campo('DS_ESTADO', tfReq)]
    property Ds_Estado : String read fDs_Estado write fDs_Estado;
    [Campo('DS_SIGLAESTADO', tfReq)]
    property Ds_Siglaestado : String read fDs_Siglaestado write fDs_Siglaestado;
    [Campo('CD_PAIS', tfReq)]
    property Cd_Pais : Integer read fCd_Pais write fCd_Pais;
    [Campo('DS_PAIS', tfReq)]
    property Ds_Pais : String read fDs_Pais write fDs_Pais;
    [Campo('DS_FONE', tfNul)]
    property Ds_Fone : String read fDs_Fone write fDs_Fone;
    [Campo('DS_CELULAR', tfNul)]
    property Ds_Celular : String read fDs_Celular write fDs_Celular;
    [Campo('DS_EMAIL', tfNul)]
    property Ds_Email : String read fDs_Email write fDs_Email;
    [Campo('IN_CONSUMIDORFINAL', tfNul)]
    property In_Consumidorfinal : String read fIn_Consumidorfinal write fIn_Consumidorfinal;
  end;

  TPessoas = class(TmCollection)
  private
    function GetItem(Index: Integer): TPessoa;
    procedure SetItem(Index: Integer; Value: TPessoa);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TPessoa;
    property Items[Index: Integer]: TPessoa read GetItem write SetItem; default;
  end;

implementation

{ TPessoa }

constructor TPessoa.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TPessoa.Destroy;
begin

  inherited;
end;

{ TPessoas }

constructor TPessoas.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TPessoa);
end;

function TPessoas.Add: TPessoa;
begin
  Result := TPessoa(inherited Add);
end;

function TPessoas.GetItem(Index: Integer): TPessoa;
begin
  Result := TPessoa(inherited GetItem(Index));
end;

procedure TPessoas.SetItem(Index: Integer; Value: TPessoa);
begin
  inherited SetItem(Index, Value);
end;

end.