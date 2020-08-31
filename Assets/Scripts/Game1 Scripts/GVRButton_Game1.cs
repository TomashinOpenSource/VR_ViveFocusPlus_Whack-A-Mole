using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GVRButton_Game1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image imgCircle;
    public UnityEvent GVRClick;
    public SoundManager_Game1 SoundManager;
    public float totalTime = 2;
    public float gvrTimer;

    private void Start()
    {
        gvrTimer = 0;
        imgCircle.fillAmount = 0;
    }

    IEnumerator GazeTimer()
    {
        SoundManager.StartSound(true);
        gvrTimer = 0;
        imgCircle.fillAmount = 0;
        float time = 0.05f;
        while (gvrTimer < totalTime)
        {
            yield return new WaitForSeconds(time);
            gvrTimer += time;
            imgCircle.fillAmount = gvrTimer / totalTime;
        }
        GVRClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(GazeTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        SoundManager.StartSound(false);
        gvrTimer = 0;
        imgCircle.fillAmount = 0;
    }
}
