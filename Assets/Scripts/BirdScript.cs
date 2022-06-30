using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    float VerticalSpeed;
    bool isLow;
    bool toUp;
    float posToMoveY;
    [SerializeField]
    Transform posToMoveTransform;
    [SerializeField]
    float throwAngle;
    [SerializeField]
    float throwPower;
    [SerializeField]
    Transform HolderTransform;
    [SerializeField]
    float Speed;
    [SerializeField]
    float HoldTime;
    Rigidbody rb;
    Rigidbody pengRb;
    private void Start()
    {
        toUp = false;
        isLow = false;
        rb = gameObject.GetComponent<Rigidbody>();
        pengRb = PenguinScript.Instance._rb;
        posToMoveY = posToMoveTransform.position.y;
        HoldAndThrow();

    }
    private void FixedUpdate()
    {

        rb.position += new Vector3(-1f,0f, 0f) * Speed * Time.deltaTime;
        if (isLow == false)

        {
            if (rb.position.y >= posToMoveY)
            {
                //print($"{posToMoveY} and  {rb.position.y}");
                rb.position += new Vector3(0f, -1f, 0f) * VerticalSpeed * Time.deltaTime;
                print("õ");
            }
            else
            {
                isLow = true;

            }
        }
        else if (isLow == true && toUp == true)
        {
            rb.position += new Vector3(0f, 1f,0f) * VerticalSpeed * Time.deltaTime;
        }
    }
    public void HoldAndThrow()
    {
        StartCoroutine(IHoldAndThrow());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sky" && toUp == true)
        {
            Destroy(gameObject);
            SkyTrigger.isSpawned = false;
        }
    }
    public IEnumerator IHoldAndThrow()
    {
        PenguinScript.Instance.SetCollider(false);
        PenguinScript.Instance.inSimulation = true;
        PenguinScript.Instance.transform.rotation = PenguinScript.Instance.startRot;
        PenguinScript.Instance.transform.position = HolderTransform.position;
        

        PenguinScript.Instance.transform.SetParent(HolderTransform);
        pengRb.velocity = new Vector3(0f,0f, 0f);
        pengRb.isKinematic = true;
        
        yield return new WaitForSeconds(HoldTime);
        PenguinScript.Instance.transform.parent = null;
        toUp = true;
        pengRb.isKinematic = false;
        PenguinScript.Instance.inSimulation = false;
        PenguinScript.Instance.SetGrounded(false);
        PenguinScript.Instance._rb.AddForce(Vector3.left * throwPower,ForceMode.Impulse);
        
        PenguinScript.Instance.SetCollider(true);

    }
}
