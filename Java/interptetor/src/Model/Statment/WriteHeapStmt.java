package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeBool;
import Model.Type.TypeRef;
import Model.Values.IValue;
import Model.Values.ValueRef;

public class WriteHeapStmt implements IStatement {

    String varName;
    IExpression expression;


    public WriteHeapStmt(IExpression expression, String varName) {
        this.expression = expression;
        this.varName = varName;
    }

    @Override
    public ProgramState execute(ProgramState state) {
      var heapTable = state.getHeapTable();

      synchronized (heapTable) {
        IValue value = expression.eval(state.getTable(), heapTable);
        var symTable = state.getTable();

        if (!symTable.exists(varName))
            throw new MyException("Var name is not define for heap allocation");

        var variable = symTable.search(varName);
        if (!(variable instanceof ValueRef))
            throw new MyException("variable is not value Ref");

        if (!((ValueRef) variable).getLocationType().equals(value.getType()))
            throw new MyException("type missmatch");

        heapTable.update(((ValueRef) variable).getAddress(), value);
        return null;
      }
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        IType typexp = expression.typecheck(typeEnv);
        typeEnv.search(varName).equals(new TypeRef(typexp));
       return typeEnv;
    }

    @Override
    public String toString() {
        return "Write Heap " + varName + "," + this.expression;
    }
}
