using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffect
{
    protected PortBehavior port;
    protected ItemBehavior item;

    public WeaponEffect(PortBehavior port, ItemBehavior item)
    {
        this.port = port;
        this.item = item;
    }

    public virtual void RegisterEventEffect() { }   //Go from item to weapon and attach to port

    public virtual void CauseEventEffect() { }      //Weapon does its effect

    public virtual void UnregisterEventEffect() { } //Remove weapon and its effect
}