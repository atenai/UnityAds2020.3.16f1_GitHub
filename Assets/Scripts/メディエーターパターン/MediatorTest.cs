using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediator
{
    public class MediatorTest : MonoBehaviour
    {
        [SerializeField] PlayerManager playerManager;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerManager.Dead();
            }
        }
    }
}