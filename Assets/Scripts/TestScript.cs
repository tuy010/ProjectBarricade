using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("isDead" ,!anim.GetBool("isDead"));
        }

        if (Input.GetKeyDown(KeyCode.Space)&& !anim.GetCurrentAnimatorStateInfo(0).IsName("reaction"))
        {
            anim.SetTrigger("hitted");
        }

        if (Input.GetKeyDown(KeyCode.E) && !anim.GetCurrentAnimatorStateInfo(0).IsName("punch"))
        {
            anim.SetTrigger("punch");
        }
    }
}
