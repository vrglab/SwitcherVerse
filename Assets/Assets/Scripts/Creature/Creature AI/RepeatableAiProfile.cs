using CleverCrow.Fluid.BTs.Trees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatableAiProfile : AiProfile
{
    public override BehaviorTreeBuilder BuildBehaviour(GameObject owner)
    {
        return new BehaviorTreeBuilder(owner).RepeatForever().Selector();
    }
}
