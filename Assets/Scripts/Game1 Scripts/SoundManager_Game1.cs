using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_Game1 : MonoBehaviour
{
    public new AudioSource[] audio;
    // 0. Луп в меню игры - 0_MenuSound
    // 1. Нажатие кнопки в игре - 1_PushingButton_Game1
    // 2. Звук выхода из игры - 2_Quit
    // 3. Удар по резине - 3_Beating_Game1
    // 4. Появление капсулы - 4_Appearing_Game1
    // 5. Звук конца игры - 5_End_Game1
    // 6. Отсчет до начала матча - 6_Start_Game1

    private void Start()
    {
        for (int i = 0; i<audio.Length; i++)
        {
            audio[i] = GetComponent<SoundManager_Game1>().audio[i];
        }
    }

    public void MenuSound()
    {
        
    }

    public void PushingButtonSound()
    {
        audio[1].Play();
    }

    public void QuitSound()
    {
        audio[2].Play();
    }

    public void BeatingSound()
    {
        audio[3].Play();
    }

    public void AppearingSound()
    {
        audio[4].Play();
    }

    public void EndSound()
    {
        audio[5].Play();
    }

    public void StartSound(bool start)
    {
        if (start) audio[6].Play();
        else audio[6].Stop();
    }
}
