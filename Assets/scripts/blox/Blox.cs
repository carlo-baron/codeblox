using UnityEngine;
using TMPro;

public class Blox : MonoBehaviour, IBlox
{
    [SerializeField]
    private BloxData value;

    public BloxData Value => value;

    private TextMeshPro text;

    void Start(){
        text = GetComponent<TextMeshPro>();
        text.text = Value.Keyword;
    }
}
