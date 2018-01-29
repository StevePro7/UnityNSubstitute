using System;
using UnityEngine;

public class SpaceshipMotor : MonoBehaviour, IMovementController, IGunController
{
	public GameObject Bullet;
	public GameObject GunMuzzle;
	public SpaceshipController controller;

	private void OnEnable()
	{
		controller.SetMovementController(this);
		controller.SetGunController(this);
	}

	private void FixedUpdate()
	{
		if (Input.GetButton("Horizontal"))
		{
			Debug.Log("Horizontal");
			controller.MoveHorizontally(Input.GetAxis("Horizontal"));
		}
		if (Input.GetButton("Vertical"))
		{
			Debug.Log("Vertical");
			controller.MoveVertically(Input.GetAxis("Vertical"));
		}
		if (Input.GetButton("Fire1"))
		{
			// Left ctrl.
			Debug.Log("Fire1");
			controller.ApplyFire();
		}
		if (Input.GetButton("Fire2"))
		{
			// Left alt.
			Debug.Log("Fire2");
			controller.ApplyReload();
		}
	}

	#region IMovementController implmentation.
	public void MoveHorizontally(float value)
	{
		float deltaX = Time.fixedDeltaTime * value;
		transform.Translate(deltaX, 0, 0);
	}
	public void MoveVertically(float value)
	{
		float deltaY = Time.fixedDeltaTime * value;
		transform.Translate(0, deltaY, 0);
	}
	#endregion

	#region IGunController implmentation.
	public void Fire()
	{
		var bullet = Instantiate(Bullet, GunMuzzle.transform.position, Quaternion.identity) as GameObject;
		bullet.transform.parent = this.transform.parent;
	}
	#endregion

}
