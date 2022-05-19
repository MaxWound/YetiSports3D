using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAndPower : MonoBehaviour
{
    public static AngleAndPower Instance;
    private bool AngleSet = false;
    private bool AngleSetting = false;
    private bool PowerSet = false;
    private bool PowerSetting = false;
    private bool ToHit = true;
    private bool IsSetting = true;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {

        if
            (Input.GetKeyDown(KeyCode.Mouse0) && ToHit == true && AngleSet == false && PowerSet == false)
        {
            IsSetting = true;

            AngleSet = true;
            AngleScript.Instance.AngleSetBool(false);
            PowerScript.Instance.SetPowerBool(true);

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && ToHit == true && AngleSet == true)
        {
            
            PowerScript.Instance.SetPowerBool(false);
            ToHit = false;
            AngleSet = false;
            IsSetting = false;
            PenguinScript.Instance.HitPenguinByAngleAndPower();

        }






    }
    public void RestartAngleAndPower()
    {
        
        if (IsSetting == false && ToHit == false)
        {
            print("Restart");
            ToHit = true;
            AngleScript.Instance.AngleSetBool(true);
        }
    }
}
