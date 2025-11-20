using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame(){
        GameManager.Instance.LoadScene(1, "Level 1");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
