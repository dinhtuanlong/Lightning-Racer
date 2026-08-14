using System.Collections;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    public Color[] colors;

    void Start()
    {
        StartCoroutine(ColorChanger());
    }

    void Update()
    {
        
    }

    IEnumerator ColorChanger()
    {
        while (true)
        {
            int randColor = Random.Range(0, 5);
            Camera.main.backgroundColor = colors[randColor];
            yield return new WaitForSeconds(10f);
        }
    }
}
