using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroys explosion object
public class DestroyItself : MonoBehaviour
{
    public void animEndDestroy()
    {
        Destroy(gameObject);
    }
}
