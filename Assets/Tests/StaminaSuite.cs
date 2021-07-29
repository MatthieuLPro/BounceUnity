using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class StaminaSuite
    {
        [UnityTest]
        public IEnumerator StaminaConsumerIsConsuming()
        {
            GameObject gameObject = new GameObject();

            StaminaData staminaData = ScriptableObject.CreateInstance<StaminaData>();
            staminaData.maxStamina = 20;
            staminaData.currentStamina = 10;
            
            Stamina.StaminaConsumer staminaConsumer = gameObject.AddComponent<Stamina.StaminaConsumer>();
            staminaConsumer.Initialize(staminaData);
            
            int initStamina = staminaData.currentStamina;

            staminaConsumer.TryToConsume(5);
            yield return null;

            Assert.Less(staminaData.currentStamina, initStamina);

            Object.DestroyImmediate(gameObject);
            staminaData = null;
        }

        [UnityTest]
        public IEnumerator StaminaDoesNotConsumerIfStaminaIsEmpty()
        {
            GameObject gameObject = new GameObject();

            StaminaData staminaData = ScriptableObject.CreateInstance<StaminaData>();
            staminaData.maxStamina = 20;
            staminaData.currentStamina = 0;
            
            Stamina.StaminaConsumer staminaConsumer = gameObject.AddComponent<Stamina.StaminaConsumer>();
            staminaConsumer.Initialize(staminaData);
            
            int initStamina = staminaData.currentStamina;

            staminaConsumer.TryToConsume(5);
            yield return null;

            Assert.AreEqual(staminaData.currentStamina, initStamina);

            Object.DestroyImmediate(gameObject);
            staminaData = null;
        }

        [UnityTest]
        public IEnumerator StaminaDoesNotConsumeIfAlreadyConsuming()
        {
            GameObject gameObject = new GameObject();

            StaminaData staminaData = ScriptableObject.CreateInstance<StaminaData>();
            staminaData.maxStamina = 20;
            staminaData.currentStamina = 10;
            staminaData.consumingSpeed = 10;
            
            Stamina.StaminaConsumer staminaConsumer = gameObject.AddComponent<Stamina.StaminaConsumer>();
            staminaConsumer.Initialize(staminaData);
            
            int initStamina = staminaData.currentStamina;

            staminaConsumer.TryToConsume(5);
            yield return null;

            Assert.AreEqual(staminaData.currentStamina, initStamina);

            Object.DestroyImmediate(gameObject);
            staminaData = null;
        }

        [UnityTest]
        public IEnumerator StaminaDoesNotRecovererIfStaminaIsFull()
        {
            GameObject gameObject = new GameObject();

            StaminaData staminaData = ScriptableObject.CreateInstance<StaminaData>();
            staminaData.maxStamina = 20;
            staminaData.currentStamina = 20;
            
            Stamina.StaminaRecoverer staminaRecoverer = gameObject.AddComponent<Stamina.StaminaRecoverer>();
            staminaRecoverer.Initialize(staminaData);
            
            int initStamina = staminaData.currentStamina;

            staminaRecoverer.TryToRecover(5);
            yield return null;

            Assert.AreEqual(staminaData.currentStamina, initStamina);

            Object.DestroyImmediate(gameObject);
            staminaData = null;
        }

        [UnityTest]
        public IEnumerator StaminaDoesNotRecovererIfAlreadyRecovering()
        {
            GameObject gameObject = new GameObject();

            StaminaData staminaData = ScriptableObject.CreateInstance<StaminaData>();
            staminaData.maxStamina = 20;
            staminaData.currentStamina = 10;
            staminaData.recoverSpeed = 10;
            
            Stamina.StaminaRecoverer staminaRecoverer = gameObject.AddComponent<Stamina.StaminaRecoverer>();
            staminaRecoverer.Initialize(staminaData);
            
            int initStamina = staminaData.currentStamina;

            staminaRecoverer.TryToRecover(5);
            yield return null;

            Assert.AreEqual(staminaData.currentStamina, initStamina);

            Object.DestroyImmediate(gameObject);
            staminaData = null;
        }

        [UnityTest]
        public IEnumerator StaminaRecovererIsRecovering()
        {
            GameObject gameObject = new GameObject();

            StaminaData staminaData = ScriptableObject.CreateInstance<StaminaData>();
            staminaData.maxStamina = 20;
            staminaData.currentStamina = 10;
            
            Stamina.StaminaRecoverer staminaRecoverer = gameObject.AddComponent<Stamina.StaminaRecoverer>();
            staminaRecoverer.Initialize(staminaData);
            
            int initStamina = staminaData.currentStamina;

            staminaRecoverer.TryToRecover(5);
            yield return null;

            Assert.Greater(staminaData.currentStamina, initStamina);

            Object.DestroyImmediate(gameObject);
            staminaData = null;
        }
    }
}
