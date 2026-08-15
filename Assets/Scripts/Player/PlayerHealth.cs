using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private string _sceneToLoad = "Game";

    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;
    private int _health;

    private void Start()
    {
        _health = _maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        UpdateHealthUI();
    }

    private void Update()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    private void Respawn()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    private void CheckAlive()
    {
        if (_health <= 0)
            Respawn();
    }

    public void UpdateHealthUI()
    {
        _healthText.text = _maxHealth + "/" + _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        CheckAlive();
        UpdateHealthUI();
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }

    public void RestoreHealth(int healthAmount)
    {
        _health += healthAmount;
        UpdateHealthUI();
    }
}
