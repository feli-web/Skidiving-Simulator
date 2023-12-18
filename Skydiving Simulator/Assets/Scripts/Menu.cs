
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    int height = 914;
    public Slider heightslider;
    public Text heghttext;
    void Start()
    {
        heightslider.maxValue = 39045;
        heightslider.minValue = 914;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Height", height);
        height = (int)heightslider.value;
        heghttext.text = "Height: " + height + " Mtrs";
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
