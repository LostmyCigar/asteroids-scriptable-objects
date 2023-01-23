using Asteroids;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


namespace Editors
{
    [CustomEditor(typeof(AstroidData))]
    public class AsteroidManagerEditor : Editor
    {

        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            //Here we could add stuff to costomize the tool
            //But i really dont know what we could add in an astroid tool to make it more user-friendly anyway
        }
    }
}

