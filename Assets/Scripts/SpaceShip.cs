using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpaceShip : MonoBehaviour
{

    public GameObject origBull;
    public SpriteRenderer spriteRenderer;

    private float speede = 0.087f;
    private float health = 100.0f;
    
    void Start()
    {
 
    }

    
    void Update()
    {
        float halfWidth = spriteRenderer.bounds.size.x / 2;
        float halfHeight = spriteRenderer.bounds.size.y / 2;

        bool isKeyDown = Input.GetKey(KeyCode.A);
        if (isKeyDown == true)
        {
            Vector3 newPos = new Vector3
            (   transform.position.x - speede, 
                transform.position.y, 
                0
            );
            Vector3 checkPos = new Vector3  
            (   newPos.x - halfWidth, 
                newPos.y, 
                0
            );


            if (ScreenHelper.isPosOnScreen(checkPos))
            {
                transform.position = newPos;
            }
            

        }   
            isKeyDown = Input.GetKey(KeyCode.D);
        if (isKeyDown == true)
        {
            Vector3 newPos = new Vector3
            (   transform.position.x + speede, 
                transform.position.y, 
                0
            );

            Vector3 checkPos = new Vector3  
            (   newPos.x + halfWidth, 
                newPos.y, 
                0
            );


            if (ScreenHelper.isPosOnScreen(checkPos))
            {
                transform.position = newPos;
            }


        }   


        isKeyDown = Input.GetKey(KeyCode.W);
        if (isKeyDown == true)
        {
            Vector3 newPos = new Vector3
            (   transform.position.x, 
                transform.position.y + speede, 
                0
            );

            Vector3 checkPos = new Vector3  
            (   newPos.x, 
                newPos.y + halfHeight, 
                0
            );

            if (ScreenHelper.isPosOnScreen(checkPos))
            {
                transform.position = newPos;
            }

        }

            isKeyDown = Input.GetKey(KeyCode.S);
        if (isKeyDown == true)
        {
            Vector3 newPos = new Vector3
            (   transform.position.x, 
                transform.position.y - speede, 
                0
            );

            Vector3 checkPos = new Vector3  
            (   newPos.x, 
                newPos.y - halfHeight, 
                0
            );

            if (ScreenHelper.isPosOnScreen(checkPos))
            {
                transform.position = newPos;
            }

        }

            isKeyDown = Input.GetKeyDown(KeyCode.Space);
        if (isKeyDown == true)
        {
            GameObject bullClone = Instantiate(origBull);

            bullClone.transform.position = transform.position;
        }

            isKeyDown = Input.GetKey(KeyCode.F);

        if (isKeyDown == true)
        {
            GameObject bullClone = Instantiate(origBull);

            bullClone.transform.position = transform.position;
        }



    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;
        EnemyBull enemyBull = otherObject.GetComponent<EnemyBull>();
        if (enemyBull != null)
        {
            health -= enemyBull.damage;
            Destroy(otherObject);
            if (health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneIds.loseScene);
                Destroy(gameObject);
            }
        }   else 
            {
                RempShip ship = otherObject.GetComponent<RempShip>();

                if (ship != null)
                {
                    Destroy(otherObject);
                    SceneManager.LoadSceneAsync(SceneIds.loseScene);
                    Destroy(gameObject);
                }
            }
    }
    

}
