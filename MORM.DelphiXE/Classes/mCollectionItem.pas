unit mCollectionItem;

interface

uses
  Classes, SysUtils, StrUtils, DB, Rtti,
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

    function GetTabela() : TTabela;
    function GetCampos() : TCampos;
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

function TmCollectionItem.GetTabela() : TTabela;
var
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  atrbRtti : TCustomAttribute;
begin
  try
    ctxRtti := TRttiContext.Create;
    typeRtti := ctxRtti.GetType(ClassType);
    for atrbRtti in typeRtti.GetAttributes do
      if atrbRtti is TTabela then
        Exit(atrbRtti as TTabela);
  finally
    ctxRtti.Free;
  end;
end;

function TmCollectionItem.GetCampos() : TCampos;
var
  ctxRtti : TRttiContext;
  typeRtti : TRttiType;
  propRtti : TRttiProperty;
  atrbRtti : TCustomAttribute;
  vCampo : TCampo;
begin
  Result := TCampos.Create;

  try
    for propRtti in typeRtti.GetProperties() do
      for atrbRtti in propRtti.GetAttributes do
        if atrbRtti is TCampo then
          with (atrbRtti as TCampo) do
            Result.Add(TCampo.Create(Campo, Tipo, propRtti.Name));
  finally
    ctxRtti.Free;
  end;
end;

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
