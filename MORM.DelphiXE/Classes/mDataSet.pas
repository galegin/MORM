unit mDataSet;

interface

uses
  Classes, SysUtils, StrUtils, Math, DB, DBClient, TypInfo,
  mObjeto, mClasse, mString, mValue;

type
  TmDataSet_Notify = record
    AfterPost : TDataSetNotifyEvent;
    BeforePost : TDataSetNotifyEvent;
  end;

  TTipoRetorno = (tprAvg, tprMax, tprMin, tprSum);

  TmDataSet = class(TDataSet)
  private
    fEdit : Boolean;
    function SetEdit(ACampo : String) : Boolean;
    procedure SetPost();
  public
    function GetValues(): TmValueList;
    procedure SetValues(AValues : TmValueList);

    procedure ClearNotify();
    function GetNotify() : TmDataSet_Notify;
    procedure SetNotify(ANotify: TmDataSet_Notify);

    function PegarB(ACampo: String) : Boolean;
    procedure SetarB(ACampo: String; AValue : Boolean);

    function PegarD(ACampo: String) : TDateTime;
    procedure SetarD(ACampo: String; AValue : TDateTime);

    function PegarF(ACampo: String) : Real;
    procedure SetarF(ACampo: String; AValue : Real);

    function PegarI(ACampo: String) : Integer;
    procedure SetarI(ACampo: String; AValue : Integer);

    function PegarS(ACampo: String) : String;
    procedure SetarS(ACampo: String; AValue : String);

    procedure FromObject(AObject : TObject);
    procedure ToObject(AObject : TObject);

    function Calcular(ACampo : String; ATipoRetorno : TTipoRetorno) : Real;

    function Avg(ACampo : String) : Real;
    function Max(ACampo : String) : Real;
    function Min(ACampo : String) : Real;
    function Sum(ACampo : String) : Real;
  end;

implementation

{ TmDataSet }

function TmDataSet.GetValues(): TmValueList;
var
  I : Integer;
  Nome : String;
  TipoField : TTipoField;
begin
  Result := TmValueList.Create;

  TipoField := tfKey;

  for I := 0 to FieldCount - 1 do begin
    with Fields[I] do begin
      Nome := FieldName;

      if LowerCase(FieldName) = 'u_version' then
        TipoField := tfNul;

      case DataType of
        ftBoolean : begin
          Result.AddB(Nome, AsBoolean, TipoField);
        end;
        ftDate, ftDateTime, ftTime, ftTimeStamp : begin
          Result.AddD(Nome, AsDateTime, TipoField);
        end;
        ftFloat, ftBCD, ftFMTBcd: begin
          Result.AddF(Nome, AsFloat, TipoField);
        end;
        ftInteger, ftSmallint, ftWord: begin
          Result.AddI(Nome, AsInteger, TipoField);
        end;
        ftString, ftWideString, ftMemo, ftFmtMemo, ftOraClob: begin
          if TmString.StartsWiths(LowerCase(FieldName), 'in_') then
            Result.AddB(Nome, (AsString = 'T'), TipoField)
          else
            Result.AddS(Nome, AsString, TipoField);
        end;
      end;

    end;
  end;
end;

procedure TmDataSet.SetValues(AValues: TmValueList);
var
  vValue : TmValue;
  vEdit : Boolean;
  I : Integer;
begin
  vEdit := State in [dsInsert, dsEdit];
  if not vEdit then
    Edit;

  for I := 0 to FieldCount - 1 do begin
    with Fields[I] do begin
      vValue := AValues.IndexOf(FieldName);

      if vValue <> nil then begin
        with vValue do begin
          case Tipo of
            tvBoolean:
              AsBoolean := (vValue as TmValueBool).Value;
            tvDateTime:
              AsDateTime := (vValue as TmValueDate).Value;
            tvInteger:
              AsInteger := (vValue as TmValueInt).Value;
            tvFloat:
              AsFloat := (vValue as TmValueFloat).Value;
            tvString:
              AsString := (vValue as TmValueStr).Value;
          end;
        end;
      end;

    end;
  end;

  if not vEdit then
    Post;
end;

//--

procedure TmDataSet.ClearNotify();
begin
  AfterPost := nil;
  BeforePost := nil;
end;

function TmDataSet.GetNotify() : TmDataSet_Notify;
begin
  Result.AfterPost := Self.AfterPost;
  Result.BeforePost := Self.BeforePost;
end;

procedure TmDataSet.SetNotify(ANotify: TmDataSet_Notify);
begin
  AfterPost := ANotify.AfterPost;
  BeforePost := ANotify.BeforePost;
end;

//--

function TmDataSet.SetEdit(ACampo : String) : Boolean;
begin
  Result := (FindField(ACampo) <> nil);
  if not Result then
    Exit;
  fEdit := State in [dsInsert, dsEdit];
  if not fEdit then
    Edit;
end;

procedure TmDataSet.SetPost();
begin
  if not fEdit then
    Post;
end;

//--

function TmDataSet.PegarB(ACampo: String): Boolean;
begin
  if FindField(ACampo) <> nil then
    Result := FieldByName(ACampo).AsBoolean
  else
    Result := False;
end;

procedure TmDataSet.SetarB(ACampo : String; AValue: Boolean);
begin
  if SetEdit(ACampo) then begin
    FieldByName(ACampo).AsBoolean := AValue;
    SetPost();
  end;
end;

//--

function TmDataSet.PegarD(ACampo: String): TDateTime;
begin
  if FindField(ACampo) <> nil then
    Result := FieldByName(ACampo).AsDateTime
  else
    Result := 0;
end;

procedure TmDataSet.SetarD(ACampo : String; AValue: TDateTime);
begin
  if SetEdit(ACampo) then begin
    FieldByName(ACampo).AsDateTime := AValue;
    SetPost();
  end;
end;

//--

function TmDataSet.PegarF(ACampo: String): Real;
begin
  if FindField(ACampo) <> nil then
    Result := FieldByName(ACampo).AsFloat
  else
    Result := 0;
end;

procedure TmDataSet.SetarF(ACampo : String; AValue: Real);
begin
  if SetEdit(ACampo) then begin
    FieldByName(ACampo).AsFloat := AValue;
    SetPost();
  end;
end;

//--

function TmDataSet.PegarI(ACampo: String): Integer;
begin
  if FindField(ACampo) <> nil then
    Result := FieldByName(ACampo).AsInteger
  else
    Result := 0;
end;

procedure TmDataSet.SetarI(ACampo : String; AValue: Integer);
begin
  if SetEdit(ACampo) then begin
    FieldByName(ACampo).AsInteger := AValue;
    SetPost();
  end;
end;

//--

function TmDataSet.PegarS(ACampo: String): String;
begin
  if FindField(ACampo) <> nil then
    Result := FieldByName(ACampo).AsString
  else
    Result := '';
end;

procedure TmDataSet.SetarS(ACampo : String; AValue: String);
begin
  if SetEdit(ACampo) then begin
    FieldByName(ACampo).AsString := AValue;
    SetPost();
  end;
end;

//--

procedure TmDataSet.FromObject(AObject: TObject);
begin
  SetValues(TmObjeto(AObject).GetValues());
end;

procedure TmDataSet.ToObject(AObject: TObject);
var
  vPropInfo : PPropInfo;
  vTipoBase : String;
  I : Integer;
begin
  for I := 0 to FieldCount - 1 do
    with Fields[I] do begin
      vPropInfo := GetPropInfo(AObject, FieldName);
      vTipoBase := LowerCase(vPropInfo^.PropType^.Name);
      case StrToTipoValue(vTipoBase) of
        tvBoolean :
          SetOrdProp(AObject, FieldName, IfThen(AsString = 'T', 1, 0));
        tvDateTime :
          SetFloatProp(AObject, FieldName, AsDateTime);
        tvFloat :
          SetFloatProp(AObject, FieldName, AsFloat);
        tvInteger :
          SetOrdProp(AObject, FieldName, AsInteger);
        tvString :
          SetStrProp(AObject, FieldName, AsString);
      end;
    end;
end;

//--

function TmDataSet.Calcular(ACampo : String; ATipoRetorno : TTipoRetorno) : Real;
var
  vRecNo : Integer;
begin
  Result := 0;

  if FindField(ACampo) = nil then
    Exit;

  vRecNo := RecNo;
  DisableControls;
  First;

  while not EOF do begin

    case ATipoRetorno of
      tprAvg, tprSum : begin
        Result := Result + FieldByName(ACampo).AsFloat;
      end;
      tprMax : begin
        if BOF or (FieldByName(ACampo).AsFloat > Result) then
          Result := FieldByName(ACampo).AsFloat;
      end;
      tprMin : begin
        if BOF or (FieldByName(ACampo).AsFloat < Result) then
          Result := FieldByName(ACampo).AsFloat;
      end;
    end;

    Next;
  end;

  case ATipoRetorno of
    tprAvg : begin
      if RecordCount > 0 then
        Result := Result / RecordCount;
    end;
  end;

  if vRecNo > 0 then
    RecNo := vRecNo;
  EnableControls;
end;

function TmDataSet.Avg(ACampo : String) : Real;
begin
  Result := Calcular(ACampo, tprAvg);
end;

function TmDataSet.Max(ACampo : String) : Real;
begin
  Result := Calcular(ACampo, tprMax);
end;

function TmDataSet.Min(ACampo : String) : Real;
begin
  Result := Calcular(ACampo, tprMin);
end;

function TmDataSet.Sum(ACampo : String) : Real;
begin
  Result := Calcular(ACampo, tprSum);
end;

//--

end.