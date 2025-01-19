using UnityEngine;

public class SugorokuGameManager : MonoBehaviour
{
    public SugorokuPlayer[] players;
    int currentPlayerIndex = 0;

    /// <summary>
    /// ボタンを押すとダイスの目によってプレイヤーが動く関数
    /// </summary>
    public void OnClickRollDiceAndMove()
    {
        int rollResult = DiceRoll();
        players[currentPlayerIndex].Move(rollResult);
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;//次のプレイヤーに移行
    }

    /// <summary>
    /// 1～6のランダムな数値を返すダイス
    /// </summary>
    /// <returns></returns>
    int DiceRoll()
    {
        int result = Random.Range(1, 7);
        Debug.Log("サイコロの目: " + result);
        return result;
    }
}
