package View;
import Controler.Controller;
import Model.ADT.IList;
import Model.ADT.MyDict;
import Model.ADT.MyList;
import Model.ADT.MyStack;
import Model.State.ProgramState;
import Model.Statment.IStatment;
import java.io.IOException;

public class UI {
    Controller controller;

    public UI(Controller controller) {
        this.controller = controller;
    }

    public void loadProgram(IStatment program) {
        this.controller.setState(ProgramState.CreateInitial(program));
    }
    public void menu()
    {
        System.out.println("0 Exit");
        System.out.println("1 Execute a program");
    }

    public void printAllStates() throws IOException {
        //System.out.println(this.controller.getState());
        while (!this.controller.isExecutionFinished())
        {  this.controller.allSteps();
           // System.out.println(this.controller.getState());
        }

    }
}
