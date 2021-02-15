package Model.Statment;
import Model.Exception.*;
import Model.Type.*;
import Model.ADT.*;
import Model.Values.*;
import Model.State.*;
public class DeclarationStmt implements IStatement {

    String variableName;
    IType type;
    public DeclarationStmt( String variableName,
            IType type)
    {
        this.type=type;
        this.variableName=variableName;
    }

    public String toString(){ return this.variableName+ " is a "+this.type.toString();}

    @Override
    public ProgramState execute(ProgramState state)  {
       IDict<String, IValue> SymTable=state.getTable();
       if(SymTable.exists(variableName))
           throw new MyException("variable exists already");
       else
        {
        SymTable.add(variableName, type.defaultValue());
        }
           return null;
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        typeEnv.add(variableName,type);
        return typeEnv;
    }
}
