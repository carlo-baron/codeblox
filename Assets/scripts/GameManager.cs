using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private SceneLoader sceneLoader;
    public string sceneTransitionMessage = "";

    public int CurrentSceneIndex {
        get {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }

    public enum GameState{
        LOADING,
        PLAYING,
        OVER
    }
    public GameState gameState;

    void Awake(){
        sceneLoader = FindFirstObjectByType<SceneLoader>();
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        gameState = GameState.PLAYING;
    }

    public void LoadScene(int sceneIndex, string message = ""){
        sceneTransitionMessage = message;
        if(sceneLoader == null) {
            sceneLoader = FindFirstObjectByType<SceneLoader>();
        }
        sceneLoader.Transition(sceneIndex);
    }
}
