using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    [SerializeField]
    private TextMeshProUGUI transitionMessage;

    void Start(){
        transitionMessage.text = GameManager.Instance.sceneTransitionMessage;
    }

    public void Transition(int sceneIndex){
        StartCoroutine(LoadSceneHelper(sceneIndex));
    }

    IEnumerator LoadSceneHelper(int sceneIndex){
        transition.SetTrigger("start");
        GameManager.Instance.gameState = GameManager.GameState.LOADING;

        yield return new WaitForSeconds(1);

        GameManager.Instance.gameState = GameManager.GameState.PLAYING;
        SceneManager.LoadScene(sceneIndex);
    }
}
