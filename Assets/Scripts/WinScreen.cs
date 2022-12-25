using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }

    public void ReplayLvl()
    {
        SceneManager.LoadSceneAsync(SceneIds.levelSceneId);
    }

    public void ReturnToMAp()
    {
        SceneManager.LoadSceneAsync(SceneIds.mapScene);
    }
}
