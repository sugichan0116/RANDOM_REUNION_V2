﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

enum QuestCategory
{
    Main,sub
}

public abstract class Quest_Behaviour:MonoBehaviour
{
    QuestCategory questCategory;
    public string questName { get; private set; }
    string questTarget;
    int? deadline;
    string queriedBy;

    public QuestInfo info;
    public Action WhenQuestAccepted { get; protected set; }
    public Action WhenQuestCleared { get; protected set; }
    public Action WhenQuestFailed { get; protected set;}
    
    virtual protected void Start() {        
        questName = this.gameObject.name;//ゲームオブジェクトの名前と同じでいいならこれ　check
    }
    abstract public bool AllNormaCleared();
}

[Serializable]
public struct QuestInfo {
    public string displayName;
    public string target;
    public string place;
    public string reward;
    public int deadLine;
    public string detail;
}