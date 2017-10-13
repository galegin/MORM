unit mMapping;

interface

uses
  Classes, SysUtils, StrUtils,
  System.Generics.Collections;

type

  //-- tabela

  TTabela = class(TCustomAttribute)
  private
    fNome : String;
  public
    constructor Create(ANome : String);
    property Nome : String read fNome;
  end;

  //-- campo

  TTipoCampo = (tfKey, tfReq, tfNul);

  TCampo = class(TCustomAttribute)
  private
    fCampo : String;
    fTipo : TTipoCampo;
  public
    constructor Create(ACampo : String; ATipo : TTipoCampo = tfNul);
    property Campo : String read fCampo;
    property Tipo : TTipoCampo read fTipo;
  end;

  //-- relacao

  TRelacao = class(TCustomAttribute)
  private
    fOwner : TObject;
    fCampos : String;
  public
    constructor Create(AOwner : TObject; ACampos : String);
    property Owner : TObject read fOwner;
    property Campos : String read fCampos;
  end;

  TRelacaoCampo = class(TCustomAttribute)
  private
    fAtributo : String;
    fAtributoRel : String;
  public
    constructor Create(AAtributo : String; AAtributoRel : String = '');
    property Atributo : String read fAtributo;
    property AtributoRel : String read fAtributoRel;
  end;

  function GetRelacaoCampos(ACampos : String) : TList<TRelacaoCampo>;

implementation

uses
  mString;

  //--

  function GetRelacaoCampos(ACampos : String) : TList<TRelacaoCampo>;
  var
    vStringArray : TmStringArray;
    vCampo : TRelacaoCampo;
    I : Integer;
  begin
    Result := TList<TRelacaoCampo>.Create;

    vStringArray := TmString.Split(ACampos, ';');
    for I := 0 to High(vStringArray) do begin
      if Pos('=', vStringArray[I]) > 0 then
        vCampo := TRelacaoCampo.Create(TmString.LeftStr(vStringArray[I], '='),
          TmString.RightStr(vStringArray[I], '='))
      else
        vCampo := TRelacaoCampo.Create(vStringArray[I]);
      Result.Add(vCampo);
    end;
  end;

{ TTabela }

constructor TTabela.Create(ANome: String);
begin
  fNome := ANome;
end;

{ TCampo }

constructor TCampo.Create(ACampo: String; ATipo: TTipoCampo);
begin
  fCampo := ACampo;
  fTipo := ATipo;
end;

{ TRelacao }

constructor TRelacao.Create(AOwner : TObject; ACampos: String);
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

end.