using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private AnimationCurve percentToDecibells;
    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        sfxVolume.value = PlayerPrefs.GetFloat("_sfxVolume", 1);
        musicVolume.value = PlayerPrefs.GetFloat("_musicVolume", 1);
    }

    private void OnDestroy()
    {
        SaveSettings();
    }
    
    

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("_sfxVolume", sfxVolume.value);
        PlayerPrefs.SetFloat("_musicVolume", musicVolume.value);
    }
    
    public void OnSFXVolumeChange(float newVolume)
    {
        audioMixer.SetFloat("_volumeSFX", percentToDecibells.Evaluate(newVolume));
    }
    
    public void OnMusicVolumeChange(float newVolume)
    {
        audioMixer.SetFloat("_volumeMusic", percentToDecibells.Evaluate(newVolume));
    }
}
