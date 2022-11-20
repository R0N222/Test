using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : Weapon
{

	[SerializeField] private GameObject bullet;

	[SerializeField] private Transform spawnPosition;
	[SerializeField] private float shootStrength;
	protected override void Act(Player p, Vector2 dir)
	{

	}

	protected override void ActEnter(Player p, Vector2 dir) // einzel schuss
	{
		GameObject g = Instantiate(bullet, spawnPosition.position,Quaternion.identity ,GameManager.instance.transform);
		g.GetComponent<Bullet>().Fly(dir.normalized * shootStrength, damage, (bul) =>
		{
			var plays = GameManager.players;
			float shortestDistance = float.MaxValue;
			int shortestIndex = 0;
			for (int i = 0; i < plays.Count; i++)
			{

				if (!plays[i].IsAlive) continue;
				float dist = Vector2.Distance(bul.transform.position, plays[i].transform.position);

                if (dist < shortestDistance)
				{
					shortestDistance = dist;
					shortestIndex = i;
				}
			}
			Player target = plays[shortestIndex];
			bul.rigid.velocity = Vector2.zero;
			bul.rigid.AddForce((target.transform.position - bul.transform.position).normalized * shootStrength,ForceMode2D.Impulse);

		} );
	}

	
}
