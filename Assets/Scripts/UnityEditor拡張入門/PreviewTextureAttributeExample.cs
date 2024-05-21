using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PreviewTextureAttributeExample : MonoBehaviour
{
    //60秒キャッシュする
    //[PreviewTexture(60)]
    public string textureURL = "https://www.hogehoge.com/image.png";

    //[PreviewTexture]
    public Texture hoge;

    GUIStyle style;

    void DrawTexture(Rect position, Texture2D texture)
    {
        float width = Mathf.Clamp(texture.width, position.width * 0.7f, position.width * 0.7f);

        var rect = new Rect(position.width * 0.15f, position.y + 16, width, texture.height * (width / texture.width));

        if (style == null)
        {
            style = new GUIStyle();
            style.imagePosition = ImagePosition.ImageOnly;
        }

        style.normal.background = texture;
        GUI.Label(rect, "", style);
    }
}
