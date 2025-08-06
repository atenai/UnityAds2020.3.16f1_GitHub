using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoButton : MonoBehaviour
{
	[SerializeField] Button button;

	void Start()
	{
		button.onClick.AddListener(OnClick);
	}

	void OnClick()
	{

	}

	void Update()
	{

	}
}
