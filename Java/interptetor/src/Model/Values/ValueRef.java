package Model.Values;

import Model.Type.IType;
import Model.Type.TypeInt;
import Model.Type.TypeRef;
import Model.Type.TypeString;

public class ValueRef implements IValue {

    int address;
    IType locationType;

    public ValueRef(int i, IType inner) {
        this.address = i;
        this.locationType = inner;
    }

    public IType getLocationType() {
        return this.locationType;
    }

    public int getAddress() {
        return this.address;
    }

    @Override
    public IType getType() {
        return new TypeRef(locationType);
    }

    public String toString() {
        return "(" + String.valueOf(address) + " , " + locationType + ")";
    }
}
