unit mIniFiles;

interface

uses
  Classes, SysUtils, StrUtils, IniFiles;

type
  TmIniFiles = class
  public
    class function ArqIni(pArq : String) : String;

    class procedure Setar(pArq, pTag, pCod : String; pVal : Variant);

    class function PegarB(pArq, pTag, pCod : String; pDef : Boolean = False) : Boolean;
    class function PegarD(pArq, pTag, pCod : String; pDef : TDateTime = 0) : TDateTime;
    class function PegarF(pArq, pTag, pCod : String; pDef : Real = 0) : Real;
    class function PegarI(pArq, pTag, pCod : String; pDef : Integer = 0) : Integer;
    class function PegarS(pArq, pTag, pCod : String; pDef : String = '') : String;
  end;

implementation

class function TmIniFiles.ArqIni(pArq : String) : String;
begin
  Result := IfThen(pArq <> '', pArq, GetCurrentDir() + '\' + ChangeFileExt(ExtractFileName(ParamStr(0)), '.ini'));
end;

class procedure TmIniFiles.Setar(pArq, pTag, pCod : String; pVal : Variant);
var
  vArqIni: TIniFile;
  vVal : String;
begin
  pArq := ArqIni(pArq);
  pTag := IfThen(pTag <> '', pTag, 'GERAL');
  vVal := pVal;

  vArqIni := TIniFile.Create(pArq);
  try
    vArqIni.WriteString(pTag, pCod, vVal);
  finally
    vArqIni.Free;
  end;
end;

class function TmIniFiles.PegarB(pArq, pTag, pCod : String; pDef : Boolean = False) : Boolean;
var
  vArqIni: TIniFile;
begin
  pArq := ArqIni(pArq);
  pTag := IfThen(pTag <> '', pTag, 'GERAL');

  vArqIni := TIniFile.Create(pArq);
  try
    Result := vArqIni.ReadBool(pTag, pCod, pDef);
  finally
    vArqIni.Free;
  end;
end;

class function TmIniFiles.PegarD(pArq, pTag, pCod : String; pDef : TDateTime = 0) : TDateTime;
var
  vArqIni: TIniFile;
begin
  pArq := ArqIni(pArq);
  pTag := IfThen(pTag <> '', pTag, 'GERAL');

  vArqIni := TIniFile.Create(pArq);
  try
    Result := vArqIni.ReadDateTime(pTag, pCod, pDef);
  finally
    vArqIni.Free;
  end;
end;

class function TmIniFiles.PegarF(pArq, pTag, pCod : String; pDef : Real = 0) : Real;
var
  vArqIni: TIniFile;
begin
  pArq := ArqIni(pArq);
  pTag := IfThen(pTag <> '', pTag, 'GERAL');

  vArqIni := TIniFile.Create(pArq);
  try
    Result := vArqIni.ReadFloat(pTag, pCod, pDef);
  finally
    vArqIni.Free;
  end;
end;

class function TmIniFiles.PegarI(pArq, pTag, pCod : String; pDef : Integer = 0) : Integer;
var
  vArqIni: TIniFile;
begin
  pArq := ArqIni(pArq);
  pTag := IfThen(pTag <> '', pTag, 'GERAL');

  vArqIni := TIniFile.Create(pArq);
  try
    Result := vArqIni.ReadInteger(pTag, pCod, pDef);
  finally
    vArqIni.Free;
  end;
end;

class function TmIniFiles.PegarS(pArq, pTag, pCod, pDef : String) : String;
var
  vArqIni: TIniFile;
begin
  pArq := ArqIni(pArq);
  pTag := IfThen(pTag <> '', pTag, 'GERAL');

  vArqIni := TIniFile.Create(pArq);
  try
    Result := vArqIni.ReadString(pTag, pCod, pDef);
  finally
    vArqIni.Free;
  end;
end;

end.