using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    //private GameObject numOfAttacks;
    //private GameObject numToHit;
    //private GameObject numToWound;
    public int attacks = 0;
    public int hit = 0;
    public int wound = 0;
    public bool explodeHit = false;
    public int[] hitDiePool;
    public int[] extraDiePool;
    public int[] woundDiePool;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Roll(attacks, hit, wound);
        }
    }

    public void Roll(int attacks, int hitReq, int woundReq)
    {
        hitDiePool = new int[6];
        woundDiePool = new int[6];
        int numOfHits = 0;
        int numOfWounds = 0;

        for(int i = 1; i <= attacks; i++)
        {
            hitDiePool[Random.Range(0, 6)]++;
        }

        Debug.Log("Hits - 6: " + hitDiePool[5] + " / 5: " + hitDiePool[4] + " / 4: " + hitDiePool[3] + " / 3: " + hitDiePool[2] + " / 2: " + hitDiePool[1] + " / 1: " + hitDiePool[0]);

        if(explodeHit)
        {
            if(hitDiePool[5] != 0)
            {
                int extraHits = hitDiePool[5];
                extraDiePool = new int[6];

                for(int i = 1; i <= attacks; i++)
                {
                    extraDiePool[Random.Range(0, 6)]++;
                }

                for (int i = 5; i >= (hitReq - 1); i--)
                {
                    numOfHits += hitDiePool[i];
                }

                Debug.Log("Exploding Hits - 6: " + extraDiePool[5] + " / 5: " + extraDiePool[4] + " / 4: " + extraDiePool[3] + " / 3: " + extraDiePool[2] + " / 2: " + extraDiePool[1] + " / 1: " + extraDiePool[0]);
            }
        }

        for (int i = 5; i >= (hitReq-1); i--)
        {
            numOfHits += hitDiePool[i];
        }

        for(int i = 1; i <= numOfHits; i++)
        {
            woundDiePool[Random.Range(0, 6)]++;
        }

        Debug.Log("Wounds - 6: " + woundDiePool[5] + " / 5: " + woundDiePool[4] + " / 4: " + woundDiePool[3] + " / 3: " + woundDiePool[2] + " / 2: " + woundDiePool[1] + " / 1: " + woundDiePool[0]);

        for (int i = 5; i >= (woundReq-1); i--)
        {
            numOfWounds += woundDiePool[i];
        }

        Debug.Log(numOfWounds + " Wounds");
    }
}
