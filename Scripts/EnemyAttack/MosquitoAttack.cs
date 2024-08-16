using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MosquitoAttack : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerCollisionDetection.isMosquitoAttack)
        {
            moveTowardPlayer();
        }
    }
    void moveTowardPlayer()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                transform.position = target.position;
                StartCoroutine(wait1Sec());


            }
        }
    }
    IEnumerator wait1Sec()
    {
        AudioManager.instance.PlayMosquitoFX.Play();
        yield return new WaitForSeconds(3f);
        AudioManager.instance.PlayMosquitoFX.Stop();
        TriggerCollisionDetection.isMosquitoAttack = false;
        Destroy(gameObject);
    }
}
