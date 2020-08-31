using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private float speedRotateX, speedRotateY, speedRotateZ;
    Light[] light;
    private void Awake()
    {
        light = GetComponentsInChildren<Light>();
        foreach (var l in light) l.color = new Color(Random.value, Random.value, Random.value);

        speedRotateX = Random.Range(-3f, 3f);
        speedRotateY = Random.Range(-3f, 3f);
        speedRotateZ = Random.Range(-3f, 3f);
    }
    private void Update()
    {
        transform.Rotate(speedRotateX, speedRotateY, speedRotateZ);
    }
}
