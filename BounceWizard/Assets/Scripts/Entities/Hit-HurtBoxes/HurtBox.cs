using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [HideInInspector] public Entity entity;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }
}
