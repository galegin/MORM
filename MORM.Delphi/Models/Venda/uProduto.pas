unit uProduto;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

type
  TProduto = class(TmCollectionItem)
  private
    fId_Produto: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Produto: Integer;
    fDs_Produto: String;
    fCd_Especie: String;
    fCd_Ncm: String;
    fCd_Cst: String;
    fCd_Csosn: String;
    fPr_Aliquota: Real;
    fTp_Producao: Integer;
    fVl_Custo: Real;
    fVl_Venda: Real;
    fVl_Promocao: Real;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Produto : String read fId_Produto write fId_Produto;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Cd_Produto : Integer read fCd_Produto write fCd_Produto;
    property Ds_Produto : String read fDs_Produto write fDs_Produto;
    property Cd_Especie : String read fCd_Especie write fCd_Especie;
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    property Cd_Cst : String read fCd_Cst write fCd_Cst;
    property Cd_Csosn : String read fCd_Csosn write fCd_Csosn;
    property Pr_Aliquota : Real read fPr_Aliquota write fPr_Aliquota;
    property Tp_Producao : Integer read fTp_Producao write fTp_Producao;
    property Vl_Custo : Real read fVl_Custo write fVl_Custo;
    property Vl_Venda : Real read fVl_Venda write fVl_Venda;
    property Vl_Promocao : Real read fVl_Promocao write fVl_Promocao;
  end;

  TProdutos = class(TmCollection)
  private
    function GetItem(Index: Integer): TProduto;
    procedure SetItem(Index: Integer; Value: TProduto);
  public
    constructor Create(AOwner: TCollection);
    function Add: TProduto;
    property Items[Index: Integer]: TProduto read GetItem write SetItem; default;
  end;

implementation

{ TProduto }

constructor TProduto.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TProduto.Destroy;
begin

  inherited;
end;

function TProduto.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'PRODUTO';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Produto', 'ID_PRODUTO', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Cd_Produto', 'CD_PRODUTO', tfReq);
    Add('Ds_Produto', 'DS_PRODUTO', tfReq);
    Add('Cd_Especie', 'CD_ESPECIE', tfReq);
    Add('Cd_Ncm', 'CD_NCM', tfReq);
    Add('Cd_Cst', 'CD_CST', tfReq);
    Add('Cd_Csosn', 'CD_CSOSN', tfReq);
    Add('Pr_Aliquota', 'PR_ALIQUOTA', tfReq);
    Add('Tp_Producao', 'TP_PRODUCAO', tfReq);
    Add('Vl_Custo', 'VL_CUSTO', tfReq);
    Add('Vl_Venda', 'VL_VENDA', tfReq);
    Add('Vl_Promocao', 'VL_PROMOCAO', tfReq);
  end;
end;

{ TProdutos }

constructor TProdutos.Create(AOwner: TCollection);
begin
  inherited Create(TProduto);
end;

function TProdutos.Add: TProduto;
begin
  Result := TProduto(inherited Add);
end;

function TProdutos.GetItem(Index: Integer): TProduto;
begin
  Result := TProduto(inherited GetItem(Index));
end;

procedure TProdutos.SetItem(Index: Integer; Value: TProduto);
begin
  inherited SetItem(Index, Value);
end;

end.