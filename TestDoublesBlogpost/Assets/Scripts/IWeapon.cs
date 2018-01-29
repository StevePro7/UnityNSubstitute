namespace SpaceTrader
{
	public interface IWeapon
	{
		Shot[] Shoot();
		void Reload();
	}
}