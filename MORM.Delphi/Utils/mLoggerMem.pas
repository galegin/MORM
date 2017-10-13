unit mLoggerMem;

(* mLoggerMem *)

interface

uses
  Classes, SysUtils, StrUtils;

type
  TmLoggerMem = class(TComponent)
  private
    fLista : TStringList;
    function GetConteudo: String;
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
    procedure Add(AMensagem : String);
  published
    property Conteudo : String read GetConteudo;
  end;

  function Instance : TmLoggerMem;
  procedure Destroy;

implementation

var
  _instance : TmLoggerMem;

  function Instance : TmLoggerMem;
  begin
    if not Assigned(_instance) then
      _instance := TmLoggerMem.Create(nil);
    Result := _instance;
  end;

  procedure Destroy;
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

(* mLoggerMem *)

constructor TmLoggerMem.Create(AOwner : TComponent);
begin
  inherited;

  fLista := TStringList.Create;
end;

destructor TmLoggerMem.Destroy;
begin
  FreeAndNil(fLista);

  inherited;
end;

procedure TmLoggerMem.Add(AMensagem: String);
const
  cMaxLin = 1000;
var
  I : Integer;
begin
  with fLista do begin
    Insert(0, AMensagem);
    if Count > cMaxLin then
      for I := Count - 1 downto cMaxLin do
        Delete(I);
  end;
end;

function TmLoggerMem.GetConteudo: String;
begin
  Result := fLista.Text;
end;

initialization
  //Instance();

finalization
  Destroy();

end.
