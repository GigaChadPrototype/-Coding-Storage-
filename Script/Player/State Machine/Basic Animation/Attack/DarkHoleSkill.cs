using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHoleSkill : PlayerState
{
    public new Player player;

    [Header("Variables")]
    protected float timeHolding;
    protected float endTime;
    protected float endDuration = 0.3f;
    public DarkHoleSkill(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        this.player = player;
    }

    public override void EnterState()
    {
        timeHolding = 0f;
        player.skill.gameObject.SetActive(true);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        timeHolding += Time.deltaTime;
        player.animator.Play("CheckpointProgress");
        if (timeHolding > 0f && timeHolding <= 0.5f) 
            player.skill.animator.Play("DHFirstForm");
        if (timeHolding >= 0.5f) 
            player.skill.animator.Play("DHSecondForm");

        if (Input.GetKeyUp(KeyCode.L))
        {
            timeHolding = -1f;
            endTime = endDuration;
        }
    }

    public override void PhysicsUpdate()
    {
        if(timeHolding < 0f) timeHolding -= Time.deltaTime;

        if(endTime > 0f)
        {
            endTime -= Time.deltaTime;
            player.skill.animator.Play("DHEndStage");
        }

        if (endTime < 0f)
        {
            endTime = 0f;
            player.skill.gameObject.SetActive(false);
            player.stateMachine.ChangeState(player.cpOut);
        }
    }
}
