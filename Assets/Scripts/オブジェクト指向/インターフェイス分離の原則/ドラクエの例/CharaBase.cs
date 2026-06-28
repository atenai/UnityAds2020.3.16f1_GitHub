using UnityEngine;

namespace ドラクエの例
{
    public abstract class CharaBase
    {
        public CharaBase(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
    }
}