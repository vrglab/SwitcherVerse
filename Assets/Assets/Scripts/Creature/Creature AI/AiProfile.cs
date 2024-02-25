using CleverCrow.Fluid.BTs.Trees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiProfile : ScriptableObject
{
    public virtual BehaviorTreeBuilder BuildBehaviour(GameObject owner)
    {
        return new BehaviorTreeBuilder(owner).Selector();
    }
}
