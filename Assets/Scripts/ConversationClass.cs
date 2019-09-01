﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class ConversationClass
{
    [SerializeField]
    List<Saying> Contents = new List<Saying>();//会話の内容

    IEnumerator Speak(){//スペースキーが押されると会話が進む
    	for(int i = 0;i < Contents.Count;i++){
	    Debug.Log(Contents[i].Who + " " + Contents[i].What);
	    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
	    yield return null;
	}
	yield break;
    }
}

[System.SerializableAttribute]
class Saying{//インスペクタから表示、編集する内容を示すクラス
    public int Who;
    [Multiline(3)]
    public string What;
}
