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

namespace UserModule_BSS_SOUNDWEB_LONDON_METER
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_METER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput ATTACK__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput RELEASE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput REFERENCE__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput ATTACK_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput RELEASE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput REFERENCE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 131;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 132;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 133;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 140;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 141;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 142;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 145;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 147;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 149;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object SUBSCRIBE__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 160;
                CreateWait ( "__SPLS_TMPVAR__WAITLABEL_0__" , 20 , __SPLS_TMPVAR__WAITLABEL_0___Callback ) ;
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_0___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 162;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 164;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 165;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0001\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 166;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 167;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0002\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 168;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 169;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0003\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 170;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 172;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 173;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object UNSUBSCRIBE__DOLLAR___OnPush_1 ( Object __EventInfo__ )

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
            __context__.SourceCodeLine = 185;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0001\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 186;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 187;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0002\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 188;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 189;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0003\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 190;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 192;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 193;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ATTACK__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 201;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0001{1}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( ATTACK__DOLLAR__  .UshortValue )) ) ; 
        __context__.SourceCodeLine = 203;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 205;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0001\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 206;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RELEASE__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 213;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0002{1}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( RELEASE__DOLLAR__  .UshortValue )) ) ; 
        __context__.SourceCodeLine = 215;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 217;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0002\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 218;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REFERENCE__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 226;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0003{1}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( REFERENCE__DOLLAR__  .UshortValue )) ) ; 
        __context__.SourceCodeLine = 228;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 230;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0003\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 231;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 245;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 247;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 248;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 250;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 252;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 253;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 255;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) ) == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 257;
                            ATTACK_FB__DOLLAR__  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 259;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) ) == 2))  ) ) 
                                { 
                                __context__.SourceCodeLine = 261;
                                RELEASE_FB__DOLLAR__  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 263;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) ) == 3))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 265;
                                    REFERENCE_FB__DOLLAR__  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    } 
                                
                                }
                            
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 268;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 248;
                } 
            
            __context__.SourceCodeLine = 271;
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
        
        __context__.SourceCodeLine = 289;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 290;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 291;
        _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
        
        
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
    _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    ATTACK__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( ATTACK__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( ATTACK__DOLLAR____AnalogSerialInput__, ATTACK__DOLLAR__ );
    
    RELEASE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( RELEASE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( RELEASE__DOLLAR____AnalogSerialInput__, RELEASE__DOLLAR__ );
    
    REFERENCE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( REFERENCE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( REFERENCE__DOLLAR____AnalogSerialInput__, REFERENCE__DOLLAR__ );
    
    ATTACK_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( ATTACK_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ATTACK_FB__DOLLAR____AnalogSerialOutput__, ATTACK_FB__DOLLAR__ );
    
    RELEASE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( RELEASE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RELEASE_FB__DOLLAR____AnalogSerialOutput__, RELEASE_FB__DOLLAR__ );
    
    REFERENCE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( REFERENCE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( REFERENCE_FB__DOLLAR____AnalogSerialOutput__, REFERENCE_FB__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_0, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_1, false ) );
    ATTACK__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( ATTACK__DOLLAR___OnChange_2, false ) );
    RELEASE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( RELEASE__DOLLAR___OnChange_3, false ) );
    REFERENCE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( REFERENCE__DOLLAR___OnChange_4, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_METER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 0;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 1;
const uint ATTACK__DOLLAR____AnalogSerialInput__ = 0;
const uint RELEASE__DOLLAR____AnalogSerialInput__ = 1;
const uint REFERENCE__DOLLAR____AnalogSerialInput__ = 2;
const uint RX__DOLLAR____AnalogSerialInput__ = 3;
const uint ATTACK_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint RELEASE_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint REFERENCE_FB__DOLLAR____AnalogSerialOutput__ = 2;
const uint TX__DOLLAR____AnalogSerialOutput__ = 3;
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
            public ushort VOLUME = 0;
            [SplusStructAttribute(3, false, true)]
            public CrestronString TEMPSTRING;
            [SplusStructAttribute(4, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(5, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort SUBSCRIBE = 0;
            
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
