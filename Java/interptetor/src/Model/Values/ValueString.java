package Model.Values;

import Model.Type.IType;
import Model.Type.TypeString;
public class ValueString implements  IValue {
    String string;
    public ValueString(String str) {
        this.string=str;
    }
    public String getValue(){return this.string;}
    @Override
    public IType getType() { return new TypeString(); }
    @Override
    public String toString()
    {
        return string;
    }
    @Override
    public int hashCode()
    {
        return this.string.hashCode();
    }

    @Override
    public boolean equals(Object other)
    {   if(other instanceof ValueString)
    {
        return string.equals(((ValueString) other).string);
    }
    else
        return false;
    }
}
