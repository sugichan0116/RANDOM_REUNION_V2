﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class MovableObjectScript : ObjectOnMapScript
{
    Rigidbody2D rb2d;

    float movement = 0.3f;
    directions _state;
    directions state {
        get { return _state; }
        set
        {
            if(stateDic[value] != null)
                sr.sprite = stateDic[value];
        }
    }

    public directions State_Initial = directions.Down;

    public Sprite Sprite_Up        = null;
    public Sprite Sprite_UpLeft    = null;
    public Sprite Sprite_UpRight   = null;
    public Sprite Sprite_Left      = null;
    public Sprite Sprite_Right     = null;
    public Sprite Sprite_Down      = null;
    public Sprite Sprite_DownLeft  = null;
    public Sprite Sprite_DownRight = null;

	Dictionary<directions, Sprite> stateDic = new Dictionary<directions, Sprite>();
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        stateDic.Add(directions.Up, Sprite_Up);
        stateDic.Add(directions.UpLeft, Sprite_UpLeft);
        stateDic.Add(directions.UpRight, Sprite_UpRight);
        stateDic.Add(directions.Left, Sprite_Left);
        stateDic.Add(directions.Right, Sprite_Right);
        stateDic.Add(directions.Down, Sprite_Down);
        stateDic.Add(directions.DownLeft, Sprite_DownLeft);
        stateDic.Add(directions.DownRight, Sprite_DownRight);

        state = directions.Down;
        transform.position = (new MapCoordinate(MapCoordinate_Initial.x, MapCoordinate_Initial.y)).ToVector2();
    }

    private void Start()
    {

    }

    public enum directions{
		Up,
		UpLeft,
		UpRight,
		Left,
		Right,
		Down,
		DownLeft,
		DownRight
	}

    public void Move(Vector2 direction)//引数の方向に移動に移動量movementだけ移動
    {
        Move(direction, movement);
    }
    public void Move(Vector2 direction, float q)//引数の方向に移動量Qだけ移動
    {
        rb2d.MovePosition(rb2d.position + direction.normalized * q);
		DirectionApply(direction);
    }
    
    public void Move(MapCoordinate mapcoordinate)//MapCoordinateのToVector2の方向に移動量movementだけ移動
    {
        Move(mapcoordinate.ToVector2());
    }
    public void Move(MapCoordinate mapcoordinate, float q)//MapCoordinateのToVector2の方向に移動量Qだけ移動
    {
        Move(mapcoordinate.ToVector2(),q);
    }
            
	void DirectionApply(Vector2 direction){
		var x = direction.x;
		var y = direction.y;

		if (y > 0) {
			if (x == 0) {
				state = directions.Up;
			} else if (x < 0) {
				state = directions.UpLeft;
			} else if (x > 0) {
				state = directions.UpRight;
			}
		} else if (y == 0) {
			if (x < 0) {
				state = directions.Left;
			} else if (x > 0) {
				state = directions.Right;
			} else if (x == 0) {
				return;
			}
		} else if (y < 0) {
			if (x == 0) {
				state = directions.Down;
			} else if (x < 0) {
				state = directions.DownLeft;
			} else if (x > 0) {
				state = directions.DownRight;
			}
		}
	}
}