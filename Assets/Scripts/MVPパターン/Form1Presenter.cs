using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVPパターン
{
    public class Form1Presenter : MonoBehaviour
    {
        [SerializeField] Form1View form1View;
        Form1Model _m;

        void Start()
        {
            _m = new Form1Model(Factories.CreateProduct());

            form1View.Button1.onClick.AddListener(() =>
            {
                _m.Button1_Click();
                form1View.Button1.GetComponentInChildren<Text>().text = _m.ButtonText;
            });
            form1View.SaveButton.onClick.AddListener(_m.SaveButton_Click);
        }
    }
}