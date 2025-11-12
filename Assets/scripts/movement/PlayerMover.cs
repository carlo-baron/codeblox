using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public IMover mover;

    void Start(){
        mover = GetComponent<IMover>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Horizontal")){
            float xDir = Input.GetAxisRaw("Horizontal");        
            mover.Move(xDir, 0);
        }else if(Input.GetButtonDown("Vertical")){
            float yDir = Input.GetAxisRaw("Vertical");        
            mover.Move(0, yDir);
        }
    }
}
