unit mDiretorio;

interface

uses
  Classes, SysUtils, StrUtils, Dialogs, Windows; //, FileCtrl;

type
  TrArquivo = record
    Arquivo : String;
    Caminho : String;
  end;

  TrArquivoArray = Array Of TrArquivo;

  TmDiretorio = class
  public
    class function PathWithDelim(const APath : String; ADelim : String = '\') : String;
    class procedure Clear(pDir : String);
    class procedure Create(pDir : String);
    class function Dialog(pDir : String = ''; pOld : Boolean = False) : String;
    class function Listar(pDir : String; pExt : String = ''; pSub : Boolean = False) : TrArquivoArray;
  end;

  procedure ClrListaArquivo(var AList_Arquivo : TrArquivoArray);
  procedure AddListaArquivo(var AList_Arquivo : TrArquivoArray; AArquivo : String; ACaminho : String);

  { function ExtractWindowsDir : String;
  function ExtractSystemDir : String;
  function ExtractTempDir : String; }

implementation

  procedure ClrListaArquivo(var AList_Arquivo : TrArquivoArray);
  begin
    SetLength(AList_Arquivo, 0);
  end;

  procedure AddListaArquivo(var AList_Arquivo : TrArquivoArray; AArquivo : String; ACaminho : String);
  begin
    SetLength(AList_Arquivo, Length(AList_Arquivo) + 1);
    AList_Arquivo[High(AList_Arquivo)].Arquivo := AArquivo;
    AList_Arquivo[High(AList_Arquivo)].Caminho := ACaminho;
  end;

  { function ExtractWindowsDir : String;
  var
    Buffer : Array[0..144] of Char;
  begin
    GetWindowsDirectory(Buffer,144);
    Result := IncludeTrailingBackSlash(StrPas(Buffer));
  end;

  function ExtractSystemDir : String;
  var
    Buffer : Array[0..144] of Char;
  begin
    GetSystemDirectory(Buffer,144);
    Result := IncludeTrailingBackSlash(StrPas(Buffer));
  end;

  function ExtractTempDir : String;
  var
    Buffer : Array[0..144] of Char;
  begin
    GetTempPath(144,Buffer);
    Result := IncludeTrailingBackSlash(StrPas(Buffer));
  end; }

class function TmDiretorio.PathWithDelim(const APath : String; ADelim : String) : String;
begin
  Result := Trim(APath);
  if Result <> '' then
    if RightStr(Result,1) <> ADelim then { Tem delimitador no final ? }
       Result := Result + ADelim;
end;

class procedure TmDiretorio.Clear(pDir : String);
var
  SR : TSearchRec;
  I : Integer;
begin
  I := FindFirst(pDir + '\*.*', faAnyFile, SR);

  while I = 0 do begin
    if (SR.Attr and faDirectory) <> faDirectory then
      DeleteFile(PChar(pDir + '\' + SR.Name));
    I := FindNext(SR);
  end;
end;

class procedure TmDiretorio.Create(pDir : String);
begin
  ForceDirectories(pDir);
end;

//***********************
//** Choose a directory **
//**   uses Messages   **
//***********************
//General usage here:
//  http://www.delphipages.com/forum/showthread.php?p=185734
//Need a class to hold a procedure to be called by Dialog.OnShow:
type
  TOpenDir = class(TObject)
  public
    Dialog: TOpenDialog;
    procedure HideControls(Sender: TObject);
  end;

const
  WM_USER = 100;

  //This procedure hides de combo box of file types...
  procedure TOpenDir.HideControls(Sender: TObject);
  const
    //CDM_HIDECONTROL and CDM_SETCONTROLTEXT values from:
    //  doc.ddart.net/msdn/header/include/commdlg.h.html
    //  CMD_HIDECONTROL = CMD_FIRST + 5 = (WM_USER + 100) + 5;
    //Usage of CDM_HIDECONTROL and CDM_SETCONTROLTEXT here:
    //  msdn.microsoft.com/en-us/library/ms646853%28VS.85%29.aspx
    //  msdn.microsoft.com/en-us/library/ms646855%28VS.85%29.aspx
    CDM_HIDECONTROL = WM_USER + 100 + 5;
    CDM_SETCONTROLTEXT = WM_USER + 100 + 4;
    //Component IDs from:
    //  msdn.microsoft.com/en-us/library/ms646960%28VS.85%29.aspx#_win32_Open_and_Save_As_Dialog_Box_Customization
    //Translation into exadecimal in dlgs.h:
    //  www.koders.com/c/fidCD2C946367FEE401460B8A91A3DB62F7D9CE3244.aspx
    //
    //File type filter...
    cmb1: integer  = $470; //Combo box with list of file type filters
    stc2: integer  = $441; //Label of the file type
    //File name const...
    cmb13: integer = $47c; //Combo box with name of the current file
    edt1: integer  = $480; //Edit with the name of the current file
    stc3: integer  = $442; //Label of the file name combo
  var
    H: THandle;
  begin
    H:= GetParent(Dialog.Handle);
    //Hide file types combo...
    SendMessage(H, CDM_HIDECONTROL, cmb1,  0);
    SendMessage(H, CDM_HIDECONTROL, stc2,  0);
    //Hide file name label, edit and combo...
    SendMessage(H, CDM_HIDECONTROL, cmb13, 0);
    SendMessage(H, CDM_HIDECONTROL, edt1,  0);
    SendMessage(H, CDM_HIDECONTROL, stc3,  0);
    //NOTE: How to change label text (the lentgh is not auto):
    //SendMessage(H, CDM_SETCONTROLTEXT, stc3, DWORD(pChar('Hello!')));
  end;

class function TmDiretorio.Dialog(pDir : String; pOld : Boolean) : String;

  //Call it when you need the user to chose a folder for you...
  function GimmeDir(var Dir: string): boolean;
  var
    OpenDialog : TOpenDialog;
    OpenDir : TOpenDir;
  begin
    //The standard dialog...
    OpenDialog := TOpenDialog.Create(nil);

    //Objetc that holds the OnShow code to hide controls
    OpenDir := TOpenDir.create;
    try
      //Conect both components...
      OpenDir.Dialog := OpenDialog;
      OpenDialog.OnShow := OpenDir.HideControls;

      //Configure it so only folders are shown (and file without extension!)...
      OpenDialog.FileName := '*.';
      OpenDialog.Filter := '*.';
      OpenDialog.Title := 'Chose a folder';
      //No need to check file existis!
      OpenDialog.Options := OpenDialog.Options + [ofNoValidate];
      //Initial folder...
      OpenDialog.InitialDir := Dir;
      //Ask user...
      if OpenDialog.Execute then begin
        Dir := ExtractFilePath(OpenDialog.FileName);
        result := true;
      end else begin
        result := false;
      end;
    finally
      //Clean up...
      OpenDir.Free;
      OpenDialog.Free;
    end;
  end;

begin
  Result := '';

  { if pOld then begin
    if SelectDirectory('Selecionar diretório', '', pDir) then
      Result := PathWithDelim(pDir)
  end else }
    if GimmeDir(pDir) then
      Result := PathWithDelim(pDir)
end;

class function TmDiretorio.Listar(pDir, pExt: String; pSub : Boolean): TrArquivoArray;
var
  SR : TSearchRec;
  R : Integer;
  vExt : String;
begin
  ClrListaArquivo(Result);

  if pDir = '' then
    raise Exception.Create('Diretorio deve ser informado');

  pExt := UpperCase(pExt);  

  R := FindFirst(pDir + '*.*', faAnyFile, SR);

  while R = 0 do begin

    // arquivo
    if ((SR.Attr and faDirectory) <> faDirectory) then begin
      vExt := UpperCase(ExtractFileExt(SR.Name));

      if (pExt = '') or (Pos(vExt, pExt) > 0) then
        AddListaArquivo(Result, SR.Name, pDir + SR.Name);

    // diretorio
    end else begin
      if Pos(SR.Name, '.|..') > 0 then begin
        R := FindNext(SR);
        Continue;
      end;

      if pSub then
        Result := Listar(pDir + SR.Name + '\', pExt, pSub);

    end;

    R := FindNext(SR);

  end;

end;

end.