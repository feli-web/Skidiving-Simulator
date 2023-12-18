using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int height;
    public GameObject player;
    void Start()
    {
        height = PlayerPrefs.GetInt("Height");
        Instantiate(player, new Vector3(0, height, 0),this.transform.rotation);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
