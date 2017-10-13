unit uOperacao;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem,
  uRegrafiscal;

type
  TOperacao = class(TmCollectionItem)
  private
    fId_Operacao: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fDs_Operacao: String;
    fTp_Modelonf: Integer;
    fTp_Modalidade: Integer;
    fTp_Operacao: Integer;
    fCd_Serie: String;
    fCd_Cfop: Integer;
    fId_Regrafiscal: Integer;
    fRegrafiscal: TRegrafiscal;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Operacao : String read fId_Operacao write fId_Operacao;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Ds_Operacao : String read fDs_Operacao write fDs_Operacao;
    property Tp_Modelonf : Integer read fTp_Modelonf write fTp_Modelonf;
    property Tp_Modalidade : Integer read fTp_Modalidade write fTp_Modalidade;
    property Tp_Operacao : Integer read fTp_Operacao write fTp_Operacao;
    property Cd_Serie : String read fCd_Serie write fCd_Serie;
    property Cd_Cfop : Integer read fCd_Cfop write fCd_Cfop;
    property Id_Regrafiscal : Integer read fId_Regrafiscal write fId_Regrafiscal;
    property Regrafiscal : TRegrafiscal read fRegrafiscal write fRegrafiscal;
  end;

  TOperacaos = class(TmCollection)
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

constructor TOperacao.Create(ACollection: TCollection);
begin
  inherited;

  fRegrafiscal:= TRegrafiscal.Create(nil);
  fRegrafiscal.SetRelacao(Self, 'Id_Regrafiscal');
end;

destructor TOperacao.Destroy;
begin
  FreeAndNil(fRegrafiscal);

  inherited;
end;

{ TOperacaos }

constructor TOperacaos.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TOperacao);
end;

function TOperacaos.Add: TOperacao;
begin
  Result := TOperacao(inherited Add);
end;

function TOperacaos.GetItem(Index: Integer): TOperacao;
begin
  Result := TOperacao(inherited GetItem(Index));
end;

procedure TOperacaos.SetItem(Index: Integer; Value: TOperacao);
begin
  inherited SetItem(Index, Value);
end;

end.