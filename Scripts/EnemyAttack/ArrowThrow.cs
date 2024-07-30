using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowThrow : MonoBehaviour
{
    public float speed = 5f;
    private void Update()
    {
        if(this.gameObject.name=="Arrow(Clone)")
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        StartCoroutine(destroyObj());
    }
    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
