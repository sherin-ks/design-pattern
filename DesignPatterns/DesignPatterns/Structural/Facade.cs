using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural;

// Subsystem 1: Virtual Machine Management
public class VirtualMachineManager
{
    public void StartVM(string vmId) => Console.WriteLine($"Starting virtual machine: {vmId}");
    public void StopVM(string vmId) => Console.WriteLine($"Stopping virtual machine: {vmId}");
}

// Subsystem 2: Storage Management
public class StorageManager
{
    public void AllocateStorage(string storageId, int size)
    {
        Console.WriteLine($"Allocating {size}GB to storage: {storageId}");
    }

    public void ReleaseStorage(string storageId)
    {
        Console.WriteLine($"Releasing storage: {storageId}");
    }
}

// Subsystem 3: Networking Management
public class NetworkManager
{
    public void ConfigureNetwork(string networkId)
    {
        Console.WriteLine($"Configuring network: {networkId}");
    }
}

// Facade: Cloud Resource Manager
public class CloudResourceManager
{
    private readonly VirtualMachineManager _vmManager = new();
    private readonly StorageManager _storageManager = new();
    private readonly NetworkManager _networkManager = new();

    public void StartApplication(string appId)
    {
        Console.WriteLine($"Starting application: {appId}");
        _vmManager.StartVM(appId);
        _storageManager.AllocateStorage($"{appId}-storage", 100);
        _networkManager.ConfigureNetwork($"{appId}-network");
    }

    public void StopApplication(string appId)
    {
        Console.WriteLine($"Stopping application: {appId}");
        _vmManager.StopVM(appId);
        _storageManager.ReleaseStorage($"{appId}-storage");
    }
}

