unit uTransitem;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('TRANSITEM')]
  TTransitem = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [Campo('NR_ITEM', tfKey)]
    property Nr_Item : Integer read fNr_Item write fNr_Item;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('ID_PRODUTO', tfReq)]
    property Id_Produto : String read fId_Produto write fId_Produto;
    [Campo('CD_PRODUTO', tfReq)]
    property Cd_Produto : Integer read fCd_Produto write fCd_Produto;
    [Campo('DS_PRODUTO', tfReq)]
    property Ds_Produto : String read fDs_Produto write fDs_Produto;
    [Campo('CD_CFOP', tfReq)]
    property Cd_Cfop : Integer read fCd_Cfop write fCd_Cfop;
    [Campo('CD_ESPECIE', tfReq)]
    property Cd_Especie : String read fCd_Especie write fCd_Especie;
    [Campo('CD_NCM', tfReq)]
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    [Campo('QT_ITEM', tfReq)]
    property Qt_Item : String read fQt_Item write fQt_Item;
    [Campo('VL_CUSTO', tfReq)]
    property Vl_Custo : String read fVl_Custo write fVl_Custo;
    [Campo('VL_UNITARIO', tfReq)]
    property Vl_Unitario : String read fVl_Unitario write fVl_Unitario;
    [Campo('VL_ITEM', tfReq)]
    property Vl_Item : String read fVl_Item write fVl_Item;
    [Campo('VL_VARIACAO', tfReq)]
    property Vl_Variacao : String read fVl_Variacao write fVl_Variacao;
    [Campo('VL_VARIACAOCAPA', tfReq)]
    property Vl_Variacaocapa : String read fVl_Variacaocapa write fVl_Variacaocapa;
    [Campo('VL_FRETE', tfReq)]
    property Vl_Frete : String read fVl_Frete write fVl_Frete;
    [Campo('VL_SEGURO', tfReq)]
    property Vl_Seguro : String read fVl_Seguro write fVl_Seguro;
    [Campo('VL_OUTRO', tfReq)]
    property Vl_Outro : String read fVl_Outro write fVl_Outro;
    [Campo('VL_DESPESA', tfReq)]
    property Vl_Despesa : String read fVl_Despesa write fVl_Despesa;
  end;

  TTransitemList = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransitem;
    procedure SetItem(Index: Integer; Value: TTransitem);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTransitem;
    property Items[Index: Integer]: TTransitem read GetItem write SetItem; default;
  end;

implementation

{ TTransitem }

constructor TTransitem.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TTransitem.Destroy;
begin

  inherited;
end;

{ TTransitemList }

constructor TTransitemList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTransitem);
end;

function TTransitemList.Add: TTransitem;
begin
  Result := TTransitem(inherited Add);
end;

function TTransitemList.GetItem(Index: Integer): TTransitem;
begin
  Result := TTransitem(inherited GetItem(Index));
end;

procedure TTransitemList.SetItem(Index: Integer; Value: TTransitem);
begin
  inherited SetItem(Index, Value);
end;

end.