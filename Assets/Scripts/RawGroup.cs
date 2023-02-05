using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawGroup : BaseGroupe
{
    public RempShip enemyShip1;
    public RempShip enemyShip2;

    private List<RempShip> ships = new List<RempShip>();


    void Start()
    {
        ships.Add(enemyShip1);
        ships.Add(enemyShip2);
    }

    
    void Update()
    {
        ships.RemoveAll(item => item == null);

        if (ships.Count == 0)
        {
            isAlive = false;  
            return;  
        }
    }
}
