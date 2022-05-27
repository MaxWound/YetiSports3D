using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleScript : MonoBehaviour
{
    [SerializeField]
    Transform firstPoint;
    [SerializeField]
    Transform secondPoint;
    [SerializeField]
    float speed;
    private int moveValue = -1;
    public Vector3 direction;
    public static AngleScript Instance;

    public float angles;
    private bool ToMove = true;
    private void Awake()
    {
        Instance = this;
    }
    public void AngleSetBool(bool _bool)
    {
        ToMove = _bool;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RotAngle();



    }
    public void RotAngle()
    {
        
        if (ToMove)
        {
            float angle = Vector3.Angle(Vector3.up, transform.forward);

            print(angle);
            if (angle <= 0f)
            {
                //print("change");
                moveValue = -1;
            }
            else if (angle >= 90)
            {
                //print("change");
                moveValue = 1;
            }
            
            transform.Rotate(Vector3.up, 90f * speed * moveValue * Time.fixedDeltaTime);
            
            direction = secondPoint.position - firstPoint.position;
        }
    }
    
}
