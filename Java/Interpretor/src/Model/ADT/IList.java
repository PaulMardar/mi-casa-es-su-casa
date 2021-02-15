package Model.ADT;

import java.util.ArrayList;

public interface IList<TElem> {

    ArrayList<TElem> getAll();
    TElem remove(int index);
    void insert(TElem element);
    boolean isEmpty();
    boolean contains(TElem e);
    int length();

}
