using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapon : MonoBehaviour
{
    void Update()
    {
        GameObject Gun = transform.Find("Pistol(Clone)").gameObject;

        if(Gun == true)
        {
            PlayerCtrl.instance.GetComponent<PlayerCtrl>()._Gun = true;
        }
        else
        {
            PlayerCtrl.instance.GetComponent<PlayerCtrl>()._Gun = false;
        }
        
    }
}
