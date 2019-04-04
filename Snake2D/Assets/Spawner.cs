using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawner will spawn pick-ups and snake's body.
public class Spawner : MonoBehaviour
{
    public GameObject _borders;
    public GameObject _snakeHead;
    public GameObject _body;

    private BodySpawner _bodySpawner;
    private CircleCollider2D _headCollider;
    private GameObject[] _snakeBody;
    private BordersHolder _bordersHolder = new BordersHolder();
   
    const float _gap = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        _bodySpawner = _body.GetComponent<BodySpawner>();
        _headCollider = _snakeHead.GetComponent<CircleCollider2D>();
        _bordersHolder.BottomY = _borders.transform.Find("Border_Bottom").GetComponent<EdgeCollider2D>().transform.position.y;
        _bordersHolder.TopY = _borders.transform.Find("Border_Top").GetComponent<EdgeCollider2D>().transform.position.y;
        _bordersHolder.RightX = _borders.transform.Find("Border_Right").GetComponent<EdgeCollider2D>().transform.position.x;
        _bordersHolder.LeftX = _borders.transform.Find("Border_Left").GetComponent<EdgeCollider2D>().transform.position.x;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        float randomX = Random.Range(_bordersHolder.LeftX + _gap, _bordersHolder.RightX - _gap);
        float randomY = Random.Range(_bordersHolder.BottomY + _gap, _bordersHolder.TopY - _gap);
        var point = new Vector2(randomX, randomY);

        if(_headCollider.bounds.Contains(point))
        {
            // If random point is within our snake, call the method again.
            Spawn();
        }
        this.transform.position = point;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Head")
        {
            Spawn();
            if (!_bodySpawner._firstSpawn)
           {
                _bodySpawner._firstSpawn = true;
                _body.SetActive(true);
            }
            else
            {
                _bodySpawner._add = true;
            }
        }
    }

    public class BordersHolder 
    {
        public float LeftX { get; set; }
        public float TopY { get; set; }
        public float RightX { get; set; }
        public float BottomY { get; set; }
    }
}
