using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceAnimationSpecifiedFrame : MonoBehaviour
{
    // ハッシュ値用の変数
    private readonly int LOSE00Hash = Animator.StringToHash("Base Layer.LOSE00");// StateはLayer名を含める
    private readonly int WAIT03Hash = Animator.StringToHash("Base Layer.WAIT03");// StateはLayer名を含める
    private readonly int JUMPHash = Animator.StringToHash("Base Layer.JUMP00");// StateはLayer名を含める

    [SerializeField] Animator animator;

    //現在のアニメーションの時間
    float startAnimationTime;
    //現在のアニメーションのハッシュ値
    int currentAnimationHash;

    bool isFramePlay = false;
    float endFrameAnimationTime = 0.0f;
    float currentAnimationTime = 0.0f;

    void Start()
    {
        animator.enabled = false;
    }

    void Update()
    {
        if (isFramePlay == true)
        {
            currentAnimationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (endFrameAnimationTime <= currentAnimationTime)
            {
                animator.enabled = false;
                isFramePlay = false;
                startAnimationTime = currentAnimationTime;
            }
        }
    }

    public void OnClickJumpAnimation()
    {
        animator.enabled = true;
        animator.Play(JUMPHash);
        animator.Update(0.0f);
        currentAnimationHash = JUMPHash;
    }

    public void OnClickLoseAnimation()
    {
        animator.enabled = true;
        animator.Play(LOSE00Hash);
        animator.Update(0.0f);
        currentAnimationHash = LOSE00Hash;
    }

    /// <summary>
    /// 再生ボタンタップ
    /// </summary>
    public void OnClickAnimationPlay()
    {
        // 再生中なら返す
        if (animator.enabled)
        {
            return;
        }
        animator.enabled = true;
        animator.Play(currentAnimationHash, 0, startAnimationTime);
    }

    /// <summary>
    /// ポーズボタンタップ
    /// </summary>
    public void OnClickAnimationPause()
    {
        animator.enabled = false;
        startAnimationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    /// <summary>
    /// 再生ボタンタップ
    /// </summary>
    public void OnClickAnimationFramePlay()
    {
        // 再生中なら返す
        if (animator.enabled)
        {
            return;
        }

        currentAnimationTime = startAnimationTime;
        endFrameAnimationTime = startAnimationTime + 0.1f;
        isFramePlay = true;

        animator.enabled = true;
        animator.Play(currentAnimationHash, 0, startAnimationTime);
    }
}
