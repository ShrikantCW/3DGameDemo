using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    MyJet jet;
    bool gotHit;

    [SerializeField] ParticleSystem EnemyDestroyPartical;

    void Start()
    {
        EnemyDestroyPartical.Stop();
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
            EnemyDestroyPartical.Play();
            Invoke("DestroyEnemy", 0.3f);

        }

    }
    
    private void OnParticleCollision(GameObject other)
    {
        if (!gotHit)
        {
            gotHit = true;
            Debug.Log("@LAser hit ");
            jet.OnHitLaserToEnemy();
            EnemyDestroyPartical.Play();

            Invoke("DestroyEnemy", 0.3f);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }





}
