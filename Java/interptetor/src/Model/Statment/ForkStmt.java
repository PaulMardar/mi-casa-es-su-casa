package Model.Statment;

import Model.ADT.IDict;
import Model.ADT.MyDict;
import Model.State.ProgramState;
import Model.Type.IType;

public class ForkStmt implements IStatement {
  private IStatement statement;

  public ForkStmt(IStatement statement) {
    this.statement = statement;
  }

  @Override
  public String toString() {
    return "fork { " + statement.toString() + " }";
  }

  @Override
  public ProgramState execute(ProgramState state) {
    return state.newThread(statement);
  }

  @Override
  public IDict<String, IType> typecheck(IDict<String, IType> typeEnv) {
      statement.typecheck(typeEnv.duplicate());
      return  typeEnv;
  }
}
