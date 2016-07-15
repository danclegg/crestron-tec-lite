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

namespace UserModule_TRACKCECVOLUME
{
    public class UserModuleClass_TRACKCECVOLUME : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DISPLAY_IS_CEC;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput SLIDER_PRESS;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_UP_FB;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_DOWN_FB;
        Crestron.Logos.SplusObjects.AnalogOutput _VOLUME;
        ushort CURRENT_VOLUME = 0;
        ushort TRACK_MANUALLY = 0;
        ushort SCALE_FACTOR = 0;
        ushort GOAL = 0;
        private void RESETVOLUME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 54;
            CURRENT_VOLUME = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 55;
            _VOLUME  .Value = (ushort) ( CURRENT_VOLUME ) ; 
            
            }
            
        object DISPLAY_IS_CEC_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 65;
                RESETVOLUME (  __context__  ) ; 
                __context__.SourceCodeLine = 66;
                TRACK_MANUALLY = (ushort) ( 1 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DISPLAY_IS_CEC_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 71;
            RESETVOLUME (  __context__  ) ; 
            __context__.SourceCodeLine = 72;
            TRACK_MANUALLY = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object VOLUME_UP_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 77;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TRACK_MANUALLY == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 78;
            CURRENT_VOLUME = (ushort) ( (CURRENT_VOLUME + SCALE_FACTOR) ) ; 
            __context__.SourceCodeLine = 79;
            _VOLUME  .Value = (ushort) ( CURRENT_VOLUME ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_DOWN_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TRACK_MANUALLY == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 86;
            CURRENT_VOLUME = (ushort) ( (CURRENT_VOLUME - SCALE_FACTOR) ) ; 
            __context__.SourceCodeLine = 87;
            _VOLUME  .Value = (ushort) ( CURRENT_VOLUME ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SLIDER_PRESS_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 93;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GOAL > CURRENT_VOLUME ))  ) ) 
            { 
            __context__.SourceCodeLine = 95;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GOAL > CURRENT_VOLUME ))  ) ) 
                { 
                __context__.SourceCodeLine = 97;
                CURRENT_VOLUME = (ushort) ( (CURRENT_VOLUME + SCALE_FACTOR) ) ; 
                __context__.SourceCodeLine = 95;
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 100;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GOAL < CURRENT_VOLUME ))  ) ) 
                { 
                __context__.SourceCodeLine = 102;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GOAL < CURRENT_VOLUME ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 104;
                    CURRENT_VOLUME = (ushort) ( (CURRENT_VOLUME - SCALE_FACTOR) ) ; 
                    __context__.SourceCodeLine = 102;
                    } 
                
                } 
            
            else 
                { 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 115;
        GOAL = (ushort) ( VOLUME  .UshortValue ) ; 
        
        
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
        
        __context__.SourceCodeLine = 126;
        CURRENT_VOLUME = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 127;
        TRACK_MANUALLY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 128;
        SCALE_FACTOR = (ushort) ( (65534 / 100) ) ; 
        __context__.SourceCodeLine = 129;
        GOAL = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 131;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    DISPLAY_IS_CEC = new Crestron.Logos.SplusObjects.DigitalInput( DISPLAY_IS_CEC__DigitalInput__, this );
    m_DigitalInputList.Add( DISPLAY_IS_CEC__DigitalInput__, DISPLAY_IS_CEC );
    
    VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_UP__DigitalInput__, VOLUME_UP );
    
    VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_DOWN__DigitalInput__, VOLUME_DOWN );
    
    SLIDER_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( SLIDER_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( SLIDER_PRESS__DigitalInput__, SLIDER_PRESS );
    
    VOLUME_UP_FB = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_UP_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( VOLUME_UP_FB__DigitalOutput__, VOLUME_UP_FB );
    
    VOLUME_DOWN_FB = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_DOWN_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( VOLUME_DOWN_FB__DigitalOutput__, VOLUME_DOWN_FB );
    
    VOLUME = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME__AnalogSerialInput__, VOLUME );
    
    _VOLUME = new Crestron.Logos.SplusObjects.AnalogOutput( _VOLUME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( _VOLUME__AnalogSerialOutput__, _VOLUME );
    
    
    DISPLAY_IS_CEC.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISPLAY_IS_CEC_OnPush_0, false ) );
    DISPLAY_IS_CEC.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DISPLAY_IS_CEC_OnRelease_1, false ) );
    VOLUME_UP.OnDigitalRelease.Add( new InputChangeHandlerWrapper( VOLUME_UP_OnRelease_2, false ) );
    VOLUME_DOWN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( VOLUME_DOWN_OnRelease_3, false ) );
    SLIDER_PRESS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SLIDER_PRESS_OnRelease_4, false ) );
    VOLUME.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TRACKCECVOLUME ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DISPLAY_IS_CEC__DigitalInput__ = 0;
const uint VOLUME_UP__DigitalInput__ = 1;
const uint VOLUME_DOWN__DigitalInput__ = 2;
const uint SLIDER_PRESS__DigitalInput__ = 3;
const uint VOLUME__AnalogSerialInput__ = 0;
const uint VOLUME_UP_FB__DigitalOutput__ = 0;
const uint VOLUME_DOWN_FB__DigitalOutput__ = 1;
const uint _VOLUME__AnalogSerialOutput__ = 0;

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
