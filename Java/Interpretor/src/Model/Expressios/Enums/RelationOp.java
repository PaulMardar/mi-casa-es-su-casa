package Model.Expressios.Enums;

public enum RelationOp {
    Smaller,Greater,Eq,SmallOrEq,GreaterOrEq,NotEq;
    @Override
    public String toString() {
        return switch (this)
                {
                    case Smaller -> "<";
                    case Greater -> ">";
                    case Eq -> "==";
                    case SmallOrEq -> "<=";
                    case GreaterOrEq ->">=";
                    case NotEq -> "!=";
                };
    }
}
