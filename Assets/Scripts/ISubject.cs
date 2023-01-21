using Enums;

public interface ISubject
{
    public void Attach(IObserver observer);
    public void Detach(IObserver observer);
    public void Notify(Message message);
}

public struct Message
{
    public Colour Colour;
    public InteriorStyle InteriorStyle;
    public Engine Engine;
}