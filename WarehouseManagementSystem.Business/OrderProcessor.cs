using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        //permitirá hacer referencia a un método que se ejecutará cuando se inicialice la orden
        public delegate bool OrderInitialized(Order order);
        public delegate void ProcessCompleted(Order order);
        public delegate void ErrorInProcess(Order order);

        public OrderInitialized OnOrderInitialized { get; set; }
        public ErrorInProcess OnErrorInProcess { get; set; }

        private void Initialize(Order order)
        {
            if (OnOrderInitialized?.Invoke(order) == false)
            {
                OnErrorInProcess?.Invoke(order);
            }
        }

        public void Process(Order order, ProcessCompleted onCompleted = default)
        {
            // Run some code..

            Initialize(order);

            onCompleted?.Invoke(order);
            // How do I produce a shipping label?
        }
    }
}