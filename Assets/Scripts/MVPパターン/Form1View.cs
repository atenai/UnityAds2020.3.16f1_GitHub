using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVPパターン
{
    public class Form1View : MonoBehaviour
    {
        [SerializeField] Button button1;
        public Button Button1 => button1;
        [SerializeField] Button saveButton;
        public Button SaveButton => saveButton;
    }
}