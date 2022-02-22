package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeBool;
import Model.Values.*;
import Model.Expressios.*;

public class IFStmt implements IStatement {
    IExpression expression;
    IStatement thenStmt;
    IStatement elseStmt;

    public IFStmt(IExpression expression,
                  IStatement thenStmt,
                  IStatement elseStmt) {
        this.expression = expression;
        this.thenStmt = thenStmt;
        this.elseStmt = elseStmt;
    }

    @Override
    public ProgramState execute(ProgramState state) {
        var v = this.expression.eval(state.getTable(), state.getHeapTable());
        if (v instanceof ValueBool) {
            var b = ((ValueBool) v).getValue();
            if (b) {
                state.getExeStack().push(thenStmt);
            } else {
                state.getExeStack().push(elseStmt);
            }
        } else throw new MyException("expresion must be bool");
        return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        IType typexp = expression.typecheck(typeEnv);
        if (typexp.equals(new TypeBool())) {
            thenStmt.typecheck((MyDict<String, IType>) typeEnv.duplicate());
            elseStmt.typecheck(typeEnv.duplicate());
            return typeEnv;
        } else throw new MyException("The condition of IF has not the type bool");
    }

    public String toString() {
        return "IF(" + this.expression.toString() + ") Then (" + this.thenStmt.toString() + ")Else(" + this.elseStmt.toString() + " )";
    }
}
