using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed;
    protected Vector2 bound;
    protected float timer;


    void Start()
	{
        Transform parent = this.transform.parent;
        bound = parent.GetComponent<BoxCollider2D>().size;
        timer = 0f;
	}
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
		{
            Vector3 target = Move();
            print("Move to " + target);
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, target, moveSpeed * Time.deltaTime);
            print(this.transform.position);
            timer = 0;
        }
    }

    public Vector3 Move()
	{
        Vector3 boundV3 = bound;
        Vector3 target = this.transform.parent.position;
        target += boundV3 * Random.Range(-1f, 1f) / 2;
        return target;
	}
}