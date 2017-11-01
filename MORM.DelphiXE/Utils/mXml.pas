unit mXml;

interface

uses
  Classes, SysUtils, StrUtils, Variants;

type
  TmXml = class(TObject)
  public
    function FromObjeto() : String;
    procedure ToObjeto(const AXml : String);

    class procedure putitem(var AXml : String; const ACod : String; AVal : Variant);

    class procedure delitem(const ACod : String; var AXml : String);

    class function itemS(const ACod, AXml : String) : String;

    class function itemB(const ACod, AXml : String) : Boolean;
    class function itemD(const ACod, AXml : String) : TDateTime;
    class function itemF(const ACod, AXml : String) : Real;
    class function itemI(const ACod, AXml : String) : Integer;

    class procedure putitemA(var AXml : String; const ATag, ACod : String; AVal : Variant);

    class function itemAS(const ACod, AXml : String) : String;

    class function itemAB(const ACod, AXml : String) : Boolean;
    class function itemAD(const ACod, AXml : String) : TDateTime;
    class function itemAF(const ACod, AXml : String) : Real;
    class function itemAI(const ACod, AXml : String) : Integer;
  end;

implementation

uses
  mString;

{ TmXml }

function TmXml.FromObjeto(): String;
begin
end;

//--

procedure TmXml.ToObjeto(const AXml: String);
begin
end;

//--

class procedure TmXml.putitem(var AXml: String; const ACod: String; AVal: Variant);
begin
  AXml := AXml +
    '<' + UpperCase(ACod) + '>' + VarToStr(AVal) +
    '</' + UpperCase(ACod) + '>';
end;

//--

class procedure TmXml.delitem(const ACod : String; var AXml : String);
var
  vVal : String;
begin
  vVal :=
    '<' + UpperCase(ACod) + '>' + itemS(ACod, AXml) +
    '</' + UpperCase(ACod) + '>';
  AXml := AnsiReplaceStr(AXml, vVal, '');
end;

//--

class function TmXml.itemS(const ACod, AXml : String): String;
begin
  Result := TmString.RightStr(AXml, '<' + UpperCase(ACod) + '>');
  Result := TmString.LeftStr(Result, '</' + UpperCase(ACod) + '>');
end;

//--

class function TmXml.itemB(const ACod, AXml : String): Boolean;
begin
  Result := Pos(itemS(ACod, AXml), '.1.S.SIM.T.TRUE.') > -1;
end;

class function TmXml.itemD(const ACod, AXml : String): TDateTime;
begin
  Result := StrToDateTimeDef(itemS(AXml, ACod), 0);
end;

class function TmXml.itemF(const ACod, AXml : String): Real;
begin
  Result := StrToFloatDef(itemS(AXml, ACod), 0);
end;

class function TmXml.itemI(const ACod, AXml : String): Integer;
begin
  Result := StrToIntDef(itemS(AXml, ACod), 0);
end;

//--

class procedure TmXml.putitemA(var AXml: String; const ATag, ACod: String; AVal: Variant);
begin
  if AXml = '' then
    AXml := '<' + ATag + ' />';
  AXml := AnsiReplaceStr(AXml, ' />', ' ' + LowerCase(ACod) + '="' + VarToStr(AVal) + '" />');
end;

//--

class function TmXml.itemAS(const ACod, AXml : String): String;
begin
  Result := TmString.RightStr(AXml, ' ' + LowerCase(ACod) + '="');
  Result := TmString.LeftStr(Result, '"');
end;

//--

class function TmXml.itemAB(const ACod, AXml : String): Boolean;
begin
  Result := Pos(itemAS(ACod, AXml), '.1.S.SIM.T.TRUE.') > -1;
end;

class function TmXml.itemAD(const ACod, AXml : String): TDateTime;
begin
  Result := StrToDateTimeDef(itemAS(AXml, ACod), 0);
end;

class function TmXml.itemAF(const ACod, AXml : String): Real;
begin
  Result := StrToFloatDef(itemAS(AXml, ACod), 0);
end;

class function TmXml.itemAI(const ACod, AXml : String): Integer;
begin
  Result := StrToIntDef(itemAS(AXml, ACod), 0);
end;

//--

end.