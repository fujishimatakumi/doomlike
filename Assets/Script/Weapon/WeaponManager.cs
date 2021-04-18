using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//武器の操作を担当するクラス
public class WeaponManager : MonoBehaviour
{

    WeaponBase _nowWeapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponAction();
    }

    private void WeaponAction()
    {
        _nowWeapon.WeaponAction();
    }

    public void SetWeapon(WeaponBase weapone) { _nowWeapon = weapone; }
}
