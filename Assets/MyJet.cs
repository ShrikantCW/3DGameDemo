using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MyJet : MonoBehaviour
{
    [SerializeField] float xSpeed=5f;

    [SerializeField] float xLimit = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = CrossPlatformInputManager.GetAxis("Horizontal");
        
        float xRelSpeed = xInput * xSpeed * Time.deltaTime;
        float xPos = xRelSpeed + transform.localPosition.x;

        float xMovement = Mathf.Clamp(xPos, -xLimit, xLimit);

        transform.localPosition = new Vector3(xMovement, transform.localPosition.y, transform.localPosition.z);
    }
}
