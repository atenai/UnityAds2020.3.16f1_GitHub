using UnityEngine;

namespace ドラクエの例
{
    public sealed class Senshi : CharaBase, IPlayer
    {
        public Senshi() : base(-300, 0, Color.red)
        {

        }

        public void Right()
        {
            X += 50;
        }
    }
}