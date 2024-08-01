using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coin;
    public int woodPlank;
    public int gems;
    public int fruit;
    public int bamboo;
    public int fish;
    public int meat;
    public int life;
    public GameData() {
        this.coin = 0;
        this.woodPlank = 0;
        this.bamboo= 0;
        this.fish = 0;
        this.meat = 0;
        this.gems = 0;
        this.life = 0;
    }
}
