unit uRegrafiscal;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem,
  uRegraimposto;

type
  TRegrafiscal = class(TmCollectionItem)
  private
    fId_Regrafiscal: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fDs_Regrafiscal: String;
    fIn_Calcimposto: String;
    fImpostos: TRegraimpostos;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Regrafiscal : Integer read fId_Regrafiscal write fId_Regrafiscal;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Ds_Regrafiscal : String read fDs_Regrafiscal write fDs_Regrafiscal;
    property In_Calcimposto : String read fIn_Calcimposto write fIn_Calcimposto;
    property Impostos : TRegraimpostos read fImpostos write fImpostos;
  end;

  TRegrafiscals = class(TmCollection)
  private
    function GetItem(Index: Integer): TRegrafiscal;
    procedure SetItem(Index: Integer; Value: TRegrafiscal);
  public
    constructor Create(AOwner: TCollection);
    function Add: TRegrafiscal;
    property Items[Index: Integer]: TRegrafiscal read GetItem write SetItem; default;
  end;

implementation

{ TRegrafiscal }

constructor TRegrafiscal.Create(ACollection: TCollection);
begin
  inherited;

  fImpostos:= TRegraimpostos.Create(nil);
  fImpostos.SetRelacao(Self, 'Id_Regrafiscal');
end;

destructor TRegrafiscal.Destroy;
begin
  FreeAndNil(fImpostos);

  inherited;
end;

//--

function TRegrafiscal.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'REGRAFISCAL';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Regrafiscal', 'ID_REGRAFISCAL', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Ds_Regrafiscal', 'DS_REGRAFISCAL', tfReq);
    Add('In_Calcimposto', 'IN_CALCIMPOSTO', tfReq);
  end;
end;

//--

{ TRegrafiscals }

constructor TRegrafiscals.Create(AOwner: TCollection);
begin
  inherited Create(TRegrafiscal);
end;

function TRegrafiscals.Add: TRegrafiscal;
begin
  Result := TRegrafiscal(inherited Add);
end;

function TRegrafiscals.GetItem(Index: Integer): TRegrafiscal;
begin
  Result := TRegrafiscal(inherited GetItem(Index));
end;

procedure TRegrafiscals.SetItem(Index: Integer; Value: TRegrafiscal);
begin
  inherited SetItem(Index, Value);
end;

end.