public enum MemberKind
{
    Silver,
    Gold,
}

public interface IMember
{
    public int GetPoints(int price);
}

public static class MemberFactory
{
    public static IMember Create(MemberKind memberKind)
    {
        if (memberKind == MemberKind.Gold)
        {
            return new Gold_Interface();
        }

        return new Silver_Interface();
    }
}
