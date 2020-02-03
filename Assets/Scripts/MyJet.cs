using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;

public class MyJet : MonoBehaviour
{
    [SerializeField] float speed=5f;

    [SerializeField] float xLimit = 5f;
    [SerializeField] float yLimit = 4f;
    [SerializeField] float pitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 2f;
    [SerializeField] float controlYawFactor = 2f;
    [SerializeField] float controlRollFactor = 2f;

    [SerializeField] int jetHealth = 10;
    [SerializeField] Text healthValue;
    [SerializeField] Text scoreValue;

    float xInput, yInput;
    float xMovement, yMovement;
    int score;
    [SerializeField] GameObject jetParticalObject;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        healthValue.text = "Health : " + jetHealth.ToString();
        scoreValue.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //To Move Jet horizontal and vertical
        MoveJet();
        // To rotate jet pitch , yaw and roll axis
        RotateJet();
        // To hit bullets
        HItBullets();
    }

    private void HItBullets()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            jetParticalObject.SetActive(true);
        }
        else
            jetParticalObject.SetActive(false);

    }

    private void MoveJet()
    {
        xInput = CrossPlatformInputManager.GetAxis("Horizontal");
        //print("CrossPlatformInputManager.GetAxis HO " + xInput);
        float xRelSpeed = xInput * speed * Time.deltaTime;
        //print(" xInput * speed * Time.deltaTime " + xRelSpeed);
        float xPos = xRelSpeed + transform.localPosition.x;
        xMovement = Mathf.Clamp(xPos, -xLimit, xLimit);

        yInput = CrossPlatformInputManager.GetAxis("Vertical");
        //print("CrossPlatformInputManager.GetAxis V" + yInput);
        float yRelSpeed = yInput * speed * Time.deltaTime;
        float yPos = yRelSpeed + transform.localPosition.y;
        yMovement = Mathf.Clamp(yPos, -yLimit, yLimit);

        transform.localPosition = new Vector3(xMovement, yMovement, transform.localPosition.z);
        
    }

    public void RotateJet()
    {
        float pitch = yMovement * pitchFactor + (yInput* controlPitchFactor);
        float yaw = transform.localPosition.x*controlYawFactor;
        float roll = xInput * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    
    public void OnCollideWithEnemy()
    {
        if(jetHealth>0)
        {
            print("Health will decrese to : " + jetHealth);

            jetHealth -= 2;
            healthValue.text = "Health : "+jetHealth.ToString();
            if (jetHealth == 0)
            {
                Destroy(gameObject);
            }
        }

    }

    public void OnHitLaserToEnemy()
    {
        score++;
        scoreValue.text = "Score : "+score.ToString();
    }

    
}
