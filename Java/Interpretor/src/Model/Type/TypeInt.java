package Model.Type;

import Model.Values.IValue;
import Model.Values.ValueInt;

public class TypeInt implements IType{
    @Override
    public boolean equals(Object otherObject)
    {
        return otherObject instanceof TypeInt;
    }
    public String toString(){return "int";}

    @Override
    public IValue defaultValue() {
        return new ValueInt(0);
    }
}
