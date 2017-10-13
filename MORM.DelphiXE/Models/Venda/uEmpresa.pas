unit uEmpresa;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('EMPRESA')]
  TEmpresa = class(TmCollectionItem)
  private
    fId_Empresa: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fId_Pessoa: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_EMPRESA', tfKey)]
    property Id_Empresa : Integer read fId_Empresa write fId_Empresa;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('ID_PESSOA', tfReq)]
    property Id_Pessoa : String read fId_Pessoa write fId_Pessoa;
  end;

  TEmpresas = class(TmCollection)
  private
    function GetItem(Index: Integer): TEmpresa;
    procedure SetItem(Index: Integer; Value: TEmpresa);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TEmpresa;
    property Items[Index: Integer]: TEmpresa read GetItem write SetItem; default;
  end;

implementation

{ TEmpresa }

constructor TEmpresa.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TEmpresa.Destroy;
begin

  inherited;
end;

{ TEmpresas }

constructor TEmpresas.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TEmpresa);
end;

function TEmpresas.Add: TEmpresa;
begin
  Result := TEmpresa(inherited Add);
end;

function TEmpresas.GetItem(Index: Integer): TEmpresa;
begin
  Result := TEmpresa(inherited GetItem(Index));
end;

procedure TEmpresas.SetItem(Index: Integer; Value: TEmpresa);
begin
  inherited SetItem(Index, Value);
end;

end.