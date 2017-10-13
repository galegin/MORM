unit uTransimposto;

interface

uses
  Classes, SysUtils, Math,
  mMapping, mCollection, mCollectionItem,
  uTipoImposto;

type
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
    function GetTp_Imposto: TTipoImposto;
    function GetVl_Baseicms: Real;
    function GetVl_Baseicmsst: Real;
    function GetVl_Cofins: Real;
    function GetVl_Icms: Real;
    function GetVl_Icmsst: Real;
    function GetVl_Ii: Real;
    function GetVl_Ipi: Real;
    function GetVl_Pis: Real;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Id_Transacao : String read fId_Transacao write fId_Transacao;
    property Nr_Item : Integer read fNr_Item write fNr_Item;
    property Cd_Imposto : Integer read fCd_Imposto write fCd_Imposto;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Pr_Aliquota : Real read fPr_Aliquota write fPr_Aliquota;
    property Vl_Basecalculo : Real read fVl_Basecalculo write fVl_Basecalculo;
    property Pr_Basecalculo : Real read fPr_Basecalculo write fPr_Basecalculo;
    property Pr_Redbasecalculo : Real read fPr_Redbasecalculo write fPr_Redbasecalculo;
    property Vl_Imposto : Real read fVl_Imposto write fVl_Imposto;
    property Vl_Outro : Real read fVl_Outro write fVl_Outro;
    property Vl_Isento : Real read fVl_Isento write fVl_Isento;
    property Cd_Cst : String read fCd_Cst write fCd_Cst;
    property Cd_Csosn : String read fCd_Csosn write fCd_Csosn;
    property Tp_Imposto : TTipoImposto read GetTp_Imposto;
    property Vl_Baseicms : Real read GetVl_Baseicms;
    property Vl_Icms : Real read GetVl_Icms;
    property Vl_Baseicmsst : Real read GetVl_Baseicmsst;
    property Vl_Icmsst : Real read GetVl_Icmsst;
    property Vl_Ii : Real read GetVl_Ii;
    property Vl_Ipi : Real read GetVl_Ipi;
    property Vl_Pis : Real read GetVl_Pis;
    property Vl_Cofins : Real read GetVl_Cofins;
  end;

  TTransimpostos = class(TmCollection)
  private
    function GetItem(Index: Integer): TTransimposto;
    procedure SetItem(Index: Integer; Value: TTransimposto);
  public
    constructor Create(AOwner: TCollection);
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

function TTransimposto.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'TRANSIMPOSTO';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Id_Transacao', 'ID_TRANSACAO', tfKey);
    Add('Nr_Item', 'NR_ITEM', tfKey);
    Add('Cd_Imposto', 'CD_IMPOSTO', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Pr_Aliquota', 'PR_ALIQUOTA', tfReq);
    Add('Vl_Basecalculo', 'VL_BASECALCULO', tfReq);
    Add('Pr_Basecalculo', 'PR_BASECALCULO', tfReq);
    Add('Pr_Redbasecalculo', 'PR_REDBASECALCULO', tfReq);
    Add('Vl_Imposto', 'VL_IMPOSTO', tfReq);
    Add('Vl_Outro', 'VL_OUTRO', tfReq);
    Add('Vl_Isento', 'VL_ISENTO', tfReq);
    Add('Cd_Cst', 'CD_CST', tfReq);
    Add('Cd_Csosn', 'CD_CSOSN', tfNul);
  end;
end;

//--

function TTransimposto.GetTp_Imposto: TTipoImposto;
begin
  Result := IntToTipoImposto(Cd_Imposto);
end;

function TTransimposto.GetVl_Baseicms: Real;
begin
  Result := IfThen(Tp_Imposto = tpiICMS, Vl_Basecalculo, 0);
end;

function TTransimposto.GetVl_Baseicmsst: Real;
begin
  Result := IfThen(Tp_Imposto = tpiICMSST, Vl_Basecalculo, 0);
end;

function TTransimposto.GetVl_Cofins: Real;
begin
  Result := IfThen(Tp_Imposto = tpiCOFINS, Vl_Imposto, 0);
end;

function TTransimposto.GetVl_Icms: Real;
begin
  Result := IfThen(Tp_Imposto = tpiICMS, Vl_Imposto, 0);
end;

function TTransimposto.GetVl_Icmsst: Real;
begin
  Result := IfThen(Tp_Imposto = tpiICMSST, Vl_Imposto, 0);
end;

function TTransimposto.GetVl_Ii: Real;
begin
  Result := IfThen(Tp_Imposto = tpiII, Vl_Imposto, 0);
end;

function TTransimposto.GetVl_Ipi: Real;
begin
  Result := IfThen(Tp_Imposto = tpiIPI, Vl_Imposto, 0);
end;

function TTransimposto.GetVl_Pis: Real;
begin
  Result := IfThen(Tp_Imposto = tpiPIS, Vl_Imposto, 0);
end;

{ TTransimpostos }

constructor TTransimpostos.Create(AOwner: TCollection);
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