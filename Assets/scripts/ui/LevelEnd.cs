using UnityEngine;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI endText;

    public void DisplayMessage(bool value){
        string message = value ? "You Win!" : "You Lose!";
        endText.text = message;
    }
}
