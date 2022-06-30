using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAndPower : MonoBehaviour
{
   public Animator yetiAnim;
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
    private void Start()
    {
        IsSetting = false;
        ToHit = false;
        RestartAngleAndPower();
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
            
            PenguinScript.Instance.HitPenguinByAngleAndPower();
            ToHit = false;
            AngleSet = false;
            IsSetting = false;
            PowerScript.Instance.gameObject.SetActive(false);
           AngleScript.Instance.gameObject.SetActive(false);

        }






    }
    public void RestartAngleAndPower()
    {
        print("1");
        if (IsSetting == false && ToHit == false)
        {
            StartCoroutine(RestartHit());
        }
    }
    public IEnumerator RestartHit()
    {
        PowerScript.Instance.gameObject.SetActive(false);
        AngleScript.Instance.gameObject.SetActive(false);
        yetiAnim.ResetTrigger("strike");

        yetiAnim.ResetTrigger("take");
        yetiAnim.SetTrigger("take");
        yetiAnim.gameObject.transform.position = new Vector3(PenguinScript.Instance.transform.position.x, yetiAnim.gameObject.transform.position.y, yetiAnim.gameObject.transform.position.z);
        
        yield return new WaitForSeconds(3f);
        PowerScript.Instance.gameObject.SetActive(true);
        AngleScript.Instance.gameObject.SetActive(true);
        print("Restart");
        ToHit = true;
        AngleScript.Instance.AngleSetBool(true);
    }
    public void HitAnim()
    {
        yetiAnim.SetTrigger("strike");
    }
}
