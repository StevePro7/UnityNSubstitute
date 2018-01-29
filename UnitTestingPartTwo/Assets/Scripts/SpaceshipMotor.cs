using UnityEngine;

public class SpaceshipMotor : MonoBehaviour
{
	public GameObject Bullet;
	public GameObject GunMuzzle;

	private void FixedUpdate()
	{
		if (Input.GetButton("Horizontal"))
		{
			Debug.Log("Horizontal");
			MoveHorizontally(Input.GetAxis("Horizontal"));
		}
		if (Input.GetButton("Vertical"))
		{
			Debug.Log("Vertical");
			MoveVertically(Input.GetAxis("Vertical"));
		}
		if (Input.GetButton("Fire1"))
		{
			// Left ctrl.
			Debug.Log("Fire1");
			if (bulletsLeft > 0 && CanFire())
			{
				lastFireTime = Time.time;
				bulletsLeft--;
				InstantiateBullet();
			}
		}
		if (Input.GetButton("Fire2"))
		{
			// Left alt.
			Debug.Log("Fire2");
			Reload();
		}
	}

	private void MoveHorizontally(float value)
	{
		float deltaX = Time.fixedDeltaTime * value * (health >= 50 ? normalSpeed : woundedSpeed);
		TransformPosition(deltaX, 0f);
	}
	private void MoveVertically(float value)
	{
		float deltaY = Time.fixedDeltaTime * value * (health >= 50 ? normalSpeed : woundedSpeed);
		TransformPosition(0f, deltaY);
	}
	private void TransformPosition(float deltaX, float deltaY)
	{
		transform.Translate(deltaX, deltaY, 0);
	}
	private bool CanFire()
	{
		return (lastFireTime + shootRate) < Time.time;
	}
	private void InstantiateBullet()
	{
		var bullet = Instantiate(Bullet, GunMuzzle.transform.position, Quaternion.identity) as GameObject;
		bullet.transform.parent = this.transform.parent;
	}
	private void Reload()
	{
		bulletsLeft = bulletCapacity;
	}

	private const int bulletCapacity = 5;

	private int bulletsLeft = 5;
	private float health = 100f;

	private float lastFireTime = float.NegativeInfinity;
	private const float normalSpeed = 15f;
	private const float shootRate = 0.5f;
	private const float woundedSpeed = 3;
}
