using System;
using System.Collections.Generic;
using UnityEngine;

public enum MovingType 
{
    Once,
    Cycle
}

namespace Level
{
    public class MoveBetween : MonoBehaviour
    {
        [SerializeField] private List<Transform> movePositions;
        [SerializeField] private GameObject movedObject;
        [SerializeField] private float speed;
        [SerializeField] private MovingType movingType = MovingType.Cycle;

        private int _currentPositionIndex = 0;

        private int _nextPositionIndex => _currentPositionIndex + 1 < movePositions.Count ? _currentPositionIndex + 1 : 0;
        private Vector3 CurrentPosition => movePositions[_currentPositionIndex].position;
        private Vector3 NextPosition => movePositions[_nextPositionIndex].position;
        private Vector3 CurrentDirection => (NextPosition - movedObject.transform.position).normalized * speed;

        private const float AchieveAccuracy = 0.1f;

        private bool NextPointAchieved()
        {
            return (movedObject.transform.position - NextPosition).magnitude < AchieveAccuracy;
        }

        private void Start()
        {
            movedObject.transform.position = CurrentPosition;
        }

        private Vector3 _startPosition;
        private Vector3 _direction;
        // Start is called before the first frame update

        // Update is called once per frame
        private void Update()
        {
            switch (movingType)
            {
                case MovingType.Cycle:
                {
                    if (NextPointAchieved())
                        _currentPositionIndex = _nextPositionIndex;    
                    movedObject.transform.position += CurrentDirection * Time.deltaTime;
                    break;
                }
                case MovingType.Once:
                {   
                    if (_nextPositionIndex != 0)
                        if (NextPointAchieved())
                            _currentPositionIndex = _nextPositionIndex;    
                        movedObject.transform.position += CurrentDirection * Time.deltaTime;
                    break;
                }
                default:
                    break;
            }
        }
    }
}
