unit uHistrel;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

type
  THistrel = class(TmCollectionItem)
  private
    fId_Histrel: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fTp_Documento: Integer;
    fCd_Histrel: Integer;
    fDs_Histrel: String;
    fNr_Parcelas: Integer;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Histrel : Integer read fId_Histrel write fId_Histrel;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Tp_Documento : Integer read fTp_Documento write fTp_Documento;
    property Cd_Histrel : Integer read fCd_Histrel write fCd_Histrel;
    property Ds_Histrel : String read fDs_Histrel write fDs_Histrel;
    property Nr_Parcelas : Integer read fNr_Parcelas write fNr_Parcelas;
  end;

  THistrels = class(TmCollection)
  private
    function GetItem(Index: Integer): THistrel;
    procedure SetItem(Index: Integer; Value: THistrel);
  public
    constructor Create(AOwner: TCollection);
    function Add: THistrel;
    property Items[Index: Integer]: THistrel read GetItem write SetItem; default;
  end;

implementation

{ THistrel }

constructor THistrel.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor THistrel.Destroy;
begin

  inherited;
end;

function THistrel.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'HISTREL';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Histrel', 'ID_HISTREL', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Tp_Documento', 'TP_DOCUMENTO', tfReq);
    Add('Cd_Histrel', 'CD_HISTREL', tfReq);
    Add('Ds_Histrel', 'DS_HISTREL', tfReq);
    Add('Nr_Parcelas', 'NR_PARCELAS', tfReq);
  end;
end;

{ THistrels }

constructor THistrels.Create(AOwner: TCollection);
begin
  inherited Create(THistrel);
end;

function THistrels.Add: THistrel;
begin
  Result := THistrel(inherited Add);
end;

function THistrels.GetItem(Index: Integer): THistrel;
begin
  Result := THistrel(inherited GetItem(Index));
end;

procedure THistrels.SetItem(Index: Integer; Value: THistrel);
begin
  inherited SetItem(Index, Value);
end;

end.