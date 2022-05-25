using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTrigger : MonoBehaviour
{
    public static bool isSpawned;
    [SerializeField]
    GameObject BirdObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PenguinScript>() != null && isSpawned == false)
        {
            isSpawned = true;
            Instantiate(BirdObj, PenguinScript.Instance.transform.position, Quaternion.identity);
        }
    }
}
