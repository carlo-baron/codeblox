using UnityEngine;
using System.Collections.Generic;

public class Mover : MonoBehaviour, IMover
{
    public Queue<Vector2> Moves { get; private set; }
    public bool CanMove { get; set; } = true;
    int CELL_SIZE = 1;

    public void Start(){
        Moves = new Queue<Vector2>();
    }

    public void Move(float x, float y){
        x = Mathf.Clamp(x, -1, 1);
        y = Mathf.Clamp(y, -1, 1);

        if(Obstructed(x, y)) return;

        Vector2 newPos = new Vector2(
                transform.position.x + (x * CELL_SIZE),
                transform.position.y + (y * CELL_SIZE)
                );
        Moves.Enqueue(newPos);
        transform.position = newPos;
    }

    private bool Obstructed(float x, float y){
        Vector2 dir = new Vector2(x, y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1);
        
        return hit;
    }
}
