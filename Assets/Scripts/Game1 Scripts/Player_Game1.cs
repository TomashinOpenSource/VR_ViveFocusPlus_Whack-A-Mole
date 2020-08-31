using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Game1 : MonoBehaviour
{
    public GameController_Game1 GameController;
    public Hammer_Game1 Hammer;
    public int score;
    public bool isStarted;



    public void HitMole()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.GetComponent<Mole_Game1>() != null)
            {
                Mole_Game1 mole = hit.transform.GetComponent<Mole_Game1>();
                if (mole.transform.localPosition.y > 0.75 * mole.visibleHeight)
                {
                    GameController.SoundManager.BeatingSound();
                    mole.Hit();
                    Hammer.Hit(mole.transform.position);
                    score += 1;
                    GameController.ScoreText.text = "SCORE: " + score;
                }
            }
        }
    }
    
    
}
