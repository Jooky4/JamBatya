using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SwitchScene(int numberscene)
    {
        SceneManager.LoadScene(numberscene);
    }

    public void LoadActiveScene()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
