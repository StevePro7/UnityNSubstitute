using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMotor01 : MonoBehaviour
{
	public GameObject Bullet;
	public GameObject GunMuzzle;

	private void FixedUpdate()
	{
		if (Input.GetButton("Horizontal"))
		{
			Debug.Log("Horizontal");
			float deltaX = Time.fixedDeltaTime * Input.GetAxis("Horizontal") * (health >= 50 ? normalSpeed : woundedSpeed);
			transform.Translate(deltaX, 0, 0);
		}
		if (Input.GetButton("Vertical"))
		{
			Debug.Log("Vertical");
			float deltaY = Time.fixedDeltaTime * Input.GetAxis("Vertical") * (health >= 50 ? normalSpeed : woundedSpeed);
			transform.Translate(0, deltaY, 0);
		}
		if (Input.GetButton("Fire1"))
		{
			// Left ctrl.
			Debug.Log("Fire1");
			if (bulletsLeft > 0 && (lastFireTime + shootRate) < Time.time)
			{
				lastFireTime = Time.time;
				bulletsLeft--;

				var bullet = Instantiate(Bullet, GunMuzzle.transform.position, Quaternion.identity) as GameObject;
				bullet.transform.parent = this.transform.parent;
			}
		}
		if (Input.GetButton("Fire2"))
		{
			// Left alt.
			Debug.Log("Fire2");
			bulletsLeft = bulletCapacity;
		}
	}

	private const int bulletCapacity = 5;
	private const float normalSpeed = 15f;
	private const float shootRate = 0.5f;
	private const float woundedSpeed = 3;

	private int bulletsLeft = 5;
	private float health = 100f;

	private float lastFireTime = float.NegativeInfinity;
}
