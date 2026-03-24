using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffect : MonoBehaviour
{
    public float kickForce = 0f;
   public float spinAmount = 0f;
   public float magnusStrenght = 0f;
    private Rigidbody _rb;
    private bool _isShoot = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !_isShoot) 
        {
            _rb.AddForce(-Vector3.forward * kickForce, ForceMode.Impulse);
            _rb.AddForce(Vector3.up * spinAmount);
            _isShoot =true;
                
        }

    }
    private void FixedUpdate()
    {
        if (_isShoot) return;
        Vector3 velocity = _rb.linearVelocity;
        Vector3 spin = _rb.linearVelocity;

        Vector3 magnusForce = magnusStrenght * Vector3.Cross(spin , velocity);
        _rb.AddForce(magnusForce);
    }
}
