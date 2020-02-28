using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    private GameObject numOfAttacks;
    private GameObject numToHit;
    private GameObject numToWound;
    public int[] hitDiePool;
    public int[] woundDiePool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Roll(int attacks, int hitReq, int woundReq)
    {
        hitDiePool = new int[6];
        woundDiePool = new int[6];
        int numOfHits = 0;
        int numOfWounds = 0;

        for(int i = 0; i <= attacks; i++)
        {
            hitDiePool[Random.Range(0, 6)]++;
        }

        for(int i = 5; i >= (hitReq - 1); i--)
        {
            numOfHits += hitDiePool[i];
        }

        for(int i = 0; i <= numOfHits; i++)
        {
            woundDiePool[Random.Range(0, 6)]++;
        }

        for (int i = 5; i >= (woundReq - 1); i--)
        {
            numOfWounds += woundDiePool[i];
        }

        return numOfWounds;
    }
}
