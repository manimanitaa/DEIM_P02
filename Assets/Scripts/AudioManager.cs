using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private float volumeThreshold;

   public void SetMusicVolume(float volume)
    {
        if (volume <= volumeThreshold)
        {
            volume = -80;
        }
        audioMixer.SetFloat("Music Volume", volume);
    }


    public void SetSoundEffectsVolume(float volume)
    {
        if (volume <= volumeThreshold)
        {
            volume = -80;
        }
        audioMixer.SetFloat("SoundEffects Volume", volume);
    }


}
