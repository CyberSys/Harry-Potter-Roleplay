using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Range(0, 10)]
    public float dayTime;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * dayTime, 0);
    }
}
