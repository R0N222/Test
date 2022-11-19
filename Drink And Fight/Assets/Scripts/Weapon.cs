using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	[SerializeField]
    protected float damage = 10;
    [SerializeField]

    private float coolDown = 0.4f;
    [SerializeField]
    private bool canAct = true;



    public abstract void ActEnter(Player p, Vector2 dir);

    public abstract void Act(Player p, Vector2 dir);
}
