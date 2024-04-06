using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    [field: HideInInspector]
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        this.gameObject.SetActive(false);
    }
}
