namespace Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly int _amount;

        public ProductCommand(Product product, PriceAction action, int amount)
        {
            _product = product;
            _priceAction = action;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (_priceAction == PriceAction.Increase)
            {
                _product.IncreasePrice(_amount);
            }
            else if(_priceAction == PriceAction.Decrease)
            {
                _product.DecreasePrice(_amount);
            }
        }
    }
}
