using UnityEngine;

namespace MasteringGameDesign
{
    public class GroundObjectController : MonoBehaviour
    {
        private void Update()
        {
            // The speed that this object rotates
            float speed = 15f;

            // Get the current rotation of the ground object
            // based on the keys pressed
            // we will be altering this value and re-applying it
            Vector3 newRotation = transform.localEulerAngles;

            // Go through each of the direction keys: up, down, left, right
            // if any of them are pressed, alter the rotation of the ground plane
            if (Input.GetKey(KeyCode.RightArrow))
            {
                newRotation.z -= Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                newRotation.z += Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                newRotation.x += Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                newRotation.x -= Time.deltaTime * speed;
            }

            // Aply the updated rotation to the ground object
            transform.localEulerAngles = newRotation;
        }
    }
}
