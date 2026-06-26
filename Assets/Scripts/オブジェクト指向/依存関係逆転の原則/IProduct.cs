namespace 依存関係逆転の原則
{
    public interface IProduct
    {
        string GetData();

        void Save(string value);
    }
}