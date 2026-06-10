public class Silver_Abstract : MemberBase
{
    public override int GetPoints(int price)
    {
        return (int)(price * 0.1f);
    }
}
