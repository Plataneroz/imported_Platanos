using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEditor;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.LowLevel;
using System.Linq;

public struct MyDeviceState : IInputStateTypeInfo
{
    public FourCC format => new FourCC( 'M', 'Y', 'D', 'V');//throw new System.NotImplementedException();

    [InputControl(name = "button1", layout = "Button", bit = 0)]
    [InputControl(name = "button2", layout = "Button", bit = 1)]
    public int buttons;
    [InputControl(name = "position", layout = "Vector2", format ="VC2S", sizeInBits =32)]
    [InputControl(name = "position/x", format = "SHRT")]
    public short x;
    [InputControl(name = "position/y", format = "SHRT", offset = 2)]
    public short y;

}

/*[InputControlLayout(stateType = typeof(MyDeviceState))]
[InitializeOnLoad]
public class MyDevice : InputDevice  
{
    

   
   public ButtonControl button1 { get; private set; }

    
   public ButtonControl button2 { get; private set; }

    
    public Vector2Control position { get; private set; }

    
    

    protected override void FinishSetup()
    {
        base.FinishSetup();

        button1 = GetChildControl<ButtonControl>(path: "button1");
        button2 = GetChildControl<ButtonControl>(path: "button2");
        position = GetChildControl<Vector2Control>(path: "position");
    }

    static MyDevice()
    {
        InputSystem.RegisterLayout<MyDevice>(
            matches: new InputDeviceMatcher()
            .WithInterface( "MyDevice")
            );

        if (!InputSystem.devices.Any(x  => x is MyDevice))
        { InputSystem.AddDevice(new InputDeviceDescription { interfaceName = "MyDevice" ,product = "ThisDevice"}); }
    }

    [MenuItem("Tools/Add MyDevice")]
    public static void Initialize() 
    {
        InputSystem.AddDevice<MyDevice>();
    }
}
*/