package Model.Values;

import Model.Type.IType;
import Model.Type.TypeInt;

public class ValueInt implements IValue{
    int intval;
    public ValueInt(int val){this.intval=val;}
    public int getValue(){return this.intval;}
    @Override
    public IType getType() { return new TypeInt(); }
    @Override
    public  String toString(){
        return String.valueOf(intval);
    }
    @Override
    public boolean equals(Object other)
    {   if(other instanceof ValueInt)
        {
        return intval==((ValueInt)other).intval;
        }
        else
            return false;
    }

}

