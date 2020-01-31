using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    MyJet jet;

    bool gotHit;
    void Start()
    {
         jet = FindObjectOfType<MyJet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gotHit)
        {
            gotHit = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("trigger with @");
            jet.OnCollideWithEnemy();
            Destroy(gameObject);


        }
        Debug.Log("OnTriggerEnter with @" + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("olliderd with @" + collision.gameObject.name);
        //jet.OnCollideWithEnemy();
        //Destroy(gameObject);
    }

    private void OnParticleTrigger()
    {
        Debug.Log("@ON particle trigger ");
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("@LAser OnParticleCollision ");
        if (!gotHit)
        {
            gotHit = true;
            Debug.Log("@LAser hit ");
            jet.OnHitLaserToEnemy();
            Destroy(gameObject);

        }
    }

    


}
