using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuActions : MonoBehaviour
{
    [Inject]
    public AppSettings AppSettings { get; set; }

    public void PlayNormalMode()
    {
        AppSettings.VRMode = false;
        SceneManager.LoadScene(1);
    }

    public void PlayVRMode()
    {
        AppSettings.VRMode = true;
        SceneManager.LoadScene(1);
    }
}
