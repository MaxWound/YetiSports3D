using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    private float snakePower;
    private void OnTriggerEnter(Collider other)
    {
        SnakeHit();
    }
    void SnakeHit()
    {
        PenguinScript.Instance.SetGrounded(false);
        PenguinScript.Instance._rb.AddForce(Vector3.up * snakePower, ForceMode.Impulse);
    }
}
