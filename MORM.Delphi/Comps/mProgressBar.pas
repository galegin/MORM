unit mProgressBar;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls;

type
  TfProgressBar = class(TForm)
    _ProgressBar: TProgressBar;
  private
  public
    procedure MessageInicio(pMensagem : String = ''; pMax : Integer = -1);
    procedure MessagePosiciona(pMensagem : String = ''; pPos : Integer = -1);
    procedure MessageTermino();
  end;

  function Instance() : TfProgressBar;
  procedure Destroy;

implementation

{$R *.dfm}

var
  _instance: TfProgressBar;

  function Instance() : TfProgressBar;
  begin
    if not Assigned(_instance) then
      _instance := TfProgressBar.Create(nil);
    Result := _instance;
  end;

  procedure Destroy;
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

{ TfProgressBar }

procedure TfProgressBar.MessageInicio(pMensagem: String; pMax: Integer);
begin
  if pMensagem <> '' then
    Caption := pMensagem;

  _ProgressBar.Position := 0;

  if pMax <> -1 then
    _ProgressBar.Max := pMax
  else
    _ProgressBar.Max := 100;

  Show();
end;

procedure TfProgressBar.MessagePosiciona(pMensagem: String; pPos: Integer);
begin
  if pMensagem <> '' then
    Caption := pMensagem;

  if pPos <> -1 then
    _ProgressBar.Position := pPos
  else
    _ProgressBar.Position := _ProgressBar.Position + 1;

  Show();
end;

procedure TfProgressBar.MessageTermino;
begin
  Close();
end;

initialization
  //Instance();

finalization
  Destroy();

end.
