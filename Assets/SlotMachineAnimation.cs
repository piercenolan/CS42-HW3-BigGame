using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineAnimation : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem pokerChipOneClick; // assign this in the Inspector

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown() // Requires a Collider on the object
    {
        anim.Play("Spin", 0, 0f); // Play from the beginning

        if (pokerChipOneClick != null)
        {
            pokerChipOneClick.Play();
        }
    }
}
