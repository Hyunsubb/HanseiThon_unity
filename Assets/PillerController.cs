using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerController : MonoBehaviour
{
    int direction = -1;

    void Update()
    {
        if (transform.position.x < -8.5f)
            Destroy(gameObject);

        transform.Translate(-0.1f, 0, 0);
    }

}
