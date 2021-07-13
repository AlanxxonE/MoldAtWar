using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefCamera : MonoBehaviour
{
    public GameObject chefCharacter;
    public float turnSpeed = 4.0f;
    public float heightOffset;
    public float widthOffset;
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

        yRot += Input.GetAxis("Mouse Y") * -turnSpeed / 10;

        if(yRot > chefCharacter.transform.position.y + 10)
        {
            yRot = chefCharacter.transform.position.y + 10;
        }
        else if(yRot < chefCharacter.transform.position.y)
        {
            yRot = chefCharacter.transform.position.y;
        }

        Debug.Log(chefCharacter.transform.position.y);
        Debug.Log(this.transform.position.y);
        float camYAxisRotation = Mathf.Clamp(yRot, chefCharacter.transform.position.y, chefCharacter.transform.position.y + 10);
        this.transform.position = new Vector3(this.transform.position.x, camYAxisRotation, this.transform.position.z);

        this.transform.LookAt(chefCharacter.transform.position);
    }
}
