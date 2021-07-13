using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicePreview : MonoBehaviour
{
    public Material niceRef;
    public Material maliceRef;
    private bool checkSlicePreview;

    public bool GetCheckSlicePreview()
    {
        return checkSlicePreview;
    }

    public void SetCheckSlicePreview(bool b)
    {
        checkSlicePreview = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = niceRef;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (checkSlicePreview == true)
        {
            checkSlicePreview = false;
        }

        GetComponent<MeshRenderer>().material = niceRef;
    }

    private void OnTriggerStay(Collider other)
    {
        if(checkSlicePreview == false)
        {
            checkSlicePreview = true;
        }

        GetComponent<MeshRenderer>().material = maliceRef;
    }
}
