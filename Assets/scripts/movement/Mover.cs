using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Mover : MonoBehaviour, IMover
{
    public Queue<Vector2> Moves { get; private set; }
    public bool CanMove { get; set; } = true;
    int CELL_SIZE = 1;

    public void Start()
    {
        Moves = new Queue<Vector2>();
    }

    public void Move(float x, float y)
    {
        x = Mathf.Clamp(x, -1, 1);
        y = Mathf.Clamp(y, -1, 1);

        Vector2 dir = new Vector2(x, y);

        RaycastHit2D hit = Obstruction(dir);

        if (hit.collider && hit.collider.gameObject != gameObject)
        {
            TryMoveObstruction(hit.collider.gameObject, dir);
            return;
        }

        Vector2 newPos = new Vector2(
            transform.position.x + (x * CELL_SIZE),
            transform.position.y + (y * CELL_SIZE)
        );

        Moves.Enqueue(newPos);
        transform.position = newPos;
    }

    private void TryMoveObstruction(GameObject hit, Vector2 dir)
    {
        IMover movable = hit.GetComponentInChildren<IMover>();
        if (movable != null){
            movable.Move(dir.x, dir.y);
        }
    }

    private RaycastHit2D Obstruction(Vector2 dir)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, 1f);

        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.transform != transform)
            {
                print(transform.parent.name + ": " + hit.collider.transform.name);
                return hit;
            }
        }

        return new RaycastHit2D();
    }
}

