using UnityEngine;

public class Bloxpoint : MonoBehaviour
{
    public string BloxKeyword { get; private set; } = "";

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("blox")){
            print("A blox has entered the zone");
            BloxData bloxData = other.transform.parent.gameObject.GetComponentInChildren<IBlox>().Value;
            BloxKeyword = bloxData.Keyword;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        print("A blox has exited the zone");
        BloxKeyword = "";
    }
}
