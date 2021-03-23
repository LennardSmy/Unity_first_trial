 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject _CoronaPrefab;
    [SerializeField] 
    private float _coronaRate = 2f;
    
    private float _nextFire = -1f;
    
   [SerializeField]
    private float _speed = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        _CoronaPos();
        _CoronaMove();
        _SelfDestruct();

    }
    
    private void _CoronaPos()
    {
        if (Time.time > _nextFire)
        {
            Debug.Log("hallo");
            _nextFire = Time.time + _coronaRate;
            
            var coronaPos = new Vector3(_RandomFloat(), 6f, 0f);
            Instantiate(_CoronaPrefab, coronaPos, Quaternion.identity);
        }

    }
    
    
    private void _CoronaMove()
    {
        this.gameObject.transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
    
    
    private void _SelfDestruct()
    {
        if (transform.position.y > -6f)
        {
            Destroy(this.gameObject);
        }
    }
    
    
    private float _RandomFloat()
    {
       float coronaRange = Random.Range(-3.8f, 3.8f);

        return coronaRange;

    }
}
