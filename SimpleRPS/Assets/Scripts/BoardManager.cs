using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoardManager : MonoBehaviour
{
    string[] Board;
    private int currentZoneIndex = -1;
    public DropZone[] dropZones = new DropZone[6];

    private static BoardManager m_instance;

    public static BoardManager Instance { get { return m_instance; } private set { } }

    private void Awake() {
        if (m_instance == null) {
            m_instance = this;
          Board  = new string[]{ "Fire", "Water", "Leaf", "Fire", "Water", "Leaf"};
        }
        else 
        {
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
    public void SetBoardElement(string newElement,int index) 
    {
        Board[index] = newElement;
        currentZoneIndex = index;
        dropZones[index].SetSprite((Sprite)AssetDatabase.LoadAssetAtPath("Assets/NewAssets/Resources/" + newElement + ".png", typeof(Sprite)));

    }
    public string GetBoardElement(int index) {
        return Board[index];
    }
}
