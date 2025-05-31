using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody{get; private set;}

    public float speed = 10f;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 2f);
    }
    private void SetRandomTrajectory() 
    {
        {
            Vector2 force = Vector2.zero;
            force.x = Random.Range(-0.2f, 0.2f);
            force.y = -0.5f;

            this.rigidbody.AddForce(force.normalized * this.speed);
        }
    }

     private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }
}
