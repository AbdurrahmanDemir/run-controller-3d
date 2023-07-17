using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propeller : MonoBehaviour
{
    public Animator animator;
    public BoxCollider _wind;


    public void propellerAnim(string stage)
    {
        if (stage=="true")
        {
            animator.SetBool("run",true);
            _wind.enabled = true;
        }
        else
        {
            animator.SetBool("run", false);
            _wind.enabled = false;

        }


        StartCoroutine(propellerTimer());
    }
    IEnumerator propellerTimer()
    {
        yield return new WaitForSeconds(2f);
        propellerAnim("true");
    }
}
