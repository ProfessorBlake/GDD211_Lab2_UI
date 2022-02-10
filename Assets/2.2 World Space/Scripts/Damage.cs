using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float time = 1f;

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f)
            Destroy(gameObject);
        transform.position += transform.up * Time.deltaTime * time * 2f;
    }
}
