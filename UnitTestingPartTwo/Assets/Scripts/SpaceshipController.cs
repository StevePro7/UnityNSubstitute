using System;

[Serializable]
public class SpaceshipController
{
	private IMovementController movementController;
	private IGunController gunController;

	// Injected variables from behavior
	private float health = 100f;
	private int bulletCapacity;
	private int bulletsLeft = 5;


	private const float normalSpeed = 15f;
	private const float woundedSpeed = 3f;
	private const float shootRate = 0.5f; 
	private float lastFireTime = float.NegativeInfinity;

	public void MoveHorizontally(float value)
	{
		movementController.MoveHorizontally(value * GetSpeed());
	}
	public void MoveVertically(float value)
	{
		movementController.MoveVertically(value * GetSpeed());
	}
	private float GetSpeed()
	{
		return health >= 50 ? normalSpeed : woundedSpeed;
	}

	public void ApplyFire(float time)
    {
		if (bulletsLeft > 0 && CanFire(time))
		{
			lastFireTime = time;
			bulletsLeft--;
			gunController.Fire();
		}
	}

	public void ApplyReload()
	{
		bulletsLeft = bulletCapacity;
	}

	public bool CanFire(float time)
	{
		return (lastFireTime + shootRate) < time;
	}

	public void SetMovementController(IMovementController movementController)
	{
		this.movementController = movementController;
	}
	public void SetGunController(IGunController gunController)
	{
		this.gunController = gunController;
	}

	public void SetHealth(float health)
	{
		this.health = health;
	}
	public void SetBulletCapacity(int bulletCapacity)
	{
		this.bulletCapacity = bulletCapacity;
	}
	public void SetBulletsLeft(int bulletsLeft)
	{
		this.bulletsLeft = bulletsLeft;
	}
}