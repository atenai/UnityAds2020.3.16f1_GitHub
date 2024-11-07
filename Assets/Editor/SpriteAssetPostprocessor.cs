using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class SpriteAssetPostprocessor : AssetPostprocessor
{
    public override uint GetVersion()
    {
        return AssetImporterUtility.VERSION;
    }

    void OnPreprocessTexture()
    {
        //Spritesフォルダは以下であれば実行
        if (assetPath.StartsWith("Assets/Sprites/") == false)
        {
            return;
        }

        TextureImporter importer = (TextureImporter)assetImporter;
        importer.textureType = TextureImporterType.Sprite;
        importer.spriteImportMode = SpriteImportMode.Multiple;
        importer.filterMode = FilterMode.Point;
    }

    void OnPostprocessTexture(Texture2D texture)
    {
        int width, height;
        if (TryGetSpriteSize(out width, out height) == false)
        {
            return;
        }

        var filename = Path.GetFileNameWithoutExtension(assetPath);

        //スプライト生成に関する各種設定
        var offset = Vector2.zero;
        var size = new Vector2(width, height);
        var padding = Vector2.zero;

        var rects = InternalSpriteUtility.GenerateGridSpriteRectangles(texture, offset, size, padding);

        //生成したスプライトのRectを元にSpriteMetaDataを生成
        var spriteMetadata = new List<SpriteMetaData>();

        for (int i = 0; i < rects.Length; i++)
        {
            var rect = rects[i];
            spriteMetadata.Add(new SpriteMetaData
            {
                name = filename + " " + i,
                rect = rect
            });
        }

        TextureImporter importer = (TextureImporter)assetImporter;
        //最後にスプライト情報を適用
        importer.spritesheet = spriteMetadata.ToArray();
    }

    bool TryGetSpriteSize(out int width, out int height)
    {
        width = 0;
        height = 0;

        var filename = Path.GetFileNameWithoutExtension(assetPath);
        var pattern = @"(?<name>.*?)_(?<width>\d+)x(?<height>\d+)";
        var regex = new Regex(pattern);

        if (regex.IsMatch(filename) == false)
        {
            return false;
        }

        var groups = regex.Match(filename).Groups;
        width = int.Parse(groups["width"].Value);
        height = int.Parse(groups["height"].Value);
        return true;
    }
}
