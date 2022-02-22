package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeRef;
import Model.Values.IValue;
import Model.Values.ValueRef;

public class newStmt implements IStatement {

    String varName;
    IExpression expression;

    public newStmt(String varName, IExpression expression) {
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
                throw new MyException("Var name is not define for heap allocation " + varName);

            var variable = symTable.search(varName);
            if (!(variable instanceof ValueRef))
                throw new MyException("variable is not value Ref");

            if (!((ValueRef) variable).getLocationType().equals(value.getType()))
                throw new MyException("type mismatch");

            var address = heapTable.alloc(value);
            var newRef = new ValueRef(address, value.getType());
            symTable.update(varName, newRef);
            return null;
        }
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        IType typevar = typeEnv.search(varName);
        IType typexp = expression.typecheck(typeEnv);
        if (typevar.equals(new TypeRef(typexp)))
            return typeEnv;
        else throw new MyException("NEW stmt: right hand side and left hand side have different types ");
    }

    @Override
    public String toString() {
        return "New Heap allocation " + varName + "," + this.expression;
    }
}
