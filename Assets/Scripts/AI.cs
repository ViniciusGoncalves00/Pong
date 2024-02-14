// using System;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// public class AI : MonoBehaviour
// {
//     [FormerlySerializedAs("Board")] [SerializeField] private FrameMesh _frameMesh;
//
//     private DrawMesh _drawMesh;
//
//     [SerializeField] private float _width = 1;
//     [SerializeField] private float _height = 2;
//
//     [SerializeField] private float DistanceFromCenter = 2;
//     private float _halfWidth;
//     private float _halfHeight;
//
//     public Rect Rect = new Rect();
//
//     public float LeftSide;
//     public float RightSide;
//     public float BottomSide;
//     public float TopSide;
//     
//     private float _boardY;
//     private float _boardHeight;
//
//     public float _increment = 0.1f;
//
//     public Vector2 _center = new Vector2(0, 0);
//
//     private void Awake()
//     {
//         
//     }
//
//     private void Start()
//     {
//         _boardY = _frameMesh.Rect.y;
//         _boardHeight = _frameMesh.Rect.height;
//         
//         _halfWidth = _width / 2;
//         _halfHeight = _height / 2;
//
//         var transformPosition = transform.position;
//
//         _center = transformPosition;
//         transformPosition.x = DistanceFromCenter;
//         transform.position = transformPosition;
//     }
//
//     private void Update()
//     {
//         Rect = _drawMesh.DefineRectFromCenter(Rect, _halfWidth, _halfHeight);
//         
//         var pos = transform.position;
//         LeftSide = pos.x - _halfWidth;
//         RightSide = pos.x + _halfWidth;
//         BottomSide = pos.y - _halfHeight;
//         TopSide = pos.y + _halfHeight;
//         
//
//         if (Input.GetKey(KeyCode.W))
//         {
//             Move(_increment);
//         }
//
//         if (Input.GetKey(KeyCode.S))
//         {
//             Move(-_increment);
//         }
//     }
//
//     private void Move(float increment)
//     {
//         var transformPosition = transform.position;
//
//         transformPosition += new Vector3(0, increment, 0);
//         transformPosition.y = Math.Clamp(transformPosition.y, _boardY + _halfHeight, _boardHeight - _halfHeight);
//         transformPosition.x = DistanceFromCenter;
//
//         transform.position = transformPosition;
//         _center = transformPosition;
//     }
//
//     
// }