using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private SceneLoader sceneLoader;
    public string sceneTransitionMessage = "";

    private int endLevelIndex = 10;

    public bool startCounting;
    private float startTime;
    public float Playtime { get; private set; } = 0;
    public int Restarts { get; private set; }

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

    void Update(){
        if(startCounting){
            startTime = Time.time;
            startCounting = false;
        }
    }

    void EndGame(){
        gameState = GameState.OVER;
        Playtime = Time.time - startTime;
    }

    public void LoadScene(int sceneIndex, string message = ""){
        if(sceneIndex == CurrentSceneIndex) Restarts += 1; 
        if(sceneIndex == endLevelIndex) {
            EndGame();
        }

        sceneTransitionMessage = message;
        if(sceneLoader == null) {
            sceneLoader = FindFirstObjectByType<SceneLoader>();
        }
        sceneLoader.Transition(sceneIndex);
    }
}
