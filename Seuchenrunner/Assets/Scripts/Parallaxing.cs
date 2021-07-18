using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls background
public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;                         //array for fore- and backgrounds
    private float[] parallaxScales;                         //movement of camera to move backgrounds
    public float smoothing = 1f;                            //smoothness of parallaxis

    private Transform cam;                                  //reference to main camera
    private Vector3 previousCamPos;                         //camera position in previous frame

    void Awake ()                                           //called before Start()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    //initialize camera position and background position
    void Start()
    {
        previousCamPos = cam.position;                      

        parallaxScales = new float[backgrounds.Length];     
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    //update camera and background positions
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallaxX = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float parallaxY = (cam.position.y - previousCamPos.y) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX;
            float backgroundTargetPosY = backgrounds[i].position.y + parallaxY;

            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgroundTargetPosY, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        //set previous camera position to new position
        previousCamPos = cam.position;
    }
}
