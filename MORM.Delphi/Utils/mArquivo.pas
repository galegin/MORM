unit mArquivo;

interface

uses
  Classes, SysUtils, Windows;

type
  TmArquivo = class
  public
    class procedure Adicionar(AArquivo, AConteudo : String);
    class procedure Gravar(AArquivo, AConteudo : String);
    class function Ler(AArquivo : String) : String;
    class procedure Excluir(AArquivo : Array Of String);
    class procedure Copiar(AOrigem, ADestino : String);
    class procedure Mover(AOrigem, ADestino : String);
  end;

implementation

{ TmArquivo }

class procedure TmArquivo.Adicionar(AArquivo, AConteudo: String);
var
  vFile : TextFile;
begin
  AssignFile(vFile, AArquivo);

  try
    if FileExists(AArquivo) then
      Append(vFile)
    else
      Rewrite(vFile);

    WriteLn(vFile, AConteudo);
  finally
    CloseFile(vFile)
  end;
end;

class procedure TmArquivo.Excluir(AArquivo: array of String);
var
  I : Integer;
begin
  for I := 0 to High(AArquivo) do
    if FileExists(AArquivo[I]) then
      DeleteFile(PAnsiChar(AArquivo[I]));
end;

class procedure TmArquivo.Gravar(AArquivo, AConteudo: String);
var
  vDir : String;
  vBuffer : Byte;
  vFile : File;
  I : Integer;
begin
  if FileExists(AArquivo) then
    DeleteFile(PChar(AArquivo));

  vDir := ExtractFileDir(AArquivo);
  ForceDirectories(vDir);

  AssignFile(vFile, AArquivo);

  ReWrite(vFile, 1);

  for I:=1 to Length(AConteudo) do begin
    vBuffer := Ord(AConteudo[I]);
    BlockWrite(vFile, vBuffer, 1);
  end;

  CloseFile(vFile);
end;

class function TmArquivo.Ler(AArquivo: String): String;
var
  readcnt : Integer;
  vFile : File;
  vByte : Byte;
begin
  Result := '';

  if not FileExists(AArquivo) then
    Exit;

  AssignFile(vFile, AArquivo);

  FileMode := 0; // modo somente leitura
  Reset(vFile, 1);

  repeat
    BlockRead(vFile, vByte, 1, readcnt);
    if (readcnt <> 0) then Result := Result + Chr(vByte);
  until (readcnt = 0);

  CloseFile(vFile);
end;

class procedure TmArquivo.Copiar(AOrigem, ADestino: String);
begin
  if (AOrigem <> '') and (ADestino <> '') then
    if FileExists(AOrigem) then
      CopyFile(PAnsiChar(AOrigem), PAnsiChar(ADestino), False);
end;

class procedure TmArquivo.Mover(AOrigem, ADestino: String);
begin
  if (AOrigem <> '') and (ADestino <> '') then
    if FileExists(AOrigem) then
      MoveFile(PAnsiChar(AOrigem), PAnsiChar(ADestino));
end;

end.