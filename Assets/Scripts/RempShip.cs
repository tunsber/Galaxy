using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RempShip : MonoBehaviour
{
    public Direction direction;
    private float speed = 0.5f;
    private float halfWidth;
    private float halfHeight;
    public SpriteRenderer shipRenderer;

    void Start()
    {
        halfWidth = shipRenderer.sprite.bounds.size.x/2;
        halfHeight  = shipRenderer.sprite.bounds.size.y/2;
    }

    
    public void FixedUpdate()
    {
        switch(direction)
        {
            case Direction.left:
                MoovingLeft();
                break;
            
            case Direction.right:
                MoovingRight();
                break;

            case Direction.up:
                MoovingUp();
                break;

            case Direction.down:
                MoovingDown();
                break;
        }
    }

    private void MoovingRight()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += speed;

        Vector3 checkPosition = newPosition;
        checkPosition.x += halfWidth;

        if (ScreenHelper.isPosOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }   else
            {
                if (transform.position.y > 0)
                {
                    direction = Direction.down;
                }   else    
                    {
                        direction = Direction.up;
                    }
            }
    }
    private void MoovingLeft()
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= speed;

        Vector3 checkPosition = newPosition;
        checkPosition.x -= halfWidth;

        if (ScreenHelper.isPosOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }   else
            {
                if (transform.position.y > 0)
                {
                    direction = Direction.down;
                }   else    
                    {
                        direction = Direction.up;
                    }
            }
    }
    private void MoovingUp()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += speed;

        Vector3 checkPosition = newPosition;
        checkPosition.y += halfHeight;

        if (ScreenHelper.isPosOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }   else
            {
                if (transform.position.x > 0)
                {
                    direction = Direction.left;
                }   else    
                    {
                        direction = Direction.right;
                    }
            }
    }
    private void MoovingDown()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed;

        Vector3 checkPosition = newPosition;
        checkPosition.y -= halfHeight;

        if (ScreenHelper.isPosOnScreen(checkPosition))
        {
            transform.position = newPosition;
        }   else
            {
                if (transform.position.x > 0)
                {
                    direction = Direction.left;
                }   else    
                    {
                        direction = Direction.right;
                    }
            }
    }
}
