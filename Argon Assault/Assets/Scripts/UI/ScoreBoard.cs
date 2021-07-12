using System.Collections;
using System.Collections.Generic;
using RS.Control;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int points = 0;

    private void OnEnable()
    {
        Enemy.OnEnemyDie += UpdateScore;
        scoreText.text = points.ToString();
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDie -= UpdateScore;
    }

    void Update()
    {
        UpdateScore(1);
    }

    public void UpdateScore(int pointsPerkill)
    {
        points += pointsPerkill;
        scoreText.text = points.ToString();
    }
}
