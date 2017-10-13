unit uTranscont;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

type
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
    function GetMapping() : PmMapping; override;
  published
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Tp_Situacao : Integer read fTp_Situacao write fTp_Situacao;
    property Cd_Terminal : Integer read fCd_Terminal write fCd_Terminal;
  end;

  TTransconts = class(TmCollection)
  private
    function GetItem(Index: Integer): TTranscont;
    procedure SetItem(Index: Integer; Value: TTranscont);
  public
    constructor Create(AOwner: TCollection);
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

function TTranscont.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'TRANSCONT';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Transacao', 'ID_TRANSACAO', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Tp_Situacao', 'TP_SITUACAO', tfReq);
    Add('Cd_Terminal', 'CD_TERMINAL', tfReq);
  end;
end;

{ TTransconts }

constructor TTransconts.Create(AOwner: TCollection);
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