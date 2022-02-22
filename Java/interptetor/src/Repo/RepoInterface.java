package Repo;

import Model.State.ProgramState;

import java.io.IOException;
import java.util.List;

public interface RepoInterface {
    List<ProgramState> getStates();
    void setStates(List<ProgramState> state);
    void doOneStepForAllStates();
    boolean isExecutionFinished();
    void logPrgStateExec(ProgramState state);
    void logAllPrgStates();
}
