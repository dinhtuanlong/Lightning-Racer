using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject diamondPrefab;
    [Range(0,1)] public float diamondSpawnChance;
    public float spawnDistanceMin = -.8f;
    public float spawnDistanceMax = .8f;
    Rigidbody rb;
    string PLAYER_STRING = "Player";
    bool needToFall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(SpawnDiamond());
    }

    void Update()
    {
        if (transform.position.y > 0)
        {
            rb.isKinematic = false;
        } else if (transform.position.y <= 0 && !needToFall)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            rb.isKinematic = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_STRING))
        {
            needToFall = true;
            Invoke("Fall", 0.2f);
        }
    }

    void Fall()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1.5f);
    }

    IEnumerator SpawnDiamond()
    {
        yield return null;
        if (diamondSpawnChance >= Random.Range(0, 1f) && diamondSpawnChance > 0)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(spawnDistanceMin, spawnDistanceMax), transform.position.y - 2.17f, transform.position.z + Random.Range(spawnDistanceMin, spawnDistanceMax));
            GameObject diamondInstance = Instantiate(diamondPrefab, spawnPos, Quaternion.identity);
            diamondInstance.transform.SetParent(this.transform);
        }
    }
}
