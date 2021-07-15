using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public GameObject chefCameraRef;
    public Transform aimTargetRef;
    public Transform lookAtAimTargetRef;
    public Transform backTargetRef;
    public Transform[] throwPointsRef;
    public Transform landPointRef;
    public GameObject knifeBladeRef;
    private float throwForce = 20.0f;
    private bool checkLookAt = true;
    private float aimCounter = -0.1f;
    private float fovCounter;
    private float smoothStep = 4.0f;
    private float landAimRot;
    public bool checkKnife = false;

    private LineRenderer lineThrowRef;
    private TrailRenderer lineMoveRef;

    //private RaycastHit hit;

    public bool GetCheckLookAt()
    {
        return checkLookAt;
    }

    // Start is called before the first frame update
    void Start()
    {
        knifeBladeRef = GameObject.FindGameObjectWithTag("Knife");
        GameObject.FindGameObjectWithTag("Knife").SetActive(false);
        lineThrowRef = GetComponent<LineRenderer>();
        lineMoveRef = GetComponent<TrailRenderer>();
        lineThrowRef.numCornerVertices = 10;
        //landPointRef.gameObject.SetActive(false);
        lineThrowRef.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkKnife)
        {
            if (!GetComponent<MeshRenderer>().enabled)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }

            if(!lineMoveRef.enabled)
            {
                lineMoveRef.enabled = true;
            }
        }
        else
        {
            if (GetComponent<MeshRenderer>().enabled)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }

            if (lineMoveRef.enabled)
            {
                lineMoveRef.enabled = false;
            }
        }

        if (Input.GetButtonUp("Aim"))
        {
            fovCounter = 0;
            checkLookAt = true;

            //if (lineThrowRef.enabled)
            //{
            //    lineThrowRef.enabled = false;
            //}

            //if (landPointRef.gameObject.activeSelf == true)
            //{
            //    landPointRef.gameObject.SetActive(false);
            //}
        }

        if (Input.GetButton("Aim"))
        {
            //if(landPointRef.gameObject.activeSelf == false)
            //{
            //    landPointRef.gameObject.SetActive(true);
            //}

            //if(!lineThrowRef.enabled)
            //{
            //    lineThrowRef.enabled = true;
            //}

            for (int i = 0; i < throwPointsRef.Length; i++)
            {
                lineThrowRef.SetPosition(i, throwPointsRef[i].position);
            }

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

        if(Input.GetButtonDown("RightHand") && checkKnife)
        {
            checkKnife = false;
            GameObject knifeClone = Instantiate(knifeBladeRef);
            knifeClone.transform.position = this.transform.position;
            knifeClone.transform.eulerAngles = this.transform.eulerAngles;
            knifeClone.SetActive(true);
            knifeClone.GetComponent<Rigidbody>().AddForce(chefCameraRef.transform.forward * throwForce + new Vector3(0, throwForce / 2, 0), ForceMode.Impulse);
        }

        landAimRot = chefCameraRef.transform.eulerAngles.x;

        landAimRot = Mathf.Clamp(landAimRot, 6, 30);

        landPointRef.transform.localPosition = new Vector3(landPointRef.transform.localPosition.x, landPointRef.transform.localPosition.y, 36 - landAimRot);

        //landPointRef.Rotate(this.transform.eulerAngles);

        //// Does the ray intersect any objects excluding the player layer
        //if (Physics.Raycast(landPointRef.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        //{
        //    landPointRef.position = new Vector3(landPointRef.position.x, hit.transform.position.y + 0.8f, landPointRef.position.z);
        //    //landPointRef.transform.position = new Vector3(landPointRef.transform.position.x, this.transform.parent.position.y - 0.5f - hit.point.y, landPointRef.transform.position.z);
        //}
        //else
        //{
        //    Debug.DrawRay(landPointRef.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
        //    Debug.Log("Did not Hit");
        //}
    }
}
