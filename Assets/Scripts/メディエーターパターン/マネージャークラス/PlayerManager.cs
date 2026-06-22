using UnityEngine;

namespace Mediator
{
    public class PlayerManager : Colleague
    {
        public void Dead()
        {
            Debug.Log("プレイヤー死亡");

            mediator.Notify(this, "Dead");
        }
    }
}