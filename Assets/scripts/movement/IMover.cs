using UnityEngine;
using System.Collections.Generic;

public interface IMover
{
    bool CanMove { get; set;}
    bool Move(float x, float y);
    Queue<Vector2> Moves { get; }
}
