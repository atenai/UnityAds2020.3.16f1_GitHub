using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DIパターン
{
    [Serializable]
    public class Form1
    {
        [SerializeField] Button button1;
        [SerializeField] Button saveButton;
        IProduct _product;

        //動く！！
        public Form1(IProduct product)
        {
            _product = product;
            Debug.Log("コンストラクタ");
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