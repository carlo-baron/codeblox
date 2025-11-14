using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    [SerializeField]
    private GameObject movePoint;
    [SerializeField]
    private float speed = 5f;
    private IMover movePointMover;
    [SerializeField]
    private float distanceThreshold = 0.05f;

    void Start(){
        movePointMover = movePoint.GetComponent<IMover>();
    }

    void Update()
    {
        if(movePointMover.Moves.Count != 0){
            movePointMover.CanMove = false;
            Vector2 targetPos = movePointMover.Moves.Peek();
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPos,
                Time.deltaTime * speed
            );

            float distance = Vector2.Distance((Vector2)transform.position, targetPos);
            if(distance <= distanceThreshold){
                movePointMover.CanMove = true;
            }

            if((Vector2)transform.position == targetPos){
                movePointMover.Moves.Dequeue();
            }
        }
    }
}
