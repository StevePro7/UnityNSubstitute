using NUnit.Framework;
using NSubstitute;

public class SpaceshipMotorTests
{
	[Test]
	public void CannotFireWithNoBullets()
	{
		// Arrange.
		var gunController = GetGunMock();
		var motor = GetControllerMock(gunController);
		motor.bulletsLeft = 0;
		gunController.ClearReceivedCalls();

        // Act.
        const float time = 0.02f;
        motor.ApplyFire(time);

		// Assert.
		gunController.DidNotReceive().Fire();
	}

	private IGunController GetGunMock()
	{
		return Substitute.For<IGunController>();
	}
	private SpaceshipController GetControllerMock(IGunController gunController)
	{
		var motor = Substitute.For<SpaceshipController>();
		//motor.CanFire().Returns(true);			// causes NSubstitute exception
		motor.SetGunController(gunController);
		return motor;
	}

}