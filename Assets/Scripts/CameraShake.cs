using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float shakeAmount;
    public float shakeTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {
            Vector2 shakeDirection = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakeDirection.x, transform.position.y + shakeDirection.y, transform.position.z);
        }

        shakeTime -= Time.deltaTime;
    }

    public void shakeCamera(float shakeAmt, float shakeDuration)
    {
        shakeAmount = shakeAmt;
        shakeTime = shakeDuration;
    }
}

