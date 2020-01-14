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

    public virtual void RegisterEventEffect() { }

    public virtual void CauseEventEffect() { }
}