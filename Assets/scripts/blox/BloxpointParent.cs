using UnityEngine;

public class BloxpointParent : MonoBehaviour
{
    Bloxpoint[] children;

    void Awake(){
        children = GetComponentsInChildren<Bloxpoint>();
    }

    public void Run(){
        print(GetBloxValueString());
    }  

    string GetBloxValueString(){
        string result = "";
        foreach(Bloxpoint child in children){
            result += child.BloxKeyword;
        }

        return result;
    }
}
