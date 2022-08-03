using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject bananaPrefab,watermelonPrefab, cherryPrefab;
    int dgr = 0;
    void Start()
    {
        for (int j = 0; j < 6; j++)
        {
            for (int k = 0; k < 5; k++)
            {
               

                Vector3 matRand = new Vector3(j, 0, k);
                if (dgr == 0 || dgr == 2 || dgr == 4 || dgr == 6 || dgr == 8 || dgr == 12 || dgr == 14 || dgr == 15 || dgr == 16 || dgr == 18 || dgr == 24 || dgr == 29)
                    Instantiate(bananaPrefab, matRand, Quaternion.identity);
                else if(dgr == 3 || dgr == 9 || dgr == 10 || dgr == 11 || dgr == 13 || dgr == 17 || dgr == 21 || dgr == 25 || dgr == 27)
                    Instantiate(watermelonPrefab, matRand, Quaternion.identity);
                else
                    Instantiate(cherryPrefab, matRand, Quaternion.identity);
                dgr++;




            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
