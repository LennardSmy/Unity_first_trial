using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 5f;
 
    
    // Start is called before the first frame update
    /*void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y. 0f);
    } */
    
  
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        
        _selfdestruct();
    }

    private void _selfdestruct()
    {
        if (transform.position.y > 6f)
        {
            Destroy(this.gameObject);
        }
    }
} 
