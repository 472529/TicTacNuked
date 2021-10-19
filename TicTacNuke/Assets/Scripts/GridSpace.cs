using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
public class GridSpace : MonoBehaviour, IPointerClickHandler
{
    public Button button;
    public TMP_Text buttonText;
    public string playerSide;
    public int player1Nukes = 2;
    public int player2Nukes = 2;

    private GameController gameController;

    public void SetGameControllerRef(GameController controller)
    {
        gameController = controller;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            
            SetSpace();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            Nuke();
        }
    }

    public void SetSpace()
    {        
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
        Debug.Log("LEFT");              
    }

    public void Nuke()
    {
        if (gameController.GetPlayerSide() == "X" /*&& player1Nukes != 0*/)
        {
            buttonText.text = "";
            button.interactable = false;
            player1Nukes -= 1;
            gameController.EndTurn();
            Debug.Log("RIGHT X");
        }
        if (gameController.GetPlayerSide() == "O" /*&& player2Nukes != 0*/)
        {
            buttonText.text = "";
            button.interactable = false;
            player2Nukes -= 1;
            gameController.EndTurn();
            Debug.Log("RIGHT O");
        }
    }
}
