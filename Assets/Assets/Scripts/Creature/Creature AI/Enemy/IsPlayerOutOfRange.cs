using CleverCrow.Fluid.BTs.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerOutOfRange : ConditionBase
{
    /*
    CircleCollider2D Range;
    protected override void OnInit()
    {
        base.OnInit();
        Range = Owner.GetComponent<CircleCollider2D>();
    }

    protected override bool OnUpdate()
    {
        if (Range != null)
        {
            if (PlayerCreature.Instance.GetComponent<Collider2D>().IsTouching(Range))
            {
                return false;
            }
        }
        else
        {
            Range = Owner.AddComponent<CircleCollider2D>();
            Range.isTrigger = true;
            Range.radius = 2;
            if (PlayerCreature.Instance.GetComponent<Collider2D>().IsTouching(Range))
            {
                return false;
            }
        }
        return true;
    }*/
    protected override bool OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
