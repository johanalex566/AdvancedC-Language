using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

    /*
     *Queremos proporcionar a los consumidores de la capa empresarial
     *Una forma de ejecutar su propio código cuando se inicialice un pedido
     *y cuando se complet el procesamiento del pedido.
     *
     *Un delegado es un tipo que representa referencias a métodos.
     *Se usa cuando necesitas un callback o recibir una devolución de llamada cuandose completea una operación.
     *
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

processor.Process(order, SendConfirmationEmail);


void SendMessageToWarehouse()
{
    Console.WriteLine("Please pack the order");
}

void SendConfirmationEmail()
{
    Console.WriteLine("Order Confirmation Email");
}