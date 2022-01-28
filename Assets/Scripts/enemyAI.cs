using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    #region Variables

    public float speed;
    private bool movingRight=true;
    public Transform groundDirection;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed *Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDirection.position ,Vector2.down,2f);

        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0,-100,0);
                movingRight = false;
            }
        }
    }
}
