unit uTransitem;

interface

uses
  Classes, SysUtils, Math,
  mMapping, mCollection, mCollectionItem, mList,
  uProduto, uTransimposto;

type
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
    fProduto: TProduto;
    fImpostos: TTransimpostos;
    function GetVl_Desconto: Real;
    function GetVl_Acrescimo: Real;
    function GetVl_Baseicms: Real;
    function GetVl_Baseicmsst: Real;
    function GetVl_Icms: Real;
    function GetVl_Icmsst: Real;
    function GetVl_Cofins: Real;
    function GetVl_Ii: Real;
    function GetVl_Ipi: Real;
    function GetVl_Pis: Real;
    function GetVl_Totitem: Real;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property Nr_Item : Integer read fNr_Item write fNr_Item;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Id_Produto : String read fId_Produto write fId_Produto;
    property Cd_Produto : Integer read fCd_Produto write fCd_Produto;
    property Ds_Produto : String read fDs_Produto write fDs_Produto;
    property Cd_Cfop : Integer read fCd_Cfop write fCd_Cfop;
    property Cd_Especie : String read fCd_Especie write fCd_Especie;
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    property Qt_Item : Real read fQt_Item write fQt_Item;
    property Vl_Custo : Real read fVl_Custo write fVl_Custo;
    property Vl_Unitario : Real read fVl_Unitario write fVl_Unitario;
    property Vl_Item : Real read fVl_Item write fVl_Item;
    property Vl_Variacao : Real read fVl_Variacao write fVl_Variacao;
    property Vl_Variacaocapa : Real read fVl_Variacaocapa write fVl_Variacaocapa;
    property Vl_Frete : Real read fVl_Frete write fVl_Frete;
    property Vl_Seguro : Real read fVl_Seguro write fVl_Seguro;
    property Vl_Outro : Real read fVl_Outro write fVl_Outro;
    property Vl_Despesa : Real read fVl_Despesa write fVl_Despesa;
    property Produto : TProduto read fProduto write fProduto;
    property Impostos : TTransimpostos read fImpostos write fImpostos;
    property Vl_Desconto : Real read GetVl_Desconto;
    property Vl_Acrescimo : Real read GetVl_Acrescimo;
    property Vl_Baseicms : Real read GetVl_Baseicms;
    property Vl_Icms : Real read GetVl_Icms;
    property Vl_Baseicmsst : Real read GetVl_Baseicmsst;
    property Vl_Icmsst : Real read GetVl_Icmsst;
    property Vl_Ii : Real read GetVl_Ii;
    property Vl_Ipi : Real read GetVl_Ipi;
    property Vl_Pis : Real read GetVl_Pis;
    property Vl_Cofins : Real read GetVl_Cofins;
    property Vl_Totitem : Real read GetVl_Totitem;
  end;

  TTransitems = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransitem;
    procedure SetItem(Index: Integer; Value: TTransitem);
  public
    constructor Create(AOwner: TCollection);
    function Add: TTransitem;
    property Items[Index: Integer]: TTransitem read GetItem write SetItem; default;
  end;

implementation

{ TTransitem }

constructor TTransitem.Create(ACollection: TCollection);
begin
  inherited;

  fProduto:= TProduto.Create(nil);
  fProduto.SetRelacao(Self, 'Id_Produto');
  fImpostos:= TTransimpostos.Create(nil);
  fImpostos.SetRelacao(Self, 'Id_Transacao');
end;

destructor TTransitem.Destroy;
begin
  FreeAndNil(fProduto);
  FreeAndNil(fImpostos);

  inherited;
end;

function TTransitem.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'TRANSITEM';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Transacao', 'ID_TRANSACAO', tfKey);
    Add('Nr_Item', 'NR_ITEM', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Id_Produto', 'ID_PRODUTO', tfReq);
    Add('Cd_Produto', 'CD_PRODUTO', tfReq);
    Add('Ds_Produto', 'DS_PRODUTO', tfReq);
    Add('Cd_Cfop', 'CD_CFOP', tfReq);
    Add('Cd_Especie', 'CD_ESPECIE', tfReq);
    Add('Cd_Ncm', 'CD_NCM', tfReq);
    Add('Qt_Item', 'QT_ITEM', tfReq);
    Add('Vl_Custo', 'VL_CUSTO', tfReq);
    Add('Vl_Unitario', 'VL_UNITARIO', tfReq);
    Add('Vl_Item', 'VL_ITEM', tfReq);
    Add('Vl_Variacao', 'VL_VARIACAO', tfReq);
    Add('Vl_Variacaocapa', 'VL_VARIACAOCAPA', tfReq);
    Add('Vl_Frete', 'VL_FRETE', tfReq);
    Add('Vl_Seguro', 'VL_SEGURO', tfReq);
    Add('Vl_Outro', 'VL_OUTRO', tfReq);
    Add('Vl_Despesa', 'VL_DESPESA', tfReq);
  end;
end;

//--

function TTransitem.GetVl_Desconto: Real;
begin
  Result :=
    IfThen(Vl_Variacao < 0, Vl_Variacao, 0) +
    IfThen(Vl_Variacaocapa < 0, Vl_Variacaocapa, 0);
end;

function TTransitem.GetVl_Acrescimo: Real;
begin
  Result :=
    IfThen(Vl_Variacao > 0, Vl_Variacao, 0) +
    IfThen(Vl_Variacaocapa > 0, Vl_Variacaocapa, 0);
end;

function TTransitem.GetVl_Baseicms: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Baseicms');
end;

function TTransitem.GetVl_Icms: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Icms');
end;

function TTransitem.GetVl_Baseicmsst: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Baseicmsst');
end;

function TTransitem.GetVl_Icmsst: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Icmsst');
end;

function TTransitem.GetVl_Cofins: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Cofins');
end;

function TTransitem.GetVl_Ii: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Ii');
end;

function TTransitem.GetVl_Ipi: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Ipi');
end;

function TTransitem.GetVl_Pis: Real;
begin
  Result := TmList(fImpostos).Sum('Vl_Pis');
end;

function TTransitem.GetVl_Totitem: Real;
begin
  Result := Vl_Unitario * Qt_Item;
end;

{ TTransitems }

constructor TTransitems.Create(AOwner: TCollection);
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