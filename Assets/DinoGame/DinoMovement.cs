using UnityEngine;
using Object = System.Object;

public class DinoMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float _speed = 10f;
    private bool _isGrounded;

    private void Awake() {
       _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        Object.Equals()
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if player lands on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // End game if player hits an obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
}
