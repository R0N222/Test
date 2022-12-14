using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{


	[SerializeField] private List<Weapon> weapons;


	[SerializeField] private Weapon weapon;
	[SerializeField] private Player player;
	[SerializeField] private Transform weaponParent;
	[SerializeField] private Vector2 offset;


	public void Init(Weapon wp)
	{
		weapon = wp;
	}
	public void SetRandomWeapon()
	{
		SpawnWeapon(weapons[Random.Range(0, weapons.Count)]);
	}

	public void SpawnWeapon(Weapon pref)
	{
		ClearWeapons();
		var wp = Instantiate(pref,offset,Quaternion.Euler(0,0,90), weaponParent);

		weapon = wp.GetComponent<Weapon>();
	}


	
	private void ClearWeapons()
	{
		foreach (GameObject wp in weaponParent)
		{
			Destroy(wp);
		}
	}

	public void ShootEnter(Player pl, Vector2 dir)
	{
		if (weapon == null) return;
		weapon.ShootEnter(player, dir);
	}

	public void Shoot(Player pl, Vector2 dir)
	{
		if (weapon == null) return;

		weapon.Shoot(pl, dir);
	}


}
