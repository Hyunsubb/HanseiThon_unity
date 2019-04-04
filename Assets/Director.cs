using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    public Text scoreText;
    public AudioSource mainMusic;
    int score = 0;

    void Start()
    {
        mainMusic.loop = true;
        mainMusic.Play();
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }

    void Update()
    {

    }
}
