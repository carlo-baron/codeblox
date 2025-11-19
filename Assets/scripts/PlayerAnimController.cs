using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    Animator anim;
    PlayerMover playerMover;
    SpriteRenderer spriteRenderer;

    void Awake(){
        anim = GetComponent<Animator>();
        playerMover = transform.parent.gameObject.GetComponentInChildren<PlayerMover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(playerMover.XDir > 0){
            anim.SetBool("isRight", true);
            spriteRenderer.flipX = false;
        }else if(playerMover.XDir < 0){
            anim.SetBool("isRight", true);
            spriteRenderer.flipX = true;
        }else{
            anim.SetBool("isRight", false);
        }

        if(playerMover.YDir > 0){
            anim.SetBool("isUp", true);
        }else if(playerMover.YDir < 0){
            anim.SetBool("isUp", false);
        }else{
            anim.SetBool("isUp", false);
        }
    }
}
