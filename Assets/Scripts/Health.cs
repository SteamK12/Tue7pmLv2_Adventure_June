using Unity.UI.Shaders.Sample;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHP;
    int hp;
    float healthHieght;

    public Image maxHealth, health;

    Canvas ui;

    public UnityEvent<int> onDeath;
    public int expOnDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthHieght = maxHealth.rectTransform.sizeDelta.y;
        ui = GetComponentInChildren<Canvas>();
        hp = maxHP;
        maxHealth.rectTransform.sizeDelta = new Vector2(maxHP, healthHieght);
        if (health.TryGetComponent<Meter>(out Meter meter))
        {
            meter.Value = 1;
        }
        else
        {
            health.rectTransform.sizeDelta = maxHealth.rectTransform.sizeDelta;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        print($"My max HP is {maxHP}, and my current is {hp}");
        if(hp <= 0)
        {
            onDeath.Invoke(expOnDeath);
            
        }

        ui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    public void ResetPlayer()
    {
        SceneManager.LoadScene(0); //get active
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        
        if (health.TryGetComponent<Meter>(out Meter meter))
        {
            meter.Value = hp / (float)maxHP;
        }
        else
        {
            health.rectTransform.sizeDelta = new Vector2(hp, healthHieght);
        }
    }

    public void IncreaseHP(int amount)
    {
        maxHP += amount;
        hp = maxHP;

        if (health.TryGetComponent<Meter>(out Meter meter))
        {
            meter.Value = hp / (float)maxHP;
        }
        else
        {
            health.rectTransform.sizeDelta = new Vector2(hp, healthHieght);
        }
    }

    public void ResetHP()
    {
        hp = maxHP;
        if (health.TryGetComponent<Meter>(out Meter meter))
        {
            meter.Value = hp / (float)maxHP;
        }
        else
        {
            health.rectTransform.sizeDelta = new Vector2(hp, healthHieght);
        }
    }
}

// HP - Current / Max
// Damage
// Player?
