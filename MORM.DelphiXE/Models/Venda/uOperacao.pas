unit uOperacao;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('OPERACAO')]
  TOperacao = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_OPERACAO', tfKey)]
    property Id_Operacao : String read fId_Operacao write fId_Operacao;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('DS_OPERACAO', tfReq)]
    property Ds_Operacao : String read fDs_Operacao write fDs_Operacao;
    [Campo('TP_MODELONF', tfReq)]
    property Tp_Modelonf : Integer read fTp_Modelonf write fTp_Modelonf;
    [Campo('TP_MODALIDADE', tfReq)]
    property Tp_Modalidade : Integer read fTp_Modalidade write fTp_Modalidade;
    [Campo('TP_OPERACAO', tfReq)]
    property Tp_Operacao : Integer read fTp_Operacao write fTp_Operacao;
    [Campo('CD_SERIE', tfReq)]
    property Cd_Serie : String read fCd_Serie write fCd_Serie;
    [Campo('CD_CFOP', tfReq)]
    property Cd_Cfop : Integer read fCd_Cfop write fCd_Cfop;
    [Campo('ID_REGRAFISCAL', tfReq)]
    property Id_Regrafiscal : Integer read fId_Regrafiscal write fId_Regrafiscal;
  end;

  TOperacaoList = class(TmCollection)
  private
    function GetItem(Index: Integer): TOperacao;
    procedure SetItem(Index: Integer; Value: TOperacao);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TOperacao;
    property Items[Index: Integer]: TOperacao read GetItem write SetItem; default;
  end;

implementation

{ TOperacao }

constructor TOperacao.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TOperacao.Destroy;
begin

  inherited;
end;

{ TOperacaoList }

constructor TOperacaoList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TOperacao);
end;

function TOperacaoList.Add: TOperacao;
begin
  Result := TOperacao(inherited Add);
end;

function TOperacaoList.GetItem(Index: Integer): TOperacao;
begin
  Result := TOperacao(inherited GetItem(Index));
end;

procedure TOperacaoList.SetItem(Index: Integer; Value: TOperacao);
begin
  inherited SetItem(Index, Value);
end;

end.