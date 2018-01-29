using System;
using System.Collections.Generic;

namespace SpaceTrader.Tests
{
	public class SpaceShipDummy : ISpaceShip
	{
		public virtual void AcceptIncomingShots(IEnumerable<Shot> round)
		{
		}

		public bool CanEquip(IWeapon weapon)
		{
			return default(bool);
		}

		public void Equip(IWeapon weapon)
		{
		}

		public void ReloadWeapons()
		{
		}

		public Shot[] Shoot()
		{
			return null;
		}

		public int AvailableWeaponSlots
		{
			get
			{
				return default(int);
			}
		}

		public float Evasion
		{
			get
			{
				return default(int);
			}
		}

		public int WeaponSlots
		{
			get
			{
				return default(int);
			}
		}

	}
}