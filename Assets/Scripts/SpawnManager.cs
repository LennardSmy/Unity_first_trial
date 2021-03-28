using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _virusPrefab;
    
    [SerializeField]
    private float _delay = 2f;

    private bool _spawningOn = true;
    
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //T
    public void playerDead()
    {
        _spawningOn = false;
    }

    IEnumerator SpawnSystem()
    {
        //this while loop should go until the game is finished of one enters a new scene. 
        
        while (_spawningOn)
        {
            Instantiate(_virusPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0f),Quaternion.identity,this.transform);
            yield return new WaitForSeconds(_delay);
        }

        if (_spawningOn == false)
        {
            Destroy(this.gameObject);
        }
    }
}
