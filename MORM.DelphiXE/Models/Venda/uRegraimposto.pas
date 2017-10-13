unit uRegraimposto;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('REGRAIMPOSTO')]
  TRegraimposto = class(TmCollectionItem)
  private
    fId_Regrafiscal: Integer;
    fCd_Imposto: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fPr_Aliquota: Real;
    fPr_Basecalculo: Real;
    fCd_Cst: String;
    fCd_Csosn: String;
    fIn_Isento: String;
    fIn_Outro: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_REGRAFISCAL', tfKey)]
    property Id_Regrafiscal : Integer read fId_Regrafiscal write fId_Regrafiscal;
    [Campo('CD_IMPOSTO', tfKey)]
    property Cd_Imposto : Integer read fCd_Imposto write fCd_Imposto;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('PR_ALIQUOTA', tfReq)]
    property Pr_Aliquota : Real read fPr_Aliquota write fPr_Aliquota;
    [Campo('PR_BASECALCULO', tfReq)]
    property Pr_Basecalculo : Real read fPr_Basecalculo write fPr_Basecalculo;
    [Campo('CD_CST', tfReq)]
    property Cd_Cst : String read fCd_Cst write fCd_Cst;
    [Campo('CD_CSOSN', tfNul)]
    property Cd_Csosn : String read fCd_Csosn write fCd_Csosn;
    [Campo('IN_ISENTO', tfReq)]
    property In_Isento : String read fIn_Isento write fIn_Isento;
    [Campo('IN_OUTRO', tfReq)]
    property In_Outro : String read fIn_Outro write fIn_Outro;
  end;

  TRegraimpostos = class(TmCollection)
  private
    function GetItem(Index: Integer): TRegraimposto;
    procedure SetItem(Index: Integer; Value: TRegraimposto);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TRegraimposto;
    property Items[Index: Integer]: TRegraimposto read GetItem write SetItem; default;
  end;

implementation

{ TRegraimposto }

constructor TRegraimposto.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TRegraimposto.Destroy;
begin

  inherited;
end;

{ TRegraimpostos }

constructor TRegraimpostos.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TRegraimposto);
end;

function TRegraimpostos.Add: TRegraimposto;
begin
  Result := TRegraimposto(inherited Add);
end;

function TRegraimpostos.GetItem(Index: Integer): TRegraimposto;
begin
  Result := TRegraimposto(inherited GetItem(Index));
end;

procedure TRegraimpostos.SetItem(Index: Integer; Value: TRegraimposto);
begin
  inherited SetItem(Index, Value);
end;

end.