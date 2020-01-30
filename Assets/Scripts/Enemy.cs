using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    MyJet jet;
    void Start()
    {
         jet = FindObjectOfType<MyJet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        jet.OnEnemyCollide();
    }

    private void OnParticleCollision(GameObject other)
    {
      
            Destroy(other.gameObject);

    }



}
