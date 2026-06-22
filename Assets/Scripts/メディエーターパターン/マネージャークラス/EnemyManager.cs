using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediator
{
    public class EnemyManager : Colleague
    {
        public void Dead()
        {
            Debug.Log("エネミー死亡");

            mediator.Notify(this, "Dead");
        }
    }
}