using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefCamera : MonoBehaviour
{
    public GameObject knifeHolderRef;
    public GameObject chefCharacter;
    public float turnSpeed = 4.0f;
    public float heightOffset;
    public float widthOffset;
    public int clampMaxOffset = 10;
    public int clampMinOffset = 0;
    private float yRot;

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
    }
}
