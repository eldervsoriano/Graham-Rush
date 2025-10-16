//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // References to the Audio Sources for Music and SFX
//    public AudioSource musicAudioSource;
//    public AudioSource sfxAudioSource;

//    // Sliders for adjusting music and SFX volume
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    // PlayerPrefs keys for saving the volume settings
//    private const string MusicVolumeKey = "MusicVolume";
//    private const string SFXVolumeKey = "SFXVolume";

//    void Start()
//    {
//        // Load saved volume settings or use default values
//        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);  // Default 75% volume
//        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f);      // Default 75% volume

//        // Set the sliders to the saved volume levels
//        musicSlider.value = savedMusicVolume;
//        sfxSlider.value = savedSFXVolume;

//        // Apply the volume settings immediately
//        SetMusicVolume(savedMusicVolume);
//        SetSFXVolume(savedSFXVolume);
//    }

//    // Adjust the music volume based on the slider value
//    public void SetMusicVolume(float volume)
//    {
//        if (musicAudioSource != null)
//        {
//            musicAudioSource.volume = volume;  // Set the volume of the Music AudioSource
//        }

//        // Save the new volume setting to PlayerPrefs
//        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
//    }

//    // Adjust the SFX volume based on the slider value
//    public void SetSFXVolume(float volume)
//    {
//        if (sfxAudioSource != null)
//        {
//            sfxAudioSource.volume = volume;  // Set the volume of the SFX AudioSource
//        }

//        // Save the new volume setting to PlayerPrefs
//        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
//    }
//}




//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // References to the Audio Sources for Music and SFX
//    public AudioSource musicAudioSource;
//    public AudioSource buttonSFXAudioSource; // New AudioSource for button SFX

//    // Sliders for adjusting music and SFX volume
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    // PlayerPrefs keys for saving the volume settings
//    private const string MusicVolumeKey = "MusicVolume";
//    private const string SFXVolumeKey = "SFXVolume";

//    void Start()
//    {
//        // Load saved volume settings or use default values
//        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);  // Default 75% volume
//        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f);      // Default 75% volume

//        // Set the sliders to the saved volume levels
//        musicSlider.value = savedMusicVolume;
//        sfxSlider.value = savedSFXVolume;

//        // Apply the volume settings immediately
//        SetMusicVolume(savedMusicVolume);
//        SetSFXVolume(savedSFXVolume);

//        // Add listeners to the sliders so they update the volume in real-time
//        musicSlider.onValueChanged.AddListener(SetMusicVolume);
//        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
//    }

//    // Adjust the music volume based on the slider value
//    public void SetMusicVolume(float volume)
//    {
//        if (musicAudioSource != null)
//        {
//            musicAudioSource.volume = volume;  // Set the volume of the Music AudioSource
//        }

//        // Save the new volume setting to PlayerPrefs
//        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
//    }

//    // Adjust the SFX volume based on the slider value
//    public void SetSFXVolume(float volume)
//    {
//        if (buttonSFXAudioSource != null)
//        {
//            buttonSFXAudioSource.volume = volume;  // Set the volume of the SFX AudioSource
//        }

//        // Save the new volume setting to PlayerPrefs
//        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
//    }

//    // Call this function to play a button click sound effect (or any other sound effect)
//    public void PlayButtonClickSFX()
//    {
//        if (buttonSFXAudioSource != null)
//        {
//            buttonSFXAudioSource.Play();  // Play the button click sound effect
//        }
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // References to the Audio Sources for Music and SFX
    public AudioSource musicAudioSource;
    public AudioSource buttonSFXAudioSource; // SFX for buttons
    public AudioSource[] otherSFXAudioSources; // Array to hold other SFX

    // Sliders for adjusting music and SFX volume
    public Slider musicSlider;
    public Slider sfxSlider;

    // PlayerPrefs keys for saving the volume settings
    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    void Start()
    {
        // Load saved volume settings or use default values
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);  // Default 75% volume
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f);      // Default 75% volume

        // Set the sliders to the saved volume levels
        musicSlider.value = savedMusicVolume;
        sfxSlider.value = savedSFXVolume;

        // Apply the volume settings immediately
        SetMusicVolume(savedMusicVolume);
        SetSFXVolume(savedSFXVolume);

        // Add listeners to the sliders so they update the volume in real-time
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // Adjust the music volume based on the slider value
    public void SetMusicVolume(float volume)
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = volume;  // Set the volume of the Music AudioSource
        }

        // Save the new volume setting to PlayerPrefs
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    // Adjust the SFX volume for all SFX sources (including button SFX) based on the slider value
    public void SetSFXVolume(float volume)
    {
        // Set the volume for the button SFX
        if (buttonSFXAudioSource != null)
        {
            buttonSFXAudioSource.volume = volume;
        }

        // Set the volume for all other SFX AudioSources in the array
        foreach (var sfx in otherSFXAudioSources)
        {
            if (sfx != null)
            {
                sfx.volume = volume;
            }
        }

        // Save the new SFX volume setting to PlayerPrefs
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }

    // Call this function to play a button click sound effect (or any other sound effect)
    public void PlayButtonClickSFX()
    {
        if (buttonSFXAudioSource != null)
        {
            buttonSFXAudioSource.Play();  // Play the button click sound effect
        }
    }

    // Call this function to play any other SFX by passing the specific AudioSource
    public void PlayOtherSFX(int index)
    {
        if (index >= 0 && index < otherSFXAudioSources.Length)
        {
            AudioSource sfx = otherSFXAudioSources[index];
            if (sfx != null)
            {
                sfx.Play();  // Play the selected sound effect
            }
        }
    }
}



















//using UnityEngine;
//using UnityEngine.UI;

//public class SoundManager : MonoBehaviour
//{
//    // References to the Audio Sources for Music and SFX
//    public AudioSource musicAudioSource;
//    public AudioSource sfxAudioSource;

//    // Sliders for adjusting music and SFX volume
//    public Slider musicSlider;
//    public Slider sfxSlider;

//    // PlayerPrefs keys for saving the volume settings
//    private const string MusicVolumeKey = "MusicVolume";
//    private const string SFXVolumeKey = "SFXVolume";

//    void Start()
//    {
//        // Load saved volume settings or use default values
//        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);  // Default 75% volume
//        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f);      // Default 75% volume

//        // Set the sliders to the saved volume levels
//        musicSlider.value = savedMusicVolume;
//        sfxSlider.value = savedSFXVolume;

//        // Apply the volume settings immediately
//        SetMusicVolume(savedMusicVolume);
//        SetSFXVolume(savedSFXVolume);
//    }

//    // Adjust the music volume based on the slider value
//    public void SetMusicVolume(float volume)
//    {
//        if (musicAudioSource != null)
//        {
//            musicAudioSource.volume = volume;  // Set the volume of the Music AudioSource
//        }

//        // Save the new volume setting to PlayerPrefs
//        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
//    }

//    // Adjust the SFX volume based on the slider value
//    public void SetSFXVolume(float volume)
//    {
//        if (sfxAudioSource != null)
//        {
//            sfxAudioSource.volume = volume;  // Set the volume of the SFX AudioSource
//        }

//        // Save the new volume setting to PlayerPrefs
//        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
//    }

//    // Play a button click sound
//    public void PlayButtonClickSFX(AudioClip clip)
//    {
//        if (sfxAudioSource != null)
//        {
//            sfxAudioSource.clip = clip;  // Set the clip to the passed sound
//            sfxAudioSource.Play();  // Play the button click sound
//        }
//    }

//}

