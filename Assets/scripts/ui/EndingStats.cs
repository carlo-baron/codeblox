using UnityEngine;
using TMPro;
using System;

public class EndingStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    void Start()
    {
        int restarts = GameManager.Instance.Restarts;
        float playtime = GameManager.Instance.Playtime;

        TimeSpan time = TimeSpan.FromSeconds(playtime);

        text.text += $"x{restarts} Restarts\n" + time.ToString(@"hh\:mm\:ss") + " Playtime";
    }

    public void BackToMenu(){
        GameManager.Instance.LoadScene(0); 
    }
}
