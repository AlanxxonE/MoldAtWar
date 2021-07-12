using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefCamera : MonoBehaviour
{
    public GameObject chefCharacter;
    public float turnSpeed = 4.0f;
    public float heightOffset;
    public float widthOffset;
    private Vector3 cameraOffset;
    private Vector3 playerPerspective;
    private Vector3 playerPerspectiveTwo;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraOffset = new Vector3(0, heightOffset, widthOffset);
        playerPerspective = chefCharacter.transform.position + cameraOffset;
        playerPerspectiveTwo = new Vector3(0, 0, widthOffset);
    }

    // Update is called once per frame
    void Update()
    {
        chefCharacter.transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);
       // playerPerspective = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * playerPerspective;
        //playerPerspectiveTwo = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * playerPerspectiveTwo;
        //this.transform.position = chefCharacter.transform.position + playerPerspective;
        this.transform.LookAt(chefCharacter.transform.position);
    }
}
