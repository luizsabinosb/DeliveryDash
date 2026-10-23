using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] TMP_Text boostText;
    // Update is called once per frame

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float steer =0f;
        float move = 0f;

        if(Keyboard.current.wKey.isPressed)
        {
            //Debug.Log("W key is pressed, pushing forward");
            move = 1f;
        }
        else if(Keyboard.current.sKey.isPressed)
        {
            //Debug.Log("S key is pressed, pushing backward");
            move = -1f;
        }
        if(Keyboard.current.aKey.isPressed)
        {
            //Debug.Log("A key is pressed, pushing left");
            steer = 1f;
        }
        else if(Keyboard.current.dKey.isPressed)
        {
            //Debug.Log("D key is pressed, pushing right");
            steer = -1f;
        }

        float moveAmout = move * currentSpeed * Time.deltaTime;
        float steerAmout = steer * steerSpeed * Time.deltaTime;
        transform.Rotate(0,0, steerAmout);
        transform.Translate(0,moveAmout,0);
    }
}
