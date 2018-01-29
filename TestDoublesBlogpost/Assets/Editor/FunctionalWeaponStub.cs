using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	public class FunctionalWeaponStub : IWeapon
	{
		public void Reload()
		{
		}

		public Shot[] Shoot()
		{
			return new[] { new Shot(0, 0, 0) };
		}
	}
}