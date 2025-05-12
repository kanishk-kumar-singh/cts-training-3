using System;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void TurnOn() => Console.WriteLine("Light is ON");
    public void TurnOff() => Console.WriteLine("Light is OFF");
}

public class LightOnCommand : ICommand
{
    private Light _light;
    public LightOnCommand(Light light) => _light = light;
    public void Execute() => _light.TurnOn();
    public void Undo() => _light.TurnOff();
}

public class LightOffCommand : ICommand
{
    private Light _light;
    public LightOffCommand(Light light) => _light = light;
    public void Execute() => _light.TurnOff();
    public void Undo() => _light.TurnOn();
}

public class RemoteControl
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void PressButton() => _command.Execute();
    public void PressUndo() => _command.Undo();
}

public class Program
{
    public static void Main()
    {
        Light livingRoomLight = new Light();
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(lightOn);
        remote.PressButton();  // Output: Light is ON
        remote.PressUndo();    // Output: Light is OFF

        remote.SetCommand(lightOff);
        remote.PressButton();  // Output: Light is OFF
        remote.PressUndo();    // Output: Light is ON
    }
}
