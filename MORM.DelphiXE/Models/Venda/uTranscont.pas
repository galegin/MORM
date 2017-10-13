unit uTranscont;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('TRANSCONT')]
  TTranscont = class(TmCollectionItem)
  private
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
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('TP_SITUACAO', tfReq)]
    property Tp_Situacao : Integer read fTp_Situacao write fTp_Situacao;
    [Campo('CD_TERMINAL', tfReq)]
    property Cd_Terminal : Integer read fCd_Terminal write fCd_Terminal;
  end;

  TTranscontList = class(TmCollection)
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

constructor TTranscont.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TTranscont.Destroy;
begin

  inherited;
end;

{ TTranscontList }

constructor TTranscontList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTranscont);
end;

function TTranscontList.Add: TTranscont;
begin
  Result := TTranscont(inherited Add);
end;

function TTranscontList.GetItem(Index: Integer): TTranscont;
begin
  Result := TTranscont(inherited GetItem(Index));
end;

procedure TTranscontList.SetItem(Index: Integer; Value: TTranscont);
begin
  inherited SetItem(Index, Value);
end;

end.