unit uCaixacont;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
  TCaixacont = class(TmCollectionItem)
  private
    fId_Caixa: Integer;
    fId_Histrel: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fVl_Contado: Real;
    fVl_Sistema: Real;
    fVl_Retirada: Real;
    fVl_Suprimento: Real;
    fVl_Diferenca: Real;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Caixa : Integer read fId_Caixa write fId_Caixa;
    property Id_Histrel : Integer read fId_Histrel write fId_Histrel;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Vl_Contado : Real read fVl_Contado write fVl_Contado;
    property Vl_Sistema : Real read fVl_Sistema write fVl_Sistema;
    property Vl_Retirada : Real read fVl_Retirada write fVl_Retirada;
    property Vl_Suprimento : Real read fVl_Suprimento write fVl_Suprimento;
    property Vl_Diferenca : Real read fVl_Diferenca write fVl_Diferenca;
  end;

  TCaixaconts = class(TmCollection)
  private
    function GetItem(Index: Integer): TCaixacont;
    procedure SetItem(Index: Integer; Value: TCaixacont);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TCaixacont;
    property Items[Index: Integer]: TCaixacont read GetItem write SetItem; default;
  end;

implementation

{ TCaixacont }

constructor TCaixacont.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TCaixacont.Destroy;
begin

  inherited;
end;

{ TCaixaconts }

constructor TCaixaconts.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TCaixacont);
end;

function TCaixaconts.Add: TCaixacont;
begin
  Result := TCaixacont(inherited Add);
end;

function TCaixaconts.GetItem(Index: Integer): TCaixacont;
begin
  Result := TCaixacont(inherited GetItem(Index));
end;

procedure TCaixaconts.SetItem(Index: Integer; Value: TCaixacont);
begin
  inherited SetItem(Index, Value);
end;

end.