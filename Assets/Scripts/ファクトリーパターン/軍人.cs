using UnityEngine;

public class 軍人 : MonoBehaviour
{
	void Start()
	{
		GunBase gunBase = GunFactory.CreateGunBase("ShotGun");
		gunBase.GetWeaponName();
	}
}
