unit mFloat;

interface

uses
  Classes, SysUtils, StrUtils;

type
  TmFloat = class(TComponent)
  public
    class function Trunced(Value: Real; Casas: Integer): Real;
    class function Rounded(Value: Real; Casas: Integer): Real;
    class function Power(Value, Potencia: Real): Real;
    class function Resto(Value, Divisor: Real; Casas: Integer = 0): Real;
    class function Fraction(Value: Real): Real;
    class function GetNumero(Value: String): Real;
    class function GetValor(Value: String): Real;
  end;

implementation

uses
  mString;

class function TmFloat.Trunced(Value: Real; Casas: Integer): Real;
var
  sValor: String;
  nPos: Integer;
begin
  //Transforma o valor em string
  sValor := FloatToStr(Value);

  //Verifica se possui pondo decimal
  nPos := Pos(DecimalSeparator, sValor);
  if (nPos > 0) then
    sValor := Copy(sValor, 1, nPos+Casas);

  Result := StrToFloat(sValor);
end;

class function TmFloat.Rounded(Value: Real; Casas: Integer): Real;
var
  sValor, sFormat: String;
begin
  //Transforma o valor em string
  sFormat := '0' + IfThen(Casas>0, '.' ,'') + TmString.Replicate('0', Casas);
  sValor := FormatFloat(sFormat,Value);
  Result := StrToFloat(sValor);
end;

class function TmFloat.Power(Value, Potencia: Real): Real;
begin
  Result := Exp(Ln(Value) * Potencia);
end;

class function TmFloat.Resto(Value, Divisor: Real; Casas: Integer = 0): Real;
begin
  Result := Value - (Trunced(Value / Divisor, Round(Casas)) * Divisor);
end;

class function TmFloat.Fraction(Value: Real): Real;
begin
  Result := Frac(Value);
end;

class function TmFloat.GetNumero(Value: String): Real;
var
  vFormat : TFormatSettings;
begin
  vFormat.DecimalSeparator := '.';
  vFormat.ThousandSeparator := ',';

  Result := Trunc(StrToFloatDef(Value, 0, vFormat));
end;

class function TmFloat.GetValor(Value: String): Real;
var
  vFormat : TFormatSettings;
begin
  vFormat.DecimalSeparator := '.';
  vFormat.ThousandSeparator := ',';

  Result := StrToFloatDef(Value, 0, vFormat);
end;

end.