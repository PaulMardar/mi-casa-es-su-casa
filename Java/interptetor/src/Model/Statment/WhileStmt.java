package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeBool;
import Model.Values.ValueBool;

public class WhileStmt implements IStatement {

    IExpression expression;
    IStatement statment;

    public WhileStmt(IExpression expression,
                     IStatement statment) {
        this.expression = expression;
        this.statment = statment;
    }

    @Override
    public ProgramState execute(ProgramState state) {
        var value = this.expression.eval(state.getTable(), state.getHeapTable());
        if (value instanceof ValueBool) {
            var b = ((ValueBool) value).getValue();
            if (b) {
                state.getExeStack().push(this);
                state.getExeStack().push(statment);
            }
        } else
            throw new MyException("value is not boolean");

        return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        IType typexp = expression.typecheck(typeEnv);
        if (typexp.equals(new TypeBool()))
        {
            statment.typecheck(typeEnv.duplicate());
            return typeEnv;
        }
        else
            throw new MyException("The condition of While has not the type bool");
    }

    public String toString() {
        return "While( " + expression + ") {" + this.statment + "}";
    }
}
