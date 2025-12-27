using UnityEngine;

namespace MasteringGameDesign
{
    public class PlayerController : MonoBehaviour
    {
        // The RigidBody physics component of this object
        // since we'll be accessing it a lot, we'll store it as a member
        private Rigidbody _rigidbody;

        [SerializeField, Tooltip("How much acceleration is applied to this object when directional input is received.")]
        private float _movementAcceleration = 2;

        [SerializeField, Tooltip("The maximum velocity of this object - keeps the player from moving too fast.")]
        private float _movementVelocityMax = 2;

        [SerializeField, Tooltip("Deceleration when no direction input is received.")]
        private float _movementFriction = 0.1f;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // Get the current speed from the RigidBody physics component
            // grabbing this ensures we retain the gravity speed
            Vector3 curSpeed = _rigidbody.linearVelocity;

            // Check to see if any of the keyboard arrows are being pressed
            // if so, adjust the speed of the player
            if (Input.GetKey(KeyCode.RightArrow))
            {
                curSpeed.x += _movementAcceleration * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                curSpeed.x -= _movementAcceleration * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                curSpeed.z += _movementAcceleration * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                curSpeed.z -= _movementAcceleration * Time.deltaTime;
            }

            // If both left and right kerys are simultaneously pressed (or not pressed), apply friction
            if (Input.GetKey(KeyCode.LeftArrow) == Input.GetKey(KeyCode.RightArrow))
            {
                curSpeed.x -= _movementFriction * curSpeed.x;
            }

            // Apply similar friction logic to up and down keys
            if (Input.GetKey(KeyCode.UpArrow) == Input.GetKey(KeyCode.DownArrow))
            {
                curSpeed.z -= _movementFriction * curSpeed.z;
            }

            // Apply the max speed
            curSpeed.x = Mathf.Clamp(curSpeed.x, -_movementVelocityMax, _movementVelocityMax);
            curSpeed.z = Mathf.Clamp(curSpeed.z, -_movementVelocityMax, _movementVelocityMax);

            // Apply the changed velocity to this object's physics component
            _rigidbody.linearVelocity = curSpeed;
        }
    }
}
