using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour, IMover
{
    public Queue<Vector2> Moves { get; private set; }
    public bool CanMove { get; set; } = true;
    int CELL_SIZE = 1;

    public void Start(){
        Moves = new Queue<Vector2>();
    }

    public void Move(float x, float y){
        Vector2 newPos = new Vector2(
                transform.position.x + (x * CELL_SIZE),
                transform.position.y + (y * CELL_SIZE)
                );
        Moves.Enqueue(newPos);
        transform.position = newPos;
    }
}
