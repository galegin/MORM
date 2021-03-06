unit mContexto;

(* mContexto *)

interface

uses
  Classes, SysUtils, StrUtils, DB, TypInfo, Math,
  mConexao, mMapping, mParametro, mComando,
  mCollection, mCollectionItem;

type
  TmContexto = class(TComponent)
  private
    FParametro: TmParametro;
    FConexao: TmConexao;
    FComando: TmComando;
  protected
  public
    constructor Create(AParametro : TmParametro); reintroduce;
    destructor Destroy; override;

    function GetLista(ACollectionClass : TCollectionClass; AWhere : String = '') : TCollection; overload;
    procedure GetLista(ACollection : TCollection; AWhere : String = ''); overload;
    procedure SetLista(ACollection : TCollection);
    procedure RemLista(ACollection : TCollection);

    function GetObjeto(ACollectionItemClass : TCollectionItemClass; AWhere : String = '') : TCollectionItem; overload;
    procedure GetObjeto(ACollectionItem : TCollectionItem; AWhere : String = ''); overload;
    procedure SetObjeto(AObjeto : TObject);
    procedure RemObjeto(AObjeto : TObject);

    procedure GetRelacaoLista(AObjeto : TObject);
    procedure GetRelacao(AObjeto : TObject);
  published
    property Parametro : TmParametro read FParametro write FParametro;
    property Conexao: TmConexao read FConexao write FConexao;
    property Comando: TmComando read FComando write FComando;
  end;

  function Instance() : TmContexto;
  procedure Destroy();

implementation

uses
  mObjeto, mDataSet, mValue;

var
  _instance : TmContexto;

  function Instance() : TmContexto;
  begin
    if not Assigned(_instance) then
      _instance := TmContexto.Create(nil);
    Result := _instance;
  end;

  procedure Destroy();
  begin
    if Assigned(_instance) then
      _instance.Free;
  end;

(* mContexto *)

constructor TmContexto.Create(AParametro : TmParametro);
begin
  if Assigned(AParametro) then
    FParametro := AParametro
  else
    FParametro := TmParametro.Create;
    
  FConexao := TmConexao.Create(FParametro);
  FComando := TmComando.Create(FParametro.TipoDatabase);
end;

destructor TmContexto.Destroy;
begin

  inherited;
end;

//-- lista

procedure TmContexto.GetLista(ACollection : TCollection; AWhere : String);
var
  vDataSet : TDataSet;
  vObject : TObject;
  vSql : String;
begin
  vSql := fComando.GetSelect(ACollection.ItemClass, AWhere);
  vDataSet := FConexao.GetConsulta(vSql);
  with vDataSet do begin
    while not EOF do begin
      vObject := ACollection.Add;
      TmDataSet(vDataSet).ToObject(vObject);
      GetRelacaoLista(vObject);
      Next;
    end;
  end;
end;

function TmContexto.GetLista(ACollectionClass: TCollectionClass;
  AWhere: String): TCollection;
begin
  Result := TmCollectionClass(ACollectionClass).Create(nil);
  GetLista(Result, AWhere);
end;

procedure TmContexto.SetLista(ACollection : TCollection);
var
  I : Integer;
begin
  for I := 0 to ACollection.Count - 1 do
    SetObjeto(ACollection.Items[I]);
end;

procedure TmContexto.RemLista(ACollection : TCollection);
var
  I : Integer;
begin
  for I := 0 to ACollection.Count - 1 do
    RemObjeto(ACollection.Items[I]);
end;

//-- objeto

procedure TmContexto.GetObjeto(ACollectionItem : TCollectionItem; AWhere : String);
var
  vDataSet : TDataSet;
  vSql : String;
begin
  vSql := fComando.GetSelect(ACollectionItem.ClassType, AWhere);
  vDataSet := FConexao.GetConsulta(vSql);
  with vDataSet do
    if not IsEmpty then begin
      TmDataSet(vDataSet).ToObject(ACollectionItem);
      GetRelacaoLista(ACollectionItem);
    end;
end;

function TmContexto.GetObjeto(ACollectionItemClass: TCollectionItemClass;
  AWhere: String): TCollectionItem;
begin
  Result := TmCollectionItemClass(ACollectionItemClass).Create(nil);
  GetObjeto(Result, AWhere);
end;

procedure TmContexto.SetObjeto(AObjeto : TObject);
var
  vDataSet : TDataSet;
  vCmd, vSql : String;
begin
  vSql := fComando.GetSelect(AObjeto);
  vDataSet := FConexao.GetConsulta(vSql);
  if not vDataSet.IsEmpty then
    vCmd := fComando.GetUpdate(AObjeto)
  else
    vCmd := fComando.GetInsert(AObjeto);
  FConexao.ExecComando(vCmd);
end;

procedure TmContexto.RemObjeto(AObjeto : TObject);
var
  vCmd : String;
begin
  vCmd := fComando.GetDelete(AObjeto);
  FConexao.ExecComando(vCmd);
end;

//-- relacao

procedure TmContexto.GetRelacaoLista(AObjeto : TObject);
var
  I : Integer;
begin
  with TmObjeto(AObjeto).GetValuesObjeto(TCollection) do
    for I := 0 to Count - 1 do
      GetRelacao(Objects[I]);

  with TmObjeto(AObjeto).GetValuesObjeto(TCollectionItem) do
    for I := 0 to Count - 1 do
      GetRelacao(Objects[I]);
end;

procedure TmContexto.GetRelacao(AObjeto : TObject);
var
  vRelacao : TRelacao;
  vCampos : TRelacaoCampos;
  vWhere : String;
  I : Integer;
begin
  if AObjeto.InheritsFrom(TmCollection) then
    vRelacao := (AObjeto as TmCollection).GetRelacao()
  else if AObjeto.InheritsFrom(TmCollectionItem) then
    vRelacao := (AObjeto as TmCollectionItem).GetRelacao()
  else
    Exit;

  vCampos := mMapping.GetRelacaoCampos(vRelacao.Campos);

  vWhere := '';
  for I := 0 to vCampos.Count - 1 do
    with TRelacaoCampo(vCampos.Items[I]) do
      AddString(vWhere, Atributo + ' = ' + Comando.GetValueStr(vRelacao.Owner, AtributoRel), ' and ', '');

  if AObjeto.InheritsFrom(TmCollection) then
    GetLista(AObjeto as TmCollection, vWhere)
  else if AObjeto.InheritsFrom(TmCollectionItem) then
    GetObjeto(AObjeto as TmCollectionItem, vWhere);
end;

//--

initialization
  //Instance();

finalization
  Destroy();

end.
