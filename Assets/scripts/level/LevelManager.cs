using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string goal;
    [SerializeField]
    private TextMeshProUGUI goalTMPro;

    public string Goal => goal;

    void Start(){
        goalTMPro.text = goal;
    }

    public void ResetLevel(){
        int index = GameManager.Instance.CurrentSceneIndex; 
        GameManager.Instance.LoadScene(index, "Level " + index);
    }
}
