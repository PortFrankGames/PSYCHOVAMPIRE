using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Starting game!");
        Destroy(gameObject);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Board");
    }
}
