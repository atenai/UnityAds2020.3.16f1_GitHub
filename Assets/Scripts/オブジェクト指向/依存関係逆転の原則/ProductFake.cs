namespace 依存関係逆転の原則
{
    public sealed class ProductFake : IProduct
    {
        public string GetData()
        {
            return "XXX Fake";
        }

        public void Save(string value)
        {
            //Save
        }
    }
}