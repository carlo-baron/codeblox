using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public IMover mover;

    void Start(){
        mover = GetComponent<IMover>();
    }

    void Update()
    {
        if(!mover.CanMove) {
            return;
        };

        if(Input.GetButton("Horizontal")){
            float xDir = Input.GetAxisRaw("Horizontal");        
            mover.Move(xDir, 0);
            return;
        }else if(Input.GetButton("Vertical")){
            float yDir = Input.GetAxisRaw("Vertical");        
            mover.Move(0, yDir);
            return;
        }
    }
}
