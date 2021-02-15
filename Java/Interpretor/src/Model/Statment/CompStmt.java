package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.State.ProgramState;
import Model.Type.IType;

public class CompStmt implements IStatement {

    IStatement statment1;
    IStatement statment2;
    public CompStmt(    IStatement statment1,
            IStatement statment2){
        this.statment1=statment1;
        this.statment2=statment2;
    }

    @Override
    public ProgramState execute(ProgramState state) {
        var stack = state.getExeStack(); // ?? = wtf
        stack.push(statment2);
        stack.push(statment1);
        return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        return statment2.typecheck(statment1.typecheck(typeEnv));
    }

    public String toString() { return  "("+this.statment1.toString() + ";" + this.statment2.toString()+")";}
}
