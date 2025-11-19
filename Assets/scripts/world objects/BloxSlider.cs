using UnityEngine;

public class BloxSlider : MonoBehaviour
{
    public enum Direction{
        LEFT = 0,
        UP = 90,
        RIGHT = 180,
        DOWN = 270
    }

    public Direction direction;

    void Start(){
        transform.Rotate(0, 0, (float)direction);
    }

    void OnTriggerEnter2D(Collider2D other){
        IMover mover = other.gameObject.GetComponent<IMover>();
        if(mover == null) return;
        Vector2 dir = GetDir();
        mover.Move(dir.x, dir.y); 
    }

    Vector2 GetDir(){
        switch(direction){
            case Direction.LEFT:
                return Vector2.left;
            case Direction.RIGHT:
                return Vector2.right;
            case Direction.UP:
                return Vector2.up;
            case Direction.DOWN:
                return Vector2.down;
            default:
                return Vector2.zero;
        }
    }
}
