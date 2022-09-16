using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    // Our Animator reference variable
    Animator _animator;
    float _snappedHorizontal;
    float _snappedVertical;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void HandleAnimatorValues(float horizontalMovement, float verticalMovement, bool isRunning)
    {
        if (horizontalMovement > 0)
        {
            _snappedHorizontal = 1;
        }
        else if (horizontalMovement < 0)
        {
            _snappedHorizontal = -1;
        }
        else
        {
            _snappedHorizontal = 0;
        }

        if (verticalMovement > 0)
        {
            _snappedVertical = 1;
        }
        else if (verticalMovement < 0)
        {
            _snappedVertical = -1;
        }
        else
        {
            _snappedVertical = 0;
        }

        if (isRunning && _snappedVertical > 0) // we don't want to run backwards
        {
            _snappedVertical = 2;
        }

        _animator.SetFloat("Horizontal", _snappedHorizontal, 0.1f, Time.deltaTime);
        _animator.SetFloat("Vertical", _snappedVertical, 0.1f, Time.deltaTime);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
