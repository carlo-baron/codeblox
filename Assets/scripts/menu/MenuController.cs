using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject settings;

    public void StartGame(){
        GameManager.Instance.LoadScene(1, "Level 1");
        GameManager.Instance.startCounting = true;
    }

    public void Settings(){
        settings.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
