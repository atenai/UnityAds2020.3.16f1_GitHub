public abstract class MemberBase
{
    public enum MemberKind
    {
        Silver,
        Gold,
    }

    public abstract int GetPoints(int price);

    public static MemberBase Create(MemberKind memberKind)
    {
        if (memberKind == MemberKind.Gold)
        {
            return new Gold_Abstract();
        }

        return new Silver_Abstract();
    }
}
