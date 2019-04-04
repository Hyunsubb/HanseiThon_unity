using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilerGenerator : MonoBehaviour {

    public GameObject Piller;
    float rand = 0;
    float delta = 0;
    float span = 2.0f;

    void Update()
    {
        GameObject gen;
        rand = Random.Range(-5.0f, 5.0f);
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;
            gen = Instantiate(Piller) as GameObject;
            gen.transform.position = new Vector2(9, rand);
        }
        rand = 0;
    }
}
