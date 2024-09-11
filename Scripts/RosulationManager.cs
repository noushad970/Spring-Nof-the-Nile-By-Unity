using UnityEngine;

public class RosulationManager : MonoBehaviour
{
    void Start()
    {
        AdjustResolutionBasedOnDevice();
    }

    void AdjustResolutionBasedOnDevice()
    {
        int memory = SystemInfo.systemMemorySize;
        int processorCount = SystemInfo.processorCount;
        string graphicsDeviceName = SystemInfo.graphicsDeviceName;

        // Example logic: Adjust based on memory size and graphics device name
        if (memory <= 2048 || graphicsDeviceName.Contains("Adreno 3xx"))
        {
            SetResolution(854, 480); // Low resolution for low-end devices
        }
        else if (memory <= 4096)
        {
            SetResolution(1280, 720); // Medium resolution for mid-range devices
        }
        else
        {
            SetResolution(1920, 1080); // High resolution for high-end devices
        }
    }

    void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, true);
    }
}
