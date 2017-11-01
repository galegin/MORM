unit mCollectionItemUnf;

(* mCollectionItemUnf *)

interface

uses
  Classes, SysUtils, StrUtils,
  mContexto, mCollectionItem, mCollection, mObjeto;

type
  TmCollectionItemUnf = class(TmCollectionItem)
  private
    fContexto : TmContexto;
  protected
  public
    constructor Create(ACollection: TCollection; AContexto: TmContexto = nil); reintroduce; overload;
    destructor Destroy; override;

    procedure Limpar();
    function Listar(AWhere : String = '') : TmCollection;
    function Consultar(AWhere : String = '') : TmCollectionItem;
    procedure Salvar();
    procedure Excluir();
  published
  end;

implementation

(* mCollectionItemUnf *)

constructor TmCollectionItemUnf.Create(ACollection: TCollection; AContexto: TmContexto);
begin
  inherited Create(ACollection);

  if Assigned(AContexto) then
    fContexto := AContexto
  else
    fContexto := mContexto.Instance;
end;

destructor TmCollectionItemUnf.Destroy;
begin

  inherited;
end;

//--

procedure TmCollectionItemUnf.Limpar();
begin
  TmObjeto(Self).ResetValues();
end;

function TmCollectionItemUnf.Listar(AWhere : String) : TmCollection;
var
  vCollection : TmCollection;
begin
  vCollection := TmCollection.Create(TmCollectionItemClass(ClassType));
  fContexto.GetLista(vCollection, AWhere);
  if vCollection.Count > 0 then
    Result := vCollection
  else
    Result := nil;
end;

function TmCollectionItemUnf.Consultar(AWhere : String) : TmCollectionItem;
var
  vCollection : TmCollection;
begin
  vCollection := TmCollection.Create(TmCollectionItemClass(ClassType));
  fContexto.GetLista(vCollection, AWhere);
  if vCollection.Count > 0 then begin
    fContexto.GetObjeto(Self, AWhere);
    Result := Self;
  end else
    Result := nil;
end;

procedure TmCollectionItemUnf.Salvar();
begin
  fContexto.SetObjeto(Self);
end;

procedure TmCollectionItemUnf.Excluir();
begin
  fContexto.RemObjeto(Self);
end;

//--

end.