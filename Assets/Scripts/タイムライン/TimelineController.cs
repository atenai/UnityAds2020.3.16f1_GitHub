using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;//追加

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTimeline();
        }
    }

    void PlayTimeline()
    {
        //playableDirectorを使用してTimelineを再生
        _playableDirector.Play();
    }
}
