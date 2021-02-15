package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.IList;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Values.IValue;

public class PrintStmt implements IStatement {
    IExpression expression;

    public PrintStmt(IExpression expression){
        this.expression=expression;
    }
    public String toString(){

        return "print "+this.expression.toString();
    }
    @Override
    public ProgramState execute(ProgramState state) throws MyException {
        IList<IValue> output = state.getOut();

        synchronized (output) {
          output.insert(this.expression.eval(state.getTable(), state.getHeapTable()));
          return null;
        }
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        expression.typecheck(typeEnv);
        return typeEnv;
    }
}
