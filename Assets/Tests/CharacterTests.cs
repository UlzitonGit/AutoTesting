using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterTests : InputTestFixture
{
    GameObject character = Resources.Load<GameObject>("Character");
    Keyboard keyboard;
    public override void Setup()
    {
        SceneManager.LoadScene("Scenes/SimpleTest");
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();
        
        var mouse = InputSystem.AddDevice<Mouse>();
        Press(mouse.rightButton);
        Release(mouse.rightButton);;
    }
    [UnityTest]
    public IEnumerator TestPlayerMoves()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);
        for (int i = 0; i < 2; i++)
        {
            Press(keyboard.upArrowKey);
            yield return new WaitForSeconds(1f);
            Release(keyboard.upArrowKey);
            yield return new WaitForSeconds(1f);
            Press(keyboard.leftArrowKey);
            yield return new WaitForSeconds(1f);
            Release(keyboard.leftArrowKey);
            yield return new WaitForSeconds(1f);
        }

        Assert.That(characterInstance.transform.GetChild(0).transform.position.z, Is.GreaterThan(1.5f));
    }
}
