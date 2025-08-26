using UnityEngine;
using UnityEngine.UI;

public class PlayerCode : MonoBehaviour
{
    public GameObject projectile1, projectile2;
    public GameObject output;
    
    float force;
    float ShootDelay;
    float shootTimer;
    bool shootOnCooldown;

    public Canvas abilityUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void ChangeColor(float alpha)
    {
        for (int index = 0; index < abilityUI.transform.childCount; index++)
        {
            Image backgroung = abilityUI.transform.GetChild(index).GetComponent<Image>();
            Color newColor = backgroung.color;
            newColor.a = alpha;
            backgroung.color = newColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootOnCooldown)
        {
            ChangeColor(0.5f);

            shootTimer += Time.deltaTime;

            if(shootTimer >= ShootDelay)
            {
                shootOnCooldown = false;
                shootTimer = 0;
                ChangeColor(1);
            }
        }


        if (shootOnCooldown == false)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                SpawnProjectile(Instantiate(projectile1));

            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                SpawnProjectile(Instantiate(projectile2));
            }
        }
    }

    void SpawnProjectile(GameObject newPew)
    {
        shootOnCooldown = true;

        newPew.transform.position = output.transform.position;
        newPew.transform.rotation = output.transform.rotation;
        newPew.tag = tag;

        ShootDelay = newPew.GetComponent<Projectile>().cooldown;
    }
}
