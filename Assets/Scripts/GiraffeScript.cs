using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeScript : MonoBehaviour
{
    [SerializeField]
    float throwPower;
    [SerializeField]
    float throwAngle;
    [SerializeField]
    float waitSec;
    [SerializeField]
    Transform spawner;
    Vector2 spawnerPos;
    private void Start()
    {
        spawnerPos = spawner.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        SpawnAndThrow();
    }
    public void SpawnAndThrow()
    {
        print("hi");
        PenguinScript.Instance._rb.position = spawnerPos;
        StartCoroutine(WaitAndThrow());

    }
    IEnumerator WaitAndThrow()
    {
        PenguinScript.Instance.inSimulation = true;
        PenguinScript.Instance._rb.velocity = new Vector2(0f, 0f);
        PenguinScript.Instance._rb.isKinematic = true;
        PenguinScript.Instance.SetVisible(false);
        yield return new WaitForSeconds(waitSec);
        PenguinScript.Instance.SetVisible(true);
        PenguinScript.Instance._rb.isKinematic = false;
        PenguinScript.Instance._rb.AddForce(Vector3.left * throwPower, ForceMode.Impulse);
        PenguinScript.Instance.inSimulation = false;
    }
}
