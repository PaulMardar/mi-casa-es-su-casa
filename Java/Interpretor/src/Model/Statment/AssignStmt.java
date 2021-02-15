package Model.Statment;

import Model.ADT.IDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;

public class AssignStmt implements IStatement {

    IExpression expression;
    String id;

    public AssignStmt(String id, IExpression expression) {
        this.expression = expression;
        this.id = id;
    }

    @Override
    public ProgramState execute(ProgramState state) {
        var v = this.expression.eval(state.getTable(), state.getHeapTable());
        //if(!state.getTable().exists(id) || !state.getTable().search(id).getType().equals(v.getType()))
        //  throw new MyException("bad assigment statment");
        state.getTable().addOrUpdate(id, v);
        return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        IType typevar = typeEnv.search(id);
        IType typexp = expression.typecheck(typeEnv);
        if (typevar.equals(typexp))
            return typeEnv;
        else
            throw new MyException("Assignment: right hand side and left hand side have different types ");
    }

    public String toString() {
        return this.id + " = " + this.expression.toString();
    }
}
