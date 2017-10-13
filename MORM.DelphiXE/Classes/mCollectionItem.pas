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
    fRelacao : PmRelacao;
  protected
    function QueryInterface(const IID: TGUID; out Obj): HResult; stdcall;
    function _AddRef: Integer; stdcall;
    function _Release: Integer; stdcall;
  public
    constructor Create(Collection: TCollection); override;
    destructor Destroy; override;

    function GetMapping() : PmMapping; virtual;

    procedure SetRelacao(AOwner : TObject; ACampos : String);
    function GetRelacao() : PmRelacao;
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

function TmCollectionItem.GetMapping: PmMapping;
begin
  Result := New(PmMapping);

  Result.Tabela := New(PmTabela);
  with Result.Tabela^ do begin
    Nome := UpperCase(Copy(ClassName, 2, Length(ClassName)));
  end;

  Result.Campos := TmCampos.Create; // mObjeto
  with Result.Campos do begin
  end;
end;

//--

procedure TmCollectionItem.SetRelacao(AOwner : TObject; ACampos : String);
begin
  fRelacao := New(PmRelacao);
  fRelacao.Owner := AOwner;
  fRelacao.Campos := ACampos;
end;

function TmCollectionItem.GetRelacao: PmRelacao;
begin
  Result := fRelacao;
end;

//--

end.
