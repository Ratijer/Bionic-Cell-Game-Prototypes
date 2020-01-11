//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LobberEffect : ItemEffect
//{
//    protected ProjectileSOAsset projectileSOAsset;

//    public LobberEffect(ItemLogic itemLogic) : base(itemLogic)
//    {
//        projectileSOAsset = itemLogic.itemSOAsset.projectileSOAsset;
//    }

//    public override void RegisterEventEffect()
//    {
//        itemLogic.port.AttackEvent += CauseEventEffect;
//        Debug.Log("Registered spore lobber effect!");
//    }

//    public override void UnregisterEventEffect()
//    {
//        itemLogic.port.AttackEvent -= CauseEventEffect;
//        Debug.Log("Registered spore lobber effect!");
//    }

//    public override void CauseEventEffect()
//    {
//        Debug.Log("Doing logic and visual of spore lobber Attack event");
//        Port port = itemLogic.port;
//        //UnitLogic unitLogic = weaponLogic.portLogic.unitLogic;

//        // Cause the event effect logically and visually
//        //Create instance of projectile
//        //GlobalSettings.instance.tableLogic.CreateProjectileLogic(projectileSOAsset, unitLogic, portLogic.assignedDirection);
//    }
//}