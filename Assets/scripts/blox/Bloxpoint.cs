using UnityEngine;

public class Bloxpoint : MonoBehaviour
{
    [SerializeField]
    private string properValue;

    public bool IsProperValue {
        get{
            return BloxKeyword == properValue; 
        }
        private set {}
    }

    private string BloxKeyword = "";

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("blox")){
            BloxData bloxData = other.transform.parent.gameObject.GetComponentInChildren<IBlox>().Value;
            BloxKeyword = bloxData.Keyword;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        BloxKeyword = "";
    }
}
