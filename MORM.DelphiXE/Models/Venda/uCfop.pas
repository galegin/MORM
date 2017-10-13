unit uCfop;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('CFOP')]
  TCfop = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('CD_CFOP', tfKey)]
    property Cd_Cfop : Integer read fCd_Cfop write fCd_Cfop;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('DS_CFOP', tfReq)]
    property Ds_Cfop : String read fDs_Cfop write fDs_Cfop;
  end;

  TCfopList = class(TmCollection)
  private
    function GetItem(Index: Integer): TCfop;
    procedure SetItem(Index: Integer; Value: TCfop);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TCfop;
    property Items[Index: Integer]: TCfop read GetItem write SetItem; default;
  end;

implementation

{ TCfop }

constructor TCfop.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TCfop.Destroy;
begin

  inherited;
end;

{ TCfopList }

constructor TCfopList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TCfop);
end;

function TCfopList.Add: TCfop;
begin
  Result := TCfop(inherited Add);
end;

function TCfopList.GetItem(Index: Integer): TCfop;
begin
  Result := TCfop(inherited GetItem(Index));
end;

procedure TCfopList.SetItem(Index: Integer; Value: TCfop);
begin
  inherited SetItem(Index, Value);
end;

end.