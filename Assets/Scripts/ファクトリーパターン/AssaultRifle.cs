/// <summary>
/// アサルトライフル（GunBaseのサブクラス）
/// </summary>
public class AssaultRifle : GunBase
{
	public override void GetWeaponName()
	{
		UnityEngine.Debug.Log("アサルトライフル");
	}
}
