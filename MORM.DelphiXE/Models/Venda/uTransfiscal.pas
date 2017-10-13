unit uTransfiscal;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('TRANSFISCAL')]
  TTransfiscal = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fTp_Operacao: Integer;
    fTp_Modalidade: Integer;
    fTp_Modelonf: Integer;
    fCd_Serie: String;
    fNr_Nf: Integer;
    fTp_Processamento: String;
    fDs_Chaveacesso: String;
    fDt_Recebimento: TDateTime;
    fNr_Recibo: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('TP_OPERACAO', tfReq)]
    property Tp_Operacao : Integer read fTp_Operacao write fTp_Operacao;
    [Campo('TP_MODALIDADE', tfReq)]
    property Tp_Modalidade : Integer read fTp_Modalidade write fTp_Modalidade;
    [Campo('TP_MODELONF', tfReq)]
    property Tp_Modelonf : Integer read fTp_Modelonf write fTp_Modelonf;
    [Campo('CD_SERIE', tfReq)]
    property Cd_Serie : String read fCd_Serie write fCd_Serie;
    [Campo('NR_NF', tfReq)]
    property Nr_Nf : Integer read fNr_Nf write fNr_Nf;
    [Campo('TP_PROCESSAMENTO', tfReq)]
    property Tp_Processamento : String read fTp_Processamento write fTp_Processamento;
    [Campo('DS_CHAVEACESSO', tfNul)]
    property Ds_Chaveacesso : String read fDs_Chaveacesso write fDs_Chaveacesso;
    [Campo('DT_RECEBIMENTO', tfNul)]
    property Dt_Recebimento : TDateTime read fDt_Recebimento write fDt_Recebimento;
    [Campo('NR_RECIBO', tfNul)]
    property Nr_Recibo : String read fNr_Recibo write fNr_Recibo;
  end;

  TTransfiscals = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransfiscal;
    procedure SetItem(Index: Integer; Value: TTransfiscal);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTransfiscal;
    property Items[Index: Integer]: TTransfiscal read GetItem write SetItem; default;
  end;

implementation

{ TTransfiscal }

constructor TTransfiscal.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTransfiscal.Destroy;
begin

  inherited;
end;

{ TTransfiscals }

constructor TTransfiscals.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTransfiscal);
end;

function TTransfiscals.Add: TTransfiscal;
begin
  Result := TTransfiscal(inherited Add);
end;

function TTransfiscals.GetItem(Index: Integer): TTransfiscal;
begin
  Result := TTransfiscal(inherited GetItem(Index));
end;

procedure TTransfiscals.SetItem(Index: Integer; Value: TTransfiscal);
begin
  inherited SetItem(Index, Value);
end;

end.