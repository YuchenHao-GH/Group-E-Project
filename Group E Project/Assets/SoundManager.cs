using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip shootSound;
    public static AudioClip levelCompleteSound;
    public static AudioClip attackSound;
    public static AudioClip devilDamageSound;
    public static AudioClip devilDeathSound;
    public static AudioClip devilAttackSound;
    public static AudioClip healthUpSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        shootSound = Resources.Load<AudioClip>("ShootSound");
        levelCompleteSound = Resources.Load<AudioClip>("LevelCompleteSound");
        attackSound = Resources.Load<AudioClip>("AttackSound");
        devilDamageSound = Resources.Load<AudioClip>("DevilDamageSound");
        devilDeathSound = Resources.Load<AudioClip>("DevilDeathSound");
        devilAttackSound = Resources.Load<AudioClip>("DevilAttackSound");
        healthUpSound = Resources.Load<AudioClip>("HealthUpSound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayShootSoundClip()
    {
        audioSrc.PlayOneShot(shootSound);
    }
    public static void PlayLevelCompleteSoundClip()
    {
        audioSrc.PlayOneShot(levelCompleteSound);
    }
    public static void PlayAttackSoundClip()
    {
        
        audioSrc.PlayOneShot(attackSound);
    }
    public static void PlayDevilDamageSoundClip()
    {
        
        audioSrc.PlayOneShot(devilDamageSound);
    }
    public static void PlayDevilDeathSoundClip()
    {
        audioSrc.PlayOneShot(devilDeathSound);
    }
    public static void PlayDevilAttackSoundClip()
    {
        audioSrc.PlayOneShot(devilAttackSound);
    }
    public static void PlayHealthUpSoundClip()
    {
        audioSrc.PlayOneShot(healthUpSound);
    }
}
