using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float health = 10.0f;
    public delegate void OnDeath(EnemyShip deadShip);
    public event OnDeath DeathEvent;
    public GameObject bullOrig;

    public void ShootBull()
    {
        GameObject bullClone = Instantiate(bullOrig);

        bullClone.transform.position = transform.position;
    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        
        GameObject azerObject = collider.gameObject;
        Bullet bulletObject = azerObject.GetComponent<Bullet>();
        if (bulletObject != null)
        {
            health -= bulletObject.damage;
            if (health <= 0)
            {
                DeathEvent.Invoke(this);
                Destroy(gameObject);
            }
            Destroy(azerObject);
        }
        
    }
}
