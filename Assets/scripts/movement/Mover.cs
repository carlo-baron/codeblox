using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour, IMover
{
    [SerializeField]
    private MoveableData movableData;

    [SerializeField]
    private bool isMoving = false;
    public bool IsMoving => isMoving;
    private Vector2 originalPosition, targetPosition;
    [SerializeField]
    private float timeToMove = 0.2f;
    private float directionScalar = 1;

    void Start(){
        directionScalar = transform.parent.localScale.x;
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

        StartCoroutine(MoveCharacter(dir));
        return true;
    }

    IEnumerator MoveCharacter(Vector2 dir){
        isMoving = true;

        float elapsedTime = 0;

        originalPosition = transform.position;
        targetPosition = originalPosition + (dir * directionScalar);

        while(elapsedTime < timeToMove){
            transform.position = Vector2.Lerp(originalPosition, targetPosition, elapsedTime/timeToMove);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
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
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, .7f, movableData.obstructionLayers);

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

