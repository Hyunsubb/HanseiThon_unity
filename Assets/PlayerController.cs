using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid;
    GameObject Microphone;
    GameObject Director;
    int score = 0;
    public GameObject BulletOB;
    public float jumpForce = 600.0f;
    float delta = 0;
    float span = 0.7f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Piller")
            SceneManager.LoadScene("GameoverScene");
    }
    
	void Start () {
        this.rigid = GetComponent<Rigidbody2D>();
        this.Microphone = GameObject.Find("MicrophoneInput");
        this.Director = GameObject.Find("Director");
	}
	
	void Update () {
        delta += Time.deltaTime;

        if(Microphone.GetComponent<MicrophoneInput>().GetDecibel() >= 11 )
        {
            this.rigid.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletOB, new Vector2(transform.position.x + 3, transform.position.y), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }

        if (rigid.velocity.y > 10)
            rigid.velocity = new Vector2(0, 10.0f);
        if (rigid.velocity.y < -10)
            rigid.velocity = new Vector2(0, -10.0f);
        
        if(delta > span)
        {
            delta = 0;
            score += 3;
            Director.GetComponent<Director>().AddScore(score);
        }
        
    }
}
