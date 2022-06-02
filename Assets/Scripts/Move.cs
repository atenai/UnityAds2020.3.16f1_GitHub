using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Œ»İ‚ÌˆÊ’u‚ğæ“¾
        Vector3 pos = this.gameObject.transform.position;
        //Œ»İ‚ÌˆÊ’u‚©‚çx•ûŒü‚É1ˆÚ“®‚·‚é
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.1f);
    }
}
