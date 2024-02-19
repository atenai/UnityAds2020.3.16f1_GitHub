using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ShotManager shotManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //空きのあるオブジェクトを借りる
            GameObject tama = shotManager.GetShot();
            tama.transform.position = this.transform.position;
            //tama.GetComponent<Shot>().shotManager = shotManager;
        }
    }
}
