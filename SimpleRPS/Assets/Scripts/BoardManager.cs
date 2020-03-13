using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {
    string[] Board;
    private int currentZoneIndex = -1;
    //public DropZone[] dropZones = new DropZone[6];
    public DropZone[] dropZones = new DropZone[7];
    public GameObject[] winGlow = new GameObject[3];
    public GameObject[] loseGlow = new GameObject[3];
    public int goalPoints;
    public Text p1Score;
    public Text p2Score;




    private static BoardManager m_instance;

    public static BoardManager Instance { get { return m_instance; } private set { } }

    
    private void Awake() {
        if (m_instance == null) {
            m_instance = this;
            Board = new string[] { "Fire", "Water", "Leaf", "Fire", "Water", "Leaf","Discard"};
        }
        else {
            Destroy(this.gameObject);
        }
    }
   
    public void SetBoardIndex(int newIndex) {
        currentZoneIndex = newIndex;
    }
    public int GetBoardIndex() {
        return currentZoneIndex;
    }

    public string[] GetBoard() {
        return Board;
    }
    public string getName(GameObject obj) {
        return obj.name;
    }
    public void SetBoardElement(string newElement, int index) {
        Board[index] = newElement;
        currentZoneIndex = index;
        dropZones[index].SetSprite((Sprite)Resources.Load("sprites/" + newElement, typeof(Sprite)));
        setGlows(index);
    }
    public string GetBoardElement(int index) {
        return Board[index];
    }

    //Checks if you're winning 1 match up. Returns 1 for YES, 0 for NO, -1 for DRAW
    public int isWinning(int myIndex) {
        //currentZoneIndex = myIndex;

        if (Board[myIndex] == "Fire" && (Board[myIndex + 3] == "Leaf") || Board[myIndex] == "Water" && (Board[myIndex + 3] == "Fire") || (Board[myIndex] == "Leaf" && (Board[myIndex + 3] == "Water"))) {
            return 1;
        }
        else if (Board[myIndex] == "Fire" && (Board[myIndex + 3] == "Water") || Board[myIndex] == "Water" && (Board[myIndex + 3] == "Leaf") || (Board[myIndex] == "Leaf" && (Board[myIndex + 3] == "Fire"))) {
            return 0;
        }
        return -1;
    }

    //Manages the win/lose glows around the board elements every time a card is played
    public void setGlows(int index) {
        //Convert index to only check the 3 pairs of elements
        //currentZoneIndex = index;
        if (index > 2) {
            index -= 3;
        }
        //Call isWinning to check the state of the match up and then enable/disable glows accordingly
        if (isWinning(index) == 1) {
            winGlow[index].SetActive(true);
            loseGlow[index].SetActive(false);
        }
        else if (isWinning(index) == 0) {
            winGlow[index].SetActive(false);
            loseGlow[index].SetActive(true);
        }
        else {
            winGlow[index].SetActive(false);
            loseGlow[index].SetActive(false);
        }
    }
    public void RefreshScore()
    {
        p1Score.text = PlayerPrefs.GetInt("myPoints").ToString();
        p2Score.text = PlayerPrefs.GetInt("enemyPoints").ToString();
    }

    // Called at the end of each round to check how many victory points each player gets based on the current board.
    // It then changes the score that is stored locally as a PlayerPref to keep it when we reload the scene for the next round.
    // IMPORTANT!!!! TO DO: In menu, on click play, do PlayerPrefs.SetInt("myPoints", 0) and PlayerPrefs.SetInt("enemyPoints", 0)
    // If the above is not deleted, it means this was not done... Please check
    public void endRound() {
        int myPoints = 0;
        int enemyPoints = 0;
        for (int i = 0; i < 3; i++) {
            if (isWinning(i) == 1) {
                myPoints++;
            }
            else if (isWinning(i) == 0) {
                enemyPoints++;
            }
        }

        PlayerPrefs.SetInt("myPoints", PlayerPrefs.GetInt("myPoints") + myPoints);
        PlayerPrefs.SetInt("enemyPoints", PlayerPrefs.GetInt("enemyPoints") + enemyPoints);
        RefreshScore();

        //Check if game is over. If not reload scene. Else load win/lose/draw scene.
        if (PlayerPrefs.GetInt("myPoints") < goalPoints && PlayerPrefs.GetInt("enemyPoints") < goalPoints) {
            SceneManager.LoadScene("Board");
            Debug.Log("HaveToRedraw");
           
        }

        else {
            //TO DO: Still need to create these scenes.
            if (PlayerPrefs.GetInt("myPoints") >= goalPoints && PlayerPrefs.GetInt("enemyPoints") >= goalPoints) {
                SceneManager.LoadScene("Draw");
            }
            else if(PlayerPrefs.GetInt("myPoints") >= goalPoints) {
                SceneManager.LoadScene("Win");
            }
            else if(PlayerPrefs.GetInt("enemyPoints") >= goalPoints) {
                SceneManager.LoadScene("Lose");
            }
        }
    }
    
  /*void Update()
    {
        RefreshScore();
    }*/
}
