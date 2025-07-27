using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour
{
	public void ButtonClick(string setting)
	{
		if (setting == "easy")
		{
			Settings.difficulty = Settings.Difficulties.EASY;
		}
		if (setting == "medium")
		{
			Settings.difficulty = Settings.Difficulties.MEDIUM;
		}
		if (setting == "hard")
		{
			Settings.difficulty = Settings.Difficulties.HARD;
		}
		if (setting == "insane")
		{
			Settings.difficulty = Settings.Difficulties.INSANE;
		}

		SceneManager.LoadScene("Sudoku_Udemy_GameScene");
	}

	public void Replay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("Sudoku_Udemy_Menu");
	}
}
