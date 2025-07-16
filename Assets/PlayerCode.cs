using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public GameObject projectile;
    public GameObject output;
    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newPew = Instantiate(projectile);
            newPew.transform.SetParent(output.transform, false);
            newPew.transform.SetParent(null);

            newPew.GetComponent<Rigidbody>().AddRelativeForce(transform.forward*force);
        }
    }
}
