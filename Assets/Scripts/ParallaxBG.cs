using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField] Transform folowingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStrenght = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (!folowingTarget)
            folowingTarget = Camera.main.transform;

        targetPreviousPosition = folowingTarget.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        var delta = folowingTarget.position - targetPreviousPosition;

        if (disableVerticalParallax)
            delta.y = 0;

        targetPreviousPosition = folowingTarget.position;
        transform.position += delta * parallaxStrenght;
    }
}
