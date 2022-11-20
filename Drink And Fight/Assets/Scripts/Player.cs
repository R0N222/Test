using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using Assets.power;
public class Player : MonoBehaviour
{
	[SerializeField] public Rigidbody2D rigid;
	[SerializeField] private float force, jumpForce, breakForce;
	[SerializeField] private bool IsGrounded = false;

	[SerializeField]
	private Vector2 movementInput, lookDir;

	[SerializeField] private bool canJump = true;
	[SerializeField] private SpriteRenderer spriteRenderer;

	[SerializeField] private Collider2D collider2D;

	[SerializeField] private float raySize = 0.2f;


	[SerializeField] private WeaponManager weaponManager;
	[SerializeField] private Weapon weapon;

	[SerializeField] private Transform weaponHolder;

	[SerializeField] private Transform aimPoint;


	[SerializeField] private SpriteRenderer skinnedMeshRenderer;

	[SerializeField] private List<ActivePower> powers = new List<ActivePower>();
	[SerializeField] private float health = 100;
	bool fireEnter = false;
	public void Start()
	{
		GameManager.instance.OnPlayerConnect(this);
		skinnedMeshRenderer.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.84f, 0.86f);
		weaponManager.Init(weapon);
	}


	public void Update()
	{

		rigid.AddForce(new Vector2(movementInput.x,0)* force * Time.deltaTime * 1000);
		Vector2 vel = rigid.velocity;
		vel.y = 0;
		rigid.AddForce(-vel.normalized * breakForce * Time.deltaTime * 1000);

		weaponHolder.LookAt(aimPoint,Vector3.forward);
		//weaponHolder.rotation = Quaternion.Euler(new Vector3(0, 0, weaponHolder.rotation.z));
	}


	private void AfterJump()
	{
		canJump = true;
	}

	public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();


	public void Jump()
	{
		Debug.Log("jump");
		if (IsGrounded && canJump)
		{
			rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			canJump = false;
			Invoke(nameof(AfterJump), 0.1f);
		}
	}


	public void Fire(CallbackContext cc)
	{

		AudioManager.Play("Shoot");

		Debug.Log("Hold");
		if (lookDir == Vector2.zero)
		{
			lookDir = movementInput;
			if(movementInput == Vector2.zero)
			{
				lookDir = Vector2.right;
			}
		}
		if (cc.started)
		{
			weaponManager.ShootEnter(this, lookDir);
			fireEnter = true;
		}

		weaponManager.Shoot(this, lookDir);
	}
	public void Look(CallbackContext cc)
	{
		lookDir = cc.ReadValue<Vector2>();
		aimPoint.position =  transform.position + new Vector3(lookDir.x,lookDir.y,-10) * 5;

	}
	public void LookMouse(CallbackContext cc)
	{
		Vector2 pos = cc.ReadValue<Vector2>();
		aimPoint.position = CamManager.instance.cam.ScreenToWorldPoint(pos);
		lookDir = aimPoint.position - transform.position;
	}


	public void Act()
	{
		Debug.Log("act");
		foreach (var p in powers)
		{
			p.TryDo(this);
		}
	}

	public void OnTriggerStay2D(Collider2D collision)
	{
		IsGrounded = true;
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
		IsGrounded = false;
	}


	public void Reset(ActivePower power)
	{
		spriteRenderer.enabled = true;
		collider2D.enabled = true;
		canJump = true;
		health = 100;
		powers.Clear();
		powers.Add(power);
	}

	public void Die()
	{
		spriteRenderer.enabled = false;
		collider2D.enabled = false;
		GameManager.instance.OnDeath(this);
		canJump = true;

		AudioManager.Play("Kill");
	}


	public void Damage(float damage)
	{

		health -= damage;
		if (health <= 0) Die();
	}

}
