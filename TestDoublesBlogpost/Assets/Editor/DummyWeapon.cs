using System;
using SpaceTrader;

namespace SpaceTrader.Tests
{
	public class DummyWeapon : IWeapon
	{
		public Shot[] Shoot()
		{
			return null;
		}

		public void Reload()
		{
			throw new NotImplementedException();
		}

	}
}