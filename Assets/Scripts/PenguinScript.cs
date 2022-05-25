using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinScript : MonoBehaviour
{
    private SphereCollider SphereCollider;
    public bool inSimulation = false;
    [SerializeField]
    float BumpForce;
    [SerializeField]
    float PowerMultiplier;
   public static PenguinScript Instance;
    MeshRenderer renderer;
    private bool StartHitted = false;
    private bool Grounded = false;
    Rigidbody rb;
   public Rigidbody _rb => rb;
    private void Awake()
    {
        SphereCollider = GetComponent<SphereCollider>();
        renderer = GetComponent<MeshRenderer>();
        Instance = this;
       rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    public void SetCollider(bool _bool)
    {
        SphereCollider.enabled = _bool;
    }
    private void OnTriggerStay(Collider other)
    {
        Grounded = true;

    }
    public void SetGrounded(bool _bool)
    {
        Grounded = _bool;
    }
    public void SetVisible(bool _bool)
    {
        renderer.enabled = _bool;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Grounded != true)
        {

            if (rb.velocity.y <= -1f)
            {

                Bump();
            }

           
                Grounded = true;
                SetRot();
           
            
            //rb.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }
    private void Bump()
    {
        rb.AddForce(Vector3.up * (rb.velocity.y * -1) * BumpForce, ForceMode.Impulse);
    }
    private void OnTriggerExit(Collider other)
    {
        Grounded = false;
    }
    
    private void FixedUpdate()
    {
        
        if(rb.velocity.magnitude < 0.05f && Grounded == true && inSimulation != true)
        {
            print("стоп");
            AngleAndPower.Instance.RestartAngleAndPower();
        }
        Rotate();
        if (Input.GetKeyDown(KeyCode.F))
        {

            HitPenguinByAngleAndPower();
            
        }
    }
    public void HitPenguinByAngleAndPower()
    {
        Grounded = false;
        StartHitted = true;
        rb.useGravity = true;
        Vector3 dir = AngleScript.Instance.direction;
        print(dir);
        rb.AddForce(dir * PowerMultiplier * PowerScript.Instance.powerValue , ForceMode.Impulse);
    }
   public void SetRot()
    {
       
            rb.MoveRotation(Quaternion.Euler(0f, -90f, 90f));
        
    }
    public void Rotate()
    {
        //  if (StartHitted == true)
        if(Grounded == false)
        {
            
            var direction = rb.velocity;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            //penguinTransform.localRotation = Quaternion.Euler(0f, 0f, angle);
            print("r");

            if (rb.velocity != Vector3.zero && Grounded == false)
            {
                rb.rotation = Quaternion.LookRotation(rb.velocity); 
            }
            
            //rb.AddTorque(Vector3.Cross(transform.right, rb.velocity));
            //rb.MoveRotation(Quaternion.LookRotation(rb.velocity - new Vector3(0f,0f,-90f), Vector3.up));
              
        }
    }
}
