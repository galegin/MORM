unit uNcm;

interface

uses
  Classes, SysUtils,
  mMapping, mCollection, mCollectionItem;

type
  TNcm = class(TmCollectionItem)
  private
    fCd_Ncm: String;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fDs_Ncm: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
    function GetMapping() : PmMapping; override;
  published
    property Cd_Ncm : String read fCd_Ncm write fCd_Ncm;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Ds_Ncm : String read fDs_Ncm write fDs_Ncm;
  end;

  TNcms = class(TmCollection)
  private
    function GetItem(Index: Integer): TNcm;
    procedure SetItem(Index: Integer; Value: TNcm);
  public
    constructor Create(AOwner: TCollection);
    function Add: TNcm;
    property Items[Index: Integer]: TNcm read GetItem write SetItem; default;
  end;

implementation

{ TNcm }

constructor TNcm.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TNcm.Destroy;
begin

  inherited;
end;

function TNcm.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := 'NCM';
  end;

  Result.Campos := TmCampos.Create;
  with Result.Campos do begin
    Add('Cd_Ncm', 'CD_NCM', tfKey);
    Add('U_Version', 'U_VERSION', tfNul);
    Add('Cd_Operador', 'CD_OPERADOR', tfReq);
    Add('Dt_Cadastro', 'DT_CADASTRO', tfReq);
    Add('Ds_Ncm', 'DS_NCM', tfReq);
  end;
end;

{ TNcms }

constructor TNcms.Create(AOwner: TCollection);
begin
  inherited Create(TNcm);
end;

function TNcms.Add: TNcm;
begin
  Result := TNcm(inherited Add);
end;

function TNcms.GetItem(Index: Integer): TNcm;
begin
  Result := TNcm(inherited GetItem(Index));
end;

procedure TNcms.SetItem(Index: Integer; Value: TNcm);
begin
  inherited SetItem(Index, Value);
end;

end.