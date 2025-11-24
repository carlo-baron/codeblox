using UnityEngine;

public class BloxpointParent : MonoBehaviour
{
    Bloxpoint[] children;
    [SerializeField]
    LevelEnd levelEnd;

    [SerializeField]
    OutputTextController outputTextController;

    void Start(){
        children = GetComponentsInChildren<Bloxpoint>();
    }

    public AudioClip correct;
    public AudioClip incorrect;

    public void Run(){
        bool isCorrect = SyntaxCheck();
        AudioManager.Instance.PlaySFX(isCorrect ? correct : incorrect);
        if(isCorrect){
            levelEnd.gameObject.SetActive(true);
            levelEnd.DisplayMessage(true);
        }
        outputTextController.DisplayMessage(isCorrect);
    }  

    bool SyntaxCheck(){
        foreach(Bloxpoint child in children){
            if(!child.IsProperValue){
                return false;
            }
        }

        return true;
    }
}
