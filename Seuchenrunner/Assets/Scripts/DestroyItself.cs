using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroys explosion object
public class DestroyItself : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
