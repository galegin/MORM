unit uTransdfe;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [TTabela('TRANSDFE')]
  TTransdfe = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fNr_Sequencia: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fTp_Evento: Integer;
    fTp_Ambiente: Integer;
    fTp_Emissao: Integer;
    fDs_Envioxml: String;
    fDs_Retornoxml: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [TCampo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [TCampo('NR_SEQUENCIA', tfKey)]
    property Nr_Sequencia : Integer read fNr_Sequencia write fNr_Sequencia;
    [TCampo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [TCampo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [TCampo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [TCampo('TP_EVENTO', tfReq)]
    property Tp_Evento : Integer read fTp_Evento write fTp_Evento;
    [TCampo('TP_AMBIENTE', tfReq)]
    property Tp_Ambiente : Integer read fTp_Ambiente write fTp_Ambiente;
    [TCampo('TP_EMISSAO', tfReq)]
    property Tp_Emissao : Integer read fTp_Emissao write fTp_Emissao;
    [TCampo('DS_ENVIOXML', tfReq)]
    property Ds_Envioxml : String read fDs_Envioxml write fDs_Envioxml;
    [TCampo('DS_RETORNOXML', tfNul)]
    property Ds_Retornoxml : String read fDs_Retornoxml write fDs_Retornoxml;
  end;

  TTransdfes = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransdfe;
    procedure SetItem(Index: Integer; Value: TTransdfe);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTransdfe;
    property Items[Index: Integer]: TTransdfe read GetItem write SetItem; default;
  end;

implementation

{ TTransdfe }

constructor TTransdfe.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTransdfe.Destroy;
begin

  inherited;
end;

{ TTransdfes }

constructor TTransdfes.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTransdfe);
end;

function TTransdfes.Add: TTransdfe;
begin
  Result := TTransdfe(inherited Add);
end;

function TTransdfes.GetItem(Index: Integer): TTransdfe;
begin
  Result := TTransdfe(inherited GetItem(Index));
end;

procedure TTransdfes.SetItem(Index: Integer; Value: TTransdfe);
begin
  inherited SetItem(Index, Value);
end;

end.