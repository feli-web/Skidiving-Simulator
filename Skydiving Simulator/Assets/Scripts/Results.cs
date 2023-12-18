using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text fv;
    public Text mass;
    public Text windres;
    public Text windz;
    public Text windx;
    public Text parachuteres;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fv.text = $"Final Velocity:  {PlayerPrefs.GetFloat("Fv").ToString("F2")}";
        mass.text = $"Mass:  {PlayerPrefs.GetFloat("Mass").ToString("F2")}";
        windres.text = $"Wind Resistance:  {PlayerPrefs.GetFloat("WindRes").ToString("F2")}";
        windz.text = $"Wind Direction Z:  {PlayerPrefs.GetFloat("WindZ").ToString("F2")}";
        windx.text = $"Wind Direction X:  {PlayerPrefs.GetFloat("WindX").ToString("F2")}";
        parachuteres.text = $"Parachute Resistance:  {PlayerPrefs.GetFloat("ParachuteRes").ToString("F2")}";
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
