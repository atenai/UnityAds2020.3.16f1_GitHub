using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CubeParameters : MonoBehaviour
{
    [SerializeField] int hp = 0;
    public int HP => hp;

    [SerializeField] int enemyID = 0;
    public int EnemyID => enemyID;
}
