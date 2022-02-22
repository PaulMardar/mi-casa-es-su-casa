package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.State.ProgramState;
import Model.Type.IType;

public class NopStmt implements IStatement {
    NopStmt(){}
    @Override
    public ProgramState execute(ProgramState state) throws MyException {
        return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        return typeEnv;
    }

    public String toString(){return "nop";}
}
