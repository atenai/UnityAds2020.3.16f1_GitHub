using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace 依存関係逆転の原則
{
    public class Form1_原則違反 : MonoBehaviour
    {
        [SerializeField] Button button1;
        ProductSqlServer_原則違反 _product = new ProductSqlServer_原則違反();

        void Start()
        {
            button1.onClick.AddListener(Button1_Click);
        }

        void Button1_Click()
        {
            button1.GetComponentInChildren<Text>().text = _product.GetData();
        }
    }
}