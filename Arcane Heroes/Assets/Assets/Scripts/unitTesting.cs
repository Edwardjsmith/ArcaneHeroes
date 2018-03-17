using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class unitTesting {

	[Test]
	public void unitTestingSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator checksJump() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var player = new GameObject().AddComponent<playerController>();

         Assert.LessOrEqual(player.GetComponent<Rigidbody2D>().velocity.y, player.jumpForce);

        yield return null;
	}
    public IEnumerator checksMovement()
    {
        var player = new GameObject().AddComponent<playerController>();
        {
            Assert.LessOrEqual(player.GetComponent<Rigidbody2D>().velocity.x, player.movementSpeed);
        }

        yield return null;
    }
}
