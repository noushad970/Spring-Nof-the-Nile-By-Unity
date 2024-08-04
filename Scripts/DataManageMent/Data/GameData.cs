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
    public int  savingWest, seaBag, rope, hammer, bible, safariHat, arrow, machete, fighter, fisherman, net, fishingRod;
    public GameData() {
        this.coin = 0;
        this.woodPlank = 0;
        this.bamboo= 0;
        this.fish = 0;
        this.meat = 0;
        this.gems = 0;
        this.life = 0;
        this.arrow = 0;
        this.machete = 0;
        this.fighter = 0;
        this.hammer = 0;
        this.safariHat = 0;
        this.savingWest = 0;
        this.seaBag = 0;
        this.rope = 0;
        this.bible = 0;
        this.fighter = 0;
        this.fisherman = 0;
        this.net = 0;
        this.fishingRod = 0;
    }
}
