package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeString;
import Model.Values.*;

import java.io.IOException;

public class FileClose  implements IStatement {
    IExpression expression;

    //if file is already closed throw exception
    public FileClose(IExpression expression)
    {
        this.expression=expression;
    }
    @Override
    public ProgramState execute(ProgramState state) {
        var v = this.expression.eval(state.getTable(), state.getHeapTable());
    if(v.getType().equals(new TypeString()))
    {
        var string= ((ValueString)v);
        var filetable = state.getFileTable();

        synchronized (filetable) {
          if(filetable.exists(string))
          {
              var buffer = filetable.search(string);
              try {
                buffer.close();
              } catch (IOException e) {
                throw new MyException("error closing file");
              }
              filetable.remove(string);
              return null;
          }
          else
              throw new MyException("file is not even opened");
        }
    } else
        throw new MyException("value must be string to close file");
    }

    @Override
    public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {

        if (!expression.typecheck(typeEnv).equals(new TypeString()))
        {
            throw new MyException("type check error in file close");
        }
        else
        {
            return typeEnv;
        }
    }

    @Override
    public String toString()
    {
        return "closing " + this.expression.toString();
    }

}
