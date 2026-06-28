using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPパターン
{
    public class Main : MonoBehaviour
    {
        [SerializeField] Form1View form1View;

        void Start()
        {
            Form1Model form1Model = new Form1Model(Factories.CreateProduct());
            Form1Presenter form1Presenter = new Form1Presenter(form1Model, form1View);
        }
    }
}