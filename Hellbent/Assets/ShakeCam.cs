using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : MonoBehaviour
{
    public Animator camAnim;
    public void CamShake()
    {
        camAnim.SetTrigger("Shake Camera");
    }
}
