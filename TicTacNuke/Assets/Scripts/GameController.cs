using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    public TMP_Text[] buttonList;
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    public bool toggle;
    public GridSpace gridSpace;

    private string playerSide;
    private int moveCount;
    
    
    


    void Awake()
    {
        SetGameControllerRefOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
    }

    void SetGameControllerRefOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerRef(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        if(moveCount >= 99)
        {
            gameOverPanel.SetActive(true);
            SetGameOverText("Its a draw!");
        }

        ChangeSides();
    }

    void GameOver()
    {
        //Debug.Log("GameOver");
        SetBoardInteractable(false);
        SetGameOverText(playerSide + " Wins!");
        
    }
    
    void ChangeSides()
    {
        playerSide = (playerSide == "O") ? "X" : "O";
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gridSpace.player1Nukes = 2;
        gridSpace.player2Nukes = 2;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);



        for (int i = 0; i < buttonList.Length; i++)
        {
            
            buttonList[i].text = "";
            
        }
        
    }

    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            //Debug.Log(toggle);
            
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
            //Debug.Log(buttonList[i].GetComponentInParent<Button>().name);
        }
    }   
}
