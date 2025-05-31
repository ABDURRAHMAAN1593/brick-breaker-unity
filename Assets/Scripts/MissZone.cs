using UnityEngine;

public class MissZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name == "Ball")
        {
            FindObjectOfType<GameManager>().Miss();
        }
    }
}

// using UnityEngine;

// [RequireComponent(typeof(Collider2D))]
// public class Miss : MonoBehaviour
// {
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         FindObjectOfType<GameManager>().Miss();
//     }

// }