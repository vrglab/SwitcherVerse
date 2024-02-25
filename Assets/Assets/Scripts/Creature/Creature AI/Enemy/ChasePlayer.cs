using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : ActionBase
{
    private AIPath AIpathFinder;

    protected override void OnInit()
    {
        base.OnInit();
        AIpathFinder = Owner.GetComponent<AIPath>();

    }

    protected override TaskStatus OnUpdate()
    {
        //AIpathFinder.destination = PlayerCreature.Instance.gameObject.transform.position;
        return TaskStatus.Success;
    }
}
