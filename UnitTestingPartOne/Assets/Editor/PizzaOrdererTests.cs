using NUnit.Framework;
using NSubstitute;

public class PizzaOrderTests
{
	private const string PIZZA_NAME = "Unity pizza with extra cheese";

	[Test]
	public void OrderedSuccessfully()
	{
		// Arrange.
		IPaymentValidator paymentValidatorMock = GetValidatorMock();
		IServerConnector connectorMock = GetConnectorMock();
		var pizzaOrderer = new PizzaOrderer(paymentValidatorMock, connectorMock);

		// Act.
		pizzaOrderer.MakeOrder(PIZZA_NAME);

		// Assert.
		connectorMock.Received(1).SendRequestForPizza(Arg.Any<string>());
	}

	private IPaymentValidator GetValidatorMock()
	{
		var mock = Substitute.For<IPaymentValidator>();
		mock.IsPaymentAccepted().Returns(true);
		return mock;
	}

	private IServerConnector GetConnectorMock()
	{
		return Substitute.For<IServerConnector>();
	}

}