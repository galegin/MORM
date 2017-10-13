unit uTransinut;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

type
  TTransinut = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fDt_Emissao: TDateTime;
    fTp_Modelonf: Integer;
    fCd_Serie: String;
    fNr_Nf: Integer;
    fDt_Recebimento: TDateTime;
    fNr_Recibo: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Dt_Emissao : TDateTime read fDt_Emissao write fDt_Emissao;
    property Tp_Modelonf : Integer read fTp_Modelonf write fTp_Modelonf;
    property Cd_Serie : String read fCd_Serie write fCd_Serie;
    property Nr_Nf : Integer read fNr_Nf write fNr_Nf;
    property Dt_Recebimento : TDateTime read fDt_Recebimento write fDt_Recebimento;
    property Nr_Recibo : String read fNr_Recibo write fNr_Recibo;
  end;

  TTransinuts = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransinut;
    procedure SetItem(Index: Integer; Value: TTransinut);
  public
    constructor Create(AOwner: TCollection);
    function Add: TTransinut;
    property Items[Index: Integer]: TTransinut read GetItem write SetItem; default;
  end;

implementation

{ TTransinut }

constructor TTransinut.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTransinut.Destroy;
begin

  inherited;
end;

function TTransinut.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'TRANSINUT';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Transacao', 'ID_TRANSACAO', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Dt_Emissao', 'DT_EMISSAO', tfReq);
    Add('Tp_Modelonf', 'TP_MODELONF', tfReq);
    Add('Cd_Serie', 'CD_SERIE', tfReq);
    Add('Nr_Nf', 'NR_NF', tfReq);
    Add('Dt_Recebimento', 'DT_RECEBIMENTO', tfNul);
    Add('Nr_Recibo', 'NR_RECIBO', tfNul);
  end;
end;

{ TTransinuts }

constructor TTransinuts.Create(AOwner: TCollection);
begin
  inherited Create(TTransinut);
end;

function TTransinuts.Add: TTransinut;
begin
  Result := TTransinut(inherited Add);
end;

function TTransinuts.GetItem(Index: Integer): TTransinut;
begin
  Result := TTransinut(inherited GetItem(Index));
end;

procedure TTransinuts.SetItem(Index: Integer; Value: TTransinut);
begin
  inherited SetItem(Index, Value);
end;

end.