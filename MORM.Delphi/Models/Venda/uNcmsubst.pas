unit uNcmsubst;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
  TNcmsubst = class(TmCollectionItem)
  private
    fUf_Origem: String;
    fUf_Destino: String;
    fCd_Ncm: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Cest: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Uf_Origem : String read fUf_Origem write fUf_Origem;
    property Uf_Destino : String read fUf_Destino write fUf_Destino;
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Cd_Cest : String read fCd_Cest write fCd_Cest;
  end;

  TNcmsubsts = class(TmCollection)
  private
    function GetItem(Index: Integer): TNcmsubst;
    procedure SetItem(Index: Integer; Value: TNcmsubst);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TNcmsubst;
    property Items[Index: Integer]: TNcmsubst read GetItem write SetItem; default;
  end;

implementation

{ TNcmsubst }

constructor TNcmsubst.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TNcmsubst.Destroy;
begin

  inherited;
end;

{ TNcmsubsts }

constructor TNcmsubsts.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TNcmsubst);
end;

function TNcmsubsts.Add: TNcmsubst;
begin
  Result := TNcmsubst(inherited Add);
end;

function TNcmsubsts.GetItem(Index: Integer): TNcmsubst;
begin
  Result := TNcmsubst(inherited GetItem(Index));
end;

procedure TNcmsubsts.SetItem(Index: Integer; Value: TNcmsubst);
begin
  inherited SetItem(Index, Value);
end;

end.