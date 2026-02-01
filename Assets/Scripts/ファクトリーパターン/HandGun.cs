/// <summary>
/// ハンドガン（GunBaseのサブクラス）
/// </summary>
public class HandGun : GunBase
{
	public override void GetWeaponName()
	{
		UnityEngine.Debug.Log("ハンドガン");
	}
}
