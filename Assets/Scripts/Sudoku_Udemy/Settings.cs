using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
	//DIFFICULTY
	public enum Difficulties
	{
		DEBUG,
		EASY,
		MEDIUM,
		HARD,
		INSANE,
	}

	public static Difficulties difficulty;
}
