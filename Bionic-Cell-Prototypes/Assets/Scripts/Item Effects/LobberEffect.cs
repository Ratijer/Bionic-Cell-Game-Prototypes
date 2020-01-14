using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberEffect : WeaponEffect
{
    public LobberEffect(PortBehavior port, ItemBehavior item) : base(port, item) { }

    public override void RegisterEventEffect()
    {
        port.AttackEvent += CauseEventEffect;

        GameObject weapon = GameObject.Instantiate(item.weaponSOAsset.weaponPrefab, port.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;

        WeaponBehavior weaponBehavior = weapon.GetComponent<WeaponBehavior>();
        weaponBehavior.SetSOAsset(item);
        weaponBehavior.SetPort(port);

        Debug.Log("Registered Lobber!");
    }

    public override void CauseEventEffect()
    {
        //Debug.Log("Doing single shot Attack event");

        //GameObject weapon = GameObject.Instantiate(item.weaponSOAsset.weaponPrefab, port.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;

        //WeaponBehavior weaponBehavior = weapon.GetComponent<WeaponBehavior>();
        //weaponBehavior.SetSOAsset(item);

        //Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 result = (new Vector3(p.x, p.y, 0.0f) - new Vector3(port.transform.position.x, port.transform.position.y, 0.0f)).normalized;

        //weaponBehavior.SetDetails(9.0f, result);
    }
}
