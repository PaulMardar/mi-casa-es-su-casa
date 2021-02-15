package View;

import Controler.Controller;

import java.io.IOException;

public class RunExample extends Command {
    private Controller ctr;

    public RunExample(String key, String desc, Controller ctr) {
        super(key, desc);
        this.ctr = ctr;
    }

    @Override
    public void execute() {
        try {
            ctr.allSteps();
        } catch (IOException e) {
            e.printStackTrace();
            //here you must treat the exceptions that can not be solved in the controller
        }
    }
}
