using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    
    Resolution[] resolutions;
    [SerializeField]
     Dropdown dropdownResolutions;

    
   // private AudioMixer audioMix;
    public AudioMixer audioMixer;
    [SerializeField]
    Slider musicSlider;
    [SerializeField]
    Slider soundSlider;

     void Start()
    {

        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;
        audioMixer.GetFloat("SoundEffect", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();
        dropdownResolutions.ClearOptions();
        int cureentResolutionsIndex = 0;

        List<string> Options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + "X" + resolutions[i].height;
            Options.Add(Option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                cureentResolutionsIndex = i;
            }

        }

        dropdownResolutions.AddOptions(Options);
        dropdownResolutions.value = cureentResolutionsIndex;
        dropdownResolutions.RefreshShownValue();

    }

   
    public void SetVolume(float audio)
    {
        audioMixer.SetFloat("Music", audio);
    }

    public void SetSoundVolume(float audio)
    {
        audioMixer.SetFloat("SoundEffect", audio);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionsIndex)
    {
        Resolution resolution = resolutions[resolutionsIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    

}
