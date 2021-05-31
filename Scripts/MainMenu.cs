using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
