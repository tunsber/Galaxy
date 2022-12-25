using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapScreen : MonoBehaviour
{
    public void startLvl1()
    {
        SceneManager.LoadSceneAsync(SceneIds.levelSceneId);
    }
}
