using UnityEngine;

public class BloxSlider : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteRenderer;

    public enum Direction {
        LEFT = 0,
        UP = 90,
        RIGHT = 180,
        DOWN = 270
    }

    public Direction direction;

    void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        Vector2 dir = GetDir();
        anim.SetFloat("Vertical", dir.y);
        spriteRenderer.flipX = dir.x <= 0;
    }

    void OnTriggerStay2D(Collider2D other) {
        IMover mover = other.GetComponent<IMover>();
        mover.IsMoving = true;
        if (mover == null) return;

        if (other.transform.position == transform.position) {

            Vector2 dir = GetDir();
            mover.Move(dir.x, dir.y);
        }
    }

    Vector2 GetDir() {
        switch (direction) {
            case Direction.LEFT: return Vector2.left;
            case Direction.RIGHT: return Vector2.right;
            case Direction.UP: return Vector2.up;
            case Direction.DOWN: return Vector2.down;
        }
        return Vector2.zero;
    }
}

