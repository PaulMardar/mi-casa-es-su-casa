package com.company;


import Model.State.ProgramState;
import Model.Values.IValue;
import javafx.application.Application;
import javafx.beans.property.ReadOnlyObjectWrapper;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import Controler.Controller;
import Model.Expressios.*;
import Model.Expressios.Enums.ArithmeticOp;
import Model.Expressios.Enums.RelationOp;
import Model.Statment.*;
import Model.Type.TypeInt;
import Model.Type.TypeRef;
import Model.Type.TypeString;
import Model.Values.ValueInt;
import Model.Values.ValueString;
import Repo.Repo;
import javafx.util.Pair;

import java.util.ArrayList;
import java.util.stream.Collectors;

public class Gui extends Application {

    public Gui() {
    }

    public static void main(String[] args) {
        try {
            launch(args);
        }
        catch (Exception e)
        {
            Alert alert = new Alert(Alert.AlertType.WARNING);
            alert.setTitle(e.getMessage());
            alert.setContentText("Careful with the next step!");
        }
    }

    private Stage ParentStage;

    private  VBox mainVbox;
    public ListView<IStatement> listPrograms;

    private TextField NrProgramStates;
    private TableView<Pair<Integer,IValue>> heapTable;


    private Button RunOneStep;
    private ListView<IValue> outList;
    private ListView<ValueString> fileTable;
    private TableView<Pair<String,IValue>> symbolTable;
    private ListView<IStatement> exeStack;

    private ListView<Integer> programStates;
    private Controller controller;


    static <A, B> TableView<Pair<A, B>> CreateTable(String firstName, String secondName) {
        var table = new TableView<Pair<A, B>>();

        table.setColumnResizePolicy(TableView.CONSTRAINED_RESIZE_POLICY);

        var column1 = new TableColumn<Pair<A, B>, A>(firstName);
        column1.setCellValueFactory(x -> new ReadOnlyObjectWrapper<>(x.getValue().getKey()));

        var column2 = new TableColumn<Pair<A, B>, B>(secondName);
        column2.setCellValueFactory(x -> new ReadOnlyObjectWrapper<>(x.getValue().getValue()));

        table.getColumns().add(column1);
        table.getColumns().add(column2);

        return table;
    }

    void UpdateAll()
    {
        if (controller.isExecutionFinished())
        {
            RunOneStep.setDisable(true);
        }

        NrProgramStates.setText(String.valueOf(controller.getStates().size()));
        if(controller.getStates().size() == 0 )
            return;
        var firstState =  controller.getStates().get(0);
        var heap =firstState.getHeapTable().pairs();
        heapTable.setItems(FXCollections.observableList(heap));

        var output = firstState.getOut().getAll();
        outList.setItems(FXCollections.observableList(output));

        var fileOut = new ArrayList<>(firstState.getFileTable().keySet());
        fileTable.setItems(FXCollections.observableList(fileOut));

        var prgStateIds =controller.getStates().stream().map(ProgramState::getId).collect(Collectors.toList());
        programStates.setItems(FXCollections.observableList(prgStateIds));

        var c = programStates.getSelectionModel().getSelectedItem();
        if( c ==null)
        {
            symbolTable.setItems(FXCollections.emptyObservableList());
            exeStack.setItems(FXCollections.emptyObservableList());
        }
        else
        {
            var a = controller.getStates().stream().filter(x-> x.getId() == c).findFirst().get();
            symbolTable.setItems(FXCollections.observableList(a.getTable().pairs()));
            exeStack.setItems(FXCollections.observableList(a.getExeStack().toList()));
        }
    }

    private void buttonPress()
    {   controller.doOneStepForAllStates();
        UpdateAll();
    }
    public void RunProgram(IStatement selectedItem)
    {
        //            var prg6 = ProgramState.CreateInitial(p6);
//            var repo6 = new Repo(prg6,"log6.txt");
//            Controller ctr6 = new Controller(repo6);
        var programstate = ProgramState.CreateInitial(selectedItem);
        Repo repo = new Repo(programstate, "out.txt");
        controller = new Controller(repo);
        System.out.println(selectedItem);

        NrProgramStates=new TextField();
        NrProgramStates.setText("0");
        programStates= new ListView<>();
        programStates.getSelectionModel().selectedItemProperty().addListener((_a,b,c)->{
            if(c ==null)
            {
                symbolTable.setItems(FXCollections.emptyObservableList());
                exeStack.setItems(FXCollections.emptyObservableList());
            }
            else
            {
                var a = controller.getStates().stream().filter(x-> x.getId() == c).findFirst().get();
                symbolTable.setItems(FXCollections.observableList(a.getTable().pairs()));
                exeStack.setItems(FXCollections.observableList(a.getExeStack().toList()));
            }
        });

        exeStack = new ListView<>();
        RunOneStep = new Button();
        RunOneStep.setText("Run one step");

        RunOneStep.setOnAction(e-> buttonPress());

        heapTable = CreateTable("adress","value");

        outList = new ListView<IValue>();
        fileTable = new ListView<ValueString>();
        symbolTable = CreateTable("variable","value");
        exeStack = new ListView<IStatement>();

        var TopMenuHbox = new HBox(RunOneStep,NrProgramStates);

        var vBox = new VBox(TopMenuHbox,
                new VBox(new Label("Heap Table"), heapTable),
                new HBox(new VBox( new Label("OutList"), outList),
                        new VBox( new Label("file table:"), fileTable),
                        new VBox( new Label("Sym Table"), symbolTable)),
                new VBox(new Label("Program States"), programStates),
                new VBox(new Label("Exe stack"), exeStack )
                );

        UpdateAll();
        var stage = new Stage();

        stage.initOwner(ParentStage);
        stage.setTitle("Main Run window");
        var scene = new Scene(vBox,800,800);

        stage.setScene(scene);
        mainVbox.setDisable(true);
        stage.showAndWait();
        mainVbox.setDisable(false);
    }

    @Override
    public void start(Stage stage) {
        // String javaVersion = System.getProperty("java.version");
        // String javafxVersion = System.getProperty("javafx.version");
        // Label l = new Label("Hello, JavaFX " + javafxVersion + ", running on Java " + javaVersion + ".");

        // Scene scene = new Scene(new StackPane(l), 640, 480);
        // stage.setScene(scene);
        // stage.show();

            var p4 =  new CompStmt(new DeclarationStmt("varf", new TypeString()),
                    new CompStmt(new AssignStmt("varf", new ValueExpression(new ValueString("test.in"))),
                            new CompStmt(new FileOpen(new VaribleExpression("varf")),
                                    new CompStmt(new DeclarationStmt("varc", new TypeInt()),
                                            new CompStmt(new FileRead(new VaribleExpression("varf"), "varc"),
                                                    new CompStmt(new PrintStmt(new VaribleExpression("varc")),
                                                            new CompStmt(new FileRead(new VaribleExpression("varf"), "varc"),
                                                                    new CompStmt(new PrintStmt(new VaribleExpression("varc")),
                                                                            new CompStmt(new FileRead(new VaribleExpression("varf"),"varc"),
                                                                                    new CompStmt(new PrintStmt(new VaribleExpression("varc")),
                                                                                            new FileClose(new VaribleExpression("varf"))))))))))));

//            var prg4 = ProgramState.CreateInitial(p4);
//            var repo4 = new Repo(prg4,"log4.txt");
//            Controller ctr4 = new Controller(repo4);

            var p5 = new CompStmt(new DeclarationStmt("v",new TypeRef(new TypeInt())),
                    new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(20))),
                            new CompStmt( new DeclarationStmt("a", new TypeRef(new TypeRef(new TypeInt()))),
                                    new CompStmt(new newStmt("a", new VaribleExpression("v")),
                                            new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(30))),
                                                    new CompStmt( new PrintStmt(new ReadHeapExpression(new VaribleExpression("v"))), new PrintStmt(new ReadHeapExpression(new ReadHeapExpression(new VaribleExpression("a"))))))))));

//            var prg5 = ProgramState.CreateInitial(p5);
//            var repo5 = new Repo(prg5,"log5.txt");
//            Controller ctr5 = new Controller(repo5);

            var p6 = new CompStmt(new DeclarationStmt("v",new TypeRef(new TypeInt())),
                    new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(20))),
                            new CompStmt( new DeclarationStmt("a", new TypeRef(new TypeRef(new TypeInt()))),
                                    new PrintStmt(new VaribleExpression("v")))));

//            var prg6 = ProgramState.CreateInitial(p6);
//            var repo6 = new Repo(prg6,"log6.txt");
//            Controller ctr6 = new Controller(repo6);

            var p7 = new CompStmt(new DeclarationStmt("v",new TypeInt()),
                    new CompStmt( new AssignStmt("v",new ValueExpression(new ValueInt(5))),
                            new WhileStmt(new RelationExpression(RelationOp.GreaterOrEq, new VaribleExpression("v"),new ValueExpression(new ValueInt(2))),
                                    new CompStmt(new AssignStmt("v",new ArithmeticExpression(ArithmeticOp.SUB,new VaribleExpression("v"),new ValueExpression(new ValueInt(1)))),
                                            new PrintStmt(new VaribleExpression("v"))))));

            // int v; Ref int a; v=10;new(a,22);
            // fork( wH(a,30); v=32; print(v); print(rH(a)) );
            // print(v);print(rH(a))

            var p8 = IStatement.concat(
                    new DeclarationStmt("v", new TypeInt()),
                    new DeclarationStmt("a", new TypeRef(new TypeInt())),
                    new AssignStmt("v", new ValueExpression(new ValueInt(10))),
                    new newStmt("a", new ValueExpression(new ValueInt(22))),
                    new ForkStmt(IStatement.concat(
                            new WriteHeapStmt(new ValueExpression(new ValueInt(30)), "a"),
                            new AssignStmt("v", new ValueExpression(new ValueInt(32))),
                            new PrintStmt(new VaribleExpression("v")),
                            new PrintStmt(new ReadHeapExpression(new VaribleExpression("a")))
                    )),
                    new PrintStmt(new VaribleExpression("v")),
                    new PrintStmt(new ReadHeapExpression(new VaribleExpression("a")))
            );



        stage.setTitle("Program statements");

        ParentStage= stage;

        listPrograms = new ListView<IStatement>();
        ObservableList<IStatement> items = FXCollections.observableArrayList (p4,p5,p6,p7,p8);
        listPrograms.setItems(items);

        var runProgram = new Button();
        runProgram.setText("RUN Program");
        runProgram.setOnAction(e -> {
            var selectedItem = listPrograms.getSelectionModel().getSelectedItem();
            if(selectedItem!= null)
            {
                RunProgram(selectedItem);
            }
        });

        VBox vbox = new VBox(runProgram ,new VBox(new Label("Program list:")), listPrograms);

        mainVbox=vbox;
        listPrograms.setScaleX(1);
        listPrograms.setScaleY(0.95);
        Scene scene = new Scene(vbox, 1000, 800);
        stage.setScene(scene);
        stage.show();
    }
}
