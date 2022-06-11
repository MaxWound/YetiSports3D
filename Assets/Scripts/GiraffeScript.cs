using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeScript : MonoBehaviour
{
    [SerializeField]
    Transform vectorA;
    [SerializeField]
    Transform vectorB;
    Collider GOcollider;
    [SerializeField]
    Animator animator;
    [SerializeField]
    float throwPower;
    [SerializeField]
    float throwAngle;
    [SerializeField]
    float waitSec;
    [SerializeField]
    Transform spawner;
    Vector3 hitDirection;
    Vector2 spawnerPos;
    private void Start()
    {
        hitDirection = vectorB.position - vectorA.position;
        //spawnerPos = spawner.position;
        GOcollider = GetComponent<Collider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        SpawnAndThrow();
    }
    public void SpawnAndThrow()
    {
        Destroy(GOcollider);
        print("hi");
        PenguinScript.Instance.transform.position = spawner.position;
        //PenguinScript.Instance._rb.position = spawner.position;

        PenguinScript.Instance.gameObject.transform.parent = spawner;
        StartCoroutine(WaitAndThrow());

    }
    IEnumerator WaitAndThrow()
    {
        animator.SetBool("Throw", true);

        PenguinScript.Instance.SetGrounded(false);
        PenguinScript.Instance.inSimulation = true;
        PenguinScript.Instance._rb.velocity = new Vector2(0f, 0f);
        PenguinScript.Instance._rb.isKinematic = true;
        //PenguinScript.Instance.SetVisible(false);
        yield return new WaitForSeconds(waitSec);
        //PenguinScript.Instance.SetVisible(true);
        PenguinScript.Instance._rb.isKinematic = false;
        animator.SetBool("Throw", false);
        PenguinScript.Instance.gameObject.transform.parent = null;
        PenguinScript.Instance.SetRot();
        PenguinScript.Instance.SetGrounded(false);
        PenguinScript.Instance.SetZ();
        
        PenguinScript.Instance._rb.AddForce(hitDirection * throwPower, ForceMode.Impulse);
        PenguinScript.Instance.SetGrounded(false);
        //animator.SetBool("Throw", false);
        yield return new WaitForSeconds(0.2f);
        PenguinScript.Instance.inSimulation = false;
    }
}
