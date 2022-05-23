using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{

  Resolution[] resolutions;

  public Dropdown resolutionDropdown;

  public void Start()
  {
    resolutions = Screen.resolutions;
    resolutionDropdown.ClearOptions();

    List<string> options = new List<string>();

    int currentResolutionIndex = 0;

    for (int i=0; i< resolutions.Length; i++) {
      string option = resolutions[i].width + "X" + resolutions[i].height;
      options.Add(option);

      if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height )
        {
          currentResolutionIndex = i;
        }
    }
    resolutionDropdown.AddOptions(options);
    resolutionDropdown.value = currentResolutionIndex;
    resolutionDropdown.RefreshShownValue();

    Screen.fullScreen = true;
  }

  public void SetVolume(float volume)
  {
    Debug.Log(volume);
  }

  public void SetFullScreen(bool isFullscreen)
  {
    Screen.fullScreen = isFullscreen;
  }

  public void SetResolution(int resolutionIndex)
  {
    Resolution resolution = resolutions[resolutionIndex];
    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
  }

}
