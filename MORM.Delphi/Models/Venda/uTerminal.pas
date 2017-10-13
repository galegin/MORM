unit uTerminal;

interface

uses
  Classes, SysUtils,
  mCollection, mCollectionItem;

type
  TTerminal = class(TmCollectionItem)
  private
    fId_Terminal: Integer;
    fU_Version: String;
    fCd_Operador: Integer;
    fDt_Cadastro: TDateTime;
    fCd_Terminal: Integer;
    fDs_Terminal: String;
  public
    constructor Create(ACollection: TCollection); override;
    destructor Destroy; override;
  published
    property Id_Terminal : Integer read fId_Terminal write fId_Terminal;
    property U_Version : String read fU_Version write fU_Version;
    property Cd_Operador : Integer read fCd_Operador write fCd_Operador;
    property Dt_Cadastro : TDateTime read fDt_Cadastro write fDt_Cadastro;
    property Cd_Terminal : Integer read fCd_Terminal write fCd_Terminal;
    property Ds_Terminal : String read fDs_Terminal write fDs_Terminal;
  end;

  TTerminals = class(TmCollection)
  private
    function GetItem(Index: Integer): TTerminal;
    procedure SetItem(Index: Integer; Value: TTerminal);
  public
    constructor Create(AItemClass: TCollectionItemClass); override;
    function Add: TTerminal;
    property Items[Index: Integer]: TTerminal read GetItem write SetItem; default;
  end;

implementation

{ TTerminal }

constructor TTerminal.Create(ACollection: TCollection);
begin
  inherited;

end;

destructor TTerminal.Destroy;
begin

  inherited;
end;

{ TTerminals }

constructor TTerminals.Create(AItemClass: TCollectionItemClass);
begin
  inherited Create(TTerminal);
end;

function TTerminals.Add: TTerminal;
begin
  Result := TTerminal(inherited Add);
end;

function TTerminals.GetItem(Index: Integer): TTerminal;
begin
  Result := TTerminal(inherited GetItem(Index));
end;

procedure TTerminals.SetItem(Index: Integer; Value: TTerminal);
begin
  inherited SetItem(Index, Value);
end;

end.