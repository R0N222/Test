using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistoleWeapon : Weapon
{

	[SerializeField] private GameObject bullet;

	[SerializeField] private Transform spawnPosition;
	[SerializeField] private float shootStrength;
	public override void Act(Player p, Vector2 dir)
	{

	}

	public override void ActEnter(Player p, Vector2 dir) // einzel schuss
	{
		GameObject g = Instantiate(bullet, spawnPosition.position,Quaternion.identity ,GameManager.instance.transform);
		g.GetComponent<Bullet>().Fly(dir.normalized * shootStrength, damage);
	}

	
}
