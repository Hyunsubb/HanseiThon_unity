using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveCont : MonoBehaviour {
    public float Speed;
	void Start () {
        Speed = 5.0f;
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Piller")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update () {
        if (transform.position.x < 10)
        {
            transform.position = new Vector2
                (transform.position.x + (Speed * Time.fixedDeltaTime), transform.position.y);
        }
        else
        {
            Destroy(gameObject);
        }
	}

}
