using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof (BoxCollider2D))]
public class PlayerMov : MonoBehaviour
{
    [SerializeField] Joystick joystick;// classe pai dos assets importados
    Rigidbody2D rb;
    Vector2 movement;
   [SerializeField] float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        movement = joystick.Direction;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}
