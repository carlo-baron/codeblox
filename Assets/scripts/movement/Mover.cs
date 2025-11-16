using UnityEngine;
using System.Collections.Generic;

public class Mover : MonoBehaviour, IMover
{
    public Queue<Vector2> Moves { get; private set; }
    public bool CanMove { get; set; } = true;
    int CELL_SIZE = 1;

    public void Start()
    {
        Moves = new Queue<Vector2>();
    }

    public bool Move(float x, float y)
    {
        x = Mathf.Clamp(x, -1, 1);
        y = Mathf.Clamp(y, -1, 1);

        Vector2 dir = new Vector2(x, y);

        RaycastHit2D hit = Obstruction(dir);

        if (hit.collider)
        {
            bool isObstructionMoved = TryMoveObstruction(hit.collider.gameObject, dir);
            if(!isObstructionMoved){
                return false;
            }
        }

        Vector2 newPos = new Vector2(
            transform.position.x + (x * CELL_SIZE),
            transform.position.y + (y * CELL_SIZE)
        );

        Moves.Enqueue(newPos);
        transform.position = newPos;

        return true;
    }

    private bool TryMoveObstruction(GameObject hit, Vector2 dir)
    {
        IMover movable = hit.GetComponentInChildren<IMover>();
        if (movable != null){
            return movable.Move(dir.x, dir.y);
        }
        return false;
    }

    private RaycastHit2D Obstruction(Vector2 dir)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, 1f);

        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.transform != transform)
            {
                return hit;
            }
        }

        return new RaycastHit2D();
    }
}

