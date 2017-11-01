unit mDataSetUnf;

  (*
  tPES_PESSOA.Limpar();
  putitem(tPES_PESSOA, 'CD_PESSOA', '1');
  tPES_PESSOA.Consultar();
  *)

interface

uses
  Classes, SysUtils, StrUtils, DB, DBClient, Variants,
  mContexto, mCollection, mCollectionItem, mDataSet, mMapping, mComando;

type
  TmDataSetUnf = class(TmDataSet)
  private
    FContexto : TmContexto;
    FCollectionItemClass : TmCollectionItemClass;
    FCollectionItem : TmCollectionItem;
    FCollection : TmCollection;

    FPosLimpar: TDataSetNotifyEvent;
    FPosListar: TDataSetNotifyEvent;
    FPosConsultar: TDataSetNotifyEvent;
    FPosIncluir: TDataSetNotifyEvent;
    FPosAlterar: TDataSetNotifyEvent;
    FPosExcluir: TDataSetNotifyEvent;
    FPosSalvar: TDataSetNotifyEvent;

    FPreListar: TDataSetNotifyEvent;
    FPreConsultar: TDataSetNotifyEvent;
    FPreLimpar: TDataSetNotifyEvent;
    FPreIncluir: TDataSetNotifyEvent;
    FPreAlterar: TDataSetNotifyEvent;
    FPreExcluir: TDataSetNotifyEvent;
    FPreSalvar: TDataSetNotifyEvent;

    procedure SetPosLimpar(const Value: TDataSetNotifyEvent);
    procedure SetPosListar(const Value: TDataSetNotifyEvent);
    procedure SetPosConsultar(const Value: TDataSetNotifyEvent);
    procedure SetPosIncluir(const Value: TDataSetNotifyEvent);
    procedure SetPosAlterar(const Value: TDataSetNotifyEvent);
    procedure SetPosExcluir(const Value: TDataSetNotifyEvent);
    procedure SetPosSalvar(const Value: TDataSetNotifyEvent);

    procedure SetPreLimpar(const Value: TDataSetNotifyEvent);
    procedure SetPreListar(const Value: TDataSetNotifyEvent);
    procedure SetPreConsultar(const Value: TDataSetNotifyEvent);
    procedure SetPreIncluir(const Value: TDataSetNotifyEvent);
    procedure SetPreAlterar(const Value: TDataSetNotifyEvent);
    procedure SetPreExcluir(const Value: TDataSetNotifyEvent);
    procedure SetPreSalvar(const Value: TDataSetNotifyEvent);
  protected
    procedure CreateFieldsTemp();
  public
    constructor Create(AOwner: TComponent); overload; override;
    constructor Create(AOwner: TComponent;
      pCollectionItemClass : TmCollectionItemClass;
      pContexto : TmContexto); reintroduce; overload; 

    procedure Limpar();
    procedure Listar();

    procedure Consultar();

    procedure Incluir();
    procedure Alterar();
    procedure Salvar();
    procedure Excluir();
  published
    property Contexto : TmContexto read FContexto;
    property CollectionItemClass : TmCollectionItemClass read FCollectionItemClass;
    property CollectionItem : TmCollectionItem read FCollectionItem;

    property PosLimpar : TDataSetNotifyEvent read FPosLimpar write SetposLimpar;
    property PosListar : TDataSetNotifyEvent read FPosListar write SetposListar;
    property PosConsultar : TDataSetNotifyEvent read FPosConsultar write SetPosConsultar;
    property PosIncluir : TDataSetNotifyEvent read FPosIncluir write SetPosIncluir;
    property PosAlterar : TDataSetNotifyEvent read FPosAlterar write SetPosAlterar;
    property PosExcluir : TDataSetNotifyEvent read FPosExcluir write SetPosExcluir;
    property PosSalvar : TDataSetNotifyEvent read FPosSalvar write SetPosSalvar;

    property PreLimpar : TDataSetNotifyEvent read FPreLimpar write SetPreLimpar;
    property PreListar : TDataSetNotifyEvent read FPreListar write SetPreListar;
    property PreConsultar : TDataSetNotifyEvent read FPreConsultar write SetPreConsultar;
    property PreIncluir : TDataSetNotifyEvent read FPreIncluir write SetPreIncluir;
    property PreAlterar : TDataSetNotifyEvent read FPreAlterar write SetPreAlterar;
    property PreExcluir : TDataSetNotifyEvent read FPreExcluir write SetPreExcluir;
    property PreSalvar : TDataSetNotifyEvent read FPreSalvar write SetPreSalvar;
  end;

procedure Register;

implementation

uses
  mObjeto, mValue;

{- Register -------------------------------------------------------------------}
procedure Register;
begin
  RegisterComponents('Comps', [TmDataSetUnf]);
end;

{- Contructor -----------------------------------------------------------------}
constructor TmDataSetUnf.Create(AOwner: TComponent);
begin
  inherited;
end;

constructor TmDataSetUnf.Create(AOwner: TComponent;
  pCollectionItemClass : TmCollectionItemClass;
  pContexto : TmContexto);
begin
  inherited Create(AOwner);

  FCollectionItemClass := pCollectionItemClass;
  FCollectionItem := TmCollectionItemClass(pCollectionItemClass).Create(nil);
  FCollection := TmCollection.Create(pCollectionItemClass);

  if Assigned(pContexto) then
    FContexto := pContexto
  else
    FContexto := mContexto.Instance;

  CreateFieldsTemp();
end;

{- Fields ---------------------------------------------------------------------}

procedure TmDataSetUnf.CreateFieldsTemp(); // mDataSet
var
  vValues : TmValueList;
  vDataType : TFieldType;
  vSize : Integer;
//  vRequired : Boolean;
  I : Integer;
begin
  if (Active) then
    Active := False;

  FieldDefs.Clear();

  vValues := TmObjeto(FCollectionItem).GetValues();
  for I := 0 to vValues.Count - 1 do begin
    with vValues.Items[I] do begin

      case Tipo of
        tvBoolean : vDataType := ftBoolean;
        tvDateTime : vDataType := ftDateTime;
        tvFloat : vDataType := ftFloat;
        tvInteger : vDataType := ftInteger;
        tvString : vDataType := ftString;
      else
        vDataType := TFieldType(Ord(-1));
      end;

      if vDataType = TFieldType(Ord(-1)) then
        Continue;

      if vDataType in [ftString] then
        vSize := 1000
      else
        vSize := 0;

//      vRequired := (TipoField in [tfKey, tfReq]);

      FieldDefs.Add(Nome, vDataType, vSize, {vRequired} False);
    end;
  end;

  if FieldDefs.Count > 0 then
    CreateDataSet;
end;

{- Functions ------------------------------------------------------------------}

procedure TmDataSetUnf.SetPosLimpar(const Value: TDataSetNotifyEvent);
begin
  FPosLimpar := Value;
end;

procedure TmDataSetUnf.SetPosConsultar(const Value: TDataSetNotifyEvent);
begin
  FPosConsultar := Value;
end;

procedure TmDataSetUnf.SetPosListar(const Value: TDataSetNotifyEvent);
begin
  FPosListar := Value;
end;

procedure TmDataSetUnf.SetPosIncluir(const Value: TDataSetNotifyEvent);
begin
  FPosIncluir := Value;
end;

procedure TmDataSetUnf.SetPosAlterar(const Value: TDataSetNotifyEvent);
begin
  FPosAlterar := Value;
end;

procedure TmDataSetUnf.SetPosExcluir(const Value: TDataSetNotifyEvent);
begin
  FPosExcluir := Value;
end;

procedure TmDataSetUnf.SetPosSalvar(const Value: TDataSetNotifyEvent);
begin
  FPosSalvar := Value;
end;

//--

procedure TmDataSetUnf.SetPreLimpar(const Value: TDataSetNotifyEvent);
begin
  FPreLimpar := Value;
end;

procedure TmDataSetUnf.SetPreListar(const Value: TDataSetNotifyEvent);
begin
  FPreListar := Value;
end;

procedure TmDataSetUnf.SetPreConsultar(const Value: TDataSetNotifyEvent);
begin
  FPreConsultar := Value;
end;

procedure TmDataSetUnf.SetPreIncluir(const Value: TDataSetNotifyEvent);
begin
  FPreIncluir := Value;
end;

procedure TmDataSetUnf.SetPreAlterar(const Value: TDataSetNotifyEvent);
begin
  FPreAlterar := Value;
end;

procedure TmDataSetUnf.SetPreExcluir(const Value: TDataSetNotifyEvent);
begin
  FPreExcluir := Value;
end;

procedure TmDataSetUnf.SetPreSalvar(const Value: TDataSetNotifyEvent);
begin
  FPreSalvar := Value;
end;

//--

procedure TmDataSetUnf.Limpar;
begin
  if Assigned(FPreLimpar) then
    FPreLimpar(Self);

  if (Active) then
    EmptyDataSet;

  if Assigned(FPosLimpar) then
    FPosLimpar(Self);
end;

procedure TmDataSetUnf.Listar;
var
  vWhere : String;
  I : Integer;
begin
  if Assigned(FPreListar) then
    FPreListar(Self);

  Limpar();

  ToObject(FCollectionItem);
  vWhere := FContexto.Comando.GetWhereAll(FCollectionItem);
  FContexto.GetLista(FCollection, vWhere);

  for I := 0 to FCollection.Count - 1 do begin
    Append();
    FromObject(FCollection.Items[I]);
    Post();
  end;

  if Assigned(FPosListar) then
    FPosListar(Self);
end;

//--

procedure TmDataSetUnf.Consultar;
var
  vWhere : String;
begin
  if Assigned(FPreConsultar) then
    FPreConsultar(Self);

  ToObject(FCollectionItem);
  vWhere := FContexto.Comando.GetWhereKey(FCollectionItem);
  FContexto.GetObjeto(FCollectionItem, vWhere);
  FromObject(FCollectionItem);

  if Assigned(FPosConsultar) then
    FPosConsultar(Self);
end;

//--

procedure TmDataSetUnf.Incluir;
begin
  if Assigned(FPreIncluir) then
    FPreIncluir(Self);

  ToObject(FCollectionItem);
  FContexto.SetObjeto(FCollectionItem);

  if Assigned(FPosIncluir) then
    FPosIncluir(Self);
end;

procedure TmDataSetUnf.Alterar;
begin
  if Assigned(FPreAlterar) then
    FPreAlterar(Self);

  ToObject(FCollectionItem);
  FContexto.SetObjeto(FCollectionItem);

  if Assigned(FPosAlterar) then
    FPosAlterar(Self);
end;

procedure TmDataSetUnf.Excluir;
begin
  if Assigned(FPreExcluir) then
    FPreExcluir(Self);

  ToObject(FCollectionItem);
  FContexto.RemObjeto(FCollectionItem);

  if Assigned(FPosExcluir) then
    FPosExcluir(Self);
end;

procedure TmDataSetUnf.Salvar;
begin
  if Assigned(FPreSalvar) then
    FPreSalvar(Self);

  ToObject(FCollectionItem);
  FContexto.SetObjeto(FCollectionItem);

  if Assigned(FPosSalvar) then
    FPosSalvar(Self);
end;

//--

end.
