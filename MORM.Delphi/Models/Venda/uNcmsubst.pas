unit uNcmsubst;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

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
    function GetMapping() : PmMapping; override;
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
    constructor Create(AOwner: TCollection);
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

function TNcmsubst.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'NCMSUBST';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Uf_Origem', 'UF_ORIGEM', tfKey);
    Add('Uf_Destino', 'UF_DESTINO', tfKey);
    Add('Cd_Ncm', 'CD_NCM', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfNul);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfNul);
    Add('Cd_Cest', 'CD_CEST', tfNul);
  end;
end;

{ TNcmsubsts }

constructor TNcmsubsts.Create(AOwner: TCollection);
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