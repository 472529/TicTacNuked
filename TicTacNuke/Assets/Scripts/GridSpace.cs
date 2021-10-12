using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public string playerSide;
    bool IsNuke = false;
    bool IsNukePressed = false;

    private GameController gameController;

    public void SetGameControllerRef(GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {
        if (IsNuke == false)
        {
            buttonText.text = gameController.GetPlayerSide();
            IsNuke = false;
            button.interactable = false;
            gameController.EndTurn();
        }
        else
        {
            Nuke();
        }
    }

    public void Nuke()
    {
        buttonText.text = "";
        IsNuke = true;
        button.interactable = false;
    }
}
