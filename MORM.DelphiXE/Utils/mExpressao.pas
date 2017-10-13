unit mExpressao;

interface

type
  TmExpressao = class
  public
    class function CalculaExpressao(expressao: string; digitos: Byte = 0): string;
  end;

implementation

// Calculo de expressoes matematicas simples
// Suporta numeros inteiros, numeros reais, parenteses
class function TmExpressao.CalculaExpressao(expressao: string; digitos: Byte): string;
var
  ipos: Integer;
  z: Char;

  function StrToReal(chaine: string): Real;
  var r: Real; Pos: Integer;
  begin
    Val(chaine, r, Pos);
    if Pos > 0 then Val(Copy(chaine, 1, Pos - 1), r, Pos);
    Result := r;
  end;

  function RealToStr(inreal: Extended; digits: Byte): string;
  var s : string;
  begin
    Str(inreal: 0: digits, s);
    realToStr := s;
  end;

  procedure NextChar;
  var s : string;
  begin
    if ipos > Length(expressao) then begin
      z := #9;
      Exit;
    end else begin
      s := Copy(expressao, ipos, 1);
      z := s[1];
      Inc(ipos);
    end;
    if z = ' ' then nextchar;
  end;

  function Expression: Real;
  var w : Real;

    function Factor: Real;
    var ws : string;
    begin
      Nextchar;
      if z in ['0'..'9'] then begin
        ws := '';
        repeat
          ws := ws + z;
          nextchar
        until not (z in ['0'..'9', '.']);
        Factor := StrToReal(ws);
      end else if z = '(' then begin
        Factor := Expression;
        nextchar
      end else if z = '+' then Factor := +Factor
      else if Z = '-' then Factor := -Factor;
    end;

    function Term : Real;
    var W: Real;
    begin
      W := Factor;
      while Z in ['*', '/'] do
        if z = '*' then w := w * Factor
        else w := w / Factor;
      Term := w;
    end;

  begin
    w := term;
    while z in ['+', '-'] do
      if z = '+' then w := w + term
      else w := w - term;
    Expression := w;
  end;

begin
  ipos := 1;
  Result := RealToStr(Expression, digitos);
end;

end.