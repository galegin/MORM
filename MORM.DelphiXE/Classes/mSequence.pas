unit mSequence;

interface

uses
  Classes, SysUtils, StrUtils;

type
  TmSequence = class(TComponent)
  private
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;

    function GetSequencia(
      ANomeEntidade : String;
      ANomeAtributo : String = '';
      ADataMovimento : TDateTime = 0;
      AGrupoMovimento : Integer = 0;
      AValorConteudo : String = '') : Integer;

  published
  end;

  function Instance : TmSequence;
  procedure Destroy;

implementation

uses
  mContexto;

var
  _instance : TmSequence;

  function Instance : TmSequence;
  begin
    if not Assigned(_instance) then
      _instance := TmSequence.Create(nil);
    Result := _instance;
  end;

  procedure Destroy;
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

constructor TmSequence.Create(AOwner : TComponent);
begin
  inherited;

end;

destructor TmSequence.Destroy;
begin

  inherited;
end;

function TmSequence.GetSequencia;
var
  vNome : String;
begin
  vNome := '';
  if ANomeEntidade <> '' then
    vNome := vNome + IfThen(vNome <> '', '_', '') + ANomeEntidade;
  if ANomeAtributo <> '' then
    vNome := vNome + IfThen(vNome <> '', '_', '') + ANomeAtributo;
  if ADataMovimento > 0 then
    vNome := vNome + IfThen(vNome <> '', '_', '') + FormatDateTime('ymmdd', ADataMovimento);
  if AGrupoMovimento > 0 then
    vNome := vNome + IfThen(vNome <> '', '_', '') + IntToStr(AGrupoMovimento);
  if AValorConteudo <> '' then
    vNome := vNome + IfThen(vNome <> '', '_', '') + AValorConteudo;

  Result := mContexto.Instance.Database.Conexao.GetSequence(vNome);
end;

initialization
  //Instance();

finalization
  Destroy();

end.