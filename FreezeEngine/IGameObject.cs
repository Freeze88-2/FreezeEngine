using System.Collections.Generic;

namespace FreezeEngine
{
    public interface IGameObject : ITransform
    {
        public abstract List<IComponent> Components { get; }

        public abstract void Update();

        public abstract string Tag { get; }

        public T GetComponent<T>() where T : IComponent;

        public void AddComponent<T>(params object[] ps) where T : IComponent;
    }
}