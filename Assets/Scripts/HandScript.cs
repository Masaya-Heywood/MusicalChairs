using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
        public Vector3 pointB;
        public Vector3 pointA;

    public GameObject discolights;
    public bool discoVar; 
    
        bool keyboardPress = false;

        void Update()
        {
        if (Input.anyKey) {
            keyboardPress = true;
        } else{
            keyboardPress = false; 
        }

        discoVar = discolights.GetComponent<DiscoLights>().lightSwitched;

        if (discoVar == false) {

        }else {

        }
    }

    public void start() {
    }

        IEnumerator Start()
        {
            var point = transform.position;

        while (discoVar == false) {
            yield return new WaitForSeconds(0.2f);

            while (discoVar == true) {
                yield return StartCoroutine(MoveObject(transform, pointA, pointB, point, 3.0f));
                yield return StartCoroutine(MoveObject(transform, pointB, pointA, point, 3.0f));
            }
        }
        
        
        yield return new WaitForSeconds(1f);
    }
       
    

        IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, Vector3 point, float time)
        {


        if (gameObject.tag == ("Left Hand"))
        {
            var i = 0.0f;
            var rate = 3.0f / time;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                thisTransform.position = Vector3.Lerp(startPos, endPos, i);
                yield return null;
            }
        }
        else
        {
            var i = 0.0f;
            var rate = 3.0f / time;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                thisTransform.position = Vector3.Lerp(endPos, startPos, i);
                yield return null;
            }
        }
           
        }
    
}
