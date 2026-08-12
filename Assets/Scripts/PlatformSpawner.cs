using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform platformsParent;
    public Transform lastPlatform;
    Vector3 lastPos;
    Vector3 newPos;
    bool stop;

    void Start()
    {
        lastPos = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    void Update()
    {
        // For testing purpose only
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     SpawnPlatforms();
        // }
    }

    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(.1f);
            GeneratePosition();
            Instantiate(platformPrefab, newPos, Quaternion.identity, platformsParent);
        }
    }

    // void SpawnPlatforms()
    // {
    //     GeneratePosition();
    //     Instantiate(platformPrefab, newPos, Quaternion.identity);
    // }

    void GeneratePosition()
    {
        newPos = lastPos;
        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newPos.x += 2f;
        } else
        {
            newPos.z += 2f;
        }
        newPos.y = 3f;
        lastPos = newPos;
    }
}
