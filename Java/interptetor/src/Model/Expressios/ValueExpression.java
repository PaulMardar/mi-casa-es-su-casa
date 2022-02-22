package Model.Expressios;

import Model.ADT.*;
import Model.Type.IType;
import Model.Values.*;

public class ValueExpression implements IExpression {
    IValue value;
    public ValueExpression(IValue value){this.value=value;}
    @Override
    public IValue eval(IDict<String, IValue> SymTable, IHeap heap)  {
        return this.value;
    }

    @Override
    public IType typecheck(IDict<String, IType> typeEnv) {
        return value.getType();
    }

    @Override
    public String toString(){
        return value.toString();
    }

}
