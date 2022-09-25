using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameObject fireball;
    public float fireBallStartDistance = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LaunchFireball();
        }
    }

    void LaunchFireball()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition = new Vector3(worldPosition.x, 0, worldPosition.z);
        Vector3 aimDirection = (worldPosition - transform.position).normalized;
        GameObject newFireball = Instantiate(fireball, transform.position + aimDirection*fireBallStartDistance, Quaternion.identity);
        newFireball.GetComponent<Rigidbody>().velocity = aimDirection;
        print("Launching fireball");
        //Tyler: Make a fireball prefab, and use Instantiate() here to create it in the scene
    }
}
