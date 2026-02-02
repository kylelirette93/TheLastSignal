using System;

public class Event
{
    private event Action action = delegate { };

    public void Publish()
    {
        action.Invoke();
    }

    public void Add(Action subscriber)
    {
        action += subscriber;
    }

    public void Remove(Action subscriber)
    {
        action -= subscriber;
    }
}

public class Event<T>
{
    private event Action<T> action;

    public void Publish(T arg)
    {
        action?.Invoke(arg);
    }

    public void Add(Action<T> subscriber)
    {
        action += subscriber;
    }

    public void Remove(Action<T> subscriber)
    {
        action -= subscriber;
    }
}
