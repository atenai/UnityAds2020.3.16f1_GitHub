/// <summary>
/// ショットガン（GunBaseのサブクラス）
/// </summary>
public class ShotGun : GunBase
{
	public override void GetWeaponName()
	{
		UnityEngine.Debug.Log("ショットガン");
	}
}
