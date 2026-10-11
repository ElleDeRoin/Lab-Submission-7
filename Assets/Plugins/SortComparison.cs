using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SortComparison : MonoBehaviour
{
    public TextAsset numbersFile;

    [DllImport("NativeSorter")]
    private static extern void TestSort(int[] a, int length);

    int[] original;

    void Start()
    {
        original = numbersFile.text
            .Split(new[] { '\n', '\r', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Debug.Log($"Loaded {original.Length} numbers, {original.Distinct().Count()} unique");

        for (int round = 1; round <= 5; round++)
        {
            Debug.Log($"--- Round {round} ---");
            TimeIt("Native C++ plugin", arr => TestSort(arr, arr.Length));
            TimeIt("Managed C# plugin", arr => ManagedSorter.Sorter.Sort(arr));
            TimeIt("MonoBehaviour", arr => MySort(arr));
        }
    }

    void MySort(int[] a)
    {
        Array.Sort(a);
    }

    void TimeIt(string label, Action<int[]> sorter)
    {
        int[] copy = (int[])original.Clone();

        Stopwatch sw = Stopwatch.StartNew();
        sorter(copy);
        sw.Stop();

        Debug.Log($"{label} took {sw.Elapsed.TotalMilliseconds:F3} ms (sorted: {IsSorted(copy)})");
    }

    bool IsSorted(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
            if (a[i - 1] > a[i]) return false;
        return true;
    }
}