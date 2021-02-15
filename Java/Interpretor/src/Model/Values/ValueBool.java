package Model.Values;

import Model.Type.TypeBool;
import Model.Type.IType;

public class ValueBool implements IValue {
    boolean boolVal;
    public ValueBool(boolean value){this.boolVal=value;}
    public boolean getValue(){return this.boolVal;}
    @Override
    public IType getType() { return new TypeBool(); }
    @Override
    public  String toString(){
        return String.valueOf(boolVal);
    }
    @Override
    public boolean equals(Object other)
    {
        if(other instanceof ValueBool)
        {
            return boolVal==((ValueBool)other).boolVal;
        }
        else
            return false;
    }


}
