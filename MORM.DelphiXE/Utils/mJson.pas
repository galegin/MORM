unit mJson;

interface

uses
  Classes, SysUtils, StrUtils;

type
  TmJson = class
  public
    class function ObjectToJson(AObject: TObject): String;
    class function JsonToObject(AClass: TClass; AJson: String): TObject;
  end;

implementation

uses
  mString, mClasse, mValue, mObjeto;

{ TmJson }

class function TmJson.ObjectToJson(AObject: TObject): String;
var
  vValues : TmValueList;
  I : Integer;
begin
  Result := '';

  vValues := TmObjeto.GetValues(AObject);

  with vValues do
    for I := 0 to Count - 1 do
      with Items[I] do
        if Items[I] Is TmValueBase then
          Result := Result + IfThen(Result <> '', ',', '') +
            '"' + Nome + '":"' + ValueStr + '"' ;

  if Result <> '' then
    Result := '{' + Result + '}' ;
end;

class function TmJson.JsonToObject(AClass: TClass; AJson: String): TObject;
var
  vStringList : TStringList;
  vValues : TmValueList;
  vValue : TmValue;
  vNome, vValor : String;
  I : Integer;
begin
  vStringList := TStringList.Create;

  if TmString.StartsWiths(AJson, '{') then
    Delete(AJson, 1, 1);
  if TmString.EndWiths(AJson, '}') then
    Delete(AJson, Length(AJson), 1);

  vStringList.Text := AnsiReplaceStr(AJson, '","', '"' + sLineBreak + '"');

  Result := TmClasse.createObjeto(AClass, nil);

  vValues := TmObjeto.GetValues(Result);

  for I := 0 to vStringList.Count - 1 do begin
    vNome := AnsiReplaceStr(TmString.LeftStr(vStringList[I], '":"'), '"', '');
    vValor := AnsiReplaceStr(TmString.RightStr(vStringList[I], '":"'), '"', '');
    vValue := vValues.IndexOf(vNome);
    if Assigned(vValue) then
      vValue.ValueStr := vValor;
  end;

  TmObjeto.SetValues(Result, vValues);
end;

end.
