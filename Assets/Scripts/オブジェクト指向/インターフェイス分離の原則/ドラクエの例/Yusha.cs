using UnityEngine;

namespace ドラクエの例
{
	public sealed class Yusha : CharaBase, IPlayer
	{
		public Yusha() : base(-300, 200, Color.blue)
		{

		}

		public void Right()
		{
			X += 10;
		}
	}
}