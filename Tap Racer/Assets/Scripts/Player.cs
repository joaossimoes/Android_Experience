using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CarValues car;
    List<GameObject> checkpoints;
    Circuit circuit;
    Vector3 targetPos;
    int checkpointIndex;
    float maxSpeed; //before it was 3f
    float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        circuit = FindObjectOfType<Circuit>();
        checkpoints = circuit.GetCheckpoints();
        checkpointIndex = 0;
        transform.position = checkpoints[0].transform.position;
        targetPos = checkpoints[checkpointIndex + 1].transform.position;
        checkpointIndex++;
        maxSpeed = car.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Accelerate();
        }
        else
        {
            Break();
        }
        Move();
        Debug.Log(currentSpeed);
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
        TargetPosition();
    }

    void TargetPosition()
    {
        if (Vector2.Distance(transform.position, targetPos) < Mathf.Epsilon)
        {
            checkpointIndex++;
            if (checkpointIndex > checkpoints.ToArray().Length - 1) {checkpointIndex = 0;}
            targetPos = checkpoints[checkpointIndex].transform.position;
        }
    }

    void Accelerate()
    {
        if (currentSpeed >= maxSpeed){return;}
        currentSpeed += car.Acceleration;      //before it was 0.01f
    }

    void Break()
    {
        if (currentSpeed <= 0){currentSpeed = 0; return;}
        currentSpeed -= car.BrakePower;                 //before it was 0.01f
    }
}
