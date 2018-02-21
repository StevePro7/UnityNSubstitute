using UnityEngine;

public class SpaceshipMonoBehaviour : MonoBehaviour, IMovementController, IGunController
{
	public GameObject BulletPrefab;
	public GameObject GunMuzzlePrefab;
	public SpaceshipController controller;


	[Range(0, 100)]
	public float health = 100f;
	public int bulletCapacity = 5;
	public int bulletsLeft = 5;

	private void OnEnable()
	{
		controller.SetMovementController(this);
		controller.SetGunController(this);

		controller.SetHealth(health);
		controller.SetBulletCapacity(bulletCapacity);
		controller.SetBulletsLeft(bulletsLeft);
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
			controller.ApplyFire(Time.deltaTime);
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
		var bullet = Instantiate(BulletPrefab, GunMuzzlePrefab.transform.position, Quaternion.identity) as GameObject;
		bullet.transform.parent = this.transform.parent;
	}
	#endregion

}
