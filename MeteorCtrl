// MeteorCtrl

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCtrl : MonoBehaviour
{
    public bool sideVertical;
    public float target;
    public Vector2 targetPos;
    public float width;
    public float height;
    public float rotationSpeed;
    public float size;
    public AnimationClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.aspect * Camera.main.orthographicSize;
        height = Camera.main.orthographicSize;
        if (sideVertical)
        {
            target = Random.Range(-width * 2, height * 2 + width * 2);
            if (target < 0)
            {
                // Side 1
                targetPos = new Vector2(target + width, height + 1);
            }
            else if (target > height * 2)
            {
                // Side 3
                targetPos = new Vector2(target - width - height * 2, -height - 1);
            }
            else
            {
                // Side 2 or 4, Depending on the Starting Side
                targetPos = new Vector2(-transform.position.x, target - height);
            }
        }
        else
        {
            target = Random.Range(-height * 2, height * 2 + width * 2);
            if (target < 0)
            {
                // Side 2
                targetPos = new Vector2(width + 1, target + height);
            }
            else if (target > width * 2)
            {
                // Side 4
                targetPos = new Vector2(-width - 1, target - height - width * 2);
            }
            else
            {
                // Side 1 or 3, Depending on the Starting Side
                targetPos = new Vector2(target - width, -transform.position.y);
            }
        }
        size = Random.Range(0.5f, 1.5f);
        this.transform.localScale = new Vector3(size, size, 1);
        rotationSpeed = Random.Range(-200f, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * 4);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if (new Vector2(transform.position.x, transform.position.y) == targetPos)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "1" || other.tag == "2")
        {
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<Animator>().SetBool("Exploded", true);
            Destroy(this.gameObject, explosionClip.length / 0.4f);
        }
    }
}
////////////////////////////////////////////////////////////////////////////////
