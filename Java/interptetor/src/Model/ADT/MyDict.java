package Model.ADT;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.Map.Entry;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import Model.Exception.MyException;
import javafx.util.Pair;

public class MyDict<TElem1,TElem2> implements IDict<TElem1,TElem2>{
    HashMap<TElem1,TElem2> dictionar;
    public MyDict() {this.dictionar=new HashMap<TElem1, TElem2>();}

    public static <K, V> MyDict<K, V> ofStream(Stream<Entry<K, V>> stream) {
      var m = stream.collect(Collectors.toMap(Entry::getKey, Entry::getValue));
      var d = new MyDict<K, V>();
      d.dictionar = new HashMap<>(m);
      return d;
    }

    @Override
    public TElem2 remove(TElem1 key) {
        return this.dictionar.remove(key);
    }

    @Override
    public TElem2 search(TElem1 key) {
        if( ! this.dictionar.containsKey(key))
            throw new MyException("dict go buuum !");
        else return this.dictionar.get(key);
    }

    @Override
    public void add(TElem1 key, TElem2 value) throws MyException {
        if(this.dictionar.containsKey(key))
            throw new MyException("key is already in dict");
        this.dictionar.put(key,value);
    }
    @Override
    public void update(TElem1 key, TElem2 newvalue) {
        this.dictionar.replace(key, newvalue);
    }

    @Override
    public boolean exists(TElem1 key) {
        return this.dictionar.containsKey(key);
    }

    @Override
    public void addOrUpdate(TElem1 key, TElem2 value) {
        this.dictionar.put(key,value);
    }

    @Override
    public Set<TElem1> keySet() {
        return this.dictionar.keySet();
    }

    @Override
    public Set<Entry<TElem1, TElem2>> entrySet() {
      return dictionar.entrySet();
    }

    @Override
    public void setContent(Map<TElem1, TElem2> m) {
      dictionar = new HashMap<>(m);
    }

    @Override
    public String toString(){

        String out="{ ";
        for(var entry: this.dictionar.entrySet())
        {
            out = out + entry.getKey()+" = "+entry.getValue()+", ";
        }
        out=out + "}";
        return out;
    }

    @Override
    public IDict<TElem1, TElem2> duplicate() {
      var d = new MyDict<TElem1, TElem2>();
      d.dictionar = new HashMap<>(dictionar);
      return d;
    }
    public List<Pair<TElem1,TElem2>> pairs()
    {
        return dictionar.entrySet().stream().map(e-> new Pair<>(e.getKey(),e.getValue())).collect(Collectors.toList());
    }
}
