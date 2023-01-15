using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenedger : MonoBehaviour
{
    private int count = 0;
    public GameObject origShip;
    public GameObject enemShip;
    public GameObject rempGroup;

    private GroupTite[] groupTite = {  GroupTite.remp };

    Vector3 starPlPos = new Vector3(0, -3.5f, 0);
    Vector3 startEnPos = new Vector3(0, 2.5f, -1.5f);

    private BaseGroupe currentGroup;

    void Start()
    {
        GameObject newOrShip = Instantiate(origShip);
        newOrShip.transform.position = starPlPos;

        CreatorGroup();
        count++;
    }

    
    void Update()
    {
        


        if (currentGroup != null && currentGroup.isAlive == false)
        {
            if (count == groupTite.Length)
            {
                SceneManager.LoadSceneAsync(SceneIds.winScene);
            }   else 
                {  
                    Destroy(currentGroup.gameObject);
                    CreatorGroup();
                    count++;
                }
            
        }

        
    }

    void CreatorGroup()
    {
        GameObject newEnShip = Instantiate(enemShip);
        newEnShip.transform.position = startEnPos;
        currentGroup = newEnShip.GetComponent<FintGroup>();
        count++;
    }
}
