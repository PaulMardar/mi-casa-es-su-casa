package Model.ADT;

import java.util.List;
import java.util.Stack;
import java.util.stream.Collectors;

public class MyStack<TElem> implements IStack<TElem> {

    Stack<TElem> stack;

    public  MyStack()
    {
        this.stack=new Stack<TElem>();
    }
    @Override
    public boolean isEmpty() {
        return this.stack.empty();
    }

    @Override
    public TElem pop() {
        return this.stack.pop();
    }

    @Override
    public void push(TElem element) {
            this.stack.push(element);
    }
    @Override
    public String toString() {
        String outString = "]";
        for (TElem elem : this.stack)
            outString = elem.toString()+","+outString  ;
        outString ="[" + outString;
        return outString;
    }
    public List<TElem> toList()
    {
        return this.stack.stream().collect(Collectors.toList());
    }
}
