using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FintGroup : BaseGroupe
{
    



    public EnemyShip enemyShip1;
    public EnemyShip enemyShip2;
    public EnemyShip enemyShip3;
    private List<EnemyShip> ships = new List<EnemyShip>();
    private float speed = 0.09f;
    private int direction = -1;
    private System.Random generator = new System.Random();


    void Start()
    {
        ships.Add(enemyShip1);
        ships.Add(enemyShip2);
        ships.Add(enemyShip3);
        enemyShip1.DeathEvent += OnShipDeath;
        enemyShip2.DeathEvent += OnShipDeath;
        enemyShip3.DeathEvent += OnShipDeath;

        InvokeRepeating("ShootGroup", 1.0f, 1.0f);

    }

    
    void Update()
    {
        ships.RemoveAll(item => item == null);

        if (ships.Count == 0)
        {
            isAlive = false;  
            CancelInvoke("ShootGroup");
            return;  
        }

        if (direction == -1)
        {
            Vector3 leftPosition = ships[0].transform.position;
            leftPosition.x -= speed * direction;

            bool onScreen = ScreenHelper.isPosOnScreen(leftPosition);
            if (onScreen)
            {
                transform.position = new Vector3
                (
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            }   else 
                {
                    direction *= -1;

                }
        }   else 
            {
                Vector3 rightPosition = ships[ships.Count - 1].transform.position;
                rightPosition.x += speed * direction;
                bool onScreen = ScreenHelper.isPosOnScreen(rightPosition);
                if (onScreen)
                {
                transform.position = new Vector3
                    (
                    transform.position.x + speed,
                    transform.position.y,
                    0
                    );
                }   else 
                    {
                        direction *= -1;
                    }
            }

    }


    void OnShipDeath(EnemyShip deadShip)
    {

        //ships.Remove(deadShip);
    }

    void ShootGroup()
    {
        int randomIndex = generator.Next(0, ships.Count);
        ships[randomIndex].ShootBull();
    }
}
