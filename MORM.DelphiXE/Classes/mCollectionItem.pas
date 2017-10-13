unit mCollectionItem;

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mMapping;

type
  TmCollectionItem = class;
  TmCollectionItemClass = class of TmCollectionItem;

  TmCollectionItem = class(TCollectionItem)
  private
    fRelacao : TRelacao;
  protected
    function QueryInterface(const IID: TGUID; out Obj): HResult; stdcall;
    function _AddRef: Integer; stdcall;
    function _Release: Integer; stdcall;
  public
    constructor Create(Collection: TCollection); override;
    destructor Destroy; override;

    procedure SetRelacao(AOwner : TObject; ACampos : String);
    function GetRelacao() : TRelacao;
  published
  end;

implementation

{ TmCollection }

constructor TmCollectionItem.Create(Collection: TCollection);
begin
  inherited;

end;

destructor TmCollectionItem.Destroy;
begin

  inherited;
end;

//--

function TmCollectionItem.QueryInterface(const IID: TGUID; out Obj): HResult;
begin
  Result := 0;
end;

function TmCollectionItem._AddRef: Integer;
begin
  Result := 0;
end;

function TmCollectionItem._Release: Integer;
begin
  Result := 0;
end;

//--

procedure TmCollectionItem.SetRelacao(AOwner : TObject; ACampos : String);
begin
  fRelacao := TRelacao.Create(AOwner, ACampos);
end;

function TmCollectionItem.GetRelacao: TRelacao;
begin
  Result := fRelacao;
end;

//--

end.
