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
            float angle = transform.eulerAngles.y;
            if ((Mathf.Repeat(angle + 180, 360) - 180 <= -90f))
            {
                moveValue = 1;
            }
            else if ((Mathf.Repeat(angle + 180, 360) - 180 >= 0f))
            {
                moveValue = -1;
            }
            
            transform.Rotate(Vector3.up, 90f * speed * moveValue * Time.deltaTime);
            
            direction = secondPoint.position - firstPoint.position;
        }
    }
    
}
