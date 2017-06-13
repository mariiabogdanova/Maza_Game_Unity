using UnityEngine;
using System.Collections;

public class ProceduralNumberGenerator
{
    public static int currentPosition = 0;
    public const string key = "124423213412341234444431243243122142341321344221";

    public static int GetNextNumber()
    {
        string currentNum = key.Substring(currentPosition++ % key.Length, 1);
        return int.Parse(currentNum);
    }
}
//123424123342421432233144441212334432121223344