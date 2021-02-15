package Model.Expressios;

import Model.ADT.*;
import Model.Type.IType;
import Model.Values.*;

public class VaribleExpression implements IExpression{

    String id;
    public VaribleExpression(String id){this.id=id;}
    @Override
    public IValue eval(IDict<String, IValue> SymTable, IHeap heap){
        return SymTable.search(id);
    }

    @Override
    public IType typecheck(IDict<String, IType> typeEnv) {
        return typeEnv.search(id);
    }

    @Override
    public String toString(){
        return id;
    }
}
