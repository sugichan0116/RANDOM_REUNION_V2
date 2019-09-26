﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnMapScript : MonoBehaviour
{
    public Sprite Sprite_Initial = null;
    public Vector2 MapCoordinate_Initial; // 初期座標 生の値がそのままマップ座標に解釈される点に注意
    MapCoordinate _position;
    public MapCoordinate Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
            transform.position = value.ToVector2();
        }
    }

    protected SpriteRenderer sr;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Sprite_Initial;
        Position = new MapCoordinate(MapCoordinate_Initial.x, MapCoordinate_Initial.y);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
