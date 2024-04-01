using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BossComponents
{
    Rigidbody2D rb2d { get; set; }
    Animator animator { get; set; }
    BoxCollider2D bc2d { get; set; }
    LayerMask jumpableGround { get; set; }
    public bool IsGrounded();
}
