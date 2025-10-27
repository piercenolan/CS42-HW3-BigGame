using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    // This variable is marked as `static`, which means it is
    // accessible by any script, anywhere! They can just write
    // Clickable.Clicks to read/write to this value.
    //
    // See an example in `ClickTracker.cs`, which is on a UI
    // object titled `Tracker Text (TMP)`.
    public static int Clicks = 0;
    public static int Chips = 0;
    public static int Range = 10;
    public static int Level = 1;
    public static int ChipsNeeded = 1000 * Level;
    public static float JackpotRatio = 0.5f;

    public ParticleSystem chipBurst;  // assign in Inspector
    public AudioClip jackpotSound;
    private AudioSource audioSource;

    /// <summary>
    /// This function is called when the mouse button clicks
    /// on this object.
    /// </summary>
    /// 
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        Clicks += 1;
        if (Random.Range(0, Range) == 0)
        {
            Chips += (int)((Chips * JackpotRatio) + 1);
            chipBurst.Play();
            audioSource.PlayOneShot(jackpotSound);
            // Clicks += (int)(Clicks * 0.15);
        }
        else
        {
            Chips += 1;  // add one point
        }
        checkLevel();
    }

    private void checkLevel()
    {
        int NewLevel = (Clicks / ChipsNeeded) + 1;
        if (NewLevel > Level)
        {
            Level = NewLevel;
            Range = Mathf.Max(1, 1000 - ((Level - 1) * 50));
        }
    }
}
