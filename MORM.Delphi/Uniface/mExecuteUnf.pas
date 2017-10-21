unit mExecuteUnf;

interface

uses
  Classes, SysUtils, Math;

  function getObjeto(pClasse: String; pOwner : TComponent; pInherits : TClass = nil) : TObject;

  function execClasse(pClasse, pMetodo, pParams : String) : String;
  function execObjeto(pClasse, pMetodo, pParams : String; pOwner : TComponent = nil) : String; overload;
  function execObjeto(pObject : TObject; pMetodo, pParams : String) : String; overload;

implementation

uses
  mLogger;

type
  TExecuteMethod = function(pParams : String) : String of object;

resourcestring
  ClasseUnInformed = 'Classe deve ser informada';
  ClasseNotFound = 'Classe "%s" nao encontrada';
  ObjectNotCreate = 'Objeto nao instanciado para a classe "%s"';
  ObjectUnInformed = 'Objeto deve ser informado';
  MethodNotFound = 'Metodo "%s" nao encontrado na classe "%s"';

  function getObjeto(pClasse: String; pOwner : TComponent; pInherits : TClass) : TObject;
  const
    cMETHOD = 'mExecuteUnf.getObjeto()';
  var
    vClass : TClass;
  begin
    Result := nil;

    if (pClasse = '') then
      raise Exception.Create(ClasseUnInformed + ' / ' + cMETHOD);

    vClass := GetClass(pClasse);
    if (vClass = nil) then
      raise Exception.Create(Format(ClasseNotFound, [pClasse]) + ' / ' + cMETHOD);

    if (pInherits <> nil) then
      if not (vClass.InheritsFrom(pInherits)) then
        Exit;

    if (vClass.InheritsFrom(TComponent)) then
      Result := TComponentClass(vClass).Create(pOwner)
    else
      Result := vClass.NewInstance();
  end;

// executar metodo estatico da classe
function execClasse(pClasse, pMetodo, pParams : String) : String;
const
  cMETHOD = 'mExecuteUnf.execClasse()';
var
  vClass : TClass;
  vRoutine : TMethod;
  vExecute : TExecuteMethod;
begin
  Result := '';

  if (pClasse = '') then
    raise Exception.Create(ClasseUnInformed + ' / ' + cMETHOD);

  vClass := GetClass(pClasse);
  if (vClass = nil) then
    raise Exception.Create(Format(ClasseNotFound, [pClasse]) + ' / ' + cMETHOD);

  //---------------------------------------------------
  //verifica metodo
  vRoutine.Data := Pointer(vClass);
  vRoutine.Code := vClass.MethodAddress(pMetodo);
  if (vRoutine.Code = nil) then
    raise Exception.Create(Format(MethodNotFound, [pMetodo, pClasse]) + ' / ' + cMETHOD);
  //--

  mLogger.Instance.Debug(pClasse + '.' + pMetodo + '()', 'pParams: ' + pParams);

  //---------------------------------------------------
  //executa metodo
  vExecute := TExecuteMethod(vRoutine);
  Result := vExecute(pParams);
  //--

  mLogger.Instance.Debug(pClasse + '.' + pMetodo + '()', 'Resut: ' + Result);
end;

// criar o objeto e executar o metodo
function execObjeto(pClasse, pMetodo, pParams : String; pOwner : TComponent) : String;
const
  cMETHOD = 'mExecuteUnf.execObjeto()';
var
  vObject : TObject;
begin
  Result := '';

  vObject := getObjeto(pClasse, pOwner);
  if (vObject = nil) then
    raise Exception.Create(Format(ObjectNotCreate, [pClasse]) + ' / ' + cMETHOD);

  try
    Result := execObjeto(vObject, pMetodo, pParams);
  finally
    FreeAndNil(vObject);
  end;
end;

// executar metodo do objeto criado
function execObjeto(pObject : TObject; pMetodo, pParams : String) : String;
const
  cMETHOD = 'mExecuteUnf.execObjeto()';
var
  vRoutine : TMethod;
  vExecute : TExecuteMethod;
begin
  Result := '';

  //---------------------------------------------------
  //verifica object
  if (pObject = nil) then
    raise Exception.Create(ObjectUnInformed + ' / ' + cMETHOD);
  //--

  //---------------------------------------------------
  //verifica metodo
  vRoutine.Data := Pointer(pObject);
  vRoutine.Code := pObject.MethodAddress(pMetodo);
  if (vRoutine.Code = nil) then
    raise Exception.Create(Format(MethodNotFound, [pMetodo, pObject.ClassName]) + ' / ' + cMETHOD);
  //--

  mLogger.Instance.Debug(pObject.ClassName + '.' + pMetodo + '()', 'pParams: ' + pParams);

  //---------------------------------------------------
  //executa metodo
  vExecute := TExecuteMethod(vRoutine);
  Result := vExecute(pParams);
  //--

  mLogger.Instance.Debug(pObject.ClassName + '.' + pMetodo + '()', 'Resut: ' + Result);
end;

end.