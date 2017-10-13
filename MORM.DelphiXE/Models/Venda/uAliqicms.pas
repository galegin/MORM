unit uAliqicms;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem, mMapping;

type
  [Tabela('ALIQICMS')]
  TAliqicms = class(TmCollectionItem)
  private
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    [Campo('UF_ORIGEM', tfKey)]
    property Uf_Origem : String read fUf_Origem write fUf_Origem;
    [Campo('UF_DESTINO', tfKey)]
    property Uf_Destino : String read fUf_Destino write fUf_Destino;
    [Campo('U_VERSION', tfNul)]
    property U_Version : String read fU_Version write fU_Version;
    [Campo('CD_OPERADOR', tfReq)]
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    [Campo('DT_CADASTRO', tfReq)]
    property Dt_Cadastro : String read fDt_Cadastro write fDt_Cadastro;
    [Campo('PR_ALIQUOTA', tfReq)]
    property Pr_Aliquota : String read fPr_Aliquota write fPr_Aliquota;
  end;

  TAliqicmsList = class(TmCollection)
  private
    function GetItem(Index: Integer): TAliqicms;
    procedure SetItem(Index: Integer; Value: TAliqicms);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TAliqicms;
    property Items[Index: Integer]: TAliqicms read GetItem write SetItem; default;
  end;

implementation

{ TAliqicms }

constructor TAliqicms.Create(AOwner: TCollection);
begin
  inherited;

end;

destructor TAliqicms.Destroy;
begin

  inherited;
end;

{ TAliqicmsList }

constructor TAliqicmsList.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TAliqicms);
end;

function TAliqicmsList.Add: TAliqicms;
begin
  Result := TAliqicms(inherited Add);
end;

function TAliqicmsList.GetItem(Index: Integer): TAliqicms;
begin
  Result := TAliqicms(inherited GetItem(Index));
end;

procedure TAliqicmsList.SetItem(Index: Integer; Value: TAliqicms);
begin
  inherited SetItem(Index, Value);
end;

end.