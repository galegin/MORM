unit uProduto;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('PRODUTO')]
  TProduto = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_PRODUTO', tfKey)]
    property Id_Produto : String read fId_Produto write fId_Produto;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('CD_PRODUTO', tfReq)]
    property Cd_Produto : Integer read fCd_Produto write fCd_Produto;
    [Campo('DS_PRODUTO', tfReq)]
    property Ds_Produto : String read fDs_Produto write fDs_Produto;
    [Campo('CD_ESPECIE', tfReq)]
    property Cd_Especie : String read fCd_Especie write fCd_Especie;
    [Campo('CD_NCM', tfReq)]
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    [Campo('CD_CST', tfReq)]
    property Cd_Cst : String read fCd_Cst write fCd_Cst;
    [Campo('CD_CSOSN', tfReq)]
    property Cd_Csosn : String read fCd_Csosn write fCd_Csosn;
    [Campo('PR_ALIQUOTA', tfReq)]
    property Pr_Aliquota : String read fPr_Aliquota write fPr_Aliquota;
    [Campo('TP_PRODUCAO', tfReq)]
    property Tp_Producao : Integer read fTp_Producao write fTp_Producao;
    [Campo('VL_CUSTO', tfReq)]
    property Vl_Custo : String read fVl_Custo write fVl_Custo;
    [Campo('VL_VENDA', tfReq)]
    property Vl_Venda : String read fVl_Venda write fVl_Venda;
    [Campo('VL_PROMOCAO', tfReq)]
    property Vl_Promocao : String read fVl_Promocao write fVl_Promocao;
  end;

  TProdutoList = class(TmCollection)
  private
    function GetItem(Index: Integer): TProduto;
    procedure SetItem(Index: Integer; Value: TProduto);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TProduto;
    property Items[Index: Integer]: TProduto read GetItem write SetItem; default;
  end;

implementation

{ TProduto }

constructor TProduto.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TProduto.Destroy;
begin

  inherited;
end;

{ TProdutoList }

constructor TProdutoList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TProduto);
end;

function TProdutoList.Add: TProduto;
begin
  Result := TProduto(inherited Add);
end;

function TProdutoList.GetItem(Index: Integer): TProduto;
begin
  Result := TProduto(inherited GetItem(Index));
end;

procedure TProdutoList.SetItem(Index: Integer; Value: TProduto);
begin
  inherited SetItem(Index, Value);
end;

end.