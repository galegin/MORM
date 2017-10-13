unit uTranscont;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('TRANSCONT')]
  TTranscont = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fTp_Situacao: Integer;
    fCd_Terminal: Integer;
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
    [Campo('TP_SITUACAO', tfReq)]
    property Tp_Situacao : Integer read fTp_Situacao write fTp_Situacao;
    [Campo('CD_TERMINAL', tfReq)]
    property Cd_Terminal : Integer read fCd_Terminal write fCd_Terminal;
  end;

  TTransconts = class(TmCollection)
  private
    function GetItem(Index: Integer): TTranscont;
    procedure SetItem(Index: Integer; Value: TTranscont);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTranscont;
    property Items[Index: Integer]: TTranscont read GetItem write SetItem; default;
  end;

implementation

{ TTranscont }

constructor TTranscont.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTranscont.Destroy;
begin

  inherited;
end;

{ TTransconts }

constructor TTransconts.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTranscont);
end;

function TTransconts.Add: TTranscont;
begin
  Result := TTranscont(inherited Add);
end;

function TTransconts.GetItem(Index: Integer): TTranscont;
begin
  Result := TTranscont(inherited GetItem(Index));
end;

procedure TTransconts.SetItem(Index: Integer; Value: TTranscont);
begin
  inherited SetItem(Index, Value);
end;

end.