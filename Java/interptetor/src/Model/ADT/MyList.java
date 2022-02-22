package Model.ADT;

import java.util.ArrayList;

public class MyList<TElem> implements IList<TElem> {
    ArrayList<TElem> mylist;
    public MyList(){this.mylist= new ArrayList<TElem>();} // to check for later if arraylist should have <TElem> ArrayList<TElem>() sau fara telem ??

    @Override
    public ArrayList<TElem> getAll() { return this.mylist; }

    @Override
    public TElem remove(int index) {
        return this.mylist.remove(index);
    }

    @Override
    public void insert(TElem element) {
        this.mylist.add(element);
    }

    @Override
    public boolean isEmpty() {
        return this.mylist.size()==0;
    }
    @Override
    public String toString() {
        String outString ="[ ";
        for (TElem elem : this.mylist)
            outString = outString + elem.toString()+",";
        outString=outString +"]";
        return outString;
    }

    @Override
    public boolean contains(TElem e) {
      return mylist.contains(e);
    }
}
