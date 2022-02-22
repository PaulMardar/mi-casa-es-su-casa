package Model.ADT;

import Model.Exception.MyException;
import javafx.util.Pair;

import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.Map.Entry;

public interface IDict<TElem1, TElem2> {
    TElem2 remove(TElem1 key);
    TElem2 search(TElem1 key);

    void add(TElem1 key,TElem2 value) throws MyException;
    void update(TElem1 key, TElem2 newvalue);
    boolean exists(TElem1 key);
    void addOrUpdate(TElem1 key,TElem2 value);

    public Set<TElem1> keySet();
    public Set<Entry<TElem1, TElem2>> entrySet();

    public void setContent(Map<TElem1, TElem2> m);
    public IDict<TElem1, TElem2> duplicate();
    public List<Pair<TElem1,TElem2>> pairs();
}
