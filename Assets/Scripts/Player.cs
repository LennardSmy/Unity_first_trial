using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    
    [SerializeField]
    private float _speed = 0.1f;

    [SerializeField] 
    private GameObject _vaccinePrefab;
    

    [SerializeField] 
    private float _vaccinationRate = 5f;
    private float nextFire = 0.0f;

    [SerializeField] 
    private int _lives = 3;

    private float _colorChannel = 1f;
    private MaterialPropertyBlock _mpb;
    [SerializeField]
    private SpawnManager _spawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_mpb);
        }
        transform.position = new Vector3(0, 0, 0);
        
        
    } 

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        CheckBoundaries();
        Vaccine();
        
        

    }

    // Player movement function
    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        // in video 12 you can see how they solved the axes moving part
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up *
                            Time.deltaTime *
                            _speed *
                            verticalInput);
        
    }
    
    
    // This Function checks boundaries and sets player's behaviour when touching them.
    private void CheckBoundaries()
    {
        if (transform.position.y > 0)
            //if th playerposition on the y axis is greater 
        {
            // we force the player position to be 0
            transform.position = new Vector3(transform.position.x,
                0,
                0);
        }

        else if (transform.position.y < -4.9f)
            //if th playerposition on the y axis is greater 
        {
            // we force the player position to be 0
            transform.position = new Vector3(transform.position.x,
                -4.9f,
                0f);
        }
        
        if (transform.position.x < -9.2f)
            //if th playerposition on the x axis is smaller than -9.1 (the left border)
        {
            // we force the player position to be +9.5f, so it comes out the other side
            transform.position = new Vector3(9.55f,
                transform.position.y,
                0f);
        }
        
        else if (transform.position.x > 9.55f)
            //if th playerposition on the x axis is bigger than right border
        {
            // we force the player position to be -9.1f, so it comes out the other side
            transform.position = new Vector3(-9.2f,
                transform.position.y,
                0f);
        }
    }

    
   // if this function is called by pressing the space bar
   // it redirects to the script "vaccine" which shoots vaccines
   private void Vaccine()
    {
        Vector3 initVaccinepos = new Vector3 (0f,0.5f,0f);
        // if spacebar is pressed 
        //then we want to instantiate the prefab (vaccine) , we call the _vaccinePrefab component
        //to which there is a script attached named "vaccine"
        

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            Debug.Log("space bar pressed");
            nextFire = Time.time + _vaccinationRate;
            Instantiate(_vaccinePrefab,(transform.position + initVaccinepos),Quaternion.identity);
        }
    }

   public void Damage()
   {
      
       //reduces lives by one
       // variable *= , += , /= , -= , %= number, ---> variable = variable *, +, /, -, % number; 
       // ++variable , variable++ , --variable , variable-- ;
       _lives = _lives - 1;

       _colorChannel -= 0.5f;
       _mpb.SetColor("_Color",new Color(_colorChannel,0,_colorChannel,1f));
       this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
       
       if (_lives == 0)
       {
           if (_spawnManager != null)
           {
               _spawnManager.playerDead();
           }
           else
           {
               Debug.LogError("SpawnManager not assigned!");
           }
           Destroy(this.gameObject);
           
       }

   }
}


    
