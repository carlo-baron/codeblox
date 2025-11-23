using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public IMover mover;
    bool allowInput = true;

    void Start(){
        mover = GetComponent<IMover>();
    }

    public float XDir { get; private set;}
    public float YDir { get; private set;}

    void Update()
    {
        if(GameManager.Instance && (GameManager.Instance.gameState == GameManager.GameState.LOADING || GameManager.Instance.gameState == GameManager.GameState.OVER)) return;
        if(mover.IsMoving) return;
        if(!allowInput) return;

        XDir = Input.GetAxisRaw("Horizontal");        
        YDir = Input.GetAxisRaw("Vertical");        

        if(Input.GetButton("Horizontal")){
            mover.Move(XDir, 0);
            return;
        }else if(Input.GetButton("Vertical")){
            mover.Move(0, YDir);
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("slider")){
            allowInput = false;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        allowInput = true;
    }
}
