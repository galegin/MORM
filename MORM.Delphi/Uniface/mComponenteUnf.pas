unit mComponenteUnf;

interface

uses
  Classes, Forms, SysUtils, StrUtils;

type
  TTipoComponenteUnf = (tcFormulario, tcRelatorio, tcServico);

  RTipoComponenteUnf = record
    Tipo : TTipoComponenteUnf;
    Codigo : String;
    Classe : String;
    Arquivo : String;
    Diretorio : String;
  end;

  TmComponenteUnf = class(TComponent)
  protected
    FListComponente : TStringList;
  public
    constructor Create(AOwner : TComponent); override;
    class function GetClasseComponenteUnf(pCmp : String) : String;
    function GetComponenteUnf(pCmp : String) : TObject;
    procedure RemComponenteUnf(pCmp : String);
  end;

  function GetTipoComponenteCmp(pCmp : String) : RTipoComponenteUnf;
  function StrToTipoComponente(pStr : String) : TTipoComponenteUnf;
  function TipoComponenteToStr(pTip : TTipoComponenteUnf) : String;

  function Instance() : TmComponenteUnf;
  procedure Destroy();

implementation

uses
  mExecuteUnf;

const
  RTipoComponenteUnfArray : Array [TTipoComponenteUnf] Of RTipoComponenteUnf = (
    (Tipo: tcFormulario; Codigo: 'F'; Classe: 'TF_{cmp}'; Arquivo: 'f{cmp}'; Diretorio: 'frm'),
    (Tipo: tcRelatorio ; Codigo: 'R'; Classe: 'TR_{cmp}'; Arquivo: 'r{cmp}'; Diretorio: 'rpt'),
    (Tipo: tcServico   ; Codigo: 'S'; Classe: 'T_{cmp}' ; Arquivo: 'c{cmp}'; Diretorio: 'svc')
  );

var
  _instance : TmComponenteUnf;

  function Instance() : TmComponenteUnf;
  begin
    if not Assigned(_instance) then
      _instance := TmComponenteUnf.Create(nil);
    Result := _instance;
  end;

  procedure Destroy();
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

  //--

  function GetTipoComponenteCmp(pCmp : String) : RTipoComponenteUnf;
  var
    vTipoComponente : TTipoComponenteUnf;
  begin
    Result.Tipo := TTipoComponenteUnf(Ord(-1));

    case pCmp[4] of
      'F' : vTipoComponente := tcFormulario;
      'R' : vTipoComponente := tcRelatorio;
      'S' : vTipoComponente := tcServico;
    else
      Exit;
    end;

    Result := RTipoComponenteUnfArray[vTipoComponente];
  end;

  function StrToTipoComponente(pStr : String) : TTipoComponenteUnf;
  var
    I: Integer;
  begin
    Result := TTipoComponenteUnf(Ord(-1));
    for I := 0 to Ord(High(TTipoComponenteUnf)) do
      if RTipoComponenteUnfArray[TTipoComponenteUnf(I)].Codigo = pStr then
        Result := RTipoComponenteUnfArray[TTipoComponenteUnf(I)].Tipo;
  end;

  function TipoComponenteToStr(pTip : TTipoComponenteUnf) : String;
  begin
    Result := RTipoComponenteUnfArray[pTip].Codigo
  end;

{ TmComponenteUnf }

constructor TmComponenteUnf.create(AOwner: TComponent);
begin
  inherited;
  FListComponente := TStringList.Create;
end;

class function TmComponenteUnf.GetClasseComponenteUnf(pCmp : String) : String;
var
  vTipoComponente : RTipoComponenteUnf;
begin
  vTipoComponente := GetTipoComponenteCmp(pCmp);
  if vTipoComponente.Tipo <> TTipoComponenteUnf(Ord(-1)) then
    Result := AnsiReplaceStr(vTipoComponente.Classe, '{cmp}', pCmp)
  else
    Result := '';  
end;

function TmComponenteUnf.GetComponenteUnf(pCmp : String) : TObject;
var
  vClassName : String;
  vIndex : Integer;
begin
  Result := nil;

  with FListComponente do  begin
    vIndex := IndexOf(pCmp);
    if vIndex > 0 then begin
      Result := Objects[vIndex];
      Exit;
    end;
  end;

  vClassName := GetClasseComponenteUnf(pCmp);
  if (vClassName = '') then
    Exit;

  Result := mExecuteUnf.getObjeto(vClassName, Self);
  if Assigned(Result) then
    FListComponente.AddObject(pCmp, Result);
end;

procedure TmComponenteUnf.RemComponenteUnf(pCmp: String);
var
  vIndex : Integer;
begin
  with FListComponente do  begin
    vIndex := IndexOf(pCmp);
    if vIndex > 0 then begin
      Objects[vIndex].Free;
      Delete(vIndex);
    end;
  end;
end;

initialization
  //Instance();

finalization
  Destroy();

end.