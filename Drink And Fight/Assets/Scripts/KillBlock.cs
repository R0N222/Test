using System.Collections;
using UnityEngine;

namespace Assets
{
	public class KillBlock : MonoBehaviour
	{

		public void OnCollisionEnter2D(Collision2D collision)
		{
			var p = collision.gameObject.GetComponent<Player>();
			if ( p != null){
				p.Die();
			}
		}
	}
}