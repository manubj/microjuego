using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 10f;
    public float rotationSpeed = 120f;

    //bullets
    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    public static int SCORE = 0;

    //initialice newPos Vector3
        Vector3 newPos = new Vector3(0,0,47);

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        transform.Rotate(Vector3.forward * -rotation * rotationSpeed);
        

       // x: 15.39 1.77
       // y: 33.22 22.18
       Vector3 newPos = transform.position;
       if(newPos.x > 15.39f)
              newPos.x = 1.77f;
        else if(newPos.x < 1.77f)
              newPos.x = 15.39f;
        else if(newPos.y > 33.22f)
                newPos.y = 22.18f;
        else if(newPos.y < 22.18f)
                newPos.y = 33.22f;
      
       transform.position = newPos; 

        if(Input.GetKeyDown(KeyCode.Space)){
            //instanciamos la bala
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            //le damos una direccióm 
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }
   
   private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
             SCORE = 0;
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
            Debug.Log("Me colisiono con otra cosa ...");
        }
   }
}

