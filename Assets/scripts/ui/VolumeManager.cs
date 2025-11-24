using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;

    void Start()
    {
        float musicValue = AudioManager.Instance.musicVolume;
        float sfxValue = AudioManager.Instance.sfxVolume;

        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;
    }

    void Update()
    {
        UpdateTextLabel(); 
        AudioManager.Instance.musicVolume = musicSlider.value;
        AudioManager.Instance.sfxVolume = sfxSlider.value;
        AudioManager.Instance.ApplyVolumes();
    }

    void UpdateTextLabel(){
        musicText.text = (int)(musicSlider.value * 100)+"%";
        sfxText.text = (int)(sfxSlider.value * 100)+"%";
    }

    public void Back(){
        gameObject.SetActive(false);
    }
}
