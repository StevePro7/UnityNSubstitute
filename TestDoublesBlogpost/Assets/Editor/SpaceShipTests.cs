using NUnit.Framework;
using NSubstitute;

namespace SpaceTrader.Tests
{
	public class SpaceShipTests
	{
		[Test]
		public void SpaceShipShootsAtLeastOneShot_WhenFunctionalWeaponIsEquiped()
		{
			// Arrange.
			var spaceShip = SpaceShipWithSingleWeaponSlot();
			spaceShip.Equip(new FunctionalWeaponStub());

			// Act.
			var round = spaceShip.Shoot();

			// Assert.
			bool roundContainsOneShot = 1 == round.Length;
			Assert.True(roundContainsOneShot);
		}

		[Test]
		public void SpaceShipShootsAtLeastOneShot_WhenFunctionalWeaponIsEquiped2()
		{
			// Arrange.
			var spaceShip = SpaceShipWithSingleWeaponSlot();

			var functionalWeaponStub = Substitute.For<IWeapon>();
			functionalWeaponStub.Shoot().Returns(new[] { new Shot(0, 0, 0) });
			spaceShip.Equip(functionalWeaponStub);

			// Act.
			var round = spaceShip.Shoot();

			// Assert.
			bool roundContainsOneShot = 1 == round.Length;
			Assert.True(roundContainsOneShot);
		}

		[Test]
		public void NoWeaponSlotsAvailable_AfterWeaponIsEquiped()
		{
			// Arrange.
			var spaceShip = SpaceShipWithSingleWeaponSlot();
			IWeapon weapon = new DummyWeapon();

			// Act.
			spaceShip.Equip(weapon);

			// Assert.
			bool noWeaponSlotsAvailable = 0 == spaceShip.AvailableWeaponSlots;
			Assert.True(noWeaponSlotsAvailable);
		}

		[Test]
		public void EachWeaponShoots_WhenSpaceShipShootIsCalled()
		{
			// Arrange.
			var weapon1 = Substitute.For<IWeapon>();
			var weapon2 = Substitute.For<IWeapon>();

			var spaceShip = new SpaceShip(2, 0);
			spaceShip.Equip(weapon1);
			spaceShip.Equip(weapon2);

			// Act.
			spaceShip.Shoot();

			// Assert.
			weapon1.Received(1).Shoot();
			weapon2.Received(1).Shoot();
		}

		[Test]
		public void EachWeaponShoots_WhenSpaceShipShootIsCalled2()
		{
			// Arrange.
			var weapon1 = Substitute.For<IWeapon>();
			var weapon2 = Substitute.For<IWeapon>();

			var spaceShip = new SpaceShip(2, 0);
			spaceShip.Equip(weapon1);
			spaceShip.Equip(weapon2);

			// Act.
			spaceShip.Shoot();

			// Assert.
			Received.InOrder(() =>
			{
				weapon1.Shoot();
				weapon2.Shoot();
				weapon1.Reload();
				weapon2.Reload();
			});
		}

		[Test]
		public void NoWeaponSlotsAvailable_AfterWeaponIsEquiped2()
		{
			// Arrange.
			SpaceShip spaceShip = SpaceShipWithSingleWeaponSlot();
			IWeapon weapon = NSubstitute.Substitute.For<IWeapon>();

			// Act.
			spaceShip.Equip(weapon);

			// Assert.
			bool noWeaponSlotsAvailable = 0 == spaceShip.AvailableWeaponSlots;
			Assert.True(noWeaponSlotsAvailable);
		}


		private static SpaceShip SpaceShipWithSingleWeaponSlot()
		{
			return new SpaceShip(1, 0);

		}

	}
}