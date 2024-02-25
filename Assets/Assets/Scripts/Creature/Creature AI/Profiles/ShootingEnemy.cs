using CleverCrow.Fluid.BTs.Trees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AiProfiles/ShootingEnemy")]
public class ShootingEnemy : ChasePlayerInRange
{
    public override BehaviorTreeBuilder BuildBehaviour(GameObject owner)
    {
        return base.BuildBehaviour(owner).RepeatUntilFailure().Sequence().IsPlayerInRange().Do("Face Player", () =>
        {
            //owner.transform.up = Utils.LooAt(owner.transform.position, PlayerCreature.Instance.transform.position);
            return CleverCrow.Fluid.BTs.Tasks.TaskStatus.Success;
        }).Do("Shoot", () =>
        {
            //owner.GetComponent<EnemyWeaponManager>().Shoot();
            return CleverCrow.Fluid.BTs.Tasks.TaskStatus.Success;
        });
    }
}
