package com.company;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;


public class Main extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{
    }

    public static void main(String[] args) {
        var Gui = new Gui();
        Gui.main(args);
    }
}

/*
IStatment p1 = new CompStmt(new DeclarationStmt("v",new TypeInt()),new CompStmt(new AssignStmt("v", new ValueExpression(new ValueInt(2))),new PrintStmt(new VaribleExpression("v"))));
        IStatment p2 = new CompStmt(new AssignStmt("a", new ArithmeticExpression(ArithmeticOp.ADD,new ValueExpression(new ValueInt(2)),new ArithmeticExpression(ArithmeticOp.MUL,new ValueExpression(new ValueInt(3)),new ValueExpression(new ValueInt(5))))),
                new CompStmt(new AssignStmt("b",new ArithmeticExpression(ArithmeticOp.ADD,new VaribleExpression("a"),new ValueExpression(new ValueInt(1)))),new PrintStmt(new VaribleExpression("b"))));
        IStatment p3 = new CompStmt(new DeclarationStmt("a",new TypeBool()),
                new CompStmt(new DeclarationStmt("v",new TypeInt()),
                        new CompStmt(new AssignStmt("a",new ValueExpression(new ValueBool(true))),
                        new CompStmt(new IFStmt(new VaribleExpression("a"),new AssignStmt("v",new ValueExpression(new ValueInt(2))),new AssignStmt("v",new ValueExpression(new ValueInt(3)))), new PrintStmt(new VaribleExpression("v")))
                                )));

        //var path = console.nextLine();


        //var repo1 = new Repo(new ProgramState( new MyStack<>(), new MyDict<>(),new MyList<>(),p1),path);


        var prg1 =  ProgramState.CreateInitial(p1);
        var repo1 = new Repo(prg1,"log1.txt");
        Controller ctr1 = new Controller(repo1);


        var prg2 = ProgramState.CreateInitial(p2);
        var repo2 = new Repo(prg2,"log2.txt");
        Controller ctr2 = new Controller(repo2);

        var prg3 = ProgramState.CreateInitial(p3);
        var repo3 = new Repo(prg3,"log3.txt");
        Controller ctr3 = new Controller(repo3);


        var p4 =  new CompStmt(new DeclarationStmt("varf", new TypeString()),
                new CompStmt(new AssignStmt("varf", new ValueExpression(new ValueString("test.in"))),
                new CompStmt(new FileOpen(new VaribleExpression("varf")),
                        new CompStmt(new DeclarationStmt("varc", new TypeInt()),
                                new CompStmt(new FileRead(new VaribleExpression("varf"), "varc"),
                                        new CompStmt(new PrintStmt(new VaribleExpression("varc")),
                                                new CompStmt(new FileRead(new VaribleExpression("varf"), "varc"),
                                                        new CompStmt(new PrintStmt(new VaribleExpression("varc")),
                                                                new FileRead(new VaribleExpression("varf"),"varc")))))))));
        var prg4 = ProgramState.CreateInitial(p4);
        var repo4 = new Repo(prg4,"log4.txt");
        Controller ctr4 = new Controller(repo4);

        var p5 = new CompStmt(new DeclarationStmt("a",new TypeRef(new TypeInt())),
                new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(20))),
                new CompStmt( new DeclarationStmt("a", new TypeRef(new TypeRef(new TypeInt()))),
                new CompStmt( new WriteHeapStmt(new ValueExpression(new ValueInt(30)),"v"),
                new CompStmt( new PrintStmt(new ReadHeapExpression(new VaribleExpression("v"))), new PrintStmt(new VaribleExpression("a")))))));
        var prg5 = ProgramState.CreateInitial(p5);
        var repo5 = new Repo(prg5,"log5.txt");
        Controller ctr5 = new Controller(repo5);



        TextMenu menu = new TextMenu();
        menu.addCommand(new ExitCommand("0", "exit"));
        menu.addCommand(new RunExample("1",p1.toString(),ctr1));
        menu.addCommand(new RunExample("2",p2.toString(),ctr2));
        menu.addCommand(new RunExample("3",p3.toString(),ctr3));
        menu.addCommand(new RunExample("4",p4.toString(),ctr4));
        menu.addCommand(new RunExample("5",p5.toString(),ctr5));
        menu.show();



            IStatment p1 = new CompStmt(new DeclarationStmt("v",new TypeInt()),new CompStmt(new AssignStmt("v", new ValueExpression(new ValueInt(2))),new PrintStmt(new VaribleExpression("v"))));
        IStatment p2 = new CompStmt(new AssignStmt("a", new ArithmeticExpression(ArithmeticOp.ADD,new ValueExpression(new ValueInt(2)),new ArithmeticExpression(ArithmeticOp.MUL,new ValueExpression(new ValueInt(3)),new ValueExpression(new ValueInt(5))))),
                new CompStmt(new AssignStmt("b",new ArithmeticExpression(ArithmeticOp.ADD,new VaribleExpression("a"),new ValueExpression(new ValueInt(1)))),new PrintStmt(new VaribleExpression("b"))));
        IStatment p3 = new CompStmt(new DeclarationStmt("a",new TypeBool()),
                new CompStmt(new DeclarationStmt("v",new TypeInt()),
                        new CompStmt(new AssignStmt("a",new ValueExpression(new ValueBool(true))),
                        new CompStmt(new IFStmt(new VaribleExpression("a"),new AssignStmt("v",new ValueExpression(new ValueInt(2))),new AssignStmt("v",new ValueExpression(new ValueInt(3)))), new PrintStmt(new VaribleExpression("v")))
                                )));

        //var path = console.nextLine();


        //var repo1 = new Repo(new ProgramState( new MyStack<>(), new MyDict<>(),new MyList<>(),p1),path);


        var prg1 =  ProgramState.CreateInitial(p1);
        var repo1 = new Repo(prg1,"log1.txt");
        Controller ctr1 = new Controller(repo1);


        var prg2 = ProgramState.CreateInitial(p2);
        var repo2 = new Repo(prg2,"log2.txt");
        Controller ctr2 = new Controller(repo2);

        var prg3 = ProgramState.CreateInitial(p3);
        var repo3 = new Repo(prg3,"log3.txt");
        Controller ctr3 = new Controller(repo3);


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

        var prg4 = ProgramState.CreateInitial(p4);
        var repo4 = new Repo(prg4,"log4.txt");
        Controller ctr4 = new Controller(repo4);

        var p5 = new CompStmt(new DeclarationStmt("v",new TypeRef(new TypeInt())),
                new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(20))),
                new CompStmt( new DeclarationStmt("a", new TypeRef(new TypeRef(new TypeInt()))),
                new CompStmt(new newStmt("a", new VaribleExpression("v")),
                new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(30))),
                new CompStmt( new PrintStmt(new ReadHeapExpression(new VaribleExpression("v"))), new PrintStmt(new ReadHeapExpression(new ReadHeapExpression(new VaribleExpression("a"))))))))));

        var prg5 = ProgramState.CreateInitial(p5);
        var repo5 = new Repo(prg5,"log5.txt");
        Controller ctr5 = new Controller(repo5);

        var p6 = new CompStmt(new DeclarationStmt("v",new TypeRef(new TypeInt())),
                new CompStmt( new newStmt("v",new ValueExpression(new ValueInt(20))),
                new CompStmt( new DeclarationStmt("a", new TypeRef(new TypeRef(new TypeInt()))),
                new PrintStmt(new VaribleExpression("v")))));

        var prg6 = ProgramState.CreateInitial(p6);
        var repo6 = new Repo(prg6,"log6.txt");
        Controller ctr6 = new Controller(repo6);

        var p7 = new CompStmt(new DeclarationStmt("v",new TypeInt()),
                new CompStmt( new AssignStmt("v",new ValueExpression(new ValueInt(5))),
                new WhileStmt(new RelationExpression(RelationOp.GreaterOrEq, new VaribleExpression("v"),new ValueExpression(new ValueInt(2))),
                  new CompStmt(new AssignStmt("v",new ArithmeticExpression(ArithmeticOp.SUB,new VaribleExpression("v"),new ValueExpression(new ValueInt(1)))),
                  new PrintStmt(new VaribleExpression("v"))))));

        var prg7 = ProgramState.CreateInitial(p7);
        var repo7 = new Repo(prg7,"log7.txt");
        Controller ctr7 = new Controller(repo7);

        // int v; Ref int a; v=10;new(a,22);
        // fork( wH(a,30); v=32; print(v); print(rH(a)) );
        // print(v);print(rH(a))

        var p8 = IStatment.concat(
          new DeclarationStmt("v", new TypeInt()),
          new DeclarationStmt("a", new TypeRef(new TypeInt())),
          new AssignStmt("v", new ValueExpression(new ValueInt(10))),
          new newStmt("a", new ValueExpression(new ValueInt(22))),
          new ForkStmt(IStatment.concat(
            new WriteHeapStmt(new ValueExpression(new ValueInt(30)), "a"),
            new AssignStmt("v", new ValueExpression(new ValueInt(32))),
            new PrintStmt(new VaribleExpression("v")),
            new PrintStmt(new ReadHeapExpression(new VaribleExpression("a")))
          )),
          new PrintStmt(new VaribleExpression("v")),
          new PrintStmt(new ReadHeapExpression(new VaribleExpression("a")))
        );

        var prg8 = ProgramState.CreateInitial(p8);
        var repo8 = new Repo(prg8,"log8.txt");
        Controller ctr8 = new Controller(repo8);



         */