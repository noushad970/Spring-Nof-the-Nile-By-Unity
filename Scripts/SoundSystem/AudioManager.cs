using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource oceanEnvironmentSound, riverEnvironmentSound, SinglePlayerSwimSound,jungleSoundFX, BGMusic,waterSoundWithBoat;
    public AudioSource gemCollide, CoinCollide, DiveIntoWater, enablePowerUp, collideWithObstacle, PlayerDamaged, playerDied, hitItem, shipDestroy, repairSound, throwMachete,getbonusFx,arrowHitSound;
    public AudioSource CrocAttackFX,punchFX,buttonPressSound,unlockItemFX,BuysomethingFX, PlayMosquitoFX,PlaySnakeSound, PlayTreeFallSound,hitWithWoodFX;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {

    }
    public void singlePlayerAudio()
    {
        SinglePlayerSwimSound.Play();
        waterSoundWithBoat.Stop();
    }
    public void PlayerWithBoatAudio()
    {
        waterSoundWithBoat.Play();
        SinglePlayerSwimSound.Stop();
    }
    public void oceanShoreAudio()
    {
        oceanEnvironmentSound.Play();
    }
    public void riverAudio()
    {
        riverEnvironmentSound.Play();
    }
    public void environmentAudio()
    {
        jungleSoundFX.Play();
    }
}
