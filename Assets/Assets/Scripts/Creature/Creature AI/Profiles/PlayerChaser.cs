using CleverCrow.Fluid.BTs.Trees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AiProfiles/PlayerChaser")]
public class PlayerChaser : AiProfile
{
    public override BehaviorTreeBuilder BuildBehaviour(GameObject owner)
    {
        return base.BuildBehaviour(owner).Sequence().ChasePlayer().End();
    }
}
