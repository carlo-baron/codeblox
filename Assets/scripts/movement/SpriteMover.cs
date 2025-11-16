using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    [SerializeField]
    private GameObject movePoint;
    [SerializeField]
    private float speed = 5f;
    private IMover movePointMover;

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

            if((Vector2)transform.position == targetPos){
                movePointMover.Moves.Dequeue();
                movePointMover.CanMove = true;
            }
        }
    }
}
