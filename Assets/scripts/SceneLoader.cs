using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private TextMeshProUGUI transitionMessage;

    void Start() {
        transitionMessage.text = GameManager.Instance.sceneTransitionMessage;
        Invoke("ClearMessage", 3f);
    }

    void ClearMessage(){
        transitionMessage.text = "";
        GameManager.Instance.sceneTransitionMessage = "";
        GameManager.Instance.gameState = GameManager.GameState.PLAYING;
    }

    public void Transition(int sceneIndex){
        StartCoroutine(LoadSceneHelper(sceneIndex));
    }

    IEnumerator LoadSceneHelper(int sceneIndex){
        transition.SetTrigger("start");
        GameManager.Instance.gameState = GameManager.GameState.LOADING;

        yield return SceneManager.LoadSceneAsync(sceneIndex);
    }
}

