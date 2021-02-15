package Model.Type;

import Model.Values.IValue;
import Model.Values.ValueString;

public class TypeString implements IType {
    @Override
    public boolean equals(Object otherObject)
    {
        return otherObject instanceof TypeString;
    }
    public String toString(){return "string";}

    @Override
    public IValue defaultValue() {
        return new ValueString("");
    }
}
