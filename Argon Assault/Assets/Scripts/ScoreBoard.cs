using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text scoreText;

    int points = 0;
    void Start()
    {
        scoreText.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreHit(int pointsPerkill)
    {
        points += pointsPerkill;
        scoreText.text = points.ToString();
    }
}
