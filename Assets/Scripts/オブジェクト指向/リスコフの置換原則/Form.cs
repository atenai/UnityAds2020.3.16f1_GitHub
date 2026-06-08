using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Form : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] InputField _inputField;
    [SerializeField] Button _button;

    private Member.MemberKind _loginKind = Member.MemberKind.Gold;
    private Member _member;

    void Start()
    {
        _button.onClick.AddListener(OnClick);
        _text.text = _loginKind.ToString();
        _member = Member.Create(_loginKind);
    }

    void Update()
    {

    }

    private void OnClick()
    {
        int points = Convert.ToInt32(_inputField.text);
        _button.GetComponentInChildren<Text>().text = _member.GetPoints(points).ToString();
    }
};