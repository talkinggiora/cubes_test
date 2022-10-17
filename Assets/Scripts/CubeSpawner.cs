using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] Transform spawner;
    [SerializeField] TMP_InputField speed;
    [SerializeField] TMP_InputField distance;
    [SerializeField] TMP_InputField time;

    private float timeValue;
    private float distanceValue;
    private float speedValue;
    private Cube newCube;

    public void Check()
    {        
        float.TryParse(time.text, out timeValue);
        float.TryParse(distance.text, out distanceValue);
        float.TryParse(speed.text, out speedValue);

        if (timeValue != 0 && distanceValue != 0 && speedValue != 0)
            StartCoroutine(Spawn());
        else
            StopAllCoroutines();
    }

    public void Clear()
    {
        StopAllCoroutines();

        if (spawner.childCount != 0)
        {
            for (int i = 0; i < spawner.childCount; i++)
                Destroy(spawner.GetChild(i).gameObject);
        }

        Check();
    }

   IEnumerator Spawn()
    {
        newCube = Instantiate(cube, spawner).GetComponent<Cube>();
        newCube.Create(speedValue, distanceValue);

        yield return new WaitForSeconds(timeValue);

        if (timeValue > 0 && distanceValue > 0 && speedValue > 0)
            StartCoroutine(Spawn());
        else
            yield break;
    }

}
