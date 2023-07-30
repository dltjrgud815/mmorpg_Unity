using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct MyVector
{
    public float x;
    public float y;
    public float z;
    
    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    public float magnitude
    {
        get { return Mathf.Sqrt(x * x + y * y + z * z); }
    }
    
    public MyVector normalized
    {
        get
        {
            float m = magnitude;
            return new MyVector(x / m, y / m, z / m);
        }
    }
    
    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    
    public static MyVector operator *(MyVector a, float b)
    {
        return new MyVector(a.x * b, a.y * b, a.z * b);
    }
    
    public static MyVector operator /(MyVector a, float b)
    {
        return new MyVector(a.x / b, a.y / b, a.z / b);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    private void Start()
    {
        Managers.Input.KeyAction -= OnKeyBoard;
        Managers.Input.KeyAction += OnKeyBoard;
    }

    private void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.3f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.3f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.3f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.3f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
