using UnityEngine;
using UnityEngine.InputSystem;

public class BezVarijabli : MonoBehaviour
{
    void Update()
    {
        camFollow();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 1500 * Time.deltaTime, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        movePlayer();   
    }
    void movePlayer()
    {
        GetComponent<Rigidbody>().linearVelocity = (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * 1000*Time.deltaTime + Vector3.down * GetComponent<Rigidbody>().linearVelocity.y;
        if (Input.GetAxisRaw("Horizontal") == 0&& Input.GetAxisRaw("Vertical")==0)
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GetComponent<Rigidbody>().linearVelocity.y, 0);
        }
    }
    void camFollow()
    {
        Camera.main.transform.localEulerAngles = Vector3.right * Mathf.Clamp(Input.GetAxisRaw("Mouse Y") * 4, -90f, 90f); 
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * 4);
    }
}
