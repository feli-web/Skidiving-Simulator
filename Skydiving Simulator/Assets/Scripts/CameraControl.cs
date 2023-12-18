using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;



    void Start()
    {
       Camera2.SetActive(false);
    }

   public void CameraOne()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);

    }

    public void CameraTwo()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        
    }
}
