package Model.ADT;

import Model.Values.IValue;

public class MyHeap extends MyDict<Integer,IValue> implements IHeap{
    int nextAddress=1;

    @Override
    public int alloc(IValue value) {
        this.add(nextAddress,value);
        return nextAddress++;
    }
}
