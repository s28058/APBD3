using System;
using System.Collections.Generic;
using APBD3;
using APBD3.Exeptions;
using APBD3.Models;

class Program
{
    static void Main()
    {
        SerialNumberGenerator generator = new SerialNumberGenerator();

        // Creating containers
        var liquidContainer1 = new LiquidContainer(2.5, 500, 3, generator.Get(ContainerType.Liquid), 1000, CargoDanger.Safe);
        var gasContainer1 = new GasContainer(2, 300, 2, generator.Get(ContainerType.Gas), 800);
        var coolingContainer1 = new CoolingContainer(2.5, 600, 3, generator.Get(ContainerType.Cooling), 1200, 15);
        
        liquidContainer1.Subscribe(HandleNotification);
        gasContainer1.Subscribe(HandleNotification);
        
        // Loading cargo into containers
        liquidContainer1.LoadCargo(800);
        gasContainer1.LoadCargo(700);
        try
        {
            coolingContainer1.LoadCargo(1000, "bananas", 13.3);
        }
        catch (ProductException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        

        // Creating a container ship
        var containerShip = new ContainerShip
        {
            MaxSpeed = 25,
            MaxContainerCount = 10,
            MaxContainersWeight = 15000
        };

        // Loading containers onto the ship
        containerShip.LoadContainer(liquidContainer1);
        containerShip.LoadContainer(gasContainer1);
        containerShip.LoadContainer(coolingContainer1);

        // Displaying information about containers on the ship
        Console.WriteLine(containerShip);

        // Trying to overload cargo into a container
        try
        {
            liquidContainer1.LoadCargo(300);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Removing a container from the ship
        containerShip.RemoveContainer(liquidContainer1.SerialNumber);

        // Displaying information about containers on the ship again
        Console.WriteLine(containerShip);

        // Moving a container between ships
        var newContainerShip = new ContainerShip
        {
            MaxSpeed = 30,
            MaxContainerCount = 15,
            MaxContainersWeight = 20000
        };

        ContainerShip.MoveContainers(gasContainer1, containerShip, newContainerShip);

        // Displaying information about the previous new ship and its cargo
        Console.WriteLine(newContainerShip);
        Console.WriteLine(containerShip);
        
        void HandleNotification(HazardNotification notification)
        {
            var (message, containerNumber) = notification;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("HAZARD:");
            Console.ResetColor();
            Console.WriteLine(message);
            Console.WriteLine($"In container: {containerNumber}\n");
        }
    }
}
