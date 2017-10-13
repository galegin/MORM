unit uRegrafiscal;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('REGRAFISCAL')]
  TRegrafiscal = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_REGRAFISCAL', tfKey)]
    property Id_Regrafiscal : Integer read fId_Regrafiscal write fId_Regrafiscal;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('DS_REGRAFISCAL', tfReq)]
    property Ds_Regrafiscal : String read fDs_Regrafiscal write fDs_Regrafiscal;
    [Campo('IN_CALCIMPOSTO', tfReq)]
    property In_Calcimposto : String read fIn_Calcimposto write fIn_Calcimposto;
  end;

  TRegrafiscalList = class(TmCollection)
  private
    function GetItem(Index: Integer): TRegrafiscal;
    procedure SetItem(Index: Integer; Value: TRegrafiscal);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TRegrafiscal;
    property Items[Index: Integer]: TRegrafiscal read GetItem write SetItem; default;
  end;

implementation

{ TRegrafiscal }

constructor TRegrafiscal.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TRegrafiscal.Destroy;
begin

  inherited;
end;

{ TRegrafiscalList }

constructor TRegrafiscalList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TRegrafiscal);
end;

function TRegrafiscalList.Add: TRegrafiscal;
begin
  Result := TRegrafiscal(inherited Add);
end;

function TRegrafiscalList.GetItem(Index: Integer): TRegrafiscal;
begin
  Result := TRegrafiscal(inherited GetItem(Index));
end;

procedure TRegrafiscalList.SetItem(Index: Integer; Value: TRegrafiscal);
begin
  inherited SetItem(Index, Value);
end;

end.