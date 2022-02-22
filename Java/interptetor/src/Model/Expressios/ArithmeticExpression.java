package Model.Expressios;

import Model.ADT.*;
import Model.Exception.MyException;
import Model.Type.*;
import Model.Values.*;
import Model.Expressios.Enums.ArithmeticOp;


public class ArithmeticExpression implements IExpression {
    IExpression expression1;
    IExpression expression2;
    ArithmeticOp operand; //1-plus, 2-minus, 3-star, 4-divide

    public ArithmeticExpression(ArithmeticOp operand, IExpression e1, IExpression e2) {
        this.operand = operand;
        this.expression1 = e1;
        this.expression2 = e2;
    }

    @Override
    public String toString() {
        if (operand == ArithmeticOp.ADD) {
            return "(" + this.expression1.toString() + " + " + this.expression2.toString() + ")";
        }
        if (operand == ArithmeticOp.SUB) {
            return "(" + this.expression1.toString() + " - " + this.expression2.toString() + ")";
        }
        if (operand == ArithmeticOp.MUL) {
            return "(" + this.expression1.toString() + " * " + this.expression2.toString() + ")";
        }
        if (operand == ArithmeticOp.DIV) {
            return "(" + this.expression1.toString() + " / " + this.expression2.toString() + ")";
        }
        return null;
    }

    @Override
    public IValue eval(IDict<String, IValue> SymTable, IHeap heap) {
        IValue v1, v2;
        v1 = this.expression1.eval(SymTable, heap); // i still don't know why  :( mergem sa bem apa gainii mai repede decat sa inteleg de ce asta e aici
        v2 = this.expression2.eval(SymTable, heap); // i still don't know why  :(
        if (!v1.getType().equals(new TypeInt()))
            throw new MyException("first operand is not int");
        if (!v2.getType().equals(new TypeInt()))
            throw new MyException("first operand is not int");
        ValueInt firstInteger = (ValueInt) v1;
        ValueInt secondInteger = (ValueInt) v2;
        int left = firstInteger.getValue();
        int right = secondInteger.getValue();
        if (operand == ArithmeticOp.ADD) {
            return new ValueInt(left + right);
        }
        if (operand == ArithmeticOp.SUB) {
            return new ValueInt(left - right);
        }
        if (operand == ArithmeticOp.MUL) {
            return new ValueInt(left * right);
        }
        if (operand == ArithmeticOp.DIV) {
            if (right == 0)
                throw new MyException("WE CAN'T divide by 0 :(");
            else
                return new ValueInt(left / right);
        }
        throw new MyException("invalid operand");

    }

    @Override
    public IType typecheck(IDict<String, IType> typeEnv) {
        IType typ1, typ2;
        typ1 = expression1.typecheck(typeEnv);
        typ2 = expression2.typecheck(typeEnv);
        if (typ1.equals(new TypeInt()))
        {
            if (typ2.equals(new TypeInt()))
            {
                return new TypeInt();
            }
            else throw new MyException("second operand is not an integer");
        } else
            throw new MyException("first operand is not an integer");
    }
}

