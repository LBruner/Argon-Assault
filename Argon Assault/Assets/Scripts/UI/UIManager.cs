using RS.Control;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] Image[] lifeImages;

    [SerializeField] GameObject[] PowerUpUIGameobjects = new GameObject[3];
    [SerializeField] Transform powerUpUIParent = null;

    List<PowerUpsController.PowerUpType> enabledPowerUps = new List<PowerUpsController.PowerUpType>();

    bool isPowerUpEnabled = false;

    GameObject lastInstantiatedUI = null;

    int points = 0;
    private float progresImageVelocity;

    private PowerUpsController controller = null;

    private void OnEnable()
    {
        Enemy.OnEnemyDie += UpdateScore;
        PlayerHealth.OnDamageTaken += UpdateLifeUI;
        PowerUpsPickup.OnEnablePowerUp += UpdatePowerUpUI;

        controller = FindObjectOfType<PowerUpsController>();

        scoreText.text = points.ToString();
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDie -= UpdateScore;
        PlayerHealth.OnDamageTaken -= UpdateLifeUI;
        PowerUpsPickup.OnEnablePowerUp -= UpdatePowerUpUI;
    }

    void Update()
    {
        UpdateScore(1);

    }

    private void UpdatePowerUpUI(PowerUpsController.PowerUpType type)
    {
        if(!enabledPowerUps.Contains(type))
        {
            lastInstantiatedUI = Instantiate(PowerUpUIGameobjects[(int)type], powerUpUIParent);
            enabledPowerUps.Add(type);
        }
        else
        {
            lastInstantiatedUI.GetComponent<Animator>().Play("PowerUp", 0, 0);
        }

        // if(enabledPowerUps.Contains(type) && obj != null)
        // {
        //     Debug.Log(enabledPowerUps.Count);
        //     obj.GetComponent<Animator>().Play("PowerUp", 0, 0);
        // }
        // else
        // {
        //     obj = Instantiate(PowerUpUIGameobjects[(int)type], powerUpUIParent);
        //     enabledPowerUps.Add(type);
        // }

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
