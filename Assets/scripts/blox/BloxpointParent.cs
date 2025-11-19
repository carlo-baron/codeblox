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

    public void Run(){
        bool isCorrect = SyntaxCheck();
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
