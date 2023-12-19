using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObjectList", menuName = "ScriptableObjects/ChestScriptableObjectList")]
public class ChestScriptableObjectList : ScriptableObject
{
    public ChestScriptableObject[] list;
}