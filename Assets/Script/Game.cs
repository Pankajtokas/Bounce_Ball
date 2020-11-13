using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const int V = 500;
    private const string SceneName = "Level2";
    Rigidbody rb;
    public GameObject winText;
    float xInput;
    float zInput;

     public float speed = 7000f;
     public float left_right_movment = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    rb.AddForce(-left_right_movment * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    rb.AddForce(left_right_movment * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }

        }
       
       /*Input = Input.GetAxis("Horizontal");
       xInput = Input.GetAxis("Horizontal");

       rb.AddForce(xInput * speed, 0, zInput * speed);
       
         for (int i =0; i<Input.touchCount; i++) {
         Touch touch = Input.GetTouch(i);
         
         if (touch.position.x < Screen.width/2)
         {
             transform.Translate(Vector3.left * Time.deltaTime * PlayerMoveSpeed);
         }
         if (touch.position.x > Screen.width/2)
         {
             transform.Translate(Vector3.right * Time.deltaTime * PlayerMoveSpeed);*/

    }
    
    public void OnMouseDown()
	{
       rb.AddForce(Vector3.up * 400);
       // Destroy(gameObject);
    }

    public void QuitGame ()
    {
        SceneManager.LoadScene(0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            winText.SetActive(true);
                     
            //Destroy(collision.gameObject);
        }   
    }
}
