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
        PlayerPrefs.SetInt("enemyPoints", 0);
        PlayerPrefs.SetInt("myPoints", 0);
        SceneManager.LoadScene("Board");
        
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

