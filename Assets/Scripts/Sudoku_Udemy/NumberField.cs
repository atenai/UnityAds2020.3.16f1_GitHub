using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberField : MonoBehaviour
{

	Board board;
	//COORDS
	int x1;
	int y1;
	int value;
	string identifier;

	public TextMeshProUGUI number;

	public void SetValues(int _x1, int _y1, int _value, string _identifier, Board _board)
	{
		x1 = _x1;
		y1 = _y1;
		value = _value;
		identifier = _identifier;
		board = _board;

		number.text = value != 0 ? value.ToString() : "";

		//valueに0以外の値が入っている場合
		if (value != 0)
		{
			//親のボタンを押せなくする
			GetComponentInParent<Button>().interactable = false;
		}
		else
		{
			number.color = Color.blue;
		}
	}

	public void ButtonClick()
	{
		InputField.instance.ActivateInputField(this);
	}

	public void ReceiveInput(int newValue)
	{
		value = newValue;
		number.text = value != 0 ? value.ToString() : "";
		//UPDATE RIDDLE
		board.SetInputInRiddleGrid(x1, y1, value);
	}

	public int GetX()
	{
		return x1;
	}

	public int GetY()
	{
		return y1;
	}

	public void SetHint(int _value)
	{
		value = _value;
		number.text = value.ToString();
		number.color = Color.red;
		GetComponentInParent<Button>().interactable = false; //ヒントを表示したらボタンを押せなくする
	}
}
