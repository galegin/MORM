unit uHistrel;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('HISTREL')]
  THistrel = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_HISTREL', tfKey)]
    property Id_Histrel : Integer read fId_Histrel write fId_Histrel;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('TP_DOCUMENTO', tfReq)]
    property Tp_Documento : Integer read fTp_Documento write fTp_Documento;
    [Campo('CD_HISTREL', tfReq)]
    property Cd_Histrel : Integer read fCd_Histrel write fCd_Histrel;
    [Campo('DS_HISTREL', tfReq)]
    property Ds_Histrel : String read fDs_Histrel write fDs_Histrel;
    [Campo('NR_PARCELAS', tfReq)]
    property Nr_Parcelas : Integer read fNr_Parcelas write fNr_Parcelas;
  end;

  THistrelList = class(TmCollection)
  private
    function GetItem(Index: Integer): THistrel;
    procedure SetItem(Index: Integer; Value: THistrel);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: THistrel;
    property Items[Index: Integer]: THistrel read GetItem write SetItem; default;
  end;

implementation

{ THistrel }

constructor THistrel.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor THistrel.Destroy;
begin

  inherited;
end;

{ THistrelList }

constructor THistrelList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(THistrel);
end;

function THistrelList.Add: THistrel;
begin
  Result := THistrel(inherited Add);
end;

function THistrelList.GetItem(Index: Integer): THistrel;
begin
  Result := THistrel(inherited GetItem(Index));
end;

procedure THistrelList.SetItem(Index: Integer; Value: THistrel);
begin
  inherited SetItem(Index, Value);
end;

end.