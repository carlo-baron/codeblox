using UnityEngine;
using TMPro;

public class OutputTextController : MonoBehaviour
{
    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>(); 
    }

    public void DisplayMessage(bool value){
        string message = value ? "Correct" : "Incorrect";
        tmp.text = message;
    }
}
