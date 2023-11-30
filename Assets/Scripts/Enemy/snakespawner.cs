using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakespawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] snakereferences;
    private GameObject spawnedsnake;
    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;
    void Start()
    {
        StartCoroutine(Spawnsnakes());
    }
    IEnumerator Spawnsnakes()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            randomIndex = 0;
            //randomSide = Random.Range(0, 2);
            randomSide = 1;
            spawnedsnake = Instantiate(snakereferences[randomIndex]);
            //left side
            if (randomSide == 0)
            {
                spawnedsnake.transform.position = leftPos.position;
                spawnedsnake.GetComponent<snake>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedsnake.transform.position = rightPos.position;
                spawnedsnake.GetComponent<snake>().speed = -20;
                //to flip the snake
                spawnedsnake.transform.localScale = new Vector3(-3f, 3f, 1f);
                //sr.flipX = true;


            }
        }

    }
}
