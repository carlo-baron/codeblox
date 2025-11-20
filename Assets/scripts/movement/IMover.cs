using UnityEngine;
using System.Collections.Generic;

public interface IMover
{
    bool Move(float x, float y);
    bool IsMoving { get; set; }
}
