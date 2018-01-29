namespace SpaceTrader
{
	public class Shot
	{
		public Shot(float beamDamage, float physicalDamage, float shieldPenetration)
		{
			BeamDamage = beamDamage;
			PhysicalDamage = physicalDamage;
			ShieldPenetration = shieldPenetration;
		}

		public float BeamDamage { get; private set; }
		public float PhysicalDamage { get; private set; }
		public float ShieldPenetration { get; private set; }
	}
}