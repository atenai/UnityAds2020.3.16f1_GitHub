public class Gold_Abstract : MemberBase
{
    public override int GetPoints(int price)
    {
        return (int)(price * 0.2f);
    }
}
