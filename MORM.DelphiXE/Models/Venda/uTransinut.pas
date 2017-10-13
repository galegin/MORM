unit uTransinut;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('TRANSINUT')]
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
  published
    [Campo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('DT_EMISSAO', tfReq)]
    property Dt_Emissao : TDateTime read fDt_Emissao write fDt_Emissao;
    [Campo('TP_MODELONF', tfReq)]
    property Tp_Modelonf : Integer read fTp_Modelonf write fTp_Modelonf;
    [Campo('CD_SERIE', tfReq)]
    property Cd_Serie : String read fCd_Serie write fCd_Serie;
    [Campo('NR_NF', tfReq)]
    property Nr_Nf : Integer read fNr_Nf write fNr_Nf;
    [Campo('DT_RECEBIMENTO', tfNul)]
    property Dt_Recebimento : TDateTime read fDt_Recebimento write fDt_Recebimento;
    [Campo('NR_RECIBO', tfNul)]
    property Nr_Recibo : String read fNr_Recibo write fNr_Recibo;
  end;

  TTransinuts = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransinut;
    procedure SetItem(Index: Integer; Value: TTransinut);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
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

{ TTransinuts }

constructor TTransinuts.Create(AItemClass: TCollectionItemClass);
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