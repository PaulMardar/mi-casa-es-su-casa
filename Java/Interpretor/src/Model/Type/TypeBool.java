package Model.Type;

import Model.Values.IValue;
import Model.Values.ValueBool;

public class TypeBool implements IType{
    @Override
    public boolean equals(Object otherObject) { return otherObject instanceof TypeBool; }
    public String toString(){return "bool";}

    @Override
    public IValue defaultValue() {
        return new ValueBool(false);
    }
}
