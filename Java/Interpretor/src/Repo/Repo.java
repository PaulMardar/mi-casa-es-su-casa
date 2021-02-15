package Repo;

import Model.ADT.MyDict;
import Model.State.ProgramState;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.stream.Collectors;

public class Repo implements RepoInterface {
  private ExecutorService executor = Executors.newFixedThreadPool(Runtime.getRuntime().availableProcessors());
  private List<ProgramState> states;
  private String logFilePath;
  private PrintWriter logFile;

  public Repo(ProgramState state, String path) {
    this.logFilePath = path;
    this.states = new ArrayList<>();
    this.states.add(state);
  }

  @Override
  public List<ProgramState> getStates() {
    return this.states;
  }

  @Override
  public void setStates(List<ProgramState> states) {
    this.states = states;
  }

  @Override
  public void doOneStepForAllStates() {
    List<Callable<ProgramState>> callables = states.stream().map(ProgramState::doOneStepDelayed)
        .collect(Collectors.toList());

    List<ProgramState> newThreads;

    try {
      newThreads = executor.invokeAll(callables).stream().map(f -> {
        try
        {
          return f.get();
        }
        catch (ExecutionException | InterruptedException e)
        {
          throw new RuntimeException(e);
        }
      })
      .filter(p -> p != null)
      .collect(Collectors.toList());
    } catch (InterruptedException e) {
      throw new RuntimeException(e);
    }

    states.addAll(newThreads);
    states.removeIf(ProgramState::isExecutionFinished);

  }

    @Override
    public boolean isExecutionFinished() {
        return this.states.isEmpty();
    }

    @Override
    public void logAllPrgStates() {
      states.forEach(this::logPrgStateExec);
    }

    @Override
    public void logPrgStateExec(ProgramState state) {
        try {
          this.logFile= new PrintWriter(new BufferedWriter(new FileWriter(logFilePath, true)));
        } catch (IOException e) {
          throw new RuntimeException(e);
        }

        logFile.append("\n");
        logFile.append(state.toString());

        logFile.flush();
        logFile.close();
    }
}
