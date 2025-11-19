using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
