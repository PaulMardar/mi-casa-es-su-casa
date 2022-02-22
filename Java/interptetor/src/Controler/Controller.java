package Controler;

import Model.ADT.*;
import Model.State.ProgramState;
import Model.Values.IValue;
import Model.Values.ValueRef;
import Repo.RepoInterface;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;


public class Controller {
    RepoInterface currentRepo;

    public Controller(){this.currentRepo=null;}

    public Controller(RepoInterface repo) {
        this.currentRepo = repo;
    }

    public List<ProgramState> getStates() {
        return this.currentRepo.getStates();
    }

    public void setStates(List<ProgramState> states) {
        this.currentRepo.setStates(states);
    }

    public void doOneStepForAllStates() { // use prg
        this.currentRepo.doOneStepForAllStates();
    }

    public void allSteps() throws IOException {
      var initialState = this.currentRepo.getStates().get(0);

      while (!this.currentRepo.isExecutionFinished()) {
        this.currentRepo.logAllPrgStates();
        this.currentRepo.doOneStepForAllStates();
        runGC(getStates());
      }

      this.currentRepo.logPrgStateExec(initialState);
    }

    public boolean isExecutionFinished() {
        return this.currentRepo.isExecutionFinished();
    }


    private static List<Integer> getAddrFromSymTables(List<ProgramState> states) {
        return states
                .stream()
                .flatMap(state -> state.getTable().entrySet().stream())
                .map(Map.Entry::getValue)
                .filter(v -> v instanceof ValueRef)
                .map(v -> ((ValueRef) v).getAddress())
                .collect(Collectors.toList());
    }

    private static Map<Integer, IValue> garbageCollect(IHeap heap, List<ProgramState> states)
    {
        var address = new ArrayList<Integer>();
        var symTabbleAddress = getAddrFromSymTables(states);

        for (var v : symTabbleAddress) {
            if (address.contains(v))
                continue;

            address.add(v);
            if(!heap.exists(v))
                continue;
            var val = heap.search(v);
            while (val instanceof ValueRef) {
                var addr = ((ValueRef) val).getAddress();
                if (!address.contains(addr))
                    address.add(addr);
                val = heap.search(addr);
            }
        }

        return heap
                .entrySet()
                .stream()
                .filter(e -> address.contains(e.getKey()))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    public static void runGC(List<ProgramState> states) {
        if (states.isEmpty())
            return;

        var heap = states.get(0).getHeapTable();
        heap.setContent(garbageCollect(heap, states));
    }
}
