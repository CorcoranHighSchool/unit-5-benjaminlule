using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public int pointValue;
    public static GameManager instance;
    private Rigidbody targetRb;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //capture the rigidbody
        targetRb = GetComponent<Rigidbody>();
        //give the rigidbody random force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Rotate the target with a random rotation on each eaxis
        targetRb.AddTorque(RandomTorque(),
            RandomTorque(),
            RandomTorque(),
            ForceMode.Impulse);
        //set the position of the target to a random position
        transform.position = RandomSpawnPos();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameManager.instance.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);



    }
}