using System.Diagnostics;
using UnityEngine;

public class FunctionTimer : MonoBehaviour
{
    void Start()
    {
        MeasureFunctionExecutionTime();
    }

    void MeasureFunctionExecutionTime()
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start(); // Start timing
        MyFunctionToTest(); // Call the function you want to measure
        stopwatch.Stop();  // Stop timing

        // Get the elapsed time
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log($"MyFunctionToTest took {elapsedMilliseconds} ms to execute.");
    }

    void MyFunctionToTest()
    {
        //TestSort(a, a.Length); //Make sure you have the code that imports your native DLL and populates the array somewhere
    }
}