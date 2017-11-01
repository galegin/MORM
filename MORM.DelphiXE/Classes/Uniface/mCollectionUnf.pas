unit mCollectionUnf;

(* mCollectionUnf *)

interface

uses
  Classes, SysUtils, StrUtils,
  mContexto, mCollection, mCollectionItem, mObjeto;

type
  TmCollectionUnf = class(TmCollection)
  private
    fContexto : TmContexto;
  protected
  public
    constructor Create(AItemClass: TCollectionItemClass; AContexto: TmContexto = nil); reintroduce; overload;
    destructor Destroy; override;

    procedure Limpar();
    function Listar(AWhere : String = '') : TmCollection;
    function Consultar(AWhere : String = '') : TmCollectionItem;
    procedure Salvar();
    procedure Excluir();
  published
  end;

implementation

(* mCollectionUnf *)

constructor TmCollectionUnf.Create(AItemClass: TCollectionItemClass; AContexto: TmContexto);
begin
  inherited Create(AItemClass);

  if Assigned(AContexto) then
    fContexto := AContexto
  else
    fContexto := mContexto.Instance;
end;

destructor TmCollectionUnf.Destroy;
begin

  inherited;
end;

//--

procedure TmCollectionUnf.Limpar();
begin
  Self.Clear();
end;

function TmCollectionUnf.Listar(AWhere : String) : TmCollection;
begin
  fContexto.GetLista(Self, AWhere);
  if Self.Count > 0 then
    Result := Self
  else
    Result := nil;
end;

function TmCollectionUnf.Consultar(AWhere : String) : TmCollectionItem;
begin
  fContexto.GetLista(Self, AWhere);
  if Self.Count > 0 then
    Result := Self.Items[0] as TmCollectionItem
  else
    Result := nil;
end;

procedure TmCollectionUnf.Salvar();
begin
  fContexto.SetLista(Self);
end;

procedure TmCollectionUnf.Excluir();
begin
  fContexto.RemLista(Self);
end;

//--

end.
