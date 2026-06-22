using UnityEngine;

namespace Mediator
{
    public class InGameMediator : MonoBehaviour, IMediator
    {
        [SerializeField] PlayerManager playerManager;
        [SerializeField] EnemyManager enemyManager;
        [SerializeField] UIManager uiManager;
        [SerializeField] SoundManager soundManager;


        void Awake()
        {
            playerManager.SetMediator(this);
            enemyManager.SetMediator(this);
            uiManager.SetMediator(this);
            soundManager.SetMediator(this);
        }

        public void Notify(object sender, string eventName)
        {
            if (eventName == "Dead")
            {
                if (sender is PlayerManager)
                {
                    Debug.Log("プレイヤー死亡");
                    uiManager.ShowGameOver();
                    //soundManager.PlaySE(number);
                }
                else if (sender is EnemyManager)
                {
                    Debug.Log("敵死亡");
                }
            }
        }
    }
}