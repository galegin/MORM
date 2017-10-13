unit uCaixamov;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('CAIXAMOV')]
  TCaixamov = class(TmCollectionItem)
  private
    fId_Caixa: Integer;
    fNr_Seq: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fTp_Lancto: Integer;
    fVl_Lancto: Real;
    fNr_Doc: Integer;
    fDs_Aux: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_CAIXA', tfKey)]
    property Id_Caixa : Integer read fId_Caixa write fId_Caixa;
    [Campo('NR_SEQ', tfKey)]
    property Nr_Seq : Integer read fNr_Seq write fNr_Seq;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('TP_LANCTO', tfReq)]
    property Tp_Lancto : Integer read fTp_Lancto write fTp_Lancto;
    [Campo('VL_LANCTO', tfReq)]
    property Vl_Lancto : Real read fVl_Lancto write fVl_Lancto;
    [Campo('NR_DOC', tfReq)]
    property Nr_Doc : Integer read fNr_Doc write fNr_Doc;
    [Campo('DS_AUX', tfReq)]
    property Ds_Aux : String read fDs_Aux write fDs_Aux;
  end;

  TCaixamovs = class(TmCollection)
  private
    function GetItem(Index: Integer): TCaixamov;
    procedure SetItem(Index: Integer; Value: TCaixamov);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TCaixamov;
    property Items[Index: Integer]: TCaixamov read GetItem write SetItem; default;
  end;

implementation

{ TCaixamov }

constructor TCaixamov.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TCaixamov.Destroy;
begin

  inherited;
end;

{ TCaixamovs }

constructor TCaixamovs.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TCaixamov);
end;

function TCaixamovs.Add: TCaixamov;
begin
  Result := TCaixamov(inherited Add);
end;

function TCaixamovs.GetItem(Index: Integer): TCaixamov;
begin
  Result := TCaixamov(inherited GetItem(Index));
end;

procedure TCaixamovs.SetItem(Index: Integer; Value: TCaixamov);
begin
  inherited SetItem(Index, Value);
end;

end.