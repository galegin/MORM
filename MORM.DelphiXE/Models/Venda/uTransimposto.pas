unit uTransimposto;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [TTabela('TRANSIMPOSTO')]
  TTransimposto = class(TmCollectionItem)
  private
    fId_Transacao: String;
    fNr_Item: Integer;
    fCd_Imposto: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fPr_Aliquota: Real;
    fVl_Basecalculo: Real;
    fPr_Basecalculo: Real;
    fPr_Redbasecalculo: Real;
    fVl_Imposto: Real;
    fVl_Outro: Real;
    fVl_Isento: Real;
    fCd_Cst: String;
    fCd_Csosn: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [TCampo('ID_TRANSACAO', tfKey)]
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    [TCampo('NR_ITEM', tfKey)]
    property Nr_Item : Integer read fNr_Item write fNr_Item;
    [TCampo('CD_IMPOSTO', tfKey)]
    property Cd_Imposto : Integer read fCd_Imposto write fCd_Imposto;
    [TCampo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [TCampo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [TCampo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [TCampo('PR_ALIQUOTA', tfReq)]
    property Pr_Aliquota : Real read fPr_Aliquota write fPr_Aliquota;
    [TCampo('VL_BASECALCULO', tfReq)]
    property Vl_Basecalculo : Real read fVl_Basecalculo write fVl_Basecalculo;
    [TCampo('PR_BASECALCULO', tfReq)]
    property Pr_Basecalculo : Real read fPr_Basecalculo write fPr_Basecalculo;
    [TCampo('PR_REDBASECALCULO', tfReq)]
    property Pr_Redbasecalculo : Real read fPr_Redbasecalculo write fPr_Redbasecalculo;
    [TCampo('VL_IMPOSTO', tfReq)]
    property Vl_Imposto : Real read fVl_Imposto write fVl_Imposto;
    [TCampo('VL_OUTRO', tfReq)]
    property Vl_Outro : Real read fVl_Outro write fVl_Outro;
    [TCampo('VL_ISENTO', tfReq)]
    property Vl_Isento : Real read fVl_Isento write fVl_Isento;
    [TCampo('CD_CST', tfReq)]
    property Cd_Cst : String read fCd_Cst write fCd_Cst;
    [TCampo('CD_CSOSN', tfNul)]
    property Cd_Csosn : String read fCd_Csosn write fCd_Csosn;
  end;

  TTransimpostos = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransimposto;
    procedure SetItem(Index: Integer; Value: TTransimposto);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTransimposto;
    property Items[Index: Integer]: TTransimposto read GetItem write SetItem; default;
  end;

implementation

{ TTransimposto }

constructor TTransimposto.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTransimposto.Destroy;
begin

  inherited;
end;

{ TTransimpostos }

constructor TTransimpostos.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTransimposto);
end;

function TTransimpostos.Add: TTransimposto;
begin
  Result := TTransimposto(inherited Add);
end;

function TTransimpostos.GetItem(Index: Integer): TTransimposto;
begin
  Result := TTransimposto(inherited GetItem(Index));
end;

procedure TTransimpostos.SetItem(Index: Integer; Value: TTransimposto);
begin
  inherited SetItem(Index, Value);
end;

end.