package Model.Expressios;

import Model.ADT.*;
import Model.Type.IType;
import Model.Values.*;

public interface IExpression {
    IValue eval(IDict<String, IValue> SymTable, IHeap heap) ;
    IType typecheck(IDict<String,IType> typeEnv);
}
