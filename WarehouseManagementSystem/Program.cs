using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

/*
 *Queremos proporcionar a los consumidores de la capa empresarial
 *Una forma de ejecutar su propio código cuando se inicialice un pedido
 *y cuando se complet el procesamiento del pedido.
 *
 *Un delegado es un tipo que representa referencias a métodos.
 *Se usa cuando necesitas un callback o recibir una devolución de llamada cuandose completea una operación.
 */

var order = new Order
{
    LineItems = new[] {
    new Item { Name ="PS1", Price =50},
    new Item { Name ="PS2", Price =60},
    new Item { Name ="PS3", Price =70},
    new Item { Name ="PS4", Price =80}
    }

};

var processor = new OrderProcessor();

processor.OnOrderInitialized = SendMessageToWarehouse; //Estamos señalando el método para delegar el trabajo

processor.OnErrorInProcess = ErrorInProcess;

processor.Process(order, SendConfirmationEmail);


bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");

    return false;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Order Confirmation Email {order.OrderNumber}");
}


void ErrorInProcess(Order order)
{
    Console.WriteLine($"Error procesing de order {order.OrderNumber}");
}
