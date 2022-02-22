package Model.Expressios;

import Model.ADT.IDict;
import Model.ADT.IHeap;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Type.IType;
import Model.Type.TypeRef;
import Model.Values.IValue;
import Model.Values.ValueRef;

public class ReadHeapExpression implements IExpression {
    IExpression expression;

    public ReadHeapExpression(IExpression expression) {
        this.expression = expression;
    }


    @Override
    public IValue eval(IDict<String, IValue> SymTable, IHeap heap) {
        IValue value = expression.eval(SymTable, heap);
        if (!(value instanceof ValueRef))
            throw new MyException("can't read the heap expression");
        var address = ((ValueRef) value).getAddress();

        synchronized (heap) {
            return heap.search(address);
        }
    }

    @Override
    public IType typecheck(IDict<String, IType> typeEnv) {
        IType typ = expression.typecheck(typeEnv);
        if (typ instanceof TypeRef) {
            TypeRef reft = (TypeRef) typ;
            return reft.getInner();
        } else throw new MyException("the rH argument is not a Ref Type");
    }



    @Override
    public String toString() {
        return expression.toString();
    }
}
