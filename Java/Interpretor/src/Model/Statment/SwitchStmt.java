package Model.Statment;

import Model.ADT.IDict;
import Model.Exception.MyException;
import Model.Expressios.Enums.RelationOp;
import Model.Expressios.IExpression;
import Model.Expressios.RelationExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeInt;

public class SwitchStmt implements IStatement {

    IExpression expression;
    IExpression expression1;
    IExpression expression2;
    IStatement statement1;
    IStatement statement2;
    IStatement statement3;

    public SwitchStmt(IExpression expression,
                      IExpression expression1,
                      IStatement statement1,
                      IExpression expression2,
                      IStatement statement2,
                      IStatement statement3)
    {
        this.expression = expression;
        this.expression1 = expression1;
        this.expression2 = expression2;
        this.statement1 =statement1;
        this.statement2 =statement2;
        this.statement3=statement3;
    }

    @Override
    public ProgramState execute(ProgramState state) throws MyException {
        var SwitchStmt = new IFStmt(new RelationExpression(RelationOp.Eq,expression,expression1),statement1,
                new IFStmt(new RelationExpression(RelationOp.Eq,expression,expression2),statement2,statement3));
        state.getExeStack().push(SwitchStmt);
        return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        if (!(this.expression.typecheck(typeEnv) instanceof TypeInt))
            throw new MyException("type check switch exception");
        if (!(this.expression1.typecheck(typeEnv) instanceof TypeInt))
            throw new MyException("type check switch exception");
        if (!(this.expression2.typecheck(typeEnv) instanceof TypeInt))
            throw new MyException("type check switch exception");


        this.statement1.typecheck(typeEnv.duplicate());
        this.statement2.typecheck(typeEnv.duplicate());
        this.statement3.typecheck(typeEnv.duplicate());

        return typeEnv;
    }

    public String toString()
    {
        return String.format("switch(%s) (case %s: %s) (case %s: %s) (default: %s)",expression,expression1,statement1,expression2,statement2,statement3);
    }
}
