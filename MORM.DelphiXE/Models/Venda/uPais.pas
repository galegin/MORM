unit uPais;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('PAIS')]
  TPais = class(TmCollectionItem)
  private
    fId_Pais: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Pais: Integer;
    fDs_Pais: String;
    fDs_Sigla: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('ID_PAIS', tfKey)]
    property Id_Pais : Integer read fId_Pais write fId_Pais;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    [Campo('CD_PAIS', tfReq)]
    property Cd_Pais : Integer read fCd_Pais write fCd_Pais;
    [Campo('DS_PAIS', tfReq)]
    property Ds_Pais : String read fDs_Pais write fDs_Pais;
    [Campo('DS_SIGLA', tfReq)]
    property Ds_Sigla : String read fDs_Sigla write fDs_Sigla;
  end;

  TPaiss = class(TmCollection)
  private
    function GetItem(Index: Integer): TPais;
    procedure SetItem(Index: Integer; Value: TPais);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TPais;
    property Items[Index: Integer]: TPais read GetItem write SetItem; default;
  end;

implementation

{ TPais }

constructor TPais.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TPais.Destroy;
begin

  inherited;
end;

{ TPaiss }

constructor TPaiss.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TPais);
end;

function TPaiss.Add: TPais;
begin
  Result := TPais(inherited Add);
end;

function TPaiss.GetItem(Index: Integer): TPais;
begin
  Result := TPais(inherited GetItem(Index));
end;

procedure TPaiss.SetItem(Index: Integer; Value: TPais);
begin
  inherited SetItem(Index, Value);
end;

end.