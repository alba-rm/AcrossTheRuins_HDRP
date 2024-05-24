using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Julien : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void SetTalkingAnimation(bool isTalking)
    {
        anim.SetBool("IsTalking", isTalking);
    }
}
