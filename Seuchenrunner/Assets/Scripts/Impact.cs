using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//impact with bullets
public class Impact : MonoBehaviour
{
    //game object destroyed
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);
    }

}
