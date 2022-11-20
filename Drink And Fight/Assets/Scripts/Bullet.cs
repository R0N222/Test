using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigid;

	private float damage;
	[SerializeField]
	private int collisionCount = 3;


	public Action<Bullet> OnHit;
	public void Fly(Vector2 dir,float damage, Action<Bullet> hit = null, int colCount = 3)
	{
		rigid.AddForce(dir, ForceMode2D.Impulse);

		if (hit == null) hit = (bul) => Destroy(bul.gameObject);
		this.damage = damage;
		collisionCount = colCount;
		OnHit = hit;
		Invoke(nameof(Destroy),10);
	}
	public void OnCollisionEnter2D(Collision2D collision)
	{
		collisionCount--;
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Player>().Damage(damage);
			AudioManager.Play("Hit");

			OnHit?.Invoke(this);
		}
		if (collisionCount == 0) Destroy(gameObject);
	}

	public void Destroy()
	{
		Destroy(gameObject);

	}
}
