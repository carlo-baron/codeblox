using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public IMover mover;

    void Start(){
        mover = GetComponent<IMover>();
    }

    public float XDir { get; private set;}
    public float YDir { get; private set;}

    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.LOADING || GameManager.Instance.gameState == GameManager.GameState.OVER) return;

        XDir = Input.GetAxisRaw("Horizontal");        
        YDir = Input.GetAxisRaw("Vertical");        

        if(!mover.CanMove) {
            return;
        };

        if(Input.GetButton("Horizontal")){
            mover.Move(XDir, 0);
            return;
        }else if(Input.GetButton("Vertical")){
            mover.Move(0, YDir);
            return;
        }
    }
}
