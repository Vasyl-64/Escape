using UnityEngine;
using UnityEngine.InputSystem;

public class ToCursorRotater : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    private void Start()
    {
        if (_cube == null)
        {
            Debug.LogError("Cube GameObject is not assigned.");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        { 
            _cube.transform.Rotate(Vector3.up, 90f * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            _cube.transform.Rotate(Vector3.forward, 90f * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.R))
        { 
            _cube.transform.Rotate(Vector3.right, 90f * Time.deltaTime);
        }
    }
}

