public class Silver_Interface : IMember
{
    public int GetPoints(int price)
    {
        return (int)(price * 0.1f);
    }
}
