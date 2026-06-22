using UnityEngine;

namespace Mediator
{
    public class SoundManager : Colleague
    {
        public void PlayGameOverSE()
        {
            Debug.Log("ゲームオーバーSE再生");
        }

        public void PlaySE(int number)
        {
            switch (number)
            {
                case 1:
                    Debug.Log("1");
                    break;
                case 2:
                    Debug.Log("2");
                    break;
                case 3:
                    Debug.Log("3");
                    break;
            }
        }
    }
}