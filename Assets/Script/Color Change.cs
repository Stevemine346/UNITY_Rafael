using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChange : MonoBehaviour
{

    public Color [] colors; 
    public Material material;
    public bool isInvisible;
    public float maxTime = 3f;

    Keyboard Keyboard;
    Gamepad Gamepad;
    private float currentTime = 0;
    private bool startTimer = false;    

    void Start()
    {
        material.color = colors[0];

        Keyboard = Keyboard.current;
        Gamepad = Gamepad.current;
       
    }

    
    void Update()
    {
        if (Keyboard != null)
        {
            if (Keyboard.fKey.wasPressedThisFrame)
            {
                ChangeColor();             
            }

            
        }
        if (Gamepad != null)
            {
                if (Gamepad.buttonNorth.wasPressedThisFrame)
                {
                    ChangeColor();
                }
            }
        if (startTimer == true)
        {
            InvisibleTimer();
        }
    }

    private void ChangeColor()
    {
        if (isInvisible == false)
        {
            material.color = colors[1];
            startTimer = true;
            isInvisible = true;
        }

        else
        {
            material.color = colors[0];
            startTimer = false;
            currentTime = 0;
            isInvisible = false;
        }
        

    }

    private void InvisibleTimer()
    {
        currentTime += Time.deltaTime;

        if (currentTime > maxTime)
        {
            material.color = colors[0];
            startTimer = false;
            currentTime = 0;
            isInvisible = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            if (isInvisible == false)
            {
                print("you lose MotherFucker");
            }
        }
    }
}
