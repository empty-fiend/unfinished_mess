using UnityEngine;

namespace CharacterScripts.functions
{
    public class MoveScript : MonoBehaviour
    {
        private bool _movingRight;
  
        public void Moving (float speed, bool isGrounded)
        {
            if (isGrounded)
            {
                transform.Translate(Vector2.right * (speed * Time.deltaTime));
            }
            else
            {
                if (_movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    _movingRight = !_movingRight;
                }
                else if (!_movingRight)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    _movingRight = !_movingRight;
                }
            }
        }

        public void Moving (float move, bool isRunning, float walkSpeed, float runSpeed, Rigidbody2D rb, Transform otherTransform)
        {
            if (move < 0)
                otherTransform.eulerAngles = new Vector3(0, -180, 0);
            if (move > 0)
                otherTransform.eulerAngles = new Vector3(0, 0, 0);

            var speed = !isRunning ? walkSpeed : runSpeed;

            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
    }
}
