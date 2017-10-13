unit uTransdfe;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
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
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property Nr_Sequencia : Integer read fNr_Sequencia write fNr_Sequencia;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Tp_Evento : Integer read fTp_Evento write fTp_Evento;
    property Tp_Ambiente : Integer read fTp_Ambiente write fTp_Ambiente;
    property Tp_Emissao : Integer read fTp_Emissao write fTp_Emissao;
    property Ds_Envioxml : String read fDs_Envioxml write fDs_Envioxml;
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