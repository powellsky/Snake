using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    public GameObject _head;
    public bool _firstSpawn = false;
    public bool _add = false;

    private List<GameObject> _bodies = new List<GameObject>();
    private GameObject _headFollower = null;
    // Start is called before the first frame update
    void Start()
    {
        // When initialised, follow the head
        if (_firstSpawn)
        {
            _headFollower = GameObject.Find("/Game Container/Head/Follower");
            this.transform.position = _headFollower.transform.position;        
            _bodies.Add(this.gameObject);
            _firstSpawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Add();
    }

    void Add()
    {
        if (_add)
        {
            _add = false;
            var clone = _bodies[_bodies.Count - 1];
            clone.name = "Body " + _bodies.Count;
            var body = Instantiate(clone, clone.transform.position, clone.transform.rotation);
            _bodies.Add(body);          
        }
    }

    void Follow()
    {
        int count = _bodies.Count;
        for(int i = 0; i < count; i++)
        {
            var current = _bodies[i];
            if (i == 0)
            {
                // Follow head
                current.transform.position = Vector2.Lerp(current.transform.position, _headFollower.transform.position, Time.deltaTime * 4f);
            }
            else
            {
                var prev = _bodies[i - 1];
                current.transform.position = Vector2.Lerp(current.transform.position, prev.transform.position, Time.deltaTime * 4);

            }
        }
    }
}
