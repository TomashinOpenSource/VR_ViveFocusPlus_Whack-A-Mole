using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole_Game1 : MonoBehaviour
{
    public float hiddenHeight = 0f;
    public float visibleHeight = 0.15f;
    public float speed = 4f;

    private Vector3 targetPosition;

    void Awake()
    {
        Hide();
        transform.localPosition = targetPosition;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
    }

    public void Rise()
    {
        targetPosition = new Vector3(transform.localPosition.x, visibleHeight, transform.localPosition.z);
    }

    public void Hide()
    {
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
    }

    public void Hit()
    {
        Hide();
    }

}
