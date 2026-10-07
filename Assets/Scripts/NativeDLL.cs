using UnityEngine;
using System.Runtime.InteropServices;

public class NativeDLL : MonoBehaviour
{

    [DllImport("NativeDLL", EntryPoint = "Sort")]
    public static extern void Sort(int[] a, int length);

    public int[] a;

    void Start()
    {
        Sort(a, a.Length);
    }
}