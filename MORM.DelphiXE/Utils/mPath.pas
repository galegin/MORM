unit mPath;

interface

uses
  Classes, SysUtils, Forms; // mPath

type
  TmPath = class
  public
    class function Current(ASub : String = ''): String;
    class function Certificados(): String;
    class function Dados(): String;
    class function DFe(): String;
    class function Log(): String;
    class function Schemas(): String;
    class function Suporte(): String;
    class function Temp(): String;
  end;

implementation

{ TmPath }

class function TmPath.Current(ASub: String): String;
begin
  Result := ExtractFilePath(Application.ExeName);
  if ASub <> '' then begin
    Result := Result + ASub;
    ForceDirectories(Result);
  end;
end;

class function TmPath.Certificados: String;
begin
  Result := Current('Certificados\');
end;

class function TmPath.Dados: String;
begin
  Result := Current('Dados\');
end;

class function TmPath.DFe: String;
begin
  Result := Current('DFe\');
end;

class function TmPath.Log: String;
begin
  Result := Current('Log\');
end;

class function TmPath.Schemas: String;
begin
  Result := Current('Schemas\');
end;

class function TmPath.Suporte: String;
begin
  Result := Current('Suporte\');
end;

class function TmPath.Temp: String;
begin
  Result := Current('Temp\');
end;

end.