using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController_Game1 : MonoBehaviour
{
    public GameObject moleContainer;
    public Player_Game1 Player;
    public SoundManager_Game1 SoundManager;
    public TextMeshPro StartStopText, TimerText, ScoreText;
    public GameObject Fireworks;

    public int time = 15;
    int prevMoleIndex = -1;


    private Mole_Game1[] moles;
    private ParticleSystem[] effects;



    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole_Game1>();
        effects = Fireworks.GetComponentsInChildren<ParticleSystem>();
        StartStopText.color = Color.green;
        StartStopText.text = "START";
    }

    public void StartGame()
    {
        if (Player.isStarted) StopGame();
        else
        {
            Player.isStarted = true;
            Player.score = 0;
            ScoreText.text = "SCORE: " + Player.score;
            StartStopText.color = Color.red;
            StartStopText.text = "STOP";
            StartCoroutine(StartTimer(time));
            StartCoroutine(RisingMoles());
        }
    }

    public void StopGame()
    {
        SoundManager.EndSound();
        foreach (ParticleSystem effect in effects) effect.Play();
        Player.isStarted = false;
        ScoreText.text = "SCORE: " + Player.score;
        Player.score = 0;
        StartStopText.color = Color.green;
        StartStopText.text = "START";
        StopAllCoroutines();
        HideAllMoles();
    }

    private void Update()
    {
        
    }

    public IEnumerator RisingMoles()
    {
        int currentMoleIndex;
        do
        {
            currentMoleIndex = Random.Range(0, moles.Length);
        } while (currentMoleIndex == prevMoleIndex);
        prevMoleIndex = currentMoleIndex;
        SoundManager.AppearingSound();
        moles[currentMoleIndex].Rise();
        StartCoroutine(HidingMoles(moles[currentMoleIndex]));
        yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        StartCoroutine(RisingMoles());
    }

    public IEnumerator HidingMoles(Mole_Game1 currentMole)
    {
        yield return new WaitForSeconds(Random.Range(2, 3));
        currentMole.Hide();
    }

    public void HideAllMoles()
    {
        foreach (var item in moles) item.Hide();
        StopAllCoroutines();
    }

    public IEnumerator StartTimer(int seconds)
    {
        do
        {
            TimerText.text = "TIME: " + seconds;
            yield return new WaitForSeconds(1);
            seconds -= 1;
        } while (seconds >= 0);
        if (seconds <= 0)
        {
            StopGame();
        }
    }

}
