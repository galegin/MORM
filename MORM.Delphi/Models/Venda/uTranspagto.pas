unit uTranspagto;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
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
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property Nr_Seq : Integer read fNr_Seq write fNr_Seq;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Id_Caixa : Integer read fId_Caixa write fId_Caixa;
    property Tp_Documento : Integer read fTp_Documento write fTp_Documento;
    property Id_Histrel : Integer read fId_Histrel write fId_Histrel;
    property Nr_Parcela : Integer read fNr_Parcela write fNr_Parcela;
    property Nr_Parcelas : Integer read fNr_Parcelas write fNr_Parcelas;
    property Nr_Documento : Integer read fNr_Documento write fNr_Documento;
    property Vl_Documento : Real read fVl_Documento write fVl_Documento;
    property Dt_Vencimento : TDateTime read fDt_Vencimento write fDt_Vencimento;
    property Cd_Autorizacao : String read fCd_Autorizacao write fCd_Autorizacao;
    property Nr_Nsu : Integer read fNr_Nsu write fNr_Nsu;
    property Ds_Redetef : String read fDs_Redetef write fDs_Redetef;
    property Nm_Operadora : String read fNm_Operadora write fNm_Operadora;
    property Nr_Banco : Integer read fNr_Banco write fNr_Banco;
    property Nr_Agencia : Integer read fNr_Agencia write fNr_Agencia;
    property Ds_Conta : String read fDs_Conta write fDs_Conta;
    property Nr_Cheque : Integer read fNr_Cheque write fNr_Cheque;
    property Ds_Cmc7 : String read fDs_Cmc7 write fDs_Cmc7;
    property Tp_Baixa : Integer read fTp_Baixa write fTp_Baixa;
    property Cd_Operbaixa : Integer read fCd_Operbaixa write fCd_Operbaixa;
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