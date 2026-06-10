using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// リスコフの置換原則
/// 子クラスは、親クラスの代わりができないといけない
/// 今回の場合はMember → Silverにクラスを変更しても問題ないようにする必要がある
/// </summary>
public class Form_Abstract : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] InputField _inputField;
    [SerializeField] Button _button;

    private MemberBase.MemberKind _loginKind = MemberBase.MemberKind.Gold;
    //親クラス
    /// <summary>
    private MemberBase _member;
    /// </summary>
    //子クラス
    //private Silver_Abstract _member;

    void Start()
    {
        _button.onClick.AddListener(OnClick);
        _text.text = _loginKind.ToString();
        _member = MemberBase.Create(_loginKind);
        //_member = new Silver_Abstract();
    }

    void OnClick()
    {
        int points = Convert.ToInt32(_inputField.text);
        _button.GetComponentInChildren<Text>().text = _member.GetPoints(points).ToString();
    }
};