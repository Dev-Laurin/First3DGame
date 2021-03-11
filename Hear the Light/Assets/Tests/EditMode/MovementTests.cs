using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTests : InputTestFixture
    {
        GameObject player_; 

        [SetUp]
        public void Setup()
        {
            player_ = new GameObject();
            player_.AddComponent<ThirdPersonMovement>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(player_); 
        }

        [Test]
        public void MoveNorth()
        {
            var gamepad = InputSystem.AddDevice<Gamepad>();
            Press(gamepad.buttonNorth); 

            //player should move in camera direction 

        }

        

    }
}

//[TestFixture]
//class TestFixture
//{
//    private InputTestFixture input = new InputTestFixture(); 
//}

//[PrebuildSetup("GameTestPrebuildSetup")]
//public class GameTestFixture
//{
//    public Game game { get; set; }
//    public InputTestFixture input { get; set; }

//    public Mouse mouse { get; set; }
//    public Keyboard keyboard { get; set; }
//    public Touch touch { get; set; }
//    public Gamepad gamepad { get; set; }
//}