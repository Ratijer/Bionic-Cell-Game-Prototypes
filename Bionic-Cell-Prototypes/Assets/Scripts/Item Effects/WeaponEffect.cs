using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffect
{
    protected PlayerController player;
    protected ItemBehavior item;

    public WeaponEffect(PlayerController player, ItemBehavior item)
    {
        this.player = player;
        this.item = item;
    }

    public virtual void RegisterEventEffect() { }

    public virtual void CauseEventEffect() { }
}