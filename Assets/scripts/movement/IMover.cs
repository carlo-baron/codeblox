using UnityEngine;
using System.Collections.Generic;

public interface IMover
{
    void Move(float x, float y);
    Queue<Vector2> Moves { get; }
}
