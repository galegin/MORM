unit uTransfiscal;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem,
  uTransdfe, uTranscont, uTransinut;

type
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
    fEventos: TTransdfes;
    fContingencia: TTranscont;
    fInutilizacao: TTransinut;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Tp_Operacao : Integer read fTp_Operacao write fTp_Operacao;
    property Tp_Modalidade : Integer read fTp_Modalidade write fTp_Modalidade;
    property Tp_Modelonf : Integer read fTp_Modelonf write fTp_Modelonf;
    property Cd_Serie : String read fCd_Serie write fCd_Serie;
    property Nr_Nf : Integer read fNr_Nf write fNr_Nf;
    property Tp_Processamento : String read fTp_Processamento write fTp_Processamento;
    property Ds_Chaveacesso : String read fDs_Chaveacesso write fDs_Chaveacesso;
    property Dt_Recebimento : TDateTime read fDt_Recebimento write fDt_Recebimento;
    property Nr_Recibo : String read fNr_Recibo write fNr_Recibo;
    property Eventos: TTransdfes read fEventos write fEventos;
    property Contingencia: TTranscont read fContingencia write fContingencia;
    property Inutilizacao: TTransinut read fInutilizacao write fInutilizacao;
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

  fEventos:= TTransdfes.Create(nil);
  fEventos.SetRelacao(Self, 'Id_Transacao');
  fContingencia:= TTranscont.Create(nil);
  fContingencia.SetRelacao(Self, 'Id_Transacao');
  fInutilizacao:= TTransinut.Create(nil);
  fInutilizacao.SetRelacao(Self, 'Id_Transacao');
end;

destructor TTransfiscal.Destroy;
begin
  FreeAndNil(fEventos);
  FreeAndNil(fContingencia);
  FreeAndNil(fInutilizacao);

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