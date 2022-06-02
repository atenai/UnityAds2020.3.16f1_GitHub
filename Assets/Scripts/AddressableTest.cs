using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class AddressableTest : MonoBehaviour
{

    Image _eventCG;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<Sprite>("Assets/Texture/K.png").Completed += sprite =>
        {
            _eventCG = GetComponent<Image>();
            _eventCG.sprite = Instantiate(sprite.Result);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
