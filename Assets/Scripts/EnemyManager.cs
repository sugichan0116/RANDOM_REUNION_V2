﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public Dictionary<string, Action> WhenEnemyDefeated { get; private set; }//Enemy側から呼び出す
    // Start is called before the first frame update
    void Start(){
        WhenEnemyDefeated = new Dictionary<string, Action>();   
    }

    public void EnemyGenerate() {
    }

    // Update is called once per frame
    void Update(){
    }
}
