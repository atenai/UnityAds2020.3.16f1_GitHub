using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// リスコフの置換原則
/// 子クラスは、親クラスの代わりができないといけない
/// 今回の場合はMember → Silverにクラスを変更しても問題ないようにする必要がある
/// </summary>
public class Form_Interface : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] InputField _inputField;
    [SerializeField] Button _button;

    private MemberKind _loginKind = MemberKind.Gold;
    //親クラス
    private IMember _member;
    //子クラス
    //private Silver _member;

    void Start()
    {
        _button.onClick.AddListener(OnClick);
        _text.text = _loginKind.ToString();
        _member = MemberFactory.Create(_loginKind);
        //_member = new Silver();
    }

    void OnClick()
    {
        int points = Convert.ToInt32(_inputField.text);
        _button.GetComponentInChildren<Text>().text = _member.GetPoints(points).ToString();
    }
};