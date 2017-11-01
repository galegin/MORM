unit mModuloUnf;

interface

uses
  Classes, SysUtils;

type
  TmModuloUnf = class(TComponent)
  private
    FCdTerminal: Real;
    FCdUsuario: Real;
    FCdEmpresa: Real;
    FDtSistema: TDateTime;
    procedure SetCdEmpresa(const Value: Real);
    procedure SetCdTerminal(const Value: Real);
    procedure SetCdUsuario(const Value: Real);
    procedure SetDtSistema(const Value: TDateTime);
  protected
  public
    constructor Create(AOwner: TComponent); overload; override;
  published
    property CdEmpresa : Real read FCdEmpresa write SetCdEmpresa;
    property CdTerminal : Real read FCdTerminal write SetCdTerminal;
    property CdUsuario : Real read FCdUsuario write SetCdUsuario;
    property DtSistema : TDateTime read FDtSistema write SetDtSistema;
  end;

  function Instance() : TmModuloUnf;
  procedure Destroy();

implementation

uses
  mIniFiles;

var
  _instance : TmModuloUnf;

  function Instance() : TmModuloUnf;
  begin
    if not Assigned(_instance) then
      _instance := TmModuloUnf.Create(nil);
    Result := _instance;
  end;

  procedure Destroy();
  begin
    if Assigned(_instance) then
      FreeAndNil(_instance);
  end;

{ TmModuloUnf }

constructor TmModuloUnf.Create(AOwner: TComponent);
begin
  inherited;
  CdEmpresa := TmIniFiles.PegarI('', '', 'Cd_Empresa');
  CdUsuario := TmIniFiles.PegarI('', '', 'Cd_Usuario');
  CdTerminal := TmIniFiles.PegarI('', '', 'Cd_Terminal');
  DtSistema := Date;
end;

procedure TmModuloUnf.SetCdEmpresa(const Value: Real);
begin
  FCdEmpresa := Value;
end;

procedure TmModuloUnf.SetCdTerminal(const Value: Real);
begin
  FCdTerminal := Value;
end;

procedure TmModuloUnf.SetCdUsuario(const Value: Real);
begin
  FCdUsuario := Value;
end;

procedure TmModuloUnf.SetDtSistema(const Value: TDateTime);
begin
  FDtSistema := Value;
end;

initialization
  //Instance();

finalization
  Destroy();

end.
