using System;
using System.Collections.Generic;

namespace FreezeEngine
{
    public class GameObject : IGameObject
    {
        public GameObject gameObject => this;
        public List<IComponent> Components { get; } = new List<IComponent>();
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public string Tag { get; protected set; }

        public virtual void Update()
        {
        }

        public void AddComponent<T>(params object[] ps) where T : IComponent
        {
            IComponent component = (T)Activator.CreateInstance(typeof(T), ps);
            Components.Add(component);
        }

        public T GetComponent<T>() where T : IComponent
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] is T)
                {
                    return (T)Components[i];
                }
            }
            return default;
        }
    }
}