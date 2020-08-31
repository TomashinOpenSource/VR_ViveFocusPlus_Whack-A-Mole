using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeScript_Game1 : MonoBehaviour
{
    public GameController_Game1 GameController;

    public void StartingGame()
    {
        if (GameController.Player.isStarted == true)
        {
            GameController.StopGame();
        }
        else if (GameController.Player.isStarted == false)
        {
            GameController.StartGame();
        }
    }
}
