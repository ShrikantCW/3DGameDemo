using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class MyJet : MonoBehaviour
{
    [SerializeField] float speed=5f;

    [SerializeField] float xLimit = 5f;
    [SerializeField] float yLimit = 4f;
    [SerializeField] float pitchFactor = 2f;
   
    [SerializeField] int jetHealth = 10;
    [SerializeField] Text healthValue;
    [SerializeField] Text scoreValue;

    float xMovement, yMovement;
    // Start is called before the first frame update
    void Start()
    {
        healthValue.text = jetHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoveJet();
        RotateJet();
    }

    private void MoveJet()
    {
        float xInput = CrossPlatformInputManager.GetAxis("Horizontal");
        //print("CrossPlatformInputManager.GetAxis HO " + xInput);
        float xRelSpeed = xInput * speed * Time.deltaTime;
        //print(" xInput * speed * Time.deltaTime " + xRelSpeed);
        float xPos = xRelSpeed + transform.localPosition.x;
        xMovement = Mathf.Clamp(xPos, -xLimit, xLimit);

        float yInput = CrossPlatformInputManager.GetAxis("Vertical");
        float yRelSpeed = yInput * speed * Time.deltaTime;
        float yPos = yRelSpeed + transform.localPosition.y;
        yMovement = Mathf.Clamp(yPos, -yLimit, yLimit);

        transform.localPosition = new Vector3(xMovement, yMovement, transform.localPosition.z);
        
    }

    public void RotateJet()
    {
        float pitch = yMovement * pitchFactor;
        float yaw=0f; 
        float roll=0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    public void OnEnemyCollide()
    {
        if(jetHealth>0)
        {
            jetHealth -= 2;
            healthValue.text = jetHealth.ToString();
            if (jetHealth == 0)
            {
                Destroy(gameObject);
            }
        }

    }
   
}
