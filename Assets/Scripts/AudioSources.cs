using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSources : MonoBehaviour
{
    public List<AudioSource> soundList;
    int currentSoundIndex = 0;
    bool isAllSoundsPlayed = false;
    bool isPlayingSound = false;  // 再生中かどうかを管理するフラグ

    void Start()
    {

    }

    float count = 0;

    void Update()
    {
        if (isAllSoundsPlayed == true)
        {
            return;
        }


        if (currentSoundIndex < soundList.Count)
        {
            Debug.Log("currentSoundIndex : " + currentSoundIndex);

            // まだ再生していない場合、新しいサウンドを再生
            if (isPlayingSound == false)
            {
                soundList[currentSoundIndex].Play();
                isPlayingSound = true;  // 再生中フラグを立てる
            }

            // 現在のサウンドが再生終了したか確認
            if (soundList[currentSoundIndex].isPlaying == false && isPlayingSound == true)
            {
                count += Time.deltaTime;
                if (2.0f <= count)
                {
                    count = 0.0f;
                    currentSoundIndex++;  // 次のサウンドへ
                    isPlayingSound = false;  // 再生中フラグをリセット
                }
            }
        }
        else
        {
            isAllSoundsPlayed = true;
            Debug.Log("全てのサウンドの再生が完了しました。");
        }
    }
}
