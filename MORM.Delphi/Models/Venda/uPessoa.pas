unit uPessoa;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
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
    property Id_Pessoa : String read fId_Pessoa write fId_Pessoa;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Cd_Pessoa : Integer read fCd_Pessoa write fCd_Pessoa;
    property Nm_Pessoa : String read fNm_Pessoa write fNm_Pessoa;
    property Nr_Cpfcnpj : String read fNr_Cpfcnpj write fNr_Cpfcnpj;
    property Nr_Rgie : String read fNr_Rgie write fNr_Rgie;
    property Nm_Fantasia : String read fNm_Fantasia write fNm_Fantasia;
    property Cd_Cep : Integer read fCd_Cep write fCd_Cep;
    property Nm_Logradouro : String read fNm_Logradouro write fNm_Logradouro;
    property Nr_Logradouro : String read fNr_Logradouro write fNr_Logradouro;
    property Ds_Bairro : String read fDs_Bairro write fDs_Bairro;
    property Ds_Complemento : String read fDs_Complemento write fDs_Complemento;
    property Cd_Municipio : Integer read fCd_Municipio write fCd_Municipio;
    property Ds_Municipio : String read fDs_Municipio write fDs_Municipio;
    property Cd_Estado : Integer read fCd_Estado write fCd_Estado;
    property Ds_Estado : String read fDs_Estado write fDs_Estado;
    property Ds_Siglaestado : String read fDs_Siglaestado write fDs_Siglaestado;
    property Cd_Pais : Integer read fCd_Pais write fCd_Pais;
    property Ds_Pais : String read fDs_Pais write fDs_Pais;
    property Ds_Fone : String read fDs_Fone write fDs_Fone;
    property Ds_Celular : String read fDs_Celular write fDs_Celular;
    property Ds_Email : String read fDs_Email write fDs_Email;
    property In_Consumidorfinal : String read fIn_Consumidorfinal write fIn_Consumidorfinal;
  end;

  TPessoas = class(TmCollection)
  private
    function GetItem(Index: Integer): TPessoa;
    procedure SetItem(Index: Integer; Value: TPessoa);
  public
    constructor Create(ItemClass: TCollectionItemClass); override;
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

constructor TPessoas.Create(ItemClass: TCollectionItemClass);
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