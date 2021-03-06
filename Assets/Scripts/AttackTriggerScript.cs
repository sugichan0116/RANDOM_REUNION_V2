﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerScript: MonoBehaviour
{
    [SerializeField]
    int damage=0;
    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D other) {
        PalameterScript palam = other.GetComponent<PalameterScript>();
        StatusScript status = other.GetComponent<StatusScript>();

        if (status!=null && status.IsInvincible) return;

        palam?.GainDamage(damage);
        status?.EnInvincible();
    }

}
