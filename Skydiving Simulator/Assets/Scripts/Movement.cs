using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 16f;
    float gravity = -9.81f;
    public float jumpHeight = 3f;
    float mass = 30;
    float windco = 10;
    float parachuteres = 1;
    Vector3 velocity;
    float x;
    float z;


    // utilizando un booleano, esta funcion evita que el y siga bajando aunque el personaje no vaya hacia abajo
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public Slider massslider;
    public Slider windslider;
    public Text masstext;
    public Text windtext;
    public Slider windzslider;
    public Slider windxslider;
    public Text windztext;
    public Text windxtext;

    public Text falling;

    public GameObject parachute;
    public Button parachutebutton;
    bool isDiving = false;

    public Canvas controls;
    public Canvas results;

    private void Start()
    {
        massslider.maxValue = 100;
        massslider.minValue = 30;
        windslider.maxValue = 50;
        windslider.minValue = 1;
        windzslider.maxValue = 1;
        windzslider.minValue = -1;
        windxslider.maxValue = 1;
        windxslider.minValue = -1;
    }
    void Update()
    {
        masstext.text = "Mass: " + mass.ToString("F2");
        windtext.text = "Wind resistance: " + windco.ToString("F2");
        windztext.text = "Wind direction Z: " + z.ToString("F2");
        windxtext.text = "Wind direction X: " + x.ToString("F2");
        mass = massslider.value;
        windco = windslider.value;
        z = windzslider.value;
        x = windxslider.value;



        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            parachute.SetActive(false);
            velocity.y = 0f;
            falling.text = "The falling velocity is " + 0f;
            x = 0f;
            z = 0f;
            parachute.SetActive(false);
            controls.gameObject.SetActive(false);
            results.gameObject.SetActive(true);
        }
        if (!isGrounded)
        {
            falling.text = "The falling velocity is " + velocity.y.ToString("F2");

            PlayerPrefs.SetFloat("Fv", -velocity.y);
            PlayerPrefs.SetFloat("Mass", mass);
            PlayerPrefs.SetFloat("WindRes", windco);
            PlayerPrefs.SetFloat("ParachuteRes", parachuteres);
            PlayerPrefs.SetFloat("WindZ", z);
            PlayerPrefs.SetFloat("WindX", x);


        }

        

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed - (mass * 0.1f)) * Time.deltaTime);

        // fall velocity
        velocity.y += ((windco + (gravity * mass))/parachuteres) * Time.deltaTime;
        


        controller.Move(velocity * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        //character animation
       
        if (isGrounded && isDiving == false)
        {
            animator.Play("Falling Flat Impact");
        }
        if (isGrounded && isDiving == true)
        {
            animator.Play("Falling To Landing");
        }
    }
    public void Parachute() 
    {
        parachute.SetActive(true);
        parachutebutton.gameObject.SetActive(false);
        isDiving = true;
        parachuteres = 4;
    }

   
}
