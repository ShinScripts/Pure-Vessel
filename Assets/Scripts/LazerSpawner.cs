using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private float timeBetweenShots = 2;
    [SerializeField] private float timeToDestroy;

    private void Start()
    {
        objectToSpawn.GetComponent<MoveItem>().timeToDestroy = timeToDestroy;
        StartCoroutine(Spawn(objectToSpawn, timeBetweenShots, spawnPos.transform.position));
    }

    private IEnumerator Spawn(GameObject itemToSpawn, float time, Vector3 position)
    {
        while (true)
        {
            Instantiate(itemToSpawn, position, itemToSpawn.transform.rotation);
            yield return new WaitForSeconds(time);
        }
    }
}
