unit mList;

interface

uses
  Classes, SysUtils, StrUtils, TypInfo, Math;

type
  TmList = class(TList)
  public
    function Avg(ACampo : String) : Real;
    function Max(ACampo : String) : Real;
    function Min(ACampo : String) : Real;
    function Sum(ACampo : String) : Real;
  end;

implementation

function TmList.Avg(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    Result := Result + GetFloatProp(TObject(Items[I]), ACampo);
  Result := IfThen(Count > 0, Result / Count, 0);
end;

function TmList.Max(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    if (I = 0) or (GetFloatProp(TObject(Items[I]), ACampo) > Result) then
      Result := GetFloatProp(TObject(Items[I]), ACampo);
end;

function TmList.Min(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    if (I = 0) or (GetFloatProp(TObject(Items[I]), ACampo) < Result) then
      Result := GetFloatProp(TObject(Items[I]), ACampo);
end;

function TmList.Sum(ACampo : String) : Real;
var
  I : Integer;
begin
  Result := 0;
  for I := 0 to Count - 1 do
    Result := Result + GetFloatProp(TObject(Items[I]), ACampo);
end;

//--

end.