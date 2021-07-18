using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefCamera : MonoBehaviour
{
    public GameObject knifeHolderRef;
    public GameObject chefCharacter;
    public Transform backTargetRef;
    public Transform zoomTargetRef;
    public float turnSpeed = 4.0f;
    public float heightOffset;
    public float widthOffset;
    public int clampMaxOffset = 10;
    public int clampMinOffset = 0;
    public float yRot;

    private float cameraCD;
    private Vector3 zoomInRef = Vector3.forward;
    private Vector3 velocity = Vector3.zero;
    private RaycastHit cameraRay;
    private float rayDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        chefCharacter.transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);

        yRot += -Input.GetAxis("Mouse Y") * turnSpeed / 50;

        if(yRot > chefCharacter.transform.position.y + 10)
        {
            yRot = chefCharacter.transform.position.y + 10;
        }
        else if(yRot < chefCharacter.transform.position.y)
        {
            yRot = chefCharacter.transform.position.y;
        }

        float camYAxisRotation = Mathf.Clamp(yRot, chefCharacter.transform.position.y + clampMinOffset, chefCharacter.transform.position.y + clampMaxOffset);
        this.transform.position = new Vector3(this.transform.position.x, camYAxisRotation, this.transform.position.z);

        if (knifeHolderRef.GetComponent<KnifeThrow>().GetCheckLookAt())
        {
            this.transform.LookAt(chefCharacter.transform.position);
        }
        else
        {
            this.transform.eulerAngles = new Vector3 (/*Mathf.Clamp(this.transform.position.y * 5, 0, 30)*/0, this.transform.parent.eulerAngles.y,0);
            this.transform.LookAt(knifeHolderRef.GetComponent<KnifeThrow>().lookAtAimTargetRef);
        }

        //// Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(chefCharacter.transform.position, -this.transform.forward, out cameraRay, Vector3.Distance(this.transform.position, chefCharacter.transform.position)))
        {
            cameraCD = 2.0f;
            if (cameraRay.collider.CompareTag("Wall"))
            {
                if (GetComponent<Camera>().fieldOfView > 30)
                {
                    GetComponent<Camera>().fieldOfView -= Time.deltaTime;
                }
                this.transform.position = Vector3.SmoothDamp(this.transform.position, zoomTargetRef.transform.position, ref velocity, 0.4f);
            }

        }
        else
        {
            cameraCD -= Time.deltaTime;

            if (cameraCD <= 0)
            {
                if (GetComponent<Camera>().fieldOfView < 60)
                {
                    GetComponent<Camera>().fieldOfView += Time.deltaTime;
                }

                if (Vector3.Distance(this.transform.position, backTargetRef.transform.position) > rayDistance)
                {
                    this.transform.position = Vector3.SmoothDamp(this.transform.position, backTargetRef.transform.position, ref velocity, 0.4f);
                }
            }
        }
    }
}
