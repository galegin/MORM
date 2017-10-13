unit mClasse;

interface

uses
  Classes, SysUtils;

type
  TmClasse = class
  public
    class function CreateObjeto(AClass: TClass; AOwner : TComponent) : TObject;
  end;

implementation

type
  TCollectionClass = class of TCollection;

class function TmClasse.CreateObjeto(AClass: TClass; AOwner : TComponent) : TObject;
begin
  if AClass.InheritsFrom(TCollection) then
    Result := TCollectionClass(AClass).Create(nil)
  else if AClass.InheritsFrom(TCollectionItem) then
    Result := TCollectionItemClass(AClass).Create(nil)
  else if AClass.InheritsFrom(TComponent) then
    Result := TComponentClass(AClass).Create(AOwner)
  else
    Result := AClass.NewInstance();
end;

end.