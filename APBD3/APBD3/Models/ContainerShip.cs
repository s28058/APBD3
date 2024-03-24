using System.Text;

namespace APBD3.Models;

public class ContainerShip
{
    public List<Container> Containers { get; } = new List<Container>();
    public double MaxSpeed { get; init; }
    public int MaxContainerCount { get; init; }
    public double MaxContainersWeight { get; init; }

    public void LoadContainer(Container container) => Containers.Add(container);
    
    public void LoadContainers(IEnumerable<Container> container) => Containers.AddRange(container);

    public void RemoveContainer(SerialNumber number) => 
        Containers.RemoveAll(c => c.SerialNumber == number);
    
    public void RemoveContainer(Container container) => 
        Containers.Remove(container);
    
    public void ReplaceContainer(SerialNumber number, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == number);
        if (index != -1)
        {
            Containers[index] = newContainer;
        }
    }
    
    public static void MoveContainers(Container container, ContainerShip sourceShip, ContainerShip destinationShip)
    {
        if (sourceShip.Containers.Contains(container))
        {
            sourceShip.Containers.Remove(container);
            destinationShip.Containers.Add(container);
        }
        else
        {
            throw new InvalidOperationException("Container not found on the source ship.");
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Container Ship Details:");
        sb.AppendLine($"Max Speed: {MaxSpeed} knots");
        sb.AppendLine($"Max Container Count: {MaxContainerCount}");
        sb.AppendLine($"Max Containers Weight: {MaxContainersWeight} kg\n");
        sb.AppendLine("Containers:");

        foreach (var container in Containers)
        {
            sb.AppendLine(container.ToString());
        }

        return sb.ToString();
    }

}