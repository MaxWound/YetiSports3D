using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinScript : MonoBehaviour
{
    [SerializeField]
    float BumpForce;
    [SerializeField]
    float PowerMultiplier;
   public static PenguinScript Instance;

    private bool StartHitted = false;
    private bool Grounded = false;
    Rigidbody rb;
    private void Awake()
    {

        Instance = this;
       rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    private void OnTriggerStay(Collider other)
    {
        Grounded = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(Grounded != true)
        {
           
            if (rb.velocity.y <= -5)
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
        
        if(rb.velocity.magnitude < 0.05f && Grounded == true)
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
    void SetRot()
    {
       
            rb.MoveRotation(Quaternion.Euler(0f, -90f, 90f));
        
    }
    void Rotate()
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
