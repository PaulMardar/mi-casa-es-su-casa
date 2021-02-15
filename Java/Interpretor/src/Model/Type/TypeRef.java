package Model.Type;

import Model.Values.IValue;
import Model.Values.ValueRef;

public class TypeRef implements IType {

    IType inner;

    public TypeRef(IType inner) {
        this.inner = inner;
    }

    public IType getInner() {
        return inner;
    }

    public boolean equals(Object another) {
        if (another instanceof TypeRef)
            return inner.equals(((TypeRef) another).getInner());
        else
            return false;
    }

    @Override
    public String toString() {
        return "Ref(" + inner.toString() + ")";
    }

    @Override
    public IValue defaultValue() {
        return new ValueRef(0, inner);
    }

}

