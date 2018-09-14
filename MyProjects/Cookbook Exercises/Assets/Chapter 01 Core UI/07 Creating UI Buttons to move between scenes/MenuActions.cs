using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void GoToPage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
