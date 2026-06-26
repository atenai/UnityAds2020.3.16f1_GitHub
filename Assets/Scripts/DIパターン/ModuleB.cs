namespace DIパターン
{
    /// <summary>
    /// 関数による依存性の注入
    /// </summary>
    public static class ModuleB
    {
        //関数で依存性を注入する
        public static string GetValue(IProduct product)
        {
            var value = product.GetData();
            if (value.Length == 5)
            {
                return value;
            }

            return product.GetData() + "%";
        }
    }
}