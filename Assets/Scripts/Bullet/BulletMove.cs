using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, bulletSpeed * Time.deltaTime);

    }
}
