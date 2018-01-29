using System.Collections.Generic;
using System.Linq;

namespace SpaceTrader.Tests
{
	public class SpaceShipSpy : SpaceShipDummy
	{
		public int HitsCount { get; private set; }

		public override void AcceptIncomingShots(IEnumerable<Shot> round)
		{
			HitsCount += round.Count();
		}
	}
}