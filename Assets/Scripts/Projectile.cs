using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeReference] protected float lifetime;
    float timer;
    [SerializeField] int damage;
    public string abilityName;
    public Image abilityImage;
    public float force;
    public float cooldown;

    // Start is called on Play
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag(tag))
        {
            if (collision.transform.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }


            Destroy(gameObject);

        }
    }
}
