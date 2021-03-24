using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject ballPrefab;
    public float impulseAmount;
    public float rotationSpeed;

    Vector3 currentPostion;
    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        currentPostion = transform.position;
        currentRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        transform.Rotate(
            -v * rotationSpeed,
            h * rotationSpeed,
            0.0f
            );

        PredictionManager.instance.Predict(ballPrefab, firePoint.transform.position, calculateForce());
        currentRotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(ballPrefab, firePoint.transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse);
        }
    }

    public Vector3 calculateForce()
    {
        return transform.forward * impulseAmount;
    }
}
