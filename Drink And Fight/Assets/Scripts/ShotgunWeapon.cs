using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon
{

	[SerializeField] private GameObject bullet;

	[SerializeField] private Transform spawnPosition;
	[SerializeField] private float shootStrength;
	[SerializeField] private int bulletAmount;
	[SerializeField] private float bloom;
	protected override void Act(Player p, Vector2 dir)
	{

	}

	protected override void ActEnter(Player p, Vector2 dir) // einzel schuss
	{
		for(int i = 0; i < bulletAmount; i++)
		{
            GameObject g = Instantiate(bullet, spawnPosition.position, Quaternion.identity, GameManager.instance.transform);
			Debug.Log(spawnPosition.position + " sopawn " + spawnPosition.name + " scale "+  spawnPosition.localScale + " "+ spawnPosition.localRotation);
            g.GetComponent<Bullet>().Fly(dir.normalized * shootStrength + new Vector2(dir.y,dir.x).normalized*Random.Range(-bloom,bloom), damage);
        }
	}

	
}
