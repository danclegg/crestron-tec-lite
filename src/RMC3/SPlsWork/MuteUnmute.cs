using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_MUTEUNMUTE
{
    public class UserModuleClass_MUTEUNMUTE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput MUTE_OFF;
        Crestron.Logos.SplusObjects.DigitalInput MUTE_ON;
        Crestron.Logos.SplusObjects.DigitalInput MUTE_TOGGLE;
        Crestron.Logos.SplusObjects.AnalogInput VOL_FB;
        Crestron.Logos.SplusObjects.DigitalOutput MUTE_OFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput MUTE_ON_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VOL;
        ushort CURRENT_VOLUME = 0;
        ushort MUTED = 0;
        private void RESETVALUES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 49;
            MUTE_OFF_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 50;
            MUTE_ON_FB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void MUTE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 54;
            MUTE_ON_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 55;
            CURRENT_VOLUME = (ushort) ( 0 ) ; 
            
            }
            
        private void UNMUTE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 59;
            MUTE_OFF_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 60;
            CURRENT_VOLUME = (ushort) ( 0 ) ; 
            
            }
            
        object MUTE_ON_OnRelease_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 70;
                RESETVALUES (  __context__  ) ; 
                __context__.SourceCodeLine = 71;
                MUTED = (ushort) ( 1 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MUTE_OFF_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 77;
            RESETVALUES (  __context__  ) ; 
            __context__.SourceCodeLine = 78;
            MUTED = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object MUTE_TOGGLE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 83;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MUTED == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 85;
            RESETVALUES (  __context__  ) ; 
            __context__.SourceCodeLine = 86;
            MUTED = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 90;
            RESETVALUES (  __context__  ) ; 
            __context__.SourceCodeLine = 91;
            MUTED = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOL_FB_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 97;
        CURRENT_VOLUME = (ushort) ( VOL_FB  .UshortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 108;
        CURRENT_VOLUME = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 109;
        MUTED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 110;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    
    MUTE_OFF = new Crestron.Logos.SplusObjects.DigitalInput( MUTE_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( MUTE_OFF__DigitalInput__, MUTE_OFF );
    
    MUTE_ON = new Crestron.Logos.SplusObjects.DigitalInput( MUTE_ON__DigitalInput__, this );
    m_DigitalInputList.Add( MUTE_ON__DigitalInput__, MUTE_ON );
    
    MUTE_TOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( MUTE_TOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( MUTE_TOGGLE__DigitalInput__, MUTE_TOGGLE );
    
    MUTE_OFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( MUTE_OFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( MUTE_OFF_FB__DigitalOutput__, MUTE_OFF_FB );
    
    MUTE_ON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( MUTE_ON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( MUTE_ON_FB__DigitalOutput__, MUTE_ON_FB );
    
    VOL_FB = new Crestron.Logos.SplusObjects.AnalogInput( VOL_FB__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOL_FB__AnalogSerialInput__, VOL_FB );
    
    VOL = new Crestron.Logos.SplusObjects.AnalogOutput( VOL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOL__AnalogSerialOutput__, VOL );
    
    
    MUTE_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( MUTE_ON_OnRelease_0, false ) );
    MUTE_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( MUTE_OFF_OnRelease_1, false ) );
    MUTE_TOGGLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( MUTE_TOGGLE_OnRelease_2, false ) );
    VOL_FB.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOL_FB_OnChange_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MUTEUNMUTE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint MUTE_OFF__DigitalInput__ = 0;
const uint MUTE_ON__DigitalInput__ = 1;
const uint MUTE_TOGGLE__DigitalInput__ = 2;
const uint VOL_FB__AnalogSerialInput__ = 0;
const uint MUTE_OFF_FB__DigitalOutput__ = 0;
const uint MUTE_ON_FB__DigitalOutput__ = 1;
const uint VOL__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
