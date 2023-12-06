using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObjectList", menuName = "ScriptableObjects/ChestScriptableObjectList")]
public class ChestScriptableObjectList : ScriptableObject
{
    public ChestScriptableObject[] list;
}