unit uEstado;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('ESTADO')]
  TEstado = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_ESTADO', tfKey)]
    property Id_Estado : Integer read fId_Estado write fId_Estado;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('CD_ESTADO', tfReq)]
    property Cd_Estado : Integer read fCd_Estado write fCd_Estado;
    [Campo('DS_ESTADO', tfReq)]
    property Ds_Estado : String read fDs_Estado write fDs_Estado;
    [Campo('DS_SIGLA', tfReq)]
    property Ds_Sigla : String read fDs_Sigla write fDs_Sigla;
    [Campo('ID_PAIS', tfReq)]
    property Id_Pais : Integer read fId_Pais write fId_Pais;
  end;

  TEstadoList = class(TmCollection)
  private
    function GetItem(Index: Integer): TEstado;
    procedure SetItem(Index: Integer; Value: TEstado);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TEstado;
    property Items[Index: Integer]: TEstado read GetItem write SetItem; default;
  end;

implementation

{ TEstado }

constructor TEstado.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TEstado.Destroy;
begin

  inherited;
end;

{ TEstadoList }

constructor TEstadoList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TEstado);
end;

function TEstadoList.Add: TEstado;
begin
  Result := TEstado(inherited Add);
end;

function TEstadoList.GetItem(Index: Integer): TEstado;
begin
  Result := TEstado(inherited GetItem(Index));
end;

procedure TEstadoList.SetItem(Index: Integer; Value: TEstado);
begin
  inherited SetItem(Index, Value);
end;

end.