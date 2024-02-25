using CleverCrow.Fluid.BTs.Tasks.Actions;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;

public class TurnMovementOff : ActionBase
{

    private AIPath AIpathFinder;

    protected override void OnInit()
    {
        base.OnInit();
        AIpathFinder = Owner.GetComponent<AIPath>();

    }

    protected override TaskStatus OnUpdate()
    {
        AIpathFinder.destination = Owner.transform.position;
        return TaskStatus.Success;
    }
}
