unit mMapping;

interface

uses
  Classes, SysUtils, StrUtils;

type

  //-- tabela

  TTabela = class
  private
    fNome : String;
  public
    constructor Create(ANome : String);
    property Nome : String read fNome;
  end;

  //-- campo

  TTipoCampo = (tfKey, tfReq, tfNul);

  TCampo = class
  private
    fAtributo : String;
    fCampo : String;
    fTipo : TTipoCampo;
  public
    constructor Create(AAtributo : String; ACampo : String = ''; ATipo : TTipoCampo = tfNul);
    property Atributo : String read fAtributo;
    property Campo : String read fCampo;
    property Tipo : TTipoCampo read fTipo;
  end;

  TCampos = class(TList)
  public
    procedure Add(AAtributo, ACampo : String; ATipo : TTipoCampo = tfNul); overload;
    function Buscar(AAtributo: String) : TCampo;
  end;

  //-- relacao

  TRelacao = class
  private
    fOwner : TObject;
    fCampos : String;
  public
    constructor Create(AOwner : TObject; ACampos : String);
    property Owner : TObject read fOwner;
    property Campos : String read fCampos;
  end;

  TRelacaoCampo = class
  private
    fAtributo : String;
    fAtributoRel : String;
  public
    constructor Create(AAtributo : String; AAtributoRel : String = '');
    property Atributo : String read fAtributo;
    property AtributoRel : String read fAtributoRel;
  end;

  TRelacaoCampos = class(TList)
  public
    procedure Add(AAtributo : String; AAtributoRel : String = ''); overload;
    function Buscar(AAtributo : String) : TRelacaoCampo;
  end;

  function GetRelacaoCampos(ACampos : String) : TRelacaoCampos;

implementation

uses
  mString;

  function GetRelacaoCampos(ACampos : String) : TRelacaoCampos;
  var
    vStringArray : TmStringArray;
    I : Integer;
  begin
    Result := TRelacaoCampos.Create;

    vStringArray := TmString.Split(ACampos, ';');
    for I := 0 to High(vStringArray) do
      if Pos('=', vStringArray[I]) > 0 then
        Result.Add(TmString.LeftStr(vStringArray[I], '='),
          TmString.RightStr(vStringArray[I], '='))
      else
        Result.Add(vStringArray[I]);
  end;

{ TTabela }

constructor TTabela.Create(ANome: String);
begin
  fNome := ANome;
end;

{ TCampo }

constructor TCampo.Create(AAtributo, ACampo: String; ATipo: TTipoCampo);
begin
  fAtributo := AAtributo;
  fCampo := IfThen(ACampo <> '', ACampo, AAtributo);
  fTipo := ATipo;
end;

{ TCampos }

procedure TCampos.Add(AAtributo, ACampo: String; ATipo: TTipoCampo);
begin
  Self.Add(TCampo.Create(AAtributo, ACampo, ATipo));
end;

function TCampos.Buscar(AAtributo: String): TCampo;
var
  I: Integer;
begin
  Result := nil;
  for I := 0 to Count - 1 do
    with TCampo(Items[I]) do
      if Atributo = AAtributo then begin
        Result := TCampo(Items[I]);
        Exit;
      end;
end;

{ TRelacao }

constructor TRelacao.Create(AOwner: TObject; ACampos: String);
begin
  fOwner := AOwner;
  fCampos := ACampos;
end;

{ TRelacaoCampo }

constructor TRelacaoCampo.Create(AAtributo, AAtributoRel: String);
begin
  fAtributo := AAtributo;
  fAtributoRel := IfThen(AAtributoRel <> '', AAtributoRel, AAtributo);
end;

{ TRelacaoCampos }

procedure TRelacaoCampos.Add(AAtributo, AAtributoRel: String);
begin
  Self.Add(TRelacaoCampo.Create(AAtributo, AAtributoRel));
end;

function TRelacaoCampos.Buscar(AAtributo: String): TRelacaoCampo;
var
  I: Integer;
begin
  Result := nil;
  for I := 0 to Count - 1 do
    with TRelacaoCampo(Items[I]) do
      if Atributo = AAtributo then begin
        Result := TRelacaoCampo(Items[I]);
        Exit;
      end;
end;

end.