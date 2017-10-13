unit mLogger;

interface

uses
  Classes, SysUtils, StrUtils;

type
  TTipoLogger = (tpmDebug, tpmErro, tpmInfo, tpmWarning);

  TmLogger = class(TComponent)
  private
    fArquivoTxt : String;
    fArquivoXml : String;
    fTipoLog : Set Of TTipoLogger;
    fInArquivo: Boolean;
    function GetInDebug: Boolean;
    procedure SetInDebug(const Value: Boolean);
    function GetInErro: Boolean;
    procedure SetInErro(const Value: Boolean);
    function GetInInfo: Boolean;
    procedure SetInInfo(const Value: Boolean);
    function GetInWarning: Boolean;
    procedure SetInWarning(const Value: Boolean);
  protected
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;

    function Log(ATipo : TTipoLogger; AMetodo, AMensagem : String) : String;

    procedure Debug(AMetodo, AMensagem : String);
    procedure Erro(AMetodo, AMensagem : String);
    procedure Info(AMetodo, AMensagem : String);
    procedure Warning(AMetodo, AMensagem : String);
  published
    property ArquivoTxt : String read fArquivoTxt write fArquivoTxt;
    property ArquivoXml : String read fArquivoXml write fArquivoXml;
    property InArquivo : Boolean read fInArquivo write fInArquivo;
    property InDebug : Boolean read GetInDebug write SetInDebug;
    property InErro : Boolean read GetInErro write SetInErro;
    property InInfo : Boolean read GetInInfo write SetInInfo;
    property InWarning : Boolean read GetInWarning write SetInWarning;
  end;

  function Instance : TmLogger;
  procedure Destroy;

implementation

uses
  mProjeto, mArquivo, mPath, mLoggerMem;

const
  TTipoLogger_Codigo : Array [TTipoLogger] of string =
    ('Debug', 'Erro', 'Info', 'Warning');

var
  _instance : TmLogger;

  function Instance : TmLogger;
  begin
    if not Assigned(_instance) then
      _instance := TmLogger.Create(nil);
    Result := _instance;
  end;

  procedure Destroy;
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

constructor TmLogger.Create(AOwner : TComponent);
begin
  inherited;

  InArquivo := True;
  InDebug := True;
  InErro := True;
  InInfo := True;
  InWarning := True;

  fArquivoTxt := TmPath.Log() + mProjeto.Instance.Codigo + '.' + FormatDateTime('yyyy.mm.dd', Date) + '.txt';
  fArquivoXml := TmPath.Log() + mProjeto.Instance.Codigo + '.' + FormatDateTime('yyyy.mm.dd', Date) + '.xml';
end;

destructor TmLogger.Destroy;
begin

  inherited;
end;

//--

function TmLogger.Log(ATipo : TTipoLogger; AMetodo, AMensagem : String) : String;
var
  vConteudoTxt, vConteudoXml : String;
begin

  if not (ATipo in fTipoLog) then
    Exit;

  //-- txt

  vConteudoTxt :=
    '[ ' + DateTimeToStr(now) + ' ]' + sLineBreak +
    'Tipo: ' + TTipoLogger_Codigo[ATipo] + sLineBreak +
    'Mensagem: ' + AMensagem + sLineBreak +
    'Metodo: ' + AMetodo + sLineBreak +
    sLineBreak ;

  if InArquivo then
    TmArquivo.Adicionar(fArquivoTxt, vConteudoTxt);

  //-- memoria

  mLoggerMem.Instance.Add(vConteudoTxt);

  //-- xml

  vConteudoXml :=
    '<log>' + sLineBreak +
    '<data_hora>' + DateTimeToStr(now) + '</data_hora>' + sLineBreak +
    '<tipo_mensagem>' + TTipoLogger_Codigo[ATipo] + '</tipo_mensagem>' + sLineBreak +
    '<mensagem>' + AMensagem + '</mensagem>' + sLineBreak +
    '<metodo>' + AMetodo + '</metodo>' + sLineBreak +
    '</log>' + sLineBreak ;

  if InArquivo then
    TmArquivo.Adicionar(fArquivoXml, vConteudoXml);

  //--

  Result := AMensagem + ' / ' + AMetodo;
end;

//--

procedure TmLogger.Debug(AMetodo, AMensagem : String);
begin
  Log(tpmDebug, AMetodo, AMensagem);
end;

procedure TmLogger.Erro(AMetodo, AMensagem : String);
begin
  Log(tpmErro, AMetodo, AMensagem);
end;

procedure TmLogger.Info(AMetodo, AMensagem : String);
begin
  Log(tpmInfo, AMetodo, AMensagem);
end;

procedure TmLogger.Warning(AMetodo, AMensagem : String);
begin
  Log(tpmWarning, AMetodo, AMensagem);
end;

//--

function TmLogger.GetInDebug: Boolean;
begin
  Result := tpmDebug in fTipoLog;
end;

procedure TmLogger.SetInDebug(const Value: Boolean);
begin
  if Value then
    fTipoLog := fTipoLog + [tpmDebug]
  else
    fTipoLog := fTipoLog - [tpmDebug]
end;

//--

function TmLogger.GetInErro: Boolean;
begin
  Result := tpmErro in fTipoLog;
end;

procedure TmLogger.SetInErro(const Value: Boolean);
begin
  if Value then
    fTipoLog := fTipoLog + [tpmErro]
  else
    fTipoLog := fTipoLog - [tpmErro]
end;

//--

function TmLogger.GetInInfo: Boolean;
begin
  Result := tpmInfo in fTipoLog;
end;

procedure TmLogger.SetInInfo(const Value: Boolean);
begin
  if Value then
    fTipoLog := fTipoLog + [tpmInfo]
  else
    fTipoLog := fTipoLog - [tpmInfo]
end;

//--

function TmLogger.GetInWarning: Boolean;
begin
  Result := tpmWarning in fTipoLog;
end;

procedure TmLogger.SetInWarning(const Value: Boolean);
begin
  if Value then
    fTipoLog := fTipoLog + [tpmWarning]
  else
    fTipoLog := fTipoLog - [tpmWarning]
end;

//--

initialization
  //Instance();

finalization
  Destroy();

end.
