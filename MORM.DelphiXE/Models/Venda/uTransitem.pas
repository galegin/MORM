unit uTransitem;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [TTabela('TRANSITEM')]
  TTransitem = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fNr_Item: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fId_Produto: String;
    fCd_Produto: Integer;
    fDs_Produto: String;
    fCd_Cfop: Integer;
    fCd_Especie: String;
    fCd_Ncm: String;
    fQt_Item: Real;
    fVl_Custo: Real;
    fVl_Unitario: Real;
    fVl_Item: Real;
    fVl_Variacao: Real;
    fVl_Variacaocapa: Real;
    fVl_Frete: Real;
    fVl_Seguro: Real;
    fVl_Outro: Real;
    fVl_Despesa: Real;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [TCampo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [TCampo('NR_ITEM', tfKey)]
    property Nr_Item : Integer read fNr_Item write fNr_Item;
    [TCampo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [TCampo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [TCampo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [TCampo('ID_PRODUTO', tfReq)]
    property Id_Produto : String read fId_Produto write fId_Produto;
    [TCampo('CD_PRODUTO', tfReq)]
    property Cd_Produto : Integer read fCd_Produto write fCd_Produto;
    [TCampo('DS_PRODUTO', tfReq)]
    property Ds_Produto : String read fDs_Produto write fDs_Produto;
    [TCampo('CD_CFOP', tfReq)]
    property Cd_Cfop : Integer read fCd_Cfop write fCd_Cfop;
    [TCampo('CD_ESPECIE', tfReq)]
    property Cd_Especie : String read fCd_Especie write fCd_Especie;
    [TCampo('CD_NCM', tfReq)]
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    [TCampo('QT_ITEM', tfReq)]
    property Qt_Item : Real read fQt_Item write fQt_Item;
    [TCampo('VL_CUSTO', tfReq)]
    property Vl_Custo : Real read fVl_Custo write fVl_Custo;
    [TCampo('VL_UNITARIO', tfReq)]
    property Vl_Unitario : Real read fVl_Unitario write fVl_Unitario;
    [TCampo('VL_ITEM', tfReq)]
    property Vl_Item : Real read fVl_Item write fVl_Item;
    [TCampo('VL_VARIACAO', tfReq)]
    property Vl_Variacao : Real read fVl_Variacao write fVl_Variacao;
    [TCampo('VL_VARIACAOCAPA', tfReq)]
    property Vl_Variacaocapa : Real read fVl_Variacaocapa write fVl_Variacaocapa;
    [TCampo('VL_FRETE', tfReq)]
    property Vl_Frete : Real read fVl_Frete write fVl_Frete;
    [TCampo('VL_SEGURO', tfReq)]
    property Vl_Seguro : Real read fVl_Seguro write fVl_Seguro;
    [TCampo('VL_OUTRO', tfReq)]
    property Vl_Outro : Real read fVl_Outro write fVl_Outro;
    [TCampo('VL_DESPESA', tfReq)]
    property Vl_Despesa : Real read fVl_Despesa write fVl_Despesa;
  end;

  TTransitems = class(TmCollection)
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

constructor TTransitem.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTransitem.Destroy;
begin

  inherited;
end;

{ TTransitems }

constructor TTransitems.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTransitem);
end;

function TTransitems.Add: TTransitem;
begin
  Result := TTransitem(inherited Add);
end;

function TTransitems.GetItem(Index: Integer): TTransitem;
begin
  Result := TTransitem(inherited GetItem(Index));
end;

procedure TTransitems.SetItem(Index: Integer; Value: TTransitem);
begin
  inherited SetItem(Index, Value);
end;

end.