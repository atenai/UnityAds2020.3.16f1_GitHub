using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DIパターン
{
    public class Main : MonoBehaviour
    {
        [SerializeField] Form1 form1;

        void Awake()
        {
            form1 = new Form1(Factories.CreateProduct());
        }

        void Start()
        {

        }
    }
}