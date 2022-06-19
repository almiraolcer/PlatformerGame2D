using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
  [SerializeField] private float speed = 2f;

  private void Update(){
      transform.Rotate(0,0, 360 * speed * Time.deltaTime);
  }
}
