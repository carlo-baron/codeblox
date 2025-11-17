using UnityEngine;

[CreateAssetMenu(fileName = "MoveableData", menuName = "Scriptable Objects/MoveableData")]
public class MoveableData : ScriptableObject
{
    public int CELL_SIZE = 1;    
    public LayerMask obstructionLayers; 
}
