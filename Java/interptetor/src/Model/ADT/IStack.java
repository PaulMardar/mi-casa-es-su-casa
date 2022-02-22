package Model.ADT;

import java.util.List;

public interface IStack<TElem> {

    boolean isEmpty();
    TElem pop();
    void push(TElem element);
    List<TElem> toList();
}
