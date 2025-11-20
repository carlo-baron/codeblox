using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private SceneLoader sceneLoader;
    public string sceneTransitionMessage = "";

    public enum GameState{
        LOADING,
        PLAYING,
        OVER
    }
    public GameState gameState;

    void Awake(){
        gameState = GameState.PLAYING;
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScene(int sceneIndex, string message = ""){
        print("Load");
        sceneTransitionMessage = message;
        if(sceneLoader == null) {
            sceneLoader = FindFirstObjectByType<SceneLoader>();
        }
        sceneLoader.Transition(sceneIndex);
    }
}
