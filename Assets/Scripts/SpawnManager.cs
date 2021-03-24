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
    
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnSystem()
    {
        while (true)
        {
            Instantiate(_virusPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0f),Quaternion.identity);
            yield return new WaitForSeconds(_delay);
        }
        
    }
}
