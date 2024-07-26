using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        //permitirá hacer referencia a un método que se ejecutará cuando se inicialice la orden
        public delegate void OrderInitialized();
        public delegate void ProcessCompleted();

        public OrderInitialized OnOrderInitialized { get; set; }


        private void Initialize(Order order)
        {
            OnOrderInitialized?.Invoke();
        }

        public void Process(Order order, ProcessCompleted onCompleted = default )
        {
            // Run some code..

            Initialize(order);

            onCompleted?.Invoke();
            // How do I produce a shipping label?
        }
    }
}