using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 答え入力クラス
/// </summary>
public class InputField : MonoBehaviour
{
	public static InputField instance;

	NumberField lastField;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		this.gameObject.SetActive(false);
	}

	public void ActivateInputField(NumberField field)
	{
		this.gameObject.SetActive(true);
		lastField = field;
	}

	//各答ボタンに割り当てた数値を答えとして反映させる
	public void ClickedInput(int number)
	{
		lastField.ReceiveInput(number);
		//DEACTIVATE PANEL
		this.gameObject.SetActive(false);
	}
}
