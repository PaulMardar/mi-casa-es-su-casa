package Model.Statment;

import Model.Exception.MyException;
import Model.State.*;
import Model.Expressios.*;
public interface IStatment {
    ProgramState execute(ProgramState state);
}
