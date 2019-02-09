﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Unit : GridObject
{
    public string characterName;
    public string characterMoniker;

    public int mxHlth = 1;

    public TurnActions turnActions;

    private int cHlth = 1;
    private int atk = 1;
    private int moveSpeed = 3;
    private int team = 0;
    private int lvl = 1;

    public Unit()
    {
        this.characterName = "0";
        this.characterMoniker = "Null";
        turnActions = new TurnActionsBasicUnit();
    }

    public Unit(CharMeta meta, int team, int mxHlth, int atk,  int moveSpeed)
    {
        this.characterName = meta.name + UnityEngine.Random.Range(0,1).ToString();
        this.characterMoniker = meta.name;
        this.team = team;
        this.mxHlth = cHlth = mxHlth;
        this.atk = atk;
        this.moveSpeed = moveSpeed;
        this.lvl = meta.lvl;
        turnActions = new TurnActionsBasicUnit();
    }

    public void Init()
    {
        cHlth = mxHlth;
    }

    public int GetLvl()
    {
        return lvl;
    }
  
    public TurnActions GetTurnActions()
    {
        return turnActions;
    }

    public void IsAttacked(int atk)
    {
        cHlth -= atk;
    }

    public bool IsDead()
    {
        return cHlth <= 0;
    }

    public int GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetCurrHealth()
    {
        return cHlth;
    }

    public int GetAttack()
    {
        return atk;
    }

    public int GetTeam()
    {
        return team;
    }
}
