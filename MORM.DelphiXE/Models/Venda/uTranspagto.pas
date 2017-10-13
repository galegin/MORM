unit uTranspagto;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('TRANSPAGTO')]
  TTranspagto = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fNr_Seq: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fId_Caixa: Integer;
    fTp_Documento: Integer;
    fId_Histrel: Integer;
    fNr_Parcela: Integer;
    fNr_Parcelas: Integer;
    fNr_Documento: Integer;
    fVl_Documento: Real;
    fDt_Vencimento: TDateTime;
    fCd_Autorizacao: String;
    fNr_Nsu: Integer;
    fDs_Redetef: String;
    fNm_Operadora: String;
    fNr_Banco: Integer;
    fNr_Agencia: Integer;
    fDs_Conta: String;
    fNr_Cheque: Integer;
    fDs_Cmc7: String;
    fTp_Baixa: Integer;
    fCd_Operbaixa: Integer;
    fDt_Baixa: TDateTime;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [Campo('NR_SEQ', tfKey)]
    property Nr_Seq : Integer read fNr_Seq write fNr_Seq;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('ID_CAIXA', tfReq)]
    property Id_Caixa : Integer read fId_Caixa write fId_Caixa;
    [Campo('TP_DOCUMENTO', tfReq)]
    property Tp_Documento : Integer read fTp_Documento write fTp_Documento;
    [Campo('ID_HISTREL', tfReq)]
    property Id_Histrel : Integer read fId_Histrel write fId_Histrel;
    [Campo('NR_PARCELA', tfReq)]
    property Nr_Parcela : Integer read fNr_Parcela write fNr_Parcela;
    [Campo('NR_PARCELAS', tfReq)]
    property Nr_Parcelas : Integer read fNr_Parcelas write fNr_Parcelas;
    [Campo('NR_DOCUMENTO', tfNul)]
    property Nr_Documento : Integer read fNr_Documento write fNr_Documento;
    [Campo('VL_DOCUMENTO', tfReq)]
    property Vl_Documento : Real read fVl_Documento write fVl_Documento;
    [Campo('DT_VENCIMENTO', tfReq)]
    property Dt_Vencimento : TDateTime read fDt_Vencimento write fDt_Vencimento;
    [Campo('CD_AUTORIZACAO', tfNul)]
    property Cd_Autorizacao : String read fCd_Autorizacao write fCd_Autorizacao;
    [Campo('NR_NSU', tfNul)]
    property Nr_Nsu : Integer read fNr_Nsu write fNr_Nsu;
    [Campo('DS_REDETEF', tfNul)]
    property Ds_Redetef : String read fDs_Redetef write fDs_Redetef;
    [Campo('NM_OPERADORA', tfNul)]
    property Nm_Operadora : String read fNm_Operadora write fNm_Operadora;
    [Campo('NR_BANCO', tfNul)]
    property Nr_Banco : Integer read fNr_Banco write fNr_Banco;
    [Campo('NR_AGENCIA', tfNul)]
    property Nr_Agencia : Integer read fNr_Agencia write fNr_Agencia;
    [Campo('DS_CONTA', tfNul)]
    property Ds_Conta : String read fDs_Conta write fDs_Conta;
    [Campo('NR_CHEQUE', tfNul)]
    property Nr_Cheque : Integer read fNr_Cheque write fNr_Cheque;
    [Campo('DS_CMC7', tfNul)]
    property Ds_Cmc7 : String read fDs_Cmc7 write fDs_Cmc7;
    [Campo('TP_BAIXA', tfNul)]
    property Tp_Baixa : Integer read fTp_Baixa write fTp_Baixa;
    [Campo('CD_OPERBAIXA', tfNul)]
    property Cd_Operbaixa : Integer read fCd_Operbaixa write fCd_Operbaixa;
    [Campo('DT_BAIXA', tfNul)]
    property Dt_Baixa : TDateTime read fDt_Baixa write fDt_Baixa;
  end;

  TTranspagtos = class(TmCollection)
  private
    function GetItem(Index: Integer): TTranspagto;
    procedure SetItem(Index: Integer; Value: TTranspagto);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTranspagto;
    property Items[Index: Integer]: TTranspagto read GetItem write SetItem; default;
  end;

implementation

{ TTranspagto }

constructor TTranspagto.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTranspagto.Destroy;
begin

  inherited;
end;

{ TTranspagtos }

constructor TTranspagtos.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTranspagto);
end;

function TTranspagtos.Add: TTranspagto;
begin
  Result := TTranspagto(inherited Add);
end;

function TTranspagtos.GetItem(Index: Integer): TTranspagto;
begin
  Result := TTranspagto(inherited GetItem(Index));
end;

procedure TTranspagtos.SetItem(Index: Integer; Value: TTranspagto);
begin
  inherited SetItem(Index, Value);
end;

end.