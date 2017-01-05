using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
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
