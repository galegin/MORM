unit mVersao;

interface

uses
  Classes, SysUtils, StrUtils, Windows, Forms;

type
  TcVersao = class
  private
    fAno : Integer;
    fMes : Integer;
    fDia : Integer;
    fRel : Integer;
    function GetStr: String;
  public
    constructor Create(AAno, AMes, ADia, ARel : Integer);
  published
    property Ano : Integer read fAno;
    property Mes : Integer read fMes;
    property Dia : Integer read fDia;
    property Rel : Integer read fRel;
    property Str : String read GetStr;
  end;

  TmVersao = class
  public
    class function Codigo(AArquivo : String) : String;
    class function Versao(AArquivo : String) : TcVersao;
  end;

implementation

{ TcVersao }

constructor TcVersao.Create(AAno, AMes, ADia, ARel: Integer);
begin
  fAno := AAno;
  fMes := AMes;
  fDia := ADia;
  fRel := ARel;
end;

function TcVersao.GetStr: String;
begin
  Result :=
    FormatFloat('00', fAno) + '.' +
    FormatFloat('00', fMes) + '.' +
    FormatFloat('00', fDia) + '.' +
    FormatFloat('00', fRel);
end;

{ TmVersao }

class function TmVersao.Codigo(AArquivo: String): String;
begin
  Result := AnsiReplaceStr(ExtractFileName(AArquivo), ExtractFileExt(AArquivo), '');
end;

class function TmVersao.Versao(AArquivo: String): TcVersao;
type
  PFFI = ^vs_FixedFileInfo;
var
  F : PFFI;
  Handle : Dword;
  Len : Longint;
  Data : Pchar;
  Buffer : Pointer;
  Tamanho : Dword;
  Parquivo: Pchar;
begin
  Result := TcVersao.Create(0,0,0,0);

  Parquivo := StrAlloc(Length(AArquivo) + 1);
  StrPcopy(Parquivo, AArquivo);
  Len := GetFileVersionInfoSize(Parquivo, Handle);
  if Len > 0 then begin
    Data := StrAlloc(Len + 1);
    if GetFileVersionInfo(Parquivo, Handle, Len, Data) then begin
      VerQueryValue(Data, '\', Buffer, Tamanho);
      F := PFFI(Buffer);
      Result := TcVersao.Create(
        HiWord(F^.dwFileVersionMs),
        LoWord(F^.dwFileVersionMs),
        HiWord(F^.dwFileVersionLs),
        LoWord(F^.dwFileVersionLs));
    end;
    StrDispose(Data);
  end;

  StrDispose(Parquivo);
end;

end.