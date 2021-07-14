using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public GameObject chefCameraRef;
    public Transform aimTargetRef;
    public Transform lookAtAimTargetRef;
    public Transform backTargetRef;
    private bool checkLookAt = true;
    private float aimCounter = -0.1f;
    private float fovCounter;
    private float smoothStep = 4.0f;

    public bool GetCheckLookAt()
    {
        return checkLookAt;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Aim"))
        {
            fovCounter = 0;
            checkLookAt = true;
        }

        if (Input.GetButton("Aim"))
        {
            if (chefCameraRef.GetComponent<ChefCamera>().clampMaxOffset == 10)
            {
                chefCameraRef.GetComponent<ChefCamera>().clampMaxOffset = 4;
                chefCameraRef.GetComponent<ChefCamera>().clampMinOffset = 2;
            }

            if(checkLookAt)
            {
                checkLookAt = false;
            }

            if(chefCameraRef.GetComponent<Camera>().fieldOfView > 45)
            {
                fovCounter -= Time.deltaTime * smoothStep;
                chefCameraRef.GetComponent<Camera>().fieldOfView += fovCounter;
            }

            if (aimCounter < 1)
            {
                aimCounter += Time.deltaTime * smoothStep;
            }   
        }
        else if(aimCounter > 0)
        {
            if (chefCameraRef.GetComponent<ChefCamera>().clampMaxOffset != 10)
            {
                chefCameraRef.GetComponent<ChefCamera>().clampMaxOffset = 10;
                chefCameraRef.GetComponent<ChefCamera>().clampMinOffset = 0;
            }

            if (chefCameraRef.GetComponent<Camera>().fieldOfView < 60)
            {
                fovCounter += Time.deltaTime * smoothStep;
                chefCameraRef.GetComponent<Camera>().fieldOfView += fovCounter;
            }

            aimCounter -= Time.deltaTime * smoothStep;
        }

        if (aimCounter >= 0)
        {
            chefCameraRef.transform.position = Vector3.Lerp(backTargetRef.position, aimTargetRef.position, aimCounter);
        }
    }
}
