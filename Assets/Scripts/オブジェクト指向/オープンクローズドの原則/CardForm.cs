using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardForm : MonoBehaviour
{
    [SerializeField] private PointForm pointFormPrefab;
    [SerializeField] private Button readButton;
    [SerializeField] private InputField CardNoTextBox;

    void Start()
    {
        readButton.onClick.AddListener(OnReadButtonClicked);
    }

    void Update()
    {

    }

    public void OnReadButtonClicked()
    {
        // 読み込みボタンがクリックされたときの処理をここに記述
        Debug.Log("読み込みボタンがクリックされました！");

        var f = Instantiate(pointFormPrefab, transform);
        f.Initialize(CardNoTextBox.text);
    }
}
