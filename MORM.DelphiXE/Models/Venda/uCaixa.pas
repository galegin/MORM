unit uCaixa;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('CAIXA')]
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
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_CAIXA', tfKey)]
    property Id_Caixa : Integer read fId_Caixa write fId_Caixa;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('ID_EMPRESA', tfReq)]
    property Id_Empresa : Integer read fId_Empresa write fId_Empresa;
    [Campo('ID_TERMINAL', tfReq)]
    property Id_Terminal : Integer read fId_Terminal write fId_Terminal;
    [Campo('DT_ABERTURA', tfReq)]
    property Dt_Abertura : TDateTime read fDt_Abertura write fDt_Abertura;
    [Campo('VL_ABERTURA', tfReq)]
    property Vl_Abertura : Real read fVl_Abertura write fVl_Abertura;
    [Campo('IN_FECHADO', tfReq)]
    property In_Fechado : String read fIn_Fechado write fIn_Fechado;
    [Campo('DT_FECHADO', tfNul)]
    property Dt_Fechado : TDateTime read fDt_Fechado write fDt_Fechado;
  end;

  TCaixas = class(TmCollection)
  private
    function GetItem(Index: Integer): TCaixa;
    procedure SetItem(Index: Integer; Value: TCaixa);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TCaixa;
    property Items[Index: Integer]: TCaixa read GetItem write SetItem; default;
  end;

implementation

{ TCaixa }

constructor TCaixa.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TCaixa.Destroy;
begin

  inherited;
end;

{ TCaixas }

constructor TCaixas.Create(AItemClass: TCollectionItemClass);
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