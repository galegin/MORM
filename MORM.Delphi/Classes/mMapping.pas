unit mMapping;

interface

uses
  Classes, SysUtils, StrUtils;

type

  //-- tabela

  PmTabela = ^TmTabela;
  TmTabela = record
    Nome : String;
  end;

  //-- campo

  TTipoCampo = (tfKey, tfReq, tfNul);

  PmCampo = ^TmCampo;
  TmCampo = record
    Atributo : String;
    Campo : String;
    Tipo : TTipoCampo;
  end;

  TmCampos = class(TList)
  public
    function Add() : PmCampo; overload;
    procedure Add(AAtributo, ACampo : String; ATipo : TTipoCampo = tfNul); overload;
    function Buscar(AAtributo: String) : PmCampo;
  end;

  //-- relacao

  PmRelacao = ^TmRelacao;
  TmRelacao = record
    Owner : TObject;
    Campos : String;
  end;

  PmRelacaoCampo = ^TmRelacaoCampo;
  TmRelacaoCampo = record
    Atributo : String;
    AtributoRel : String;
  end;

  TmRelacaoCampos = class(TList)
  public
    function Add() : PmRelacaoCampo; overload;
    procedure Add(AAtributo : String; AAtributoRel : String = ''); overload;
    function Buscar(AAtributo : String) : PmRelacaoCampo;
  end;

  //-- mapping

  PmMapping = ^RMapping;
  RMapping = record
    Tabela : PmTabela;
    Campos : TmCampos;
  end;

  procedure FreeMapping(var AMapping : PmMapping);

  function GetRelacaoCampos(ACampos : String) : TmRelacaoCampos;

implementation

uses
  mString;

  //-- campo

  procedure FreeCampos(var ACampos : TmCampos);
  var
    I: Integer;
  begin
    for I := ACampos.Count - 1 downto 0 do begin
      Dispose(PmCampo(ACampos.Items[I]));
      ACampos.Delete(I);
    end;
  end;

  //-- relacao

  procedure FreeRelacaoCampo(var ACampos : TmRelacaoCampos);
  var
    I: Integer;
  begin
    for I := ACampos.Count - 1 downto 0 do begin
      Dispose(PmRelacaoCampo(ACampos.Items[I]));
      ACampos.Delete(I);
    end;
  end;

  //-- mapping

  procedure FreeMapping(var AMapping : PmMapping);
  begin
    if AMapping.Tabela <> nil then
      Dispose(PmTabela(AMapping.Tabela));
    if AMapping.Campos <> nil then
      FreeCampos(AMapping.Campos);
    if AMapping <> nil then
      Dispose(PmMapping(AMapping));
  end;

{ TmCampos }

function TmCampos.Add: PmCampo;
begin
  Result := New(PmCampo);
  Self.Add(Result);
end;

procedure TmCampos.Add(AAtributo, ACampo: String; ATipo: TTipoCampo);
begin
  with Self.Add^ do begin
    Atributo := AAtributo;
    Campo := IfThen(ACampo <> '', ACampo, AAtributo);
    Tipo := ATipo;
  end;
end;

function TmCampos.Buscar(AAtributo: String): PmCampo;
var
  I: Integer;
begin
  Result := nil;
  for I := 0 to Count - 1 do
    with PmCampo(Items[I])^ do
      if Atributo = AAtributo then begin
        Result := PmCampo(Items[I]);
        Exit;
      end;
end;

{ TmRelacaoCampos }

function TmRelacaoCampos.Add: PmRelacaoCampo;
begin
  Result := New(PmRelacaoCampo);
  Self.Add(Result);
end;

procedure TmRelacaoCampos.Add(AAtributo, AAtributoRel: String);
begin
  with Self.Add^ do begin
    Atributo := AAtributo;
    AtributoRel := IfThen(AAtributoRel <> '', AAtributoRel, AAtributo);
  end;
end;

function TmRelacaoCampos.Buscar(AAtributo: String): PmRelacaoCampo;
var
  I: Integer;
begin
  Result := nil;
  for I := 0 to Count - 1 do
    with PmRelacaoCampo(Items[I])^ do
      if Atributo = AAtributo then begin
        Result := PmRelacaoCampo(Items[I]);
        Exit;
      end;
end;

//--

function GetRelacaoCampos(ACampos : String) : TmRelacaoCampos;
var
  vStringArray : TmStringArray;
  vCampo : PmRelacaoCampo;
  I : Integer;
begin
  Result := TmRelacaoCampos.Create;

  vStringArray := TmString.Split(ACampos, ';');
  for I := 0 to High(vStringArray) do begin
    vCampo := Result.Add;
    if Pos('=', vStringArray[I]) > 0 then begin
      vCampo.Atributo := TmString.LeftStr(vStringArray[I], '=');
      vCampo.AtributoRel := TmString.RightStr(vStringArray[I], '=');
    end else begin
      vCampo.Atributo := vStringArray[I];
      vCampo.AtributoRel := vStringArray[I];
    end;
  end;
end;

end.