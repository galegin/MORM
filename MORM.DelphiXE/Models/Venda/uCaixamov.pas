unit uCaixamov;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('CAIXAMOV')]
  TCaixamov = class(TmCollectionItem)
  private
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
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('TP_LANCTO', tfReq)]
    property Tp_Lancto : Integer read fTp_Lancto write fTp_Lancto;
    [Campo('VL_LANCTO', tfReq)]
    property Vl_Lancto : String read fVl_Lancto write fVl_Lancto;
    [Campo('NR_DOC', tfReq)]
    property Nr_Doc : Integer read fNr_Doc write fNr_Doc;
    [Campo('DS_AUX', tfReq)]
    property Ds_Aux : String read fDs_Aux write fDs_Aux;
  end;

  TCaixamovList = class(TmCollection)
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

constructor TCaixamov.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TCaixamov.Destroy;
begin

  inherited;
end;

{ TCaixamovList }

constructor TCaixamovList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TCaixamov);
end;

function TCaixamovList.Add: TCaixamov;
begin
  Result := TCaixamov(inherited Add);
end;

function TCaixamovList.GetItem(Index: Integer): TCaixamov;
begin
  Result := TCaixamov(inherited GetItem(Index));
end;

procedure TCaixamovList.SetItem(Index: Integer; Value: TCaixamov);
begin
  inherited SetItem(Index, Value);
end;

end.