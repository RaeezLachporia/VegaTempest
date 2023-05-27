using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuHandling : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadHowToPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMap()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadAuditorium()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadRNOffice()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadCanteen()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
