using System.Collections.Generic;
using UnityEngine;

//武器の操作を担当するクラス
public class WeaponManager : MonoBehaviour
{
    List<WeaponBase> _weaponList;
    int _nowWeaponIndex;
    [SerializeField] bool _debug;
    void Start()
    {
        _weaponList = new List<WeaponBase>();
        _nowWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //WeaponAction();
        WeaponChange();
    }

    private void WeaponAction()
    {
        _weaponList[_nowWeaponIndex].WeaponAction();
    }

    public void SetWeapon(WeaponBase weapone) { _weaponList.Add(weapone); }

    //武器を変更する関数
    //武器は一周する
    private void WeaponChange()
    {
        float mouseWhellAxis = Input.GetAxis("ScrollWheel");
        //マウスホイールを上に回転させた場合一つ前の武器に切り替える
        if (mouseWhellAxis > 0)
        {
            if (_nowWeaponIndex == 0)
            {
                _nowWeaponIndex = _weaponList.Count - 1;
            }
            else
            {
                //int beforIndex = _nowWeaponIndex;
                _nowWeaponIndex = (_nowWeaponIndex - 1) % _weaponList.Count;
            }
        }
        //マウスホイールを下に回転させた場合一つ後の武器に切り替える
        else if(mouseWhellAxis < 0)
        {
            //int beforIndex = _nowWeaponIndex;
            _nowWeaponIndex = (_nowWeaponIndex + 1) %_weaponList.Count;
        }

        if (_debug) Debug.Log("nowIndex:" + _nowWeaponIndex);
    }
}

