using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBull : MonoBehaviour
{
    private float speede = 0.37f;
    public float damage = 1.0f;
    
    void Start()
    {

        
    }
    
    void FixedUpdate()
    {
        transform.position = new Vector3
        (
            transform.position.x, 
            transform.position.y - speede, 
            0
        );

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

    }
}
