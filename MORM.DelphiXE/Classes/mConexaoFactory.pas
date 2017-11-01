unit mConexaoFactory;

(* mConexaoFactory *)

interface

uses
  Classes, SysUtils, StrUtils, DB,
  mTipoDatabase, mConexaoIntf, mParametro;

type
  TmConexaoFactory = class
  private
  protected
  public
    class function CreateDbConnection(pParametro : TmParametro) : IConexao;
  end;

implementation

uses
  mConexaoA,
  mConexaoB,
  mConexaoX,
  mConexaoZ;

(* mConexaoFactory *)

class function TmConexaoFactory.CreateDbConnection(pParametro: TmParametro): IConexao;
begin
  case pParametro.TipoDatabase of
    tdMsAccess, tdSqlServer:
      Result := TmConexaoA.Create(pParametro);
    tdDBase, tdParadox:
      Result := TmConexaoB.Create(pParametro);
    tdFirebird, tdOracle:
      Result := TmConexaoX.Create(pParametro);
    tdMySql:
      Result := TmConexaoZ.Create(pParametro);
  else
    Result := nil;
  end;
end;

end.
