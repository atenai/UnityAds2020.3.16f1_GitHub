using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoButton : MonoBehaviour
{
	[SerializeField] Button button;
	[SerializeField] SudokuGameManager sudokuGameManager;

	void Start()
	{
		button.onClick.AddListener(OnClick);
	}

	void OnClick()
	{
		sudokuGameManager.ToggleMemoMode();
	}

	void Update()
	{

	}
}
