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

namespace UserModule_BSS_SOUNDWEB_LONDON_MATRIX_MIXER
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_MATRIX_MIXER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> OUTPUT_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput INPUT__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> OUTPUT_GAIN__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> OUTPUT_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> OUTPUT_GAIN_FB__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        UShortParameter IMAXOUTPUT;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 168;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 169;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 170;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 178;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 179;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 180;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 183;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 185;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 187;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object OUTPUT_MUTE__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 199;
                _SplusNVRAM.STATEVARONOFF = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 200;
                _SplusNVRAM.STATEVARONOFF = (ushort) ( (((_SplusNVRAM.STATEVARONOFF - 1) * 128) + (_SplusNVRAM.INPUT - 1)) ) ; 
                __context__.SourceCodeLine = 201;
                MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) ) ; 
                __context__.SourceCodeLine = 203;
                if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 205;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) ) ; 
                    __context__.SourceCodeLine = 206;
                    Functions.ProcessLogic ( ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object OUTPUT_MUTE__DOLLAR___OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 211;
            _SplusNVRAM.STATEVARONOFF = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 212;
            _SplusNVRAM.STATEVARONOFF = (ushort) ( (((_SplusNVRAM.STATEVARONOFF - 1) * 128) + (_SplusNVRAM.INPUT - 1)) ) ; 
            __context__.SourceCodeLine = 213;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) ) ; 
            __context__.SourceCodeLine = 215;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 217;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARONOFF ) ) ) ) ; 
                __context__.SourceCodeLine = 218;
                Functions.ProcessLogic ( ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object OUTPUT_GAIN__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 225;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 227;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.VOLUMEOUTPUT[ _SplusNVRAM.X ] != OUTPUT_GAIN__DOLLAR__[ _SplusNVRAM.X ] .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 229;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN[ _SplusNVRAM.X ])  ) ) 
                { 
                __context__.SourceCodeLine = 231;
                _SplusNVRAM.XOKGAIN [ _SplusNVRAM.X] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 232;
                _SplusNVRAM.STATEVARGAIN = (ushort) ( (16384 + (((_SplusNVRAM.X - 1) * 128) + (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 234;
                _SplusNVRAM.VOLUMEOUTPUT [ _SplusNVRAM.X] = (ushort) ( OUTPUT_GAIN__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 235;
                OUTPUT_GAIN_FB__DOLLAR__ [ _SplusNVRAM.X]  .Value = (ushort) ( OUTPUT_GAIN__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 237;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARGAIN ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARGAIN ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( OUTPUT_GAIN__DOLLAR__[ _SplusNVRAM.X ] .UshortValue )) ) ; 
                __context__.SourceCodeLine = 238;
                _SplusNVRAM.XOKGAIN [ _SplusNVRAM.X] = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUBSCRIBE__DOLLAR___OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 246;
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
        
            
            __context__.SourceCodeLine = 248;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 250;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 251;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.INPUT - 1) ) ; 
                __context__.SourceCodeLine = 252;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)IMAXOUTPUT  .Value; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 254;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((_SplusNVRAM.INPUT - 1) + ((_SplusNVRAM.I - 1) * 128)) ) ; 
                    __context__.SourceCodeLine = 255;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 256;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 258;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.STATEVARSUB + 16384) ) ; 
                    __context__.SourceCodeLine = 259;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 260;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 261;
                    Functions.Delay (  (int) ( 5 ) ) ; 
                    __context__.SourceCodeLine = 252;
                    } 
                
                __context__.SourceCodeLine = 263;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 264;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object UNSUBSCRIBE__DOLLAR___OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 272;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 274;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 275;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.INPUT - 1) ) ; 
            __context__.SourceCodeLine = 276;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)IMAXOUTPUT  .Value; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 278;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((_SplusNVRAM.INPUT - 1) + ((_SplusNVRAM.I - 1) * 128)) ) ; 
                __context__.SourceCodeLine = 279;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 280;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 282;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.STATEVARSUB + 16384) ) ; 
                __context__.SourceCodeLine = 283;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 284;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 285;
                Functions.Delay (  (int) ( 5 ) ) ; 
                __context__.SourceCodeLine = 276;
                } 
            
            __context__.SourceCodeLine = 287;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 288;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 296;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INPUT__DOLLAR__  .UshortValue > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 297;
            _SplusNVRAM.INPUT = (ushort) ( INPUT__DOLLAR__  .UshortValue ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 300;
            _SplusNVRAM.INPUT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 301;
            Print( "error input for the automixer cannot be 0. set to default of 1") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 315;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 317;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 318;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 320;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 322;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 323;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 325;
                        _SplusNVRAM.STATEVARRECEIVE = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 326;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( _SplusNVRAM.STATEVARRECEIVE , 128 ) == (_SplusNVRAM.INPUT - 1)))  ) ) 
                            { 
                            __context__.SourceCodeLine = 328;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.STATEVARRECEIVE < 16384 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 330;
                                if ( Functions.TestForTrue  ( ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 333;
                                    OUTPUT_MUTE_FB__DOLLAR__ [ ((_SplusNVRAM.STATEVARRECEIVE / 128) + 1)]  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 337;
                                    OUTPUT_MUTE_FB__DOLLAR__ [ ((_SplusNVRAM.STATEVARRECEIVE / 128) + 1)]  .Value = (ushort) ( 0 ) ; 
                                    } 
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 343;
                                _SplusNVRAM.STATEVARRECEIVE = (ushort) ( (((_SplusNVRAM.STATEVARRECEIVE - 16384) / 128) + 1) ) ; 
                                __context__.SourceCodeLine = 344;
                                _SplusNVRAM.VOLUMEOUTPUT [ _SplusNVRAM.X] = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 345;
                                OUTPUT_GAIN_FB__DOLLAR__ [ _SplusNVRAM.STATEVARRECEIVE]  .Value = (ushort) ( _SplusNVRAM.VOLUMEOUTPUT[ _SplusNVRAM.X ] ) ; 
                                } 
                            
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 349;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 318;
                } 
            
            __context__.SourceCodeLine = 353;
            _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 374;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 375;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 376;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)48; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 378;
            _SplusNVRAM.XOKGAIN [ I] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 376;
            } 
        
        __context__.SourceCodeLine = 380;
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
    _SplusNVRAM.VOLUMEOUTPUT  = new ushort[ 49 ];
    _SplusNVRAM.XOKGAIN  = new ushort[ 49 ];
    _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    _SplusNVRAM.TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    OUTPUT_MUTE__DOLLAR__ = new InOutArray<DigitalInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        OUTPUT_MUTE__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( OUTPUT_MUTE__DOLLAR____DigitalInput__ + i, OUTPUT_MUTE__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( OUTPUT_MUTE__DOLLAR____DigitalInput__ + i, OUTPUT_MUTE__DOLLAR__[i+1] );
    }
    
    OUTPUT_MUTE_FB__DOLLAR__ = new InOutArray<DigitalOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        OUTPUT_MUTE_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( OUTPUT_MUTE_FB__DOLLAR____DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( OUTPUT_MUTE_FB__DOLLAR____DigitalOutput__ + i, OUTPUT_MUTE_FB__DOLLAR__[i+1] );
    }
    
    INPUT__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( INPUT__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( INPUT__DOLLAR____AnalogSerialInput__, INPUT__DOLLAR__ );
    
    OUTPUT_GAIN__DOLLAR__ = new InOutArray<AnalogInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        OUTPUT_GAIN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( OUTPUT_GAIN__DOLLAR____AnalogSerialInput__ + i, OUTPUT_GAIN__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( OUTPUT_GAIN__DOLLAR____AnalogSerialInput__ + i, OUTPUT_GAIN__DOLLAR__[i+1] );
    }
    
    OUTPUT_GAIN_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        OUTPUT_GAIN_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( OUTPUT_GAIN_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( OUTPUT_GAIN_FB__DOLLAR____AnalogSerialOutput__ + i, OUTPUT_GAIN_FB__DOLLAR__[i+1] );
    }
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    IMAXOUTPUT = new UShortParameter( IMAXOUTPUT__Parameter__, this );
    m_ParameterList.Add( IMAXOUTPUT__Parameter__, IMAXOUTPUT );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    for( uint i = 0; i < 48; i++ )
        OUTPUT_MUTE__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( OUTPUT_MUTE__DOLLAR___OnPush_0, false ) );
        
    for( uint i = 0; i < 48; i++ )
        OUTPUT_MUTE__DOLLAR__[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( OUTPUT_MUTE__DOLLAR___OnRelease_1, false ) );
        
    for( uint i = 0; i < 48; i++ )
        OUTPUT_GAIN__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( OUTPUT_GAIN__DOLLAR___OnChange_2, false ) );
        
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_3, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_4, false ) );
    INPUT__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( INPUT__DOLLAR___OnChange_5, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_MATRIX_MIXER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 0;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 1;
const uint OUTPUT_MUTE__DOLLAR____DigitalInput__ = 2;
const uint INPUT__DOLLAR____AnalogSerialInput__ = 0;
const uint RX__DOLLAR____AnalogSerialInput__ = 1;
const uint OUTPUT_GAIN__DOLLAR____AnalogSerialInput__ = 2;
const uint OUTPUT_MUTE_FB__DOLLAR____DigitalOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint OUTPUT_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint OBJECTID__DOLLAR____Parameter__ = 10;
const uint IMAXOUTPUT__Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort [] VOLUMEOUTPUT;
            [SplusStructAttribute(2, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort INPUT = 0;
            [SplusStructAttribute(4, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(5, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort SUBSCRIBE = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort [] XOKGAIN;
            [SplusStructAttribute(9, false, true)]
            public ushort XOKSUBSCRIBE = 0;
            [SplusStructAttribute(10, false, true)]
            public CrestronString TEMPSTRING;
            [SplusStructAttribute(11, false, true)]
            public ushort STATEVARONOFF = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort STATEVARGAIN = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort STATEVARSUB = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort STATEVARRECEIVE = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort X = 0;
            
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
