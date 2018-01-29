using System;
using UnityEngine;

[Serializable]
public class SpaceshipController
{
	public const float normalSpeed = 15f;
	public const float woundedSpeed = 3f;
	public const float shootRate = 0.5f;
	public int bulletCapacity = 5;

	[Range(0, 100)]
	public float health = 100f;
	public int bulletsLeft = 5;

	private IMovementController movementController;
	private IGunController gunController;

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

	public void ApplyFire()
	{
		if (bulletsLeft > 0 && CanFire())
		{
			lastFireTime = Time.time;
			bulletsLeft--;
			gunController.Fire();
		}
	}

	public void ApplyReload()
	{
		bulletsLeft = bulletCapacity;
	}

	public bool CanFire()
	{
		return (lastFireTime + shootRate) < Time.time;
	}

	public void SetMovementController(IMovementController movementController)
	{
		this.movementController = movementController;
	}
	public void SetGunController(IGunController gunController)
	{
		this.gunController = gunController;
	}
}