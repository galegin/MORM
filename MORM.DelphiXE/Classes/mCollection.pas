unit mCollection;

interface

uses
  Classes, SysUtils, StrUtils, DB, TypInfo, Math,
  mMapping;

type
  TCollectionClass = class of TCollection;

  TmCollection = class;
  TmCollectionClass = class of TmCollection;

  TmCollection = class(TCollection)
  private
    fRelacao : PmRelacao;
  protected
    function QueryInterface(const IID: TGUID; out Obj): HResult; stdcall;
    function _AddRef: Integer; stdcall;
    function _Release: Integer; stdcall;
  public
    IsUpdate : Boolean;

    constructor Create(ItemClass: TCollectionItemClass); reintroduce; virtual;
    destructor Destroy; override;

    procedure SetRelacao(AOwner : TObject; ACampos : String);
    function GetRelacao() : PmRelacao;

    function Avg(ACampo : String) : Real;
    function Max(ACampo : String) : Real;
    function Min(ACampo : String) : Real;
    function Sum(ACampo : String) : Real;
  published
  end;

implementation

uses
  mCollectionItem;

{ TmCollection }

constructor TmCollection.Create(ItemClass: TCollectionItemClass);
begin
  inherited;

end;

destructor TmCollection.Destroy;
begin

  inherited;
end;

//--

function TmCollection.QueryInterface;
begin
  Result := 0;
end;

function TmCollection._AddRef: Integer;
begin
  Result := 0;
end;

function TmCollection._Release: Integer;
begin
  Result := 0;
end;

//--

procedure TmCollection.SetRelacao(AOwner : TObject; ACampos : String);
begin
  fRelacao := New(PmRelacao);
  fRelacao.Owner := AOwner;
  fRelacao.Campos := ACampos;
end;

function TmCollection.GetRelacao: PmRelacao;
begin
  Result := fRelacao;
end;

//--

function TmCollection.Avg(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    Result := Result + GetFloatProp(GetItem(I), ACampo);
  Result := IfThen(Count > 0, Result / Count, 0);
end;

function TmCollection.Max(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    if (I = 0) or (GetFloatProp(Items[I], ACampo) > Result) then
      Result := GetFloatProp(Items[I], ACampo);
end;

function TmCollection.Min(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    if (I = 0) or (GetFloatProp(Items[I], ACampo) < Result) then
      Result := GetFloatProp(Items[I], ACampo);
end;

function TmCollection.Sum(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    Result := Result + GetFloatProp(Items[I], ACampo);
end;

//--

end.