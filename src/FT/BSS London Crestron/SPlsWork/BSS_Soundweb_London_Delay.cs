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

namespace UserModule_BSS_SOUNDWEB_LONDON_DELAY
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_DELAY : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput DELAY__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput DELAY_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        object DELAY__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 154;
                _SplusNVRAM.DELAY_INT = (ushort) ( DELAY__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 155;
                _SplusNVRAM.DELAYSTRING  .UpdateValue ( Functions.ItoA (  (int) ( _SplusNVRAM.DELAY_INT ) )  ) ; 
                __context__.SourceCodeLine = 156;
                _SplusNVRAM.DELAYVALUE = (uint) ( ((Functions.Atoi( Functions.Right( _SplusNVRAM.DELAYSTRING , (int)( 1 ) ) ) * 96) / 10) ) ; 
                __context__.SourceCodeLine = 157;
                _SplusNVRAM.DELAYVALUE = (uint) ( (_SplusNVRAM.DELAYVALUE + (Functions.Atoi( Functions.Left( _SplusNVRAM.DELAYSTRING , (int)( (Functions.Length( _SplusNVRAM.DELAYSTRING ) - 1) ) ) ) * 96)) ) ; 
                __context__.SourceCodeLine = 158;
                _SplusNVRAM.DELAY1 = (ushort) ( (_SplusNVRAM.DELAYVALUE / 65536) ) ; 
                __context__.SourceCodeLine = 159;
                _SplusNVRAM.DELAY2 = (ushort) ( ((_SplusNVRAM.DELAYVALUE - (_SplusNVRAM.DELAY1 * 65536)) / 256) ) ; 
                __context__.SourceCodeLine = 160;
                _SplusNVRAM.DELAY3 = (ushort) ( (_SplusNVRAM.DELAYVALUE - ((_SplusNVRAM.DELAYVALUE / 256) * 256)) ) ; 
                __context__.SourceCodeLine = 161;
                _SplusNVRAM.DELAYSENDSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.DELAY1 ) ) + Functions.Chr (  (int) ( _SplusNVRAM.DELAY2 ) ) + Functions.Chr (  (int) ( _SplusNVRAM.DELAY3 ) )  ) ; 
                __context__.SourceCodeLine = 162;
                MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0000{1}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , _SplusNVRAM.DELAYSENDSTRING ) ; 
                __context__.SourceCodeLine = 163;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SUBSCRIBE__DOLLAR___OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 170;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 172;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 173;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 174;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object UNSUBSCRIBE__DOLLAR___OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 181;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 183;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 184;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 185;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 199;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 201;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 202;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 204;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 206;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 207;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 209;
                        _SplusNVRAM.DELAYVALUE_FB = (uint) ( 0 ) ; 
                        __context__.SourceCodeLine = 211;
                        _SplusNVRAM.DELAYVALUE_FB = (uint) ( (_SplusNVRAM.DELAYVALUE_FB + (Byte( _SplusNVRAM.TEMPSTRING , (int)( 12 ) ) * 65536)) ) ; 
                        __context__.SourceCodeLine = 212;
                        _SplusNVRAM.DELAYVALUE_FB = (uint) ( (_SplusNVRAM.DELAYVALUE_FB + (Byte( _SplusNVRAM.TEMPSTRING , (int)( 13 ) ) * 256)) ) ; 
                        __context__.SourceCodeLine = 213;
                        _SplusNVRAM.DELAYVALUE_FB = (uint) ( (_SplusNVRAM.DELAYVALUE_FB + Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) )) ) ; 
                        __context__.SourceCodeLine = 214;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.DELAYVALUE_FB <= 261120 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 216;
                            _SplusNVRAM.VALUE_FB = (ushort) ( (_SplusNVRAM.DELAYVALUE_FB / 96) ) ; 
                            __context__.SourceCodeLine = 217;
                            _SplusNVRAM.DECIMALVALUE_FB = (ushort) ( (((_SplusNVRAM.DELAYVALUE_FB - (96 * _SplusNVRAM.VALUE_FB)) * 10) / 96) ) ; 
                            __context__.SourceCodeLine = 218;
                            DELAY_FB__DOLLAR__  .Value = (ushort) ( ((_SplusNVRAM.VALUE_FB * 10) + _SplusNVRAM.DECIMALVALUE_FB) ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 221;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 202;
                } 
            
            __context__.SourceCodeLine = 224;
            _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
            } 
        
        
        
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
        
        __context__.SourceCodeLine = 242;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 243;
        _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 244;
        _SplusNVRAM.DELAY_INT = (ushort) ( 0 ) ; 
        
        
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
    _SplusNVRAM.TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    _SplusNVRAM.DELAYSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    _SplusNVRAM.DELAYSENDSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    DELAY__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( DELAY__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( DELAY__DOLLAR____AnalogSerialInput__, DELAY__DOLLAR__ );
    
    DELAY_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( DELAY_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DELAY_FB__DOLLAR____AnalogSerialOutput__, DELAY_FB__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    
    DELAY__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( DELAY__DOLLAR___OnChange_0, false ) );
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_1, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_2, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_DELAY ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 0;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 1;
const uint DELAY__DOLLAR____AnalogSerialInput__ = 0;
const uint RX__DOLLAR____AnalogSerialInput__ = 1;
const uint DELAY_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 1;
const uint OBJECTID__DOLLAR____Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort XOKSUBSCRIBE = 0;
            [SplusStructAttribute(2, false, true)]
            public CrestronString TEMPSTRING;
            [SplusStructAttribute(3, false, true)]
            public CrestronString DELAYSTRING;
            [SplusStructAttribute(4, false, true)]
            public uint DELAYVALUE = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort DELAY1 = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort DELAY2 = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort DELAY3 = 0;
            [SplusStructAttribute(8, false, true)]
            public CrestronString DELAYSENDSTRING;
            [SplusStructAttribute(9, false, true)]
            public ushort VALUE_FB = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort DECIMALVALUE_FB = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort DELAY_INT = 0;
            [SplusStructAttribute(12, false, true)]
            public uint DELAYVALUE_FB = 0;
            
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
