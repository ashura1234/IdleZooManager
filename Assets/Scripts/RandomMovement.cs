using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float rotationSpeed = 1;
    protected Vector2 bound;
    protected Vector3 _direction;
    protected Quaternion _lookRotation;
    protected float moveTime;
    protected float rotateTime;
    protected GameObject t;
    protected Vector3 target;
    protected float timer = 3;
    
    void Start()
    {
        Transform parent = this.transform.parent;
        bound = parent.GetComponent<BoxCollider2D>().size;
        CalculateTarget();
        this.transform.forward = new Vector3(1, 0, 0);
        this.transform.up = new Vector3(0, 0, -1);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, _lookRotation, rotationSpeed * Time.deltaTime);
            if (timer > 3 + rotateTime)
            {
                this.transform.localPosition += _direction * moveSpeed * Time.deltaTime;
            }
            if (timer > 3 + rotateTime + moveTime)
            {
                print("Moved to " + this.transform.localPosition);
                timer = 0;
                CalculateTarget();
            }
        }
    }

    private void CalculateTarget()
    {
        Vector3 boundV3 = bound;
        target.x = boundV3.x * Random.Range(-0.5f, 0.5f);
        target.y = boundV3.y * Random.Range(-0.5f, 0.5f);
        target.z = this.transform.position.z;

        print("Moving to " + target);
        _direction = (target - transform.localPosition).normalized;
        print("Direction = " + _direction);
        print("Forward = " + this.transform.forward);
        print("Up = " + this.transform.up);
        _lookRotation = Quaternion.LookRotation(_direction, new Vector3(0,0,-1));
        rotateTime = 1 / rotationSpeed;
        moveTime = Vector3.Distance(target, this.transform.localPosition) / moveSpeed;
    }
}

