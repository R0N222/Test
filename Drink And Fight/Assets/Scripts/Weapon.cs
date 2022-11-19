using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Weapon : MonoBehaviour
{
	[SerializeField]
    protected float damage = 10;
    [SerializeField]

    private float coolDown = 0.2f;
    [SerializeField]
    private bool canAct = true;

    private float lastTimeShot = 0;
    private float lastTimeShotEnter = 0;


    public void ShootEnter(Player p, Vector2 dir)
	{
        CheckCooldown(p, dir, false,(p, dir) => {
            ActEnter(p, dir);
            });
	}
    public void Shoot(Player p, Vector2 dir)
    {
		CheckCooldown(p, dir, true, (p,dir) => Act(p, dir));
    }

    public void CheckCooldown(Player p, Vector2 dir, bool lts, Action<Player,Vector2> act)
	{
        if (Time.time - (lts ? lastTimeShot : lastTimeShotEnter) <= coolDown) return;

		act(p, dir);

        if (lts) lastTimeShot = Time.time;
        else lastTimeShotEnter = Time.time;

    }

	
    protected abstract void ActEnter(Player p, Vector2 dir);
    protected abstract void Act(Player p, Vector2 dir);
}
