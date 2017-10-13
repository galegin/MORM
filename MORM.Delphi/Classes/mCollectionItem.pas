unit mCollectionItem;

interface

uses
  Classes, SysUtils, StrUtils, DB, TypInfo,
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

    function GetTabela() : TTabela; virtual;
    function GetCampos() : TCampos; virtual;
    procedure SetRelacao(AOwner : TObject; ACampos : String);
    function GetRelacao() : TRelacao;
  published
  end;

implementation

uses
  mValue;

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
begin
  Result := TTabela.Create(UpperCase(Copy(ClassName, 2, Length(ClassName))));
end;

function TmCollectionItem.GetCampos() : TCampos;
var
  vPropInfo : PPropInfo;
  vPropList : PPropList;
  vNome, vTipoBase : String;
  vTipoCampo : TTipoCampo;
  Count, I : Integer;
begin
  Result := TCampos.Create;

  Count := GetPropList(Self.ClassInfo, tkProperties, nil, False);
  GetMem(vPropList, Count * SizeOf(Pointer));

  try
    GetPropList(Self.ClassInfo, tkProperties, vPropList, False);

    vTipoCampo := mMapping.tfKey;

    for I := 0 to Count - 1 do begin
      vPropInfo := vPropList^[I];
      vNome := vPropInfo^.Name;

      //-- read-only
      if vPropInfo^.SetProc = nil then
        Continue;

      if LowerCase(vNome) = 'u_version' then
        vTipoCampo := mMapping.tfNul;

      vTipoBase := LowerCase(vPropInfo^.PropType^.Name);
      if StrToTipoValue(vTipoBase) <> TTipoValue(Ord(-1)) then
        Result.Add(vNome, UpperCase(vNome), vTipoCampo);
    end;
  finally
    FreeMem(vPropList);
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
