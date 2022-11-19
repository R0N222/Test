using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;

	private float damage;

    public void Fly(Vector2 dir,float damage)
	{
		rigid.AddForce(dir, ForceMode2D.Impulse);
		this.damage = damage;

		Invoke(nameof(Destroy),5);
	}
	[SerializeField]
	private int collisionCount = 3;
	public void OnCollisionEnter2D(Collision2D collision)
	{
		collisionCount--;
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Player>().Damage(damage);
			AudioManager.Play("Hit");

			Destroy(gameObject);
		}
		if (collisionCount == 0) Destroy(gameObject);
	}

	public void Destroy()
	{
		Destroy(gameObject);

	}
}
