using CleverCrow.Fluid.BTs.Trees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class BehaviourTreeExtensions
{
    public static BehaviorTreeBuilder ChasePlayer(this BehaviorTreeBuilder builder)
    {
        return builder.AddNode(new ChasePlayer());
    }

    public static BehaviorTreeBuilder TurnMovementOff(this BehaviorTreeBuilder builder)
    {
        return builder.AddNode(new TurnMovementOff());
    }

    public static BehaviorTreeBuilder IsPlayerInRange(this BehaviorTreeBuilder builder)
    {
        return builder.AddNode(new IsPlayerInRange());
    }

    public static BehaviorTreeBuilder IsPlayerOutOfRange(this BehaviorTreeBuilder builder)
    {
        return builder.AddNode(new IsPlayerOutOfRange());
    }
}
