package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeInt;
import Model.Type.TypeString;
import Model.Values.*;

import java.io.IOException;

public class FileRead implements IStatement {
    IExpression expression;
    String var_name;

    public FileRead(IExpression expression,String variableName)
    {
        this.expression=expression;
        this.var_name=variableName;
    }
    @Override
    public ProgramState execute(ProgramState state) {

        var v = this.expression.eval(state.getTable(),state.getHeapTable());
        if(!v.getType().equals(new TypeString()))
        {
          throw  new MyException("value is not string");
        }
        if(!state.getTable().exists(var_name))
            throw new MyException("var is not in the symtable");

        var type = state.getTable().search(var_name).getType();
        if(!type.equals(new TypeInt()))
        {
            throw new MyException("variable is not int in symtable");
        }

        var fileTable = state.getFileTable();
        synchronized (fileTable) {
            //        if(!state.getFileTable().exists((stringValue)v))
            //            throw new MyException("var is not in the symtable");

            var buff = state.getFileTable().search((ValueString)v);

            try {
                var line = buff.readLine();

                if (line == null)
                  throw new MyException("we reached EOF ");

                var number =  Integer.parseInt(line);
                state.getTable().addOrUpdate(var_name,new ValueInt(number));
            }
            catch (IOException e)
            {
                throw new MyException("we reached EOF ");
            }

            return null;
        }
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
        if (!expression.typecheck(typeEnv).equals(new TypeString()))
        {
            throw new MyException("type check error in file close");
        }

        if(!typeEnv.search(var_name).equals(new TypeInt()))
        {
            throw new MyException("type check error in file close");
        }
        return typeEnv;

    }

    @Override
    public String toString()
    {
        return "reading " + this.expression.toString();
    }
}
