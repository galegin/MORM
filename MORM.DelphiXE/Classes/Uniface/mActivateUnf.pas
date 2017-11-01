unit mActivateUnf;

interface

uses
  Classes, SysUtils, StrUtils;

  function activateCmp(pComponente, pMetodo, pParams : String) : String; overload;
  function activateCmp(pComponente, pMetodo : String; pCdEmpresa : Real; pParams : String) : String; overload;

implementation

uses
  mExecuteUnf, mComponenteUnf, mXml;

function activateCmp(pComponente, pMetodo, pParams : String) : String;
const
  cDS_METHOD = 'TmActivateUnf.activateCmp()';
var
  vObject : TObject;
begin
  try
    vObject := mComponenteUnf.Instance.GetComponenteUnf(pComponente);
    if Assigned(vObject) then
      Result := mExecuteUnf.execObjeto(vObject, pMetodo, pParams)
    else
      Result := '';
  finally
    mComponenteUnf.Instance.RemComponenteUnf(pComponente);
  end;
end;

function activateCmp(pComponente, pMetodo : String; pCdEmpresa : Real; pParams : String) : String;
var
  vParams : String;
begin
  vParams := '';
  TmXml.putitem(vParams, 'CD_EMPRESA', pCdEmpresa);
  TmXml.putitem(vParams, 'LST_PARAMETRO', pParams);
  Result := activateCmp(pComponente, pMetodo, vParams);
end;

end.