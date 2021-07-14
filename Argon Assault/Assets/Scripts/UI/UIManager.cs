using RS.Control;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] Image[] lifeImages;

    [SerializeField] GameObject[] PowerUpUIGameobjects = new GameObject[3];
    [SerializeField] Transform powerUpUIParent = null;

    bool isPowerUpEnabled = false;
    bool setNewTime = false;

    int points = 0;
    float timer;
    private float progresImageVelocity;

    private void OnEnable()
    {
        Enemy.OnEnemyDie += UpdateScore;
        PlayerHealth.OnDamageTaken += UpdateLifeUI;
        PowerUps.OnEnablePowerUp += UpdatePowerUpUI;

        scoreText.text = points.ToString();
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDie -= UpdateScore;
        PlayerHealth.OnDamageTaken -= UpdateLifeUI;
        PowerUps.OnEnablePowerUp -= UpdatePowerUpUI;
    }

    void Update()
    {
        UpdateScore(1);
    }

    private void UpdatePowerUpUI(PowerUps.PowerUpType type)
    {
        Instantiate(PowerUpUIGameobjects[(int)type], powerUpUIParent);
    }

    public void UpdateScore(int pointsPerkill)
    {
        points += pointsPerkill;
        scoreText.text = points.ToString();
    }

    public void UpdateLifeUI(int currentLives)
    {
        for (int i = currentLives + 1; i > currentLives; i--)
        {
            lifeImages[i - 1].color = Color.gray;
        }
    }
}
