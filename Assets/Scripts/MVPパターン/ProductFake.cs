namespace MVPパターン
{
    public sealed class ProductFake : IProduct
    {
        public string GetData()
        {
            return "XXX Fake";
        }

        public void Save(string value)
        {
            UnityEngine.Debug.Log(value);
        }
    }
}