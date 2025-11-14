using UnityEngine;
using System.Collections.Generic;

public interface IMover
{
    bool CanMove { get; set;}
    void Move(float x, float y);
    Queue<Vector2> Moves { get; }
}
