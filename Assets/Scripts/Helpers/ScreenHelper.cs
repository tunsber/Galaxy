using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHelper
{
   public static bool isPosOnScreen(Vector3 position)
    {
        Vector3 verter = Camera.main.WorldToScreenPoint(position);
        if  ( verter.x > 0 &&
              verter.y > 0 && 
              verter.x < Screen.width && 
              verter.y < Screen.height)
            {
              return true;  
            }   else    
                {
                    return false;
                }

    }

}
