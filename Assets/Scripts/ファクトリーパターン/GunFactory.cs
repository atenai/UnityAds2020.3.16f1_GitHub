/// <summary>
/// ガンファクトリー（どのサブクラスをインスタンスするか？の生成をつかさどるのでファクトリーパターン）
/// </summary>
public static class GunFactory
{
	/// <summary>
	/// 銃を生成
	/// </summary>
	/// <param name="weaponName">銃の名前</param>
	/// <returns>銃</returns>
	public static GunBase CreateGunBase(string weaponName)
	{
		if (weaponName == "AssaultRifle")
		{
			return new AssaultRifle();
		}

		if (weaponName == "ShotGun")
		{
			return new ShotGun();
		}

		return new HandGun();
	}
}
