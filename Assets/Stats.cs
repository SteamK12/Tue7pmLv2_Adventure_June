using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public UnityEvent<int> onLevelUp;
    public int exp;
    public int expRequired;
    public Health health;
    public int minLvUpHp, maxLvUpHp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(exp >= expRequired)
        {
            int levels = exp / expRequired;
            exp %= expRequired;
            onLevelUp.Invoke(levels);
        }
    }

    public void GainExp(int amount)
    {
        exp += amount;
    }

    public void LevelUp(int amount)
    {
        for(int counter = 0; counter < amount; counter++)
        {
            print($"You leveled up {amount} times!");
            int randomHP = Random.Range(minLvUpHp, maxLvUpHp + 1);
            health.IncreaseHP(randomHP);
        }
    }
}
