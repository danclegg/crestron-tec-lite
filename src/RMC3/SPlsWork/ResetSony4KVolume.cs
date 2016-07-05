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

namespace UserModule_RESETSONY4KVOLUME
{
    public class UserModuleClass_RESETSONY4KVOLUME : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput START_RESET;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_LEVEL_IN;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_DOWN;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_LEVEL_OUT;
        object START_RESET_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort COUNTER = 0;
                
                
                __context__.SourceCodeLine = 28;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)100; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( COUNTER  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (COUNTER  >= __FN_FORSTART_VAL__1) && (COUNTER  <= __FN_FOREND_VAL__1) ) : ( (COUNTER  <= __FN_FORSTART_VAL__1) && (COUNTER  >= __FN_FOREND_VAL__1) ) ; COUNTER  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 29;
                    VOLUME_DOWN  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 30;
                    Functions.Delay (  (int) ( 5 ) ) ; 
                    __context__.SourceCodeLine = 31;
                    VOLUME_DOWN  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 33;
                    COUNTER = (ushort) ( (COUNTER + 1) ) ; 
                    __context__.SourceCodeLine = 28;
                    } 
                
                __context__.SourceCodeLine = 35;
                VOLUME_DOWN  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 46;
                VOLUME_LEVEL_OUT  .Value = (ushort) ( 0 ) ; 
                
                
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
            
            __context__.SourceCodeLine = 54;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        START_RESET = new Crestron.Logos.SplusObjects.DigitalInput( START_RESET__DigitalInput__, this );
        m_DigitalInputList.Add( START_RESET__DigitalInput__, START_RESET );
        
        VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_UP__DigitalOutput__, this );
        m_DigitalOutputList.Add( VOLUME_UP__DigitalOutput__, VOLUME_UP );
        
        VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_DOWN__DigitalOutput__, this );
        m_DigitalOutputList.Add( VOLUME_DOWN__DigitalOutput__, VOLUME_DOWN );
        
        VOLUME_LEVEL_IN = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_LEVEL_IN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( VOLUME_LEVEL_IN__AnalogSerialInput__, VOLUME_LEVEL_IN );
        
        VOLUME_LEVEL_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_LEVEL_OUT__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( VOLUME_LEVEL_OUT__AnalogSerialOutput__, VOLUME_LEVEL_OUT );
        
        
        START_RESET.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_RESET_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_RESETSONY4KVOLUME ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint START_RESET__DigitalInput__ = 0;
    const uint VOLUME_LEVEL_IN__AnalogSerialInput__ = 0;
    const uint VOLUME_UP__DigitalOutput__ = 0;
    const uint VOLUME_DOWN__DigitalOutput__ = 1;
    const uint VOLUME_LEVEL_OUT__AnalogSerialOutput__ = 0;
    
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
