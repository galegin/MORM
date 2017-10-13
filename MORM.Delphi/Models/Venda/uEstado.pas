unit uEstado;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem,
  uPais;

type
  TEstado = class(TmCollectionItem)
  private
    fId_Estado: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Estado: Integer;
    fDs_Estado: String;
    fDs_Sigla: String;
    fId_Pais: Integer;
    fPais: TPais;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Estado : Integer read fId_Estado write fId_Estado;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Cd_Estado : Integer read fCd_Estado write fCd_Estado;
    property Ds_Estado : String read fDs_Estado write fDs_Estado;
    property Ds_Sigla : String read fDs_Sigla write fDs_Sigla;
    property Id_Pais : Integer read fId_Pais write fId_Pais;
    property Pais : TPais read fPais write fPais;
  end;

  TEstados = class(TmCollection)
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

constructor TEstado.Create(ACollection: TCollection);
begin
  inherited;

  fPais:= TPais.Create(nil);
  fPais.SetRelacao(Self, 'Id_Pais');
end;

destructor TEstado.Destroy;
begin
  FreeAndNil(fPais);

  inherited;
end;

{ TEstados }

constructor TEstados.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TEstado);
end;

function TEstados.Add: TEstado;
begin
  Result := TEstado(inherited Add);
end;

function TEstados.GetItem(Index: Integer): TEstado;
begin
  Result := TEstado(inherited GetItem(Index));
end;

procedure TEstados.SetItem(Index: Integer; Value: TEstado);
begin
  inherited SetItem(Index, Value);
end;

end.