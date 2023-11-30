using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] snakereferences;
    private GameObject spawnedsnake;
    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;
    public DoorClosing L;
    void Start()
    {
        StartCoroutine(Spawnsnakes());
    }
    IEnumerator Spawnsnakes()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            randomIndex = 0;
            //randomSide = Random.Range(0, 2);
            randomSide = 0;
            L.bouldertrigger = false;
            spawnedsnake = Instantiate(snakereferences[randomIndex]);
            //left side
            if (randomSide == 0)
            {
                spawnedsnake.transform.position = leftPos.position;
                spawnedsnake.GetComponent<boulder>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedsnake.transform.position = rightPos.position;
                spawnedsnake.GetComponent<boulder>().speed = -6;
                //to flip the snake
                spawnedsnake.transform.localScale = new Vector3(-9f, 3f, 1f);
                //sr.flipX = true;
            }
        }

    }
}
