namespace DIパターン
{
    /// <summary>
    /// クラスによる依存性の注入
    /// </summary>
    public class ModuleA
    {
        IProduct _product;

        //コンストラクタで依存性を注入する
        public ModuleA(IProduct product)
        {
            _product = product;
        }

        public string GetValue()
        {
            var value = _product.GetData();
            if (value.Length == 5)
            {
                return value;
            }

            return _product.GetData() + "%";
        }
    }
}