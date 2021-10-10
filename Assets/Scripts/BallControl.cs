using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        float forcemagnitude = yInitialForce * yInitialForce + xInitialForce * xInitialForce;
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float xNewInitialForce = Mathf.Sqrt(forcemagnitude - yRandomInitialForce * yRandomInitialForce);
        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xNewInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xNewInitialForce, yRandomInitialForce));
        }
    }
    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);

    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        RestartGame();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
