package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.State.*;
import Model.Type.IType;

public interface IStatement {
    ProgramState execute(ProgramState state);

    public static IStatement concat(IStatement... statements) {
      var statement = statements[statements.length - 1];

      for (int i = statements.length - 2; i >= 0; --i)
        statement = new CompStmt(statements[i], statement);
      statement=new CompStmt(statement,new NopStmt());
      return statement;
    }

    public IDict<String, IType> typecheck(IDict<String,IType> typeEnv);
}
