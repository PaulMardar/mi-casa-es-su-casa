package Model.ADT;


import Model.Values.IValue;

import java.util.HashMap;

// leave for now
public interface IHeap extends IDict<Integer,IValue>{

    public int alloc(IValue value );

}
