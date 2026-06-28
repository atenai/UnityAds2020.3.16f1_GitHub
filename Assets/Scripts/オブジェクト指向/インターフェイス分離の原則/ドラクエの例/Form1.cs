using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ドラクエの例
{
    public class Form1 : MonoBehaviour
    {
        [SerializeField] Image imageYusha;
        [SerializeField] Image imageSenshi;
        [SerializeField] Image imageMurabitoA;
        [SerializeField] Button rightButton;
        [SerializeField] Button senshiButton;

        List<CharaBase> charaList = new List<CharaBase>();
        CharaBase yushaCharaBase;
        CharaBase senshiCharaBase;
        CharaBase murabitoACharaBase = new MurabitoA();

        IPlayer player;
        IPlayer yusha = new Yusha();
        IPlayer senshi = new Senshi();

        void Start()
        {
            rightButton.onClick.AddListener(RightButton_Click);
            senshiButton.onClick.AddListener(SenshiButton_Click);

            yushaCharaBase = yusha as CharaBase;
            senshiCharaBase = senshi as CharaBase;

            charaList.Add(yushaCharaBase);
            charaList.Add(senshiCharaBase);
            charaList.Add(murabitoACharaBase);

            imageYusha.color = yushaCharaBase.Color;
            imageSenshi.color = senshiCharaBase.Color;
            imageMurabitoA.color = murabitoACharaBase.Color;

            player = yusha;
        }

        void Update()
        {
            imageYusha.GetComponent<RectTransform>().localPosition = new Vector2(yushaCharaBase.X, yushaCharaBase.Y);
            imageSenshi.GetComponent<RectTransform>().localPosition = new Vector2(senshiCharaBase.X, senshiCharaBase.Y);
            imageMurabitoA.GetComponent<RectTransform>().localPosition = new Vector2(murabitoACharaBase.X, murabitoACharaBase.Y);
        }

        void RightButton_Click()
        {
            player.Right();
        }

        void SenshiButton_Click()
        {
            player = senshi;
        }
    }
}