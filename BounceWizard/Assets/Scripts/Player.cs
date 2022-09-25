using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
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
        print("Launching fireball");
        //Tyler: Make a fireball prefab, and use Instantiate() here to create it in the scene
    }
}
