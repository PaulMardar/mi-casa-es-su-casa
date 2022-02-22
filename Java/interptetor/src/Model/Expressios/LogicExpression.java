package Model.Expressios;

import Model.ADT.*;
import Model.Exception.MyException;
import Model.Type.*;
import Model.Values.*;

public class LogicExpression implements IExpression{
    IExpression expression1;
    IExpression expression2;
    int operand; // 1 & 2 or
    public LogicExpression(int operand, IExpression e1,IExpression e2)
    {
        this.expression1=e1;
        this.expression2=e2;
        this.operand=operand;
    }
    @Override
    public String toString()
    {
        if(operand==1)
            return "("+this.expression1.toString()+ " && " + this.expression2.toString()+")";
        if(operand ==2)
            return "("+this.expression1.toString()+ " || " + this.expression2.toString()+")";
        else
            return null;
    }

    @Override
    public IValue eval(IDict<String, IValue> SymTable, IHeap heap)  {
        IValue v1,v2;
        v1=this.expression1.eval(SymTable, heap);
        v2=this.expression2.eval(SymTable, heap);
        if(!v1.getType().equals(new TypeBool()))
            throw new MyException("first operant is not bool in logic expresion");
        if(!v2.getType().equals(new TypeBool()))
            throw new MyException("second operant is not bool in logic expresion");
        ValueBool b1= (ValueBool)v1;
        ValueBool b2= (ValueBool)v2;
        boolean left =b1.getValue();
        boolean right = b2.getValue();
        if(operand ==1)
        {
            if(left && right)
                return new ValueBool(true);
            else return new ValueBool(false);
        }
        if(operand ==2)
        {
           if(left || right)
               return new ValueBool(true);
           else return new ValueBool(false);
        }
        return new ValueBool(false);
    }

    @Override
    public IType typecheck(IDict<String, IType> typeEnv)
    {
        IType typ1, typ2;
        typ1 = expression1.typecheck(typeEnv);
        typ2 = expression2.typecheck(typeEnv);
        if (typ1.equals(new TypeBool()))
        {
            if (typ2.equals(new TypeBool()))
            {
                return new TypeBool();
            }
            else throw new MyException("second operand is not an bool");
        } else
            throw new MyException("first operand is not an bool");
    }

}
