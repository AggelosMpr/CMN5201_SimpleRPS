using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void startApp()
    {
        SceneManager.LoadScene("Board");
        PlayerPrefs.SetInt("enemyPoints", 0);
        PlayerPrefs.SetInt("myPoints", 0);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }
}

