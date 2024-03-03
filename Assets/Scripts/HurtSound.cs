using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSound : MonoBehaviour
{
    public AudioClip enemyHurt;
    public AudioClip playerHurt;
    public AudioClip enemyDie;
    public AudioClip playerDie;

    public void EnemyHurt()
    {
        AudioSystem.Play(enemyHurt);
    }
    public void PlayerHurt()
    {
        AudioSystem.Play(playerHurt);
    }
    public void EnemyDie()
    {
        AudioSystem.Play(enemyDie);
    }
    public void PlayerDie()
    {
        AudioSystem.Play(playerDie);
    }
}
