public class Gold_Interface : IMember
{
    public int GetPoints(int price)
    {
        return (int)(price * 0.2f);
    }
}
