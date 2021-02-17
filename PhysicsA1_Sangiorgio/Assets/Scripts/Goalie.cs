using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalie : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 back = new Vector3(-6.0f, 5, 0);
    Vector3 forth = new Vector3(6.0f, 5, 0);
    float changeDir = 0;
    float speed = 1; 
    float targetDirection = 1; 

    void Update()
    {
        transform.position = Vector3.Lerp(back, forth, changeDir); 
        changeDir += Time.deltaTime * speed * targetDirection; 
        if (changeDir >= 1 || changeDir <= 0) targetDirection *= -1; 
    }

}
