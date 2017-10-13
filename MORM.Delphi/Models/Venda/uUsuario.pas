unit uUsuario;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
  TUsuario = class(TmCollectionItem)
  private
    fId_Usuario: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fNm_Usuario: String;
    fNm_Login: String;
    fCd_Senha: String;
    fCd_Papel: String;
    fTp_Bloqueio: Integer;
    fDt_Bloqueio: TDateTime;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Usuario : Integer read fId_Usuario write fId_Usuario;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Nm_Usuario : String read fNm_Usuario write fNm_Usuario;
    property Nm_Login : String read fNm_Login write fNm_Login;
    property Cd_Senha : String read fCd_Senha write fCd_Senha;
    property Cd_Papel : String read fCd_Papel write fCd_Papel;
    property Tp_Bloqueio : Integer read fTp_Bloqueio write fTp_Bloqueio;
    property Dt_Bloqueio : TDateTime read fDt_Bloqueio write fDt_Bloqueio;
  end;

  TUsuarios = class(TmCollection)
  private
    function GetItem(Index: Integer): TUsuario;
    procedure SetItem(Index: Integer; Value: TUsuario);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TUsuario;
    property Items[Index: Integer]: TUsuario read GetItem write SetItem; default;
  end;

implementation

{ TUsuario }

constructor TUsuario.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TUsuario.Destroy;
begin

  inherited;
end;

{ TUsuarios }

constructor TUsuarios.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TUsuario);
end;

function TUsuarios.Add: TUsuario;
begin
  Result := TUsuario(inherited Add);
end;

function TUsuarios.GetItem(Index: Integer): TUsuario;
begin
  Result := TUsuario(inherited GetItem(Index));
end;

procedure TUsuarios.SetItem(Index: Integer; Value: TUsuario);
begin
  inherited SetItem(Index, Value);
end;

end.