using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class enemyController: MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField]private Transform _player;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _searchDistanse;
    [SerializeField] private float _safeDistance;

    private float _distance;

    private float _targetDistanse;

    private Vector3 direction;

    private bool _isPlayer;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        _distance = Vector3.Distance (transform.position, _player.position);

        _targetDistanse = Vector3.Distance(transform.position, _target.position);

        if (_distance < _searchDistanse)
        { 
            direction = _player.position - transform.position;
            _isPlayer = true;
        }
        else
        {
            direction = _target.position - transform.position;
            _isPlayer = false;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        if (_distance > _safeDistance && _isPlayer)
        {
            _rb.AddForce(transform.forward * _speed * Time.fixedDeltaTime);
        }

        if (_targetDistanse > _safeDistance && !_isPlayer)
        {
            _rb.AddForce(transform.forward * _speed * Time.fixedDeltaTime);
        }
    }
}
