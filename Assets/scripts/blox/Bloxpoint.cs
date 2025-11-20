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

    public string BloxKeyword { get; private set; } = "";
    private Collider2D currentBlock;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("blox")){
            IBlox bloxData = other.transform.parent.gameObject.GetComponentInChildren<IBlox>();
            if(bloxData == null) return;

            currentBlock = other;
            BloxKeyword = bloxData.Value.Keyword;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other == currentBlock){
            BloxKeyword = "";
            currentBlock = null;
        }
    }
}
