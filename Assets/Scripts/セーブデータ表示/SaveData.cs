using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
	public int level = 10;
	public string userName = "Yuta";
	public PlayerStatus playerStatus = new PlayerStatus();
	public EnemyStatus enemyStatus = new EnemyStatus();
	private float playTime = 123.45f;

	// 🔽 追加したセーブデータ構造
	public List<PlayerStatus> partyMembers = new List<PlayerStatus>()
	{
		new PlayerStatus() { playerName = "Alice", hp = 120, mp = 60 },
		new PlayerStatus() { playerName = "Bob", hp = 90, mp = 40 }
	};

	public Dictionary<string, EnemyStatus> enemyDictionary = new Dictionary<string, EnemyStatus>()
	{
		{ "goblin", new EnemyStatus() { enemyName = "Goblin", hp = 25, mp = 10, level = new Level() { number = 1 } } },
		{ "boss",   new EnemyStatus() { enemyName = "Dragon", hp = 999, mp = 500, level = new Level() { number = 10 } } }
	};

	public int Auto { get; set; } = 5;
}

[Serializable]
public class PlayerStatus
{
	public string playerName = "Player";
	public int hp = 100;
	public int mp = 50;
}

[Serializable]
public class EnemyStatus
{
	public string enemyName = "Enemy";
	public int hp = 20;
	public int mp = 40;
	public Level level = new Level();
}

[Serializable]
public class Level
{
	public int number = 5;
}
