using APBD3;
using APBD3.Models;

var serialNumberGenerator = new SerialNumberGenerator();

var containerNumber = serialNumberGenerator.Get(ContainerType.Liquid);
var liquidContainer = new LiquidContainer(100, 20, 10, containerNumber, 100, CargoDanger.Hazardous);

liquidContainer.Subscribe(HandleNotification);

liquidContainer.LoadCargo(80);

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