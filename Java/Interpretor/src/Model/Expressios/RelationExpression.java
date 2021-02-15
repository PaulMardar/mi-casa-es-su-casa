package Model.Expressios;

import Model.ADT.IDict;
import Model.ADT.IHeap;
import Model.ADT.MyDict;
import Model.Values.IValue;
import Model.Exception.MyException;
import Model.Type.*;
import Model.Values.*;
import Model.Expressios.Enums.RelationOp;
public class RelationExpression implements  IExpression{

    IExpression expression1;
    IExpression expression2;
    RelationOp operand;
    public RelationExpression(RelationOp operand,IExpression e1,IExpression e2)
    {
        this.operand=operand;
        this.expression1=e1;
        this.expression2=e2;
    }

    @Override
    public IValue eval(IDict<String, IValue> SymTable, IHeap heap) {
        IValue v1,v2;
        v1=this.expression1.eval(SymTable, heap);
        v2=this.expression2.eval(SymTable, heap);
        boolean validOp1;
        validOp1 = (v1.getType().equals(new TypeInt())) || v1.getType().equals(new TypeBool());
        boolean validOp2;
        validOp2 = (v2.getType().equals(new TypeInt())) || v2.getType().equals(new TypeBool());
        if(!validOp1)
            throw new MyException("first operant in comparison is not bool or int");
        if(!validOp2)
            throw new MyException("second operant in comparison is not bool or int");
        // check if both expression are int or bool at the same time
        if(v1.getType().equals(new TypeInt()) && v2.getType().equals(new TypeBool()))
            throw new MyException("not matching operands in comparison");
        if(v1.getType().equals(new TypeBool()) && v2.getType().equals(new TypeInt()))
            throw new MyException("not matching operands in comparison");

        if(v1.getType().equals(new TypeBool()))
        {
        var first = (ValueBool) v1;
        var second =(ValueBool) v2;
        var left = first.getValue();
        var right = second.getValue();
            if(operand == RelationOp.Eq)
                return new ValueBool(left == right);
            if(operand ==RelationOp.NotEq)
                return new ValueBool(left != right);
        }
        else
        {
            var first = (ValueInt) v1;
            var second = (ValueInt) v2;
            var left = first.getValue();
            var right = second.getValue();
            if(operand == RelationOp.Eq)
                return new ValueBool(left == right);
            if(operand ==RelationOp.NotEq)
                return new ValueBool(left != right);
            if(operand ==RelationOp.Smaller)
                return new ValueBool(left < right);
            if(operand ==RelationOp.SmallOrEq)
                return new ValueBool(left <= right);
            if(operand ==RelationOp.Greater)
                return new ValueBool(left > right);
            if(operand ==RelationOp.GreaterOrEq)
                return new ValueBool(left >= right);
        }
        return null;
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
                return new TypeBool();
            }
            else throw new MyException("second operand is not an integer");
        } else
            throw new MyException("first operand is not an integer");
    }

    @Override
    public String toString()
    {
            return "("+expression1+" "+operand +" "+expression2;
    }

}
