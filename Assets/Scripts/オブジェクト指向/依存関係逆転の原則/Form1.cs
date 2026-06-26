using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace 依存関係逆転の原則
{
    public class Form1 : MonoBehaviour
    {
        [SerializeField] Button button1;
        [SerializeField] Button saveButton;
        IProduct _product = Factories.CreateProduct();

        void Start()
        {
            button1.onClick.AddListener(Button1_Click);
            saveButton.onClick.AddListener(SaveButton_Click);
        }

        void Button1_Click()
        {
            button1.GetComponentInChildren<Text>().text = _product.GetData();
        }

        void SaveButton_Click()
        {
            _product.Save("AAAAA");
        }
    }
}