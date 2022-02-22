package Model.State;

import Model.ADT.*;
import Model.Statment.*;
import Model.Values.*;

import java.io.BufferedReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.Callable;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.stream.Collectors;

public class ProgramState {
    AtomicInteger nextId;
    int id;
    IStack<IStatement> exeStack;
    IDict<String, IValue> SymTable;
    IList<IValue> out;
    IDict<ValueString, BufferedReader> FileTable;
    IHeap HeapTable;
    public int getId() {return this.id;}
    private ProgramState(
        AtomicInteger nextId,
        int id,
        IDict<String, IValue> SymTable,
        IList<IValue> out,
        IDict<ValueString, BufferedReader> fileTable,
        IHeap heapTable,
        IStatement initialProgram
    ) {



        this.nextId = nextId;
        this.id = id;

        this.exeStack = new MyStack<>();
        this.exeStack.push(initialProgram);

        this.SymTable = SymTable;
        this.out = out;
        this.FileTable = fileTable;
        this.HeapTable = heapTable;
    }

    public int getNextId() {
      return nextId.incrementAndGet();
    }

    public static ProgramState CreateInitial(IStatement statement) {

        statement.typecheck(new MyDict<>());
        return new ProgramState(new AtomicInteger(0), 0, new MyDict<>(), new MyList<>(), new MyDict<>(), new MyHeap(), statement);
    }

    public ProgramState newThread(IStatement statement) {
      return new ProgramState(nextId, getNextId(), SymTable.duplicate(), out, FileTable, HeapTable, statement);
    }

    public IDict<String, IValue> getTable() {
        return this.SymTable;
    }

    public IStack<IStatement> getExeStack() {
        return this.exeStack;
    }

    public IList<IValue> getOut() {
        return this.out;
    }

    public IDict<ValueString, BufferedReader> getFileTable() {
        return this.FileTable;
    }

    public IHeap getHeapTable() {
        return this.HeapTable;
    }

    public ProgramState doOneStep() {
      var stack = getExeStack();
      if (stack.isEmpty())
        return null; //throw new MyException("Evaluation finished.");

      return stack.pop().execute(this);
    }

    public Callable<ProgramState> doOneStepDelayed() {
      return this::doOneStep;
    }

    public boolean isExecutionFinished() {
      return this.getExeStack().isEmpty();
    }

    public String toString() {
        return
                "ID is: " + String.valueOf(this.id) + "\n" +
                "File table is: " + this.FileTable.keySet().toString() + "\n" +
                "Execution stack is " + this.exeStack.toString() + "\n" +
                "Table symbol is: " + this.SymTable.toString() + "\n" +
                "Out list =" + this.out.toString() + "\n" +
                "heap :" + this.HeapTable.toString() + "\n";
    }

    IDict<Integer, IValue> unsafeGarbageCollector(List<Integer> symTableAddr, IDict<Integer, IValue> heap) {
        return MyDict.ofStream(heap.entrySet().stream().filter(e -> symTableAddr.contains(e.getKey())));
    }


}
