using APBD3.Models;

var containerNumber = new SerialNumber(ContainerType.Liquid, 1);
var container = new LiquidContainer(100, 20, 10, containerNumber, 100, CargoDanger.Hazardous);

container.Subscribe(HandleNotification);

container.LoadCargo(80);

Console.WriteLine("I'm done :D");

void HandleNotification(HazardNotification notification)
{
    var (message, containerNumber) = notification;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("HAZARD:");
    Console.ResetColor();
    Console.WriteLine(message);
    Console.WriteLine($"In container: {containerNumber}\n");
}