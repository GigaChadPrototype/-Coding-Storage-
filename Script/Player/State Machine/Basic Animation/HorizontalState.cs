using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HorizontalState : PlayerState
{
    public SetCheckPoint checkPoint;
    public HorizontalState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        checkPoint = FindObjectOfType<SetCheckPoint>();
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        #region Main
        if (player.IsGrounded())
        {
            #region Run Animation
            if (player.posX != 0)
            {
                player.animator.Play("Run");
            }
            #endregion

            #region Idle Animation
            else if(player.posX == 0)
            {
                player.animator.Play("Idle");
            }
            #endregion

            player.jumpStep = 2;
        }
        #endregion

        #region Movement -> Jump
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
        {
            player.rb2d.velocity = new Vector2(player.rb2d.velocity.x, player.jumpForce);
        }

        if (!player.IsGrounded())
        {
            player.stateMachine.ChangeState(player.jumpState);
        }
        #endregion

        #region Movement -> Attack
        if (Input.GetKeyDown(KeyCode.K) && player.attackCDtime <= 0f)
        {
            player.stateMachine.ChangeState(player.attackState);
        }
        #endregion

        #region Movement -> Checkpoint
        if (Input.GetKeyDown(KeyCode.E) && checkPoint.atCheckPointReached)
        {
            player.stateMachine.ChangeState(player.cpIn);
        }
        #endregion
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
