package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.Exception.MyException;
import Model.Expressios.IExpression;
import Model.State.ProgramState;
import Model.Type.IType;
import Model.Type.TypeString;
import Model.Values.ValueString;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class FileOpen  implements IStatement {
    IExpression expression;

    public FileOpen(IExpression e)
    {
        this.expression= e;
    }

    // pop a statment


    @Override
    public ProgramState execute(ProgramState state) {
        // pop a statment
        var v = this.expression.eval(state.getTable(), state.getHeapTable());
        if(v.getType().toString()=="string")
        {
            var fileName = (ValueString) v;
            var fileTable = state.getFileTable();

            synchronized (fileTable) {
              //var symTable = state.getTable();
              if (fileTable.exists(fileName)) {
                throw new MyException("file already opened");
              }
              else{
                  try{
                      BufferedReader buffat = Files.newBufferedReader(Paths.get(fileName.getValue()));
                      fileTable.addOrUpdate(fileName, buffat);
                  }
                  catch (IOException E)
                  {
                    E.printStackTrace();
                      throw new MyException("Can't open file");
                  }
                  // create file ?
              }
            }
        }
        else throw new MyException("we can't open the file the file name is not string ");


        return null;
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
        return "opening " + this.expression.toString();
    }
}
