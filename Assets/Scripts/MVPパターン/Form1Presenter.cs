using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVPパターン
{
    public class Form1Presenter
    {
        Form1Model form1Model;
        Form1View form1View;

        public Form1Presenter(Form1Model form1Model, Form1View form1View)
        {
            this.form1Model = form1Model;
            this.form1View = form1View;

            form1View.Button1.onClick.AddListener(() =>
            {
                form1Model.Button1_Click();
                form1View.Button1.GetComponentInChildren<Text>().text = form1Model.ButtonText;
            });
            form1View.SaveButton.onClick.AddListener(form1Model.SaveButton_Click);
        }
    }
}