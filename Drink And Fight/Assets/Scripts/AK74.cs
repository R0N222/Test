using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK74 : Weapon
{

	[SerializeField] private GameObject bullet;

	[SerializeField] private Transform spawnPosition;
	[SerializeField] private float shootStrength;
	protected override void Act(Player p, Vector2 dir)
	{
        GameObject g = Instantiate(bullet, spawnPosition.position, Quaternion.identity, GameManager.instance.transform);
        g.GetComponent<Bullet>().Fly(dir.normalized * shootStrength, damage);
    }

	protected override void ActEnter(Player p, Vector2 dir) // einzel schuss
	{
		
	}

	
}
