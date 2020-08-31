using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_Game1 : MonoBehaviour
{
    public GameObject Player;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Hit(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }

    void Update()
    {
        transform.rotation = Player.transform.rotation;
        transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * 8);
    }
}
