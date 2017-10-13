unit uHistrel;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
  THistrel = class(TmCollectionItem)
  private
    fId_Histrel: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fTp_Documento: Integer;
    fCd_Histrel: Integer;
    fDs_Histrel: String;
    fNr_Parcelas: Integer;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Histrel : Integer read fId_Histrel write fId_Histrel;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Tp_Documento : Integer read fTp_Documento write fTp_Documento;
    property Cd_Histrel : Integer read fCd_Histrel write fCd_Histrel;
    property Ds_Histrel : String read fDs_Histrel write fDs_Histrel;
    property Nr_Parcelas : Integer read fNr_Parcelas write fNr_Parcelas;
  end;

  THistrels = class(TmCollection)
  private
    function GetItem(Index: Integer): THistrel;
    procedure SetItem(Index: Integer; Value: THistrel);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: THistrel;
    property Items[Index: Integer]: THistrel read GetItem write SetItem; default;
  end;

implementation

{ THistrel }

constructor THistrel.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor THistrel.Destroy;
begin

  inherited;
end;

{ THistrels }

constructor THistrels.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(THistrel);
end;

function THistrels.Add: THistrel;
begin
  Result := THistrel(inherited Add);
end;

function THistrels.GetItem(Index: Integer): THistrel;
begin
  Result := THistrel(inherited GetItem(Index));
end;

procedure THistrels.SetItem(Index: Integer; Value: THistrel);
begin
  inherited SetItem(Index, Value);
end;

end.