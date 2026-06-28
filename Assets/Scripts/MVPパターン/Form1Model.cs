using UnityEngine;

namespace MVPパターン
{
    public class Form1Model
    {
        public string ButtonText { get; set; }

        IProduct _product;

        public Form1Model(IProduct product)
        {
            Debug.Log("コンストラクタ");
            _product = product;
        }

        public void Button1_Click()
        {
            ButtonText = _product.GetData();
        }

        public void SaveButton_Click()
        {
            _product.Save("AAAAA");
        }
    }
}