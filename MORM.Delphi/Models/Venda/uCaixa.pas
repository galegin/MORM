unit uCaixa;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem,
  uEmpresa, uTerminal,
  uCaixacont, uCaixamov,
  uTranspagto;

type
  TCaixa = class(TmCollectionItem)
  private
    fId_Caixa: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fId_Empresa: Integer;
    fId_Terminal: Integer;
    fDt_Abertura: TDateTime;
    fVl_Abertura: Real;
    fIn_Fechado: String;
    fDt_Fechado: TDateTime;
    fEmpresa: TEmpresa;
    fTerminal: TTerminal;
    fContagens: TCaixaconts;
    fMovtos: TCaixamovs;
    fPagtos: TTranspagtos;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Caixa : Integer read fId_Caixa write fId_Caixa;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Id_Empresa : Integer read fId_Empresa write fId_Empresa;
    property Id_Terminal : Integer read fId_Terminal write fId_Terminal;
    property Dt_Abertura : TDateTime read fDt_Abertura write fDt_Abertura;
    property Vl_Abertura : Real read fVl_Abertura write fVl_Abertura;
    property In_Fechado : String read fIn_Fechado write fIn_Fechado;
    property Dt_Fechado : TDateTime read fDt_Fechado write fDt_Fechado;
    property Empresa : TEmpresa read fEmpresa write fEmpresa;
    property Terminal : TTerminal read fTerminal write fTerminal;
    property Contagens : TCaixaconts read fContagens write fContagens;
    property Movtos : TCaixamovs read fMovtos write fMovtos;
    property Pagtos : TTranspagtos read fPagtos write fPagtos;
  end;

  TCaixas = class(TmCollection)
  private
    function GetItem(Index: Integer): TCaixa;
    procedure SetItem(Index: Integer; Value: TCaixa);
  public
    constructor Create(AOwner: TCollection);
    function Add: TCaixa;
    property Items[Index: Integer]: TCaixa read GetItem write SetItem; default;
  end;

implementation

{ TCaixa }

constructor TCaixa.Create(ACollection: TCollection);
begin
  inherited;

  fEmpresa:= TEmpresa.Create(nil);
  fEmpresa.SetRelacao(Self, 'Id_Empresa');
  fTerminal:= TTerminal.Create(nil);
  fTerminal.SetRelacao(Self, 'Id_Terminal');
  fContagens:= TCaixaconts.Create;
  fContagens.SetRelacao(Self, 'Id_Caixa');
  fMovtos:= TCaixamovs.Create;
  fMovtos.SetRelacao(Self, 'Id_Caixa');
  fPagtos:= TTranspagtos.Create;
  fPagtos.SetRelacao(Self, 'Id_Caixa');
end;

destructor TCaixa.Destroy;
begin
  FreeAndNil(fEmpresa);
  FreeAndNil(fTerminal);
  FreeAndNil(fContagens);
  FreeAndNil(fMovtos);
  FreeAndNil(fPagtos);

  inherited;
end;

function TCaixa.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'CAIXA';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Caixa', 'ID_CAIXA', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Id_Empresa', 'CD_EMPRESA', tfReq);
    Add('Id_Terminal', 'CD_TERMINAL', tfReq);
    Add('Dt_Abertura', 'DT_ABERTURA', tfReq);
    Add('Vl_Abertura', 'VL_ABERTURA', tfReq);
    Add('In_Fechado', 'IN_FECHADO', tfReq);
    Add('Dt_Fechado', 'DT_FECHADO', tfNul);
  end;
end;

{ TCaixas }

constructor TCaixas.Create(AOwner: TCollection);
begin
  inherited Create(TCaixa);
end;

function TCaixas.Add: TCaixa;
begin
  Result := TCaixa(inherited Add);
end;

function TCaixas.GetItem(Index: Integer): TCaixa;
begin
  Result := TCaixa(inherited GetItem(Index));
end;

procedure TCaixas.SetItem(Index: Integer; Value: TCaixa);
begin
  inherited SetItem(Index, Value);
end;

end.