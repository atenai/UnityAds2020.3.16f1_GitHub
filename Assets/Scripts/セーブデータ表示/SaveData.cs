using System;
using System.Reflection;
using UnityEngine;

[Serializable]
public class SaveData
{
	public int level = 10;
	public string userName = "Yuta";
	public PlayerStatus playerStatus = new PlayerStatus();
	public EnemyStatus enemyStatus = new EnemyStatus();
	private float playTime = 123.45f;
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