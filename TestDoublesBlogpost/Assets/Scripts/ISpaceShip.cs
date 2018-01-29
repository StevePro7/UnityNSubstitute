using System.Collections.Generic;

namespace SpaceTrader
{
	public interface ISpaceShip
	{
		// Methods
		bool CanEquip(IWeapon weapon);
		void Equip(IWeapon weapon);
		Shot[] Shoot();
		void ReloadWeapons();
		void AcceptIncomingShots(IEnumerable<Shot> round);

		// Properties
		int WeaponSlots { get; }
		int AvailableWeaponSlots { get; }
		float Evasion { get; }
	}
}