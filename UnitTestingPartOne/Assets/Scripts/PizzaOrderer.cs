public class PizzaOrderer
{
	public PizzaOrderer(IPaymentValidator paymentValidator, IServerConnector serverConnector)
	{
		this.paymentValidator = paymentValidator;
		this.serverConnector = serverConnector;
	}

	public void MakeOrder(string pizzaName)
	{
		if (paymentValidator.IsPaymentAccepted())
		{
			serverConnector.SendRequestForPizza(pizzaName);
		}
	}

	private IPaymentValidator paymentValidator;
	private IServerConnector serverConnector;
}