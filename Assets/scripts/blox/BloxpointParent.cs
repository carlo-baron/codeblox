using UnityEngine;

public class BloxpointParent : MonoBehaviour
{
    Bloxpoint[] children;
    [SerializeField]
    LevelEnd levelEnd;

    void Start(){
        children = GetComponentsInChildren<Bloxpoint>();
    }

    public void Run(){
        bool isCorrect = SyntaxCheck();
        print(isCorrect);
        if(isCorrect){
            levelEnd.gameObject.SetActive(true);
            levelEnd.DisplayMessage(true);
        }
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
