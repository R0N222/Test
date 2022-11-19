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
		weapon.ShootEnter(player, dir);
	}

	public void Shoot(Player pl, Vector2 dir)
	{
		weapon.Shoot(pl, dir);
	}


}
