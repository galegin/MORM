unit uRegraimposto;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

type
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
    function GetMapping() : PmMapping; override;
  published
    property Id_Regrafiscal : Integer read fId_Regrafiscal write fId_Regrafiscal;
    property Cd_Imposto : Integer read fCd_Imposto write fCd_Imposto;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Pr_Aliquota : Real read fPr_Aliquota write fPr_Aliquota;
    property Pr_Basecalculo : Real read fPr_Basecalculo write fPr_Basecalculo;
    property Cd_Cst : String read fCd_Cst write fCd_Cst;
    property Cd_Csosn : String read fCd_Csosn write fCd_Csosn;
    property In_Isento : String read fIn_Isento write fIn_Isento;
    property In_Outro : String read fIn_Outro write fIn_Outro;
  end;

  TRegraimpostos = class(TmCollection)
  private
    function GetItem(Index: Integer): TRegraimposto;
    procedure SetItem(Index: Integer; Value: TRegraimposto);
  public
    constructor Create(AOwner: TCollection);
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

function TRegraimposto.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'REGRAIMPOSTO';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Regrafiscal', 'ID_REGRAFISCAL', tfKey);
    Add('Cd_Imposto', 'CD_IMPOSTO', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Pr_Aliquota', 'PR_ALIQUOTA', tfReq);
    Add('Pr_Basecalculo', 'PR_BASECALCULO', tfReq);
    Add('Cd_Cst', 'CD_CST', tfReq);
    Add('Cd_Csosn', 'CD_CSOSN', tfNul);
    Add('In_Isento', 'IN_ISENTO', tfReq);
    Add('In_Outro', 'IN_OUTRO', tfReq);
  end;
end;

{ TRegraimpostos }

constructor TRegraimpostos.Create(AOwner: TCollection);
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