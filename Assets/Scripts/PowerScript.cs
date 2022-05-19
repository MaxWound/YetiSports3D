using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public static PowerScript Instance;
    [SerializeField]
    float moveSpeed;
    
    [SerializeField]
    Transform pointTransform;

    [SerializeField]
    Transform highPoint;
    [SerializeField]
    Transform lowPoint;
    private bool ToMove = false;
    // Start is called before the first frame update
    int moveValue = 1;
    public float powerValue;
    // Update is called once per frame
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (ToMove)
        {

            pointTransform.localPosition += new Vector3(0, 0.1f * moveValue, 0) * moveSpeed * Time.fixedDeltaTime;
            if (pointTransform.localPosition.y >= highPoint.localPosition.y)
            {
                moveValue = -1;
            }
            else if (pointTransform.localPosition.y <= lowPoint.localPosition.y)
            {
                moveValue = 1;
            }
            powerValue = pointTransform.localPosition.y - lowPoint.localPosition.y;
        }
    }
    public void SetPowerBool(bool _bool)
    {
        ToMove = _bool;
    }

}
