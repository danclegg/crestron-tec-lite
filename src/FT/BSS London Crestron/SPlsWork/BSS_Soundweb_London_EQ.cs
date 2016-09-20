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

namespace UserModule_BSS_SOUNDWEB_LONDON_EQ
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_EQ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BYPASS_ON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BYPASS_OFF__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput INPUT__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput BOOSTPERCENT__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput WIDTH__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput FREQUENCY__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput TYPE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput SLOPE__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput BYPASS_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput BOOSTPERCENT_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput WIDTH_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput FREQUENCY_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput TYPE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput SLOPE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput BOOSTSTRING_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput WIDTHSTRING_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput FREQUENCYSTRING_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TYPESTRING_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SLOPESTRING_FB__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
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
            
            
            __context__.SourceCodeLine = 177;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 178;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 179;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 182;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 184;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 186;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        private ushort VOLUMEPERCENTROUND (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            
            __context__.SourceCodeLine = 189;
            _SplusNVRAM.ROUNDPART = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 190;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.ROUNDPART > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 191;
                _SplusNVRAM.RETURNI = (ushort) ( (Byte( STR , (int)( 2 ) ) + 1) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 194;
                _SplusNVRAM.RETURNI = (ushort) ( Byte( STR , (int)( 2 ) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 196;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object BOOSTPERCENT__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 207;
                _SplusNVRAM.STATEVARBOOST = (ushort) ( (2 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 208;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( _SplusNVRAM.XOKBOOST ) && Functions.TestForTrue ( Functions.BoolToInt (BOOSTPERCENT_FB__DOLLAR__  .Value != BOOSTPERCENT__DOLLAR__  .UshortValue) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( BOOSTPERCENT__DOLLAR__  .UshortValue >= 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( BOOSTPERCENT__DOLLAR__  .UshortValue < 101 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 210;
                    _SplusNVRAM.XOKBOOST = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 211;
                    MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}\u0000{3}\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARBOOST ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARBOOST ) ) ) , Functions.Chr (  (int) ( BOOSTPERCENT__DOLLAR__  .UshortValue ) ) ) ; 
                    __context__.SourceCodeLine = 212;
                    BOOSTPERCENT_FB__DOLLAR__  .Value = (ushort) ( BOOSTPERCENT__DOLLAR__  .UshortValue ) ; 
                    __context__.SourceCodeLine = 213;
                    BOOSTSTRING_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.BOOSTSTRING [ (BOOSTPERCENT__DOLLAR__  .UshortValue + 1) ]  ) ; 
                    __context__.SourceCodeLine = 214;
                    _SplusNVRAM.XOKBOOST = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object WIDTH__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 218;
            _SplusNVRAM.STATEVARWIDTH = (ushort) ( (3 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
            __context__.SourceCodeLine = 219;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (WIDTH_FB__DOLLAR__  .Value != WIDTH__DOLLAR__  .UshortValue) ) && Functions.TestForTrue ( Functions.BoolToInt ( WIDTH__DOLLAR__  .UshortValue >= 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( WIDTH__DOLLAR__  .UshortValue < 101 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 220;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}\u0000{3}\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARWIDTH ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARWIDTH ) ) ) , Functions.Chr (  (int) ( WIDTH__DOLLAR__  .UshortValue ) ) ) ; 
                __context__.SourceCodeLine = 221;
                WIDTH_FB__DOLLAR__  .Value = (ushort) ( WIDTH__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 222;
                WIDTHSTRING_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.WIDTHSTRING [ (WIDTH__DOLLAR__  .UshortValue + 1) ]  ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object FREQUENCY__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 226;
        _SplusNVRAM.STATEVARFREQUENCY = (ushort) ( (1 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
        __context__.SourceCodeLine = 227;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (FREQUENCY_FB__DOLLAR__  .Value != FREQUENCY__DOLLAR__  .UshortValue) ) && Functions.TestForTrue ( Functions.BoolToInt ( FREQUENCY__DOLLAR__  .UshortValue >= 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( FREQUENCY__DOLLAR__  .UshortValue < 101 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 228;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}\u0000{3}\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARFREQUENCY ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARFREQUENCY ) ) ) , Functions.Chr (  (int) ( FREQUENCY__DOLLAR__  .UshortValue ) ) ) ; 
            __context__.SourceCodeLine = 229;
            FREQUENCY_FB__DOLLAR__  .Value = (ushort) ( FREQUENCY__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 230;
            FREQUENCYSTRING_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.FREQUENCYSTRING [ (FREQUENCY__DOLLAR__  .UshortValue + 1) ]  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TYPE__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 235;
        _SplusNVRAM.STATEVARTYPE = (ushort) ( (4 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
        __context__.SourceCodeLine = 236;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( TYPE__DOLLAR__  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( TYPE__DOLLAR__  .UshortValue < 3 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 237;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARTYPE ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARTYPE ) ) ) , Functions.Chr (  (int) ( TYPE__DOLLAR__  .UshortValue ) ) ) ; 
            __context__.SourceCodeLine = 239;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 241;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARTYPE ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARTYPE ) ) ) ) ; 
                __context__.SourceCodeLine = 242;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SLOPE__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 248;
        _SplusNVRAM.STATEVARSLOPE = (ushort) ( (6 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
        __context__.SourceCodeLine = 249;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( SLOPE__DOLLAR__  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( SLOPE__DOLLAR__  .UshortValue < 4 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 250;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSLOPE ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSLOPE ) ) ) , Functions.Chr (  (int) ( SLOPE__DOLLAR__  .UshortValue ) ) ) ; 
            __context__.SourceCodeLine = 252;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 254;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSLOPE ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSLOPE ) ) ) ) ; 
                __context__.SourceCodeLine = 255;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYPASS_ON__DOLLAR___OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 260;
        _SplusNVRAM.STATEVARBYPASS = (ushort) ( (16 * (_SplusNVRAM.INPUT - 1)) ) ; 
        __context__.SourceCodeLine = 261;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) ) ; 
        __context__.SourceCodeLine = 263;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 265;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) ) ; 
            __context__.SourceCodeLine = 266;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BYPASS_OFF__DOLLAR___OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 270;
        _SplusNVRAM.STATEVARBYPASS = (ushort) ( (16 * (_SplusNVRAM.INPUT - 1)) ) ; 
        __context__.SourceCodeLine = 271;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) ) ; 
        __context__.SourceCodeLine = 273;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 275;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARBYPASS ) ) ) ) ; 
            __context__.SourceCodeLine = 276;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUBSCRIBE__DOLLAR___OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 283;
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
        
            
            __context__.SourceCodeLine = 285;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 287;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 288;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (1 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 289;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 290;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 291;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (2 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 292;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 293;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 294;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (3 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 295;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 296;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 297;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (4 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 298;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 299;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 300;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (6 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
                __context__.SourceCodeLine = 301;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 302;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 303;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (16 * (_SplusNVRAM.INPUT - 1)) ) ; 
                __context__.SourceCodeLine = 304;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 305;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 306;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 307;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object UNSUBSCRIBE__DOLLAR___OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 318;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 320;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 321;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (1 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
            __context__.SourceCodeLine = 322;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 323;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 324;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (2 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
            __context__.SourceCodeLine = 325;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 326;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 327;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (3 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
            __context__.SourceCodeLine = 328;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 329;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 330;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (4 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
            __context__.SourceCodeLine = 331;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 332;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 333;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (6 + (16 * (_SplusNVRAM.INPUT - 1))) ) ; 
            __context__.SourceCodeLine = 334;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 335;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 336;
            _SplusNVRAM.STATEVARSUB = (ushort) ( (16 * (_SplusNVRAM.INPUT - 1)) ) ; 
            __context__.SourceCodeLine = 337;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 338;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 339;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 340;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT__DOLLAR___OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 347;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INPUT__DOLLAR__  .UshortValue > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 348;
            _SplusNVRAM.INPUT = (ushort) ( INPUT__DOLLAR__  .UshortValue ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 351;
            _SplusNVRAM.INPUT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 352;
            Print( "\r\nerror input for the EQ cannot be 0. set to default of 1") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 366;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 368;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 369;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 371;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 373;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 374;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 376;
                        _SplusNVRAM.ICASE = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 377;
                        
                            {
                            int __SPLS_TMPVAR__SWTCH_1__ = ((int)_SplusNVRAM.ICASE);
                            
                                { 
                                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( (16 * (_SplusNVRAM.INPUT - 1))) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 381;
                                    BYPASS_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    } 
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( (1 + (16 * (_SplusNVRAM.INPUT - 1)))) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 385;
                                    _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTROUND( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 387;
                                    FREQUENCY_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                    __context__.SourceCodeLine = 388;
                                    FREQUENCYSTRING_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.FREQUENCYSTRING [ (_SplusNVRAM.VOLUMEINPUT + 1) ]  ) ; 
                                    } 
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( (2 + (16 * (_SplusNVRAM.INPUT - 1)))) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 392;
                                    _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTROUND( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 393;
                                    BOOSTPERCENT_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                    __context__.SourceCodeLine = 394;
                                    BOOSTSTRING_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.FREQUENCYSTRING [ (_SplusNVRAM.VOLUMEINPUT + 1) ]  ) ; 
                                    } 
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( (3 + (16 * (_SplusNVRAM.INPUT - 1)))) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 398;
                                    _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTROUND( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 399;
                                    WIDTH_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                    __context__.SourceCodeLine = 400;
                                    WIDTHSTRING_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.WIDTHSTRING [ (_SplusNVRAM.VOLUMEINPUT + 1) ]  ) ; 
                                    } 
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( (4 + (16 * (_SplusNVRAM.INPUT - 1)))) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 404;
                                    _SplusNVRAM.VALUE = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    __context__.SourceCodeLine = 405;
                                    TYPE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VALUE ) ; 
                                    __context__.SourceCodeLine = 406;
                                    
                                        {
                                        int __SPLS_TMPVAR__SWTCH_2__ = ((int)_SplusNVRAM.VALUE);
                                        
                                            { 
                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 0) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 408;
                                                TYPESTRING_FB__DOLLAR__  .UpdateValue ( "Bell"  ) ; 
                                                } 
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 411;
                                                TYPESTRING_FB__DOLLAR__  .UpdateValue ( "Low Shelf"  ) ; 
                                                } 
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 414;
                                                TYPESTRING_FB__DOLLAR__  .UpdateValue ( "High Shelf"  ) ; 
                                                } 
                                            
                                            } 
                                            
                                        }
                                        
                                    
                                    __context__.SourceCodeLine = 417;
                                    break ; 
                                    } 
                                
                                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( (6 + (16 * (_SplusNVRAM.INPUT - 1)))) ) ) ) 
                                    { 
                                    __context__.SourceCodeLine = 422;
                                    _SplusNVRAM.VALUE = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    __context__.SourceCodeLine = 423;
                                    SLOPE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VALUE ) ; 
                                    __context__.SourceCodeLine = 424;
                                    
                                        {
                                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)_SplusNVRAM.VALUE);
                                        
                                            { 
                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 0) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 426;
                                                SLOPESTRING_FB__DOLLAR__  .UpdateValue ( "6dB/Oct"  ) ; 
                                                } 
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 429;
                                                SLOPESTRING_FB__DOLLAR__  .UpdateValue ( "9dB/Oct"  ) ; 
                                                } 
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 432;
                                                SLOPESTRING_FB__DOLLAR__  .UpdateValue ( "12dB/Oct"  ) ; 
                                                } 
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                                                { 
                                                __context__.SourceCodeLine = 435;
                                                SLOPESTRING_FB__DOLLAR__  .UpdateValue ( "15dB/Oct"  ) ; 
                                                } 
                                            
                                            } 
                                            
                                        }
                                        
                                    
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 439;
                                    Print( "\r\ndefault {0:d}", (ushort)Functions.Length( _SplusNVRAM.TEMPSTRING )) ; 
                                    }
                                
                                } 
                                
                            }
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 442;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 369;
                } 
            
            __context__.SourceCodeLine = 445;
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
        
        __context__.SourceCodeLine = 465;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 466;
        _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 467;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 468;
        _SplusNVRAM.XOKBOOST = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 469;
        _SplusNVRAM.INPUT = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 473;
        _SplusNVRAM.BOOSTSTRING [ 1 ]  .UpdateValue ( "Notch"  ) ; 
        __context__.SourceCodeLine = 474;
        _SplusNVRAM.BOOSTSTRING [ 2 ]  .UpdateValue ( "-14.7 dB"  ) ; 
        __context__.SourceCodeLine = 475;
        _SplusNVRAM.BOOSTSTRING [ 3 ]  .UpdateValue ( "-14.4 dB"  ) ; 
        __context__.SourceCodeLine = 476;
        _SplusNVRAM.BOOSTSTRING [ 4 ]  .UpdateValue ( "-14.1 dB"  ) ; 
        __context__.SourceCodeLine = 477;
        _SplusNVRAM.BOOSTSTRING [ 5 ]  .UpdateValue ( "-13.8 dB"  ) ; 
        __context__.SourceCodeLine = 478;
        _SplusNVRAM.BOOSTSTRING [ 6 ]  .UpdateValue ( "-13.5 dB"  ) ; 
        __context__.SourceCodeLine = 479;
        _SplusNVRAM.BOOSTSTRING [ 7 ]  .UpdateValue ( "-13.2 dB"  ) ; 
        __context__.SourceCodeLine = 480;
        _SplusNVRAM.BOOSTSTRING [ 8 ]  .UpdateValue ( "-12.9 dB"  ) ; 
        __context__.SourceCodeLine = 481;
        _SplusNVRAM.BOOSTSTRING [ 9 ]  .UpdateValue ( "-12.6 dB"  ) ; 
        __context__.SourceCodeLine = 482;
        _SplusNVRAM.BOOSTSTRING [ 10 ]  .UpdateValue ( "-12.3 dB"  ) ; 
        __context__.SourceCodeLine = 483;
        _SplusNVRAM.BOOSTSTRING [ 11 ]  .UpdateValue ( "-12.0 dB"  ) ; 
        __context__.SourceCodeLine = 484;
        _SplusNVRAM.BOOSTSTRING [ 12 ]  .UpdateValue ( "-11.7 dB"  ) ; 
        __context__.SourceCodeLine = 485;
        _SplusNVRAM.BOOSTSTRING [ 13 ]  .UpdateValue ( "-11.4 dB"  ) ; 
        __context__.SourceCodeLine = 486;
        _SplusNVRAM.BOOSTSTRING [ 14 ]  .UpdateValue ( "-11.1 dB"  ) ; 
        __context__.SourceCodeLine = 487;
        _SplusNVRAM.BOOSTSTRING [ 15 ]  .UpdateValue ( "-10.8 dB"  ) ; 
        __context__.SourceCodeLine = 488;
        _SplusNVRAM.BOOSTSTRING [ 16 ]  .UpdateValue ( "-10.5 dB"  ) ; 
        __context__.SourceCodeLine = 489;
        _SplusNVRAM.BOOSTSTRING [ 17 ]  .UpdateValue ( "-10.2 dB"  ) ; 
        __context__.SourceCodeLine = 490;
        _SplusNVRAM.BOOSTSTRING [ 18 ]  .UpdateValue ( "-9.9 dB"  ) ; 
        __context__.SourceCodeLine = 491;
        _SplusNVRAM.BOOSTSTRING [ 19 ]  .UpdateValue ( "-9.6 dB"  ) ; 
        __context__.SourceCodeLine = 492;
        _SplusNVRAM.BOOSTSTRING [ 20 ]  .UpdateValue ( "-9.3 dB"  ) ; 
        __context__.SourceCodeLine = 493;
        _SplusNVRAM.BOOSTSTRING [ 21 ]  .UpdateValue ( "-9.0 dB"  ) ; 
        __context__.SourceCodeLine = 494;
        _SplusNVRAM.BOOSTSTRING [ 22 ]  .UpdateValue ( "-8.7 dB"  ) ; 
        __context__.SourceCodeLine = 495;
        _SplusNVRAM.BOOSTSTRING [ 23 ]  .UpdateValue ( "-8.4 dB"  ) ; 
        __context__.SourceCodeLine = 496;
        _SplusNVRAM.BOOSTSTRING [ 24 ]  .UpdateValue ( "-8.1 dB"  ) ; 
        __context__.SourceCodeLine = 497;
        _SplusNVRAM.BOOSTSTRING [ 25 ]  .UpdateValue ( "-7.8 dB"  ) ; 
        __context__.SourceCodeLine = 498;
        _SplusNVRAM.BOOSTSTRING [ 26 ]  .UpdateValue ( "-7.5 dB"  ) ; 
        __context__.SourceCodeLine = 499;
        _SplusNVRAM.BOOSTSTRING [ 27 ]  .UpdateValue ( "-7.2 dB"  ) ; 
        __context__.SourceCodeLine = 500;
        _SplusNVRAM.BOOSTSTRING [ 28 ]  .UpdateValue ( "-6.9 dB"  ) ; 
        __context__.SourceCodeLine = 501;
        _SplusNVRAM.BOOSTSTRING [ 29 ]  .UpdateValue ( "-6.6 dB"  ) ; 
        __context__.SourceCodeLine = 502;
        _SplusNVRAM.BOOSTSTRING [ 30 ]  .UpdateValue ( "-6.3 dB"  ) ; 
        __context__.SourceCodeLine = 503;
        _SplusNVRAM.BOOSTSTRING [ 31 ]  .UpdateValue ( "-6.0 dB"  ) ; 
        __context__.SourceCodeLine = 504;
        _SplusNVRAM.BOOSTSTRING [ 32 ]  .UpdateValue ( "-5.7 dB"  ) ; 
        __context__.SourceCodeLine = 505;
        _SplusNVRAM.BOOSTSTRING [ 33 ]  .UpdateValue ( "-5.4 dB"  ) ; 
        __context__.SourceCodeLine = 506;
        _SplusNVRAM.BOOSTSTRING [ 34 ]  .UpdateValue ( "-5.1 dB"  ) ; 
        __context__.SourceCodeLine = 507;
        _SplusNVRAM.BOOSTSTRING [ 35 ]  .UpdateValue ( "-4.8 dB"  ) ; 
        __context__.SourceCodeLine = 508;
        _SplusNVRAM.BOOSTSTRING [ 36 ]  .UpdateValue ( "-4.5 dB"  ) ; 
        __context__.SourceCodeLine = 509;
        _SplusNVRAM.BOOSTSTRING [ 37 ]  .UpdateValue ( "-4.2 dB"  ) ; 
        __context__.SourceCodeLine = 510;
        _SplusNVRAM.BOOSTSTRING [ 38 ]  .UpdateValue ( "-3.9 dB"  ) ; 
        __context__.SourceCodeLine = 511;
        _SplusNVRAM.BOOSTSTRING [ 39 ]  .UpdateValue ( "-3.6 dB"  ) ; 
        __context__.SourceCodeLine = 512;
        _SplusNVRAM.BOOSTSTRING [ 40 ]  .UpdateValue ( "-3.3 dB"  ) ; 
        __context__.SourceCodeLine = 513;
        _SplusNVRAM.BOOSTSTRING [ 41 ]  .UpdateValue ( "-3.0 dB"  ) ; 
        __context__.SourceCodeLine = 514;
        _SplusNVRAM.BOOSTSTRING [ 42 ]  .UpdateValue ( "-2.7 dB"  ) ; 
        __context__.SourceCodeLine = 515;
        _SplusNVRAM.BOOSTSTRING [ 43 ]  .UpdateValue ( "-2.4 dB"  ) ; 
        __context__.SourceCodeLine = 516;
        _SplusNVRAM.BOOSTSTRING [ 44 ]  .UpdateValue ( "-2.1 dB"  ) ; 
        __context__.SourceCodeLine = 517;
        _SplusNVRAM.BOOSTSTRING [ 45 ]  .UpdateValue ( "-1.8 dB"  ) ; 
        __context__.SourceCodeLine = 518;
        _SplusNVRAM.BOOSTSTRING [ 46 ]  .UpdateValue ( "-1.5 dB"  ) ; 
        __context__.SourceCodeLine = 519;
        _SplusNVRAM.BOOSTSTRING [ 47 ]  .UpdateValue ( "-1.2 dB"  ) ; 
        __context__.SourceCodeLine = 520;
        _SplusNVRAM.BOOSTSTRING [ 48 ]  .UpdateValue ( "-.9 dB"  ) ; 
        __context__.SourceCodeLine = 521;
        _SplusNVRAM.BOOSTSTRING [ 49 ]  .UpdateValue ( "-.6 dB"  ) ; 
        __context__.SourceCodeLine = 522;
        _SplusNVRAM.BOOSTSTRING [ 50 ]  .UpdateValue ( "-.3 dB"  ) ; 
        __context__.SourceCodeLine = 523;
        _SplusNVRAM.BOOSTSTRING [ 51 ]  .UpdateValue ( "0 dB"  ) ; 
        __context__.SourceCodeLine = 524;
        _SplusNVRAM.BOOSTSTRING [ 52 ]  .UpdateValue ( ".3 dB"  ) ; 
        __context__.SourceCodeLine = 525;
        _SplusNVRAM.BOOSTSTRING [ 53 ]  .UpdateValue ( ".6 dB"  ) ; 
        __context__.SourceCodeLine = 526;
        _SplusNVRAM.BOOSTSTRING [ 54 ]  .UpdateValue ( ".9 dB"  ) ; 
        __context__.SourceCodeLine = 527;
        _SplusNVRAM.BOOSTSTRING [ 55 ]  .UpdateValue ( "1.2 dB"  ) ; 
        __context__.SourceCodeLine = 528;
        _SplusNVRAM.BOOSTSTRING [ 56 ]  .UpdateValue ( "1.5 dB"  ) ; 
        __context__.SourceCodeLine = 529;
        _SplusNVRAM.BOOSTSTRING [ 57 ]  .UpdateValue ( "1.8 dB"  ) ; 
        __context__.SourceCodeLine = 530;
        _SplusNVRAM.BOOSTSTRING [ 58 ]  .UpdateValue ( "2.1 dB"  ) ; 
        __context__.SourceCodeLine = 531;
        _SplusNVRAM.BOOSTSTRING [ 59 ]  .UpdateValue ( "2.4 dB"  ) ; 
        __context__.SourceCodeLine = 532;
        _SplusNVRAM.BOOSTSTRING [ 60 ]  .UpdateValue ( "2.7 dB"  ) ; 
        __context__.SourceCodeLine = 533;
        _SplusNVRAM.BOOSTSTRING [ 61 ]  .UpdateValue ( "3.0 dB"  ) ; 
        __context__.SourceCodeLine = 534;
        _SplusNVRAM.BOOSTSTRING [ 62 ]  .UpdateValue ( "3.3 dB"  ) ; 
        __context__.SourceCodeLine = 535;
        _SplusNVRAM.BOOSTSTRING [ 63 ]  .UpdateValue ( "3.6 dB"  ) ; 
        __context__.SourceCodeLine = 536;
        _SplusNVRAM.BOOSTSTRING [ 64 ]  .UpdateValue ( "3.9 dB"  ) ; 
        __context__.SourceCodeLine = 537;
        _SplusNVRAM.BOOSTSTRING [ 65 ]  .UpdateValue ( "4.2 dB"  ) ; 
        __context__.SourceCodeLine = 538;
        _SplusNVRAM.BOOSTSTRING [ 66 ]  .UpdateValue ( "4.5 dB"  ) ; 
        __context__.SourceCodeLine = 539;
        _SplusNVRAM.BOOSTSTRING [ 67 ]  .UpdateValue ( "4.8 dB"  ) ; 
        __context__.SourceCodeLine = 540;
        _SplusNVRAM.BOOSTSTRING [ 68 ]  .UpdateValue ( "5.1 dB"  ) ; 
        __context__.SourceCodeLine = 541;
        _SplusNVRAM.BOOSTSTRING [ 69 ]  .UpdateValue ( "5.4 dB"  ) ; 
        __context__.SourceCodeLine = 542;
        _SplusNVRAM.BOOSTSTRING [ 70 ]  .UpdateValue ( "5.7 dB"  ) ; 
        __context__.SourceCodeLine = 543;
        _SplusNVRAM.BOOSTSTRING [ 71 ]  .UpdateValue ( "6.0 dB"  ) ; 
        __context__.SourceCodeLine = 544;
        _SplusNVRAM.BOOSTSTRING [ 72 ]  .UpdateValue ( "6.3 dB"  ) ; 
        __context__.SourceCodeLine = 545;
        _SplusNVRAM.BOOSTSTRING [ 73 ]  .UpdateValue ( "6.6 dB"  ) ; 
        __context__.SourceCodeLine = 546;
        _SplusNVRAM.BOOSTSTRING [ 74 ]  .UpdateValue ( "6.9 dB"  ) ; 
        __context__.SourceCodeLine = 547;
        _SplusNVRAM.BOOSTSTRING [ 75 ]  .UpdateValue ( "7.2 dB"  ) ; 
        __context__.SourceCodeLine = 548;
        _SplusNVRAM.BOOSTSTRING [ 76 ]  .UpdateValue ( "7.5 dB"  ) ; 
        __context__.SourceCodeLine = 549;
        _SplusNVRAM.BOOSTSTRING [ 77 ]  .UpdateValue ( "7.8 dB"  ) ; 
        __context__.SourceCodeLine = 550;
        _SplusNVRAM.BOOSTSTRING [ 78 ]  .UpdateValue ( "8.1 dB"  ) ; 
        __context__.SourceCodeLine = 551;
        _SplusNVRAM.BOOSTSTRING [ 79 ]  .UpdateValue ( "8.4 dB"  ) ; 
        __context__.SourceCodeLine = 552;
        _SplusNVRAM.BOOSTSTRING [ 80 ]  .UpdateValue ( "8.7 dB"  ) ; 
        __context__.SourceCodeLine = 553;
        _SplusNVRAM.BOOSTSTRING [ 81 ]  .UpdateValue ( "9.0 dB"  ) ; 
        __context__.SourceCodeLine = 554;
        _SplusNVRAM.BOOSTSTRING [ 82 ]  .UpdateValue ( "9.3 dB"  ) ; 
        __context__.SourceCodeLine = 555;
        _SplusNVRAM.BOOSTSTRING [ 83 ]  .UpdateValue ( "9.6 dB"  ) ; 
        __context__.SourceCodeLine = 556;
        _SplusNVRAM.BOOSTSTRING [ 84 ]  .UpdateValue ( "9.9 dB"  ) ; 
        __context__.SourceCodeLine = 557;
        _SplusNVRAM.BOOSTSTRING [ 85 ]  .UpdateValue ( "10.2 dB"  ) ; 
        __context__.SourceCodeLine = 558;
        _SplusNVRAM.BOOSTSTRING [ 86 ]  .UpdateValue ( "10.5 dB"  ) ; 
        __context__.SourceCodeLine = 559;
        _SplusNVRAM.BOOSTSTRING [ 87 ]  .UpdateValue ( "10.8 dB"  ) ; 
        __context__.SourceCodeLine = 560;
        _SplusNVRAM.BOOSTSTRING [ 88 ]  .UpdateValue ( "11.1 dB"  ) ; 
        __context__.SourceCodeLine = 561;
        _SplusNVRAM.BOOSTSTRING [ 89 ]  .UpdateValue ( "11.4 dB"  ) ; 
        __context__.SourceCodeLine = 562;
        _SplusNVRAM.BOOSTSTRING [ 90 ]  .UpdateValue ( "11.7 dB"  ) ; 
        __context__.SourceCodeLine = 563;
        _SplusNVRAM.BOOSTSTRING [ 91 ]  .UpdateValue ( "12.0 dB"  ) ; 
        __context__.SourceCodeLine = 564;
        _SplusNVRAM.BOOSTSTRING [ 92 ]  .UpdateValue ( "12.3 dB"  ) ; 
        __context__.SourceCodeLine = 565;
        _SplusNVRAM.BOOSTSTRING [ 93 ]  .UpdateValue ( "12.6 dB"  ) ; 
        __context__.SourceCodeLine = 566;
        _SplusNVRAM.BOOSTSTRING [ 94 ]  .UpdateValue ( "12.9 dB"  ) ; 
        __context__.SourceCodeLine = 567;
        _SplusNVRAM.BOOSTSTRING [ 95 ]  .UpdateValue ( "13.2 dB"  ) ; 
        __context__.SourceCodeLine = 568;
        _SplusNVRAM.BOOSTSTRING [ 96 ]  .UpdateValue ( "13.5 dB"  ) ; 
        __context__.SourceCodeLine = 569;
        _SplusNVRAM.BOOSTSTRING [ 97 ]  .UpdateValue ( "13.8 dB"  ) ; 
        __context__.SourceCodeLine = 570;
        _SplusNVRAM.BOOSTSTRING [ 98 ]  .UpdateValue ( "14.1 dB"  ) ; 
        __context__.SourceCodeLine = 571;
        _SplusNVRAM.BOOSTSTRING [ 99 ]  .UpdateValue ( "14.4 dB"  ) ; 
        __context__.SourceCodeLine = 572;
        _SplusNVRAM.BOOSTSTRING [ 100 ]  .UpdateValue ( "14.7 dB"  ) ; 
        __context__.SourceCodeLine = 573;
        _SplusNVRAM.BOOSTSTRING [ 101 ]  .UpdateValue ( "15.0 dB"  ) ; 
        __context__.SourceCodeLine = 576;
        _SplusNVRAM.WIDTH [ 1] = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 577;
        _SplusNVRAM.WIDTH [ 2] = (ushort) ( 328 ) ; 
        __context__.SourceCodeLine = 578;
        _SplusNVRAM.WIDTH [ 3] = (ushort) ( 983 ) ; 
        __context__.SourceCodeLine = 579;
        _SplusNVRAM.WIDTH [ 4] = (ushort) ( 1683 ) ; 
        __context__.SourceCodeLine = 580;
        _SplusNVRAM.WIDTH [ 5] = (ushort) ( 2293 ) ; 
        __context__.SourceCodeLine = 581;
        _SplusNVRAM.WIDTH [ 6] = (ushort) ( 2949 ) ; 
        __context__.SourceCodeLine = 582;
        _SplusNVRAM.WIDTH [ 7] = (ushort) ( 3604 ) ; 
        __context__.SourceCodeLine = 583;
        _SplusNVRAM.WIDTH [ 8] = (ushort) ( 4259 ) ; 
        __context__.SourceCodeLine = 584;
        _SplusNVRAM.WIDTH [ 9] = (ushort) ( 4915 ) ; 
        __context__.SourceCodeLine = 585;
        _SplusNVRAM.WIDTH [ 10] = (ushort) ( 5570 ) ; 
        __context__.SourceCodeLine = 586;
        _SplusNVRAM.WIDTH [ 11] = (ushort) ( 6225 ) ; 
        __context__.SourceCodeLine = 587;
        _SplusNVRAM.WIDTH [ 12] = (ushort) ( 6881 ) ; 
        __context__.SourceCodeLine = 588;
        _SplusNVRAM.WIDTH [ 13] = (ushort) ( 7536 ) ; 
        __context__.SourceCodeLine = 589;
        _SplusNVRAM.WIDTH [ 14] = (ushort) ( 8191 ) ; 
        __context__.SourceCodeLine = 590;
        _SplusNVRAM.WIDTH [ 15] = (ushort) ( 8847 ) ; 
        __context__.SourceCodeLine = 591;
        _SplusNVRAM.WIDTH [ 16] = (ushort) ( 9502 ) ; 
        __context__.SourceCodeLine = 592;
        _SplusNVRAM.WIDTH [ 17] = (ushort) ( 10157 ) ; 
        __context__.SourceCodeLine = 593;
        _SplusNVRAM.WIDTH [ 18] = (ushort) ( 10813 ) ; 
        __context__.SourceCodeLine = 594;
        _SplusNVRAM.WIDTH [ 19] = (ushort) ( 11468 ) ; 
        __context__.SourceCodeLine = 595;
        _SplusNVRAM.WIDTH [ 20] = (ushort) ( 12123 ) ; 
        __context__.SourceCodeLine = 596;
        _SplusNVRAM.WIDTH [ 21] = (ushort) ( 12779 ) ; 
        __context__.SourceCodeLine = 597;
        _SplusNVRAM.WIDTH [ 22] = (ushort) ( 13434 ) ; 
        __context__.SourceCodeLine = 598;
        _SplusNVRAM.WIDTH [ 23] = (ushort) ( 14090 ) ; 
        __context__.SourceCodeLine = 599;
        _SplusNVRAM.WIDTH [ 24] = (ushort) ( 14745 ) ; 
        __context__.SourceCodeLine = 600;
        _SplusNVRAM.WIDTH [ 25] = (ushort) ( 15400 ) ; 
        __context__.SourceCodeLine = 601;
        _SplusNVRAM.WIDTH [ 26] = (ushort) ( 16056 ) ; 
        __context__.SourceCodeLine = 602;
        _SplusNVRAM.WIDTH [ 27] = (ushort) ( 16711 ) ; 
        __context__.SourceCodeLine = 603;
        _SplusNVRAM.WIDTH [ 28] = (ushort) ( 17366 ) ; 
        __context__.SourceCodeLine = 604;
        _SplusNVRAM.WIDTH [ 29] = (ushort) ( 18022 ) ; 
        __context__.SourceCodeLine = 605;
        _SplusNVRAM.WIDTH [ 30] = (ushort) ( 18677 ) ; 
        __context__.SourceCodeLine = 606;
        _SplusNVRAM.WIDTH [ 31] = (ushort) ( 19332 ) ; 
        __context__.SourceCodeLine = 607;
        _SplusNVRAM.WIDTH [ 32] = (ushort) ( 19988 ) ; 
        __context__.SourceCodeLine = 608;
        _SplusNVRAM.WIDTH [ 33] = (ushort) ( 20643 ) ; 
        __context__.SourceCodeLine = 609;
        _SplusNVRAM.WIDTH [ 34] = (ushort) ( 21298 ) ; 
        __context__.SourceCodeLine = 610;
        _SplusNVRAM.WIDTH [ 35] = (ushort) ( 21954 ) ; 
        __context__.SourceCodeLine = 611;
        _SplusNVRAM.WIDTH [ 36] = (ushort) ( 22609 ) ; 
        __context__.SourceCodeLine = 612;
        _SplusNVRAM.WIDTH [ 37] = (ushort) ( 23264 ) ; 
        __context__.SourceCodeLine = 613;
        _SplusNVRAM.WIDTH [ 38] = (ushort) ( 23920 ) ; 
        __context__.SourceCodeLine = 614;
        _SplusNVRAM.WIDTH [ 39] = (ushort) ( 24575 ) ; 
        __context__.SourceCodeLine = 615;
        _SplusNVRAM.WIDTH [ 40] = (ushort) ( 25230 ) ; 
        __context__.SourceCodeLine = 616;
        _SplusNVRAM.WIDTH [ 41] = (ushort) ( 25886 ) ; 
        __context__.SourceCodeLine = 617;
        _SplusNVRAM.WIDTH [ 42] = (ushort) ( 26541 ) ; 
        __context__.SourceCodeLine = 618;
        _SplusNVRAM.WIDTH [ 43] = (ushort) ( 27197 ) ; 
        __context__.SourceCodeLine = 619;
        _SplusNVRAM.WIDTH [ 44] = (ushort) ( 27852 ) ; 
        __context__.SourceCodeLine = 620;
        _SplusNVRAM.WIDTH [ 45] = (ushort) ( 28507 ) ; 
        __context__.SourceCodeLine = 621;
        _SplusNVRAM.WIDTH [ 46] = (ushort) ( 29163 ) ; 
        __context__.SourceCodeLine = 622;
        _SplusNVRAM.WIDTH [ 47] = (ushort) ( 29818 ) ; 
        __context__.SourceCodeLine = 623;
        _SplusNVRAM.WIDTH [ 48] = (ushort) ( 30473 ) ; 
        __context__.SourceCodeLine = 624;
        _SplusNVRAM.WIDTH [ 49] = (ushort) ( 31129 ) ; 
        __context__.SourceCodeLine = 625;
        _SplusNVRAM.WIDTH [ 50] = (ushort) ( 31784 ) ; 
        __context__.SourceCodeLine = 626;
        _SplusNVRAM.WIDTH [ 51] = (ushort) ( 32439 ) ; 
        __context__.SourceCodeLine = 627;
        _SplusNVRAM.WIDTH [ 52] = (ushort) ( 33095 ) ; 
        __context__.SourceCodeLine = 628;
        _SplusNVRAM.WIDTH [ 53] = (ushort) ( 33750 ) ; 
        __context__.SourceCodeLine = 629;
        _SplusNVRAM.WIDTH [ 54] = (ushort) ( 34405 ) ; 
        __context__.SourceCodeLine = 630;
        _SplusNVRAM.WIDTH [ 55] = (ushort) ( 35061 ) ; 
        __context__.SourceCodeLine = 631;
        _SplusNVRAM.WIDTH [ 56] = (ushort) ( 35716 ) ; 
        __context__.SourceCodeLine = 632;
        _SplusNVRAM.WIDTH [ 57] = (ushort) ( 36371 ) ; 
        __context__.SourceCodeLine = 633;
        _SplusNVRAM.WIDTH [ 58] = (ushort) ( 37027 ) ; 
        __context__.SourceCodeLine = 634;
        _SplusNVRAM.WIDTH [ 59] = (ushort) ( 37682 ) ; 
        __context__.SourceCodeLine = 635;
        _SplusNVRAM.WIDTH [ 60] = (ushort) ( 38337 ) ; 
        __context__.SourceCodeLine = 636;
        _SplusNVRAM.WIDTH [ 61] = (ushort) ( 38993 ) ; 
        __context__.SourceCodeLine = 637;
        _SplusNVRAM.WIDTH [ 62] = (ushort) ( 39648 ) ; 
        __context__.SourceCodeLine = 638;
        _SplusNVRAM.WIDTH [ 63] = (ushort) ( 40304 ) ; 
        __context__.SourceCodeLine = 639;
        _SplusNVRAM.WIDTH [ 64] = (ushort) ( 40959 ) ; 
        __context__.SourceCodeLine = 640;
        _SplusNVRAM.WIDTH [ 65] = (ushort) ( 41614 ) ; 
        __context__.SourceCodeLine = 641;
        _SplusNVRAM.WIDTH [ 66] = (ushort) ( 42270 ) ; 
        __context__.SourceCodeLine = 642;
        _SplusNVRAM.WIDTH [ 67] = (ushort) ( 42925 ) ; 
        __context__.SourceCodeLine = 643;
        _SplusNVRAM.WIDTH [ 68] = (ushort) ( 43580 ) ; 
        __context__.SourceCodeLine = 644;
        _SplusNVRAM.WIDTH [ 69] = (ushort) ( 44236 ) ; 
        __context__.SourceCodeLine = 645;
        _SplusNVRAM.WIDTH [ 70] = (ushort) ( 44891 ) ; 
        __context__.SourceCodeLine = 646;
        _SplusNVRAM.WIDTH [ 71] = (ushort) ( 45546 ) ; 
        __context__.SourceCodeLine = 647;
        _SplusNVRAM.WIDTH [ 72] = (ushort) ( 46202 ) ; 
        __context__.SourceCodeLine = 648;
        _SplusNVRAM.WIDTH [ 73] = (ushort) ( 46857 ) ; 
        __context__.SourceCodeLine = 649;
        _SplusNVRAM.WIDTH [ 74] = (ushort) ( 47512 ) ; 
        __context__.SourceCodeLine = 650;
        _SplusNVRAM.WIDTH [ 75] = (ushort) ( 48168 ) ; 
        __context__.SourceCodeLine = 651;
        _SplusNVRAM.WIDTH [ 76] = (ushort) ( 48823 ) ; 
        __context__.SourceCodeLine = 652;
        _SplusNVRAM.WIDTH [ 77] = (ushort) ( 49478 ) ; 
        __context__.SourceCodeLine = 653;
        _SplusNVRAM.WIDTH [ 78] = (ushort) ( 50134 ) ; 
        __context__.SourceCodeLine = 654;
        _SplusNVRAM.WIDTH [ 79] = (ushort) ( 50789 ) ; 
        __context__.SourceCodeLine = 655;
        _SplusNVRAM.WIDTH [ 80] = (ushort) ( 51444 ) ; 
        __context__.SourceCodeLine = 656;
        _SplusNVRAM.WIDTH [ 81] = (ushort) ( 52100 ) ; 
        __context__.SourceCodeLine = 657;
        _SplusNVRAM.WIDTH [ 82] = (ushort) ( 52755 ) ; 
        __context__.SourceCodeLine = 658;
        _SplusNVRAM.WIDTH [ 83] = (ushort) ( 53411 ) ; 
        __context__.SourceCodeLine = 659;
        _SplusNVRAM.WIDTH [ 84] = (ushort) ( 54066 ) ; 
        __context__.SourceCodeLine = 660;
        _SplusNVRAM.WIDTH [ 85] = (ushort) ( 54721 ) ; 
        __context__.SourceCodeLine = 661;
        _SplusNVRAM.WIDTH [ 86] = (ushort) ( 55377 ) ; 
        __context__.SourceCodeLine = 662;
        _SplusNVRAM.WIDTH [ 87] = (ushort) ( 56032 ) ; 
        __context__.SourceCodeLine = 663;
        _SplusNVRAM.WIDTH [ 88] = (ushort) ( 56687 ) ; 
        __context__.SourceCodeLine = 664;
        _SplusNVRAM.WIDTH [ 89] = (ushort) ( 57343 ) ; 
        __context__.SourceCodeLine = 665;
        _SplusNVRAM.WIDTH [ 90] = (ushort) ( 57998 ) ; 
        __context__.SourceCodeLine = 666;
        _SplusNVRAM.WIDTH [ 91] = (ushort) ( 58653 ) ; 
        __context__.SourceCodeLine = 667;
        _SplusNVRAM.WIDTH [ 92] = (ushort) ( 59309 ) ; 
        __context__.SourceCodeLine = 668;
        _SplusNVRAM.WIDTH [ 93] = (ushort) ( 59964 ) ; 
        __context__.SourceCodeLine = 669;
        _SplusNVRAM.WIDTH [ 94] = (ushort) ( 60619 ) ; 
        __context__.SourceCodeLine = 670;
        _SplusNVRAM.WIDTH [ 95] = (ushort) ( 61275 ) ; 
        __context__.SourceCodeLine = 671;
        _SplusNVRAM.WIDTH [ 96] = (ushort) ( 61930 ) ; 
        __context__.SourceCodeLine = 672;
        _SplusNVRAM.WIDTH [ 97] = (ushort) ( 62585 ) ; 
        __context__.SourceCodeLine = 673;
        _SplusNVRAM.WIDTH [ 98] = (ushort) ( 63241 ) ; 
        __context__.SourceCodeLine = 674;
        _SplusNVRAM.WIDTH [ 99] = (ushort) ( 63896 ) ; 
        __context__.SourceCodeLine = 675;
        _SplusNVRAM.WIDTH [ 100] = (ushort) ( 64551 ) ; 
        __context__.SourceCodeLine = 676;
        _SplusNVRAM.WIDTH [ 101] = (ushort) ( 65535 ) ; 
        __context__.SourceCodeLine = 678;
        _SplusNVRAM.WIDTHSTRING [ 1 ]  .UpdateValue ( "0.01"  ) ; 
        __context__.SourceCodeLine = 679;
        _SplusNVRAM.WIDTHSTRING [ 2 ]  .UpdateValue ( "0.05"  ) ; 
        __context__.SourceCodeLine = 680;
        _SplusNVRAM.WIDTHSTRING [ 3 ]  .UpdateValue ( "0.09"  ) ; 
        __context__.SourceCodeLine = 681;
        _SplusNVRAM.WIDTHSTRING [ 4 ]  .UpdateValue ( "0.13"  ) ; 
        __context__.SourceCodeLine = 682;
        _SplusNVRAM.WIDTHSTRING [ 5 ]  .UpdateValue ( "0.17"  ) ; 
        __context__.SourceCodeLine = 683;
        _SplusNVRAM.WIDTHSTRING [ 6 ]  .UpdateValue ( "0.21"  ) ; 
        __context__.SourceCodeLine = 684;
        _SplusNVRAM.WIDTHSTRING [ 7 ]  .UpdateValue ( "0.25"  ) ; 
        __context__.SourceCodeLine = 685;
        _SplusNVRAM.WIDTHSTRING [ 8 ]  .UpdateValue ( "0.29"  ) ; 
        __context__.SourceCodeLine = 686;
        _SplusNVRAM.WIDTHSTRING [ 9 ]  .UpdateValue ( "0.33"  ) ; 
        __context__.SourceCodeLine = 687;
        _SplusNVRAM.WIDTHSTRING [ 10 ]  .UpdateValue ( "0.37"  ) ; 
        __context__.SourceCodeLine = 688;
        _SplusNVRAM.WIDTHSTRING [ 11 ]  .UpdateValue ( "0.41"  ) ; 
        __context__.SourceCodeLine = 689;
        _SplusNVRAM.WIDTHSTRING [ 12 ]  .UpdateValue ( "0.45"  ) ; 
        __context__.SourceCodeLine = 690;
        _SplusNVRAM.WIDTHSTRING [ 13 ]  .UpdateValue ( "0.49"  ) ; 
        __context__.SourceCodeLine = 691;
        _SplusNVRAM.WIDTHSTRING [ 14 ]  .UpdateValue ( "0.53"  ) ; 
        __context__.SourceCodeLine = 692;
        _SplusNVRAM.WIDTHSTRING [ 15 ]  .UpdateValue ( "0.57"  ) ; 
        __context__.SourceCodeLine = 693;
        _SplusNVRAM.WIDTHSTRING [ 16 ]  .UpdateValue ( "0.61"  ) ; 
        __context__.SourceCodeLine = 694;
        _SplusNVRAM.WIDTHSTRING [ 17 ]  .UpdateValue ( "0.65"  ) ; 
        __context__.SourceCodeLine = 695;
        _SplusNVRAM.WIDTHSTRING [ 18 ]  .UpdateValue ( "0.69"  ) ; 
        __context__.SourceCodeLine = 696;
        _SplusNVRAM.WIDTHSTRING [ 19 ]  .UpdateValue ( "0.73"  ) ; 
        __context__.SourceCodeLine = 697;
        _SplusNVRAM.WIDTHSTRING [ 20 ]  .UpdateValue ( "0.77"  ) ; 
        __context__.SourceCodeLine = 698;
        _SplusNVRAM.WIDTHSTRING [ 21 ]  .UpdateValue ( "0.81"  ) ; 
        __context__.SourceCodeLine = 699;
        _SplusNVRAM.WIDTHSTRING [ 22 ]  .UpdateValue ( "0.85"  ) ; 
        __context__.SourceCodeLine = 700;
        _SplusNVRAM.WIDTHSTRING [ 23 ]  .UpdateValue ( "0.89"  ) ; 
        __context__.SourceCodeLine = 701;
        _SplusNVRAM.WIDTHSTRING [ 24 ]  .UpdateValue ( "0.93"  ) ; 
        __context__.SourceCodeLine = 702;
        _SplusNVRAM.WIDTHSTRING [ 25 ]  .UpdateValue ( "0.97"  ) ; 
        __context__.SourceCodeLine = 703;
        _SplusNVRAM.WIDTHSTRING [ 26 ]  .UpdateValue ( "1.01"  ) ; 
        __context__.SourceCodeLine = 704;
        _SplusNVRAM.WIDTHSTRING [ 27 ]  .UpdateValue ( "1.05"  ) ; 
        __context__.SourceCodeLine = 705;
        _SplusNVRAM.WIDTHSTRING [ 28 ]  .UpdateValue ( "1.09"  ) ; 
        __context__.SourceCodeLine = 706;
        _SplusNVRAM.WIDTHSTRING [ 29 ]  .UpdateValue ( "1.13"  ) ; 
        __context__.SourceCodeLine = 707;
        _SplusNVRAM.WIDTHSTRING [ 30 ]  .UpdateValue ( "1.17"  ) ; 
        __context__.SourceCodeLine = 708;
        _SplusNVRAM.WIDTHSTRING [ 31 ]  .UpdateValue ( "1.21"  ) ; 
        __context__.SourceCodeLine = 709;
        _SplusNVRAM.WIDTHSTRING [ 32 ]  .UpdateValue ( "1.25"  ) ; 
        __context__.SourceCodeLine = 710;
        _SplusNVRAM.WIDTHSTRING [ 33 ]  .UpdateValue ( "1.29"  ) ; 
        __context__.SourceCodeLine = 711;
        _SplusNVRAM.WIDTHSTRING [ 34 ]  .UpdateValue ( "1.33"  ) ; 
        __context__.SourceCodeLine = 712;
        _SplusNVRAM.WIDTHSTRING [ 35 ]  .UpdateValue ( "1.37"  ) ; 
        __context__.SourceCodeLine = 713;
        _SplusNVRAM.WIDTHSTRING [ 36 ]  .UpdateValue ( "1.41"  ) ; 
        __context__.SourceCodeLine = 714;
        _SplusNVRAM.WIDTHSTRING [ 37 ]  .UpdateValue ( "1.45"  ) ; 
        __context__.SourceCodeLine = 715;
        _SplusNVRAM.WIDTHSTRING [ 38 ]  .UpdateValue ( "1.49"  ) ; 
        __context__.SourceCodeLine = 716;
        _SplusNVRAM.WIDTHSTRING [ 39 ]  .UpdateValue ( "1.53"  ) ; 
        __context__.SourceCodeLine = 717;
        _SplusNVRAM.WIDTHSTRING [ 40 ]  .UpdateValue ( "1.57"  ) ; 
        __context__.SourceCodeLine = 718;
        _SplusNVRAM.WIDTHSTRING [ 41 ]  .UpdateValue ( "1.61"  ) ; 
        __context__.SourceCodeLine = 719;
        _SplusNVRAM.WIDTHSTRING [ 42 ]  .UpdateValue ( "1.65"  ) ; 
        __context__.SourceCodeLine = 720;
        _SplusNVRAM.WIDTHSTRING [ 43 ]  .UpdateValue ( "1.69"  ) ; 
        __context__.SourceCodeLine = 721;
        _SplusNVRAM.WIDTHSTRING [ 44 ]  .UpdateValue ( "1.73"  ) ; 
        __context__.SourceCodeLine = 722;
        _SplusNVRAM.WIDTHSTRING [ 45 ]  .UpdateValue ( "1.77"  ) ; 
        __context__.SourceCodeLine = 723;
        _SplusNVRAM.WIDTHSTRING [ 46 ]  .UpdateValue ( "1.81"  ) ; 
        __context__.SourceCodeLine = 724;
        _SplusNVRAM.WIDTHSTRING [ 47 ]  .UpdateValue ( "1.85"  ) ; 
        __context__.SourceCodeLine = 725;
        _SplusNVRAM.WIDTHSTRING [ 48 ]  .UpdateValue ( "1.89"  ) ; 
        __context__.SourceCodeLine = 726;
        _SplusNVRAM.WIDTHSTRING [ 49 ]  .UpdateValue ( "1.93"  ) ; 
        __context__.SourceCodeLine = 727;
        _SplusNVRAM.WIDTHSTRING [ 50 ]  .UpdateValue ( "1.96"  ) ; 
        __context__.SourceCodeLine = 728;
        _SplusNVRAM.WIDTHSTRING [ 51 ]  .UpdateValue ( "2.00"  ) ; 
        __context__.SourceCodeLine = 729;
        _SplusNVRAM.WIDTHSTRING [ 52 ]  .UpdateValue ( "2.04"  ) ; 
        __context__.SourceCodeLine = 730;
        _SplusNVRAM.WIDTHSTRING [ 53 ]  .UpdateValue ( "2.08"  ) ; 
        __context__.SourceCodeLine = 731;
        _SplusNVRAM.WIDTHSTRING [ 54 ]  .UpdateValue ( "2.12"  ) ; 
        __context__.SourceCodeLine = 732;
        _SplusNVRAM.WIDTHSTRING [ 55 ]  .UpdateValue ( "2.16"  ) ; 
        __context__.SourceCodeLine = 733;
        _SplusNVRAM.WIDTHSTRING [ 56 ]  .UpdateValue ( "2.20"  ) ; 
        __context__.SourceCodeLine = 734;
        _SplusNVRAM.WIDTHSTRING [ 57 ]  .UpdateValue ( "2.24"  ) ; 
        __context__.SourceCodeLine = 735;
        _SplusNVRAM.WIDTHSTRING [ 58 ]  .UpdateValue ( "2.28"  ) ; 
        __context__.SourceCodeLine = 736;
        _SplusNVRAM.WIDTHSTRING [ 59 ]  .UpdateValue ( "2.32"  ) ; 
        __context__.SourceCodeLine = 737;
        _SplusNVRAM.WIDTHSTRING [ 60 ]  .UpdateValue ( "2.36"  ) ; 
        __context__.SourceCodeLine = 738;
        _SplusNVRAM.WIDTHSTRING [ 61 ]  .UpdateValue ( "2.40"  ) ; 
        __context__.SourceCodeLine = 739;
        _SplusNVRAM.WIDTHSTRING [ 62 ]  .UpdateValue ( "2.44"  ) ; 
        __context__.SourceCodeLine = 740;
        _SplusNVRAM.WIDTHSTRING [ 63 ]  .UpdateValue ( "2.48"  ) ; 
        __context__.SourceCodeLine = 741;
        _SplusNVRAM.WIDTHSTRING [ 64 ]  .UpdateValue ( "2.52"  ) ; 
        __context__.SourceCodeLine = 742;
        _SplusNVRAM.WIDTHSTRING [ 65 ]  .UpdateValue ( "2.56"  ) ; 
        __context__.SourceCodeLine = 743;
        _SplusNVRAM.WIDTHSTRING [ 66 ]  .UpdateValue ( "2.60"  ) ; 
        __context__.SourceCodeLine = 744;
        _SplusNVRAM.WIDTHSTRING [ 67 ]  .UpdateValue ( "2.64"  ) ; 
        __context__.SourceCodeLine = 745;
        _SplusNVRAM.WIDTHSTRING [ 68 ]  .UpdateValue ( "2.68"  ) ; 
        __context__.SourceCodeLine = 746;
        _SplusNVRAM.WIDTHSTRING [ 69 ]  .UpdateValue ( "2.72"  ) ; 
        __context__.SourceCodeLine = 747;
        _SplusNVRAM.WIDTHSTRING [ 70 ]  .UpdateValue ( "2.76"  ) ; 
        __context__.SourceCodeLine = 748;
        _SplusNVRAM.WIDTHSTRING [ 71 ]  .UpdateValue ( "2.80"  ) ; 
        __context__.SourceCodeLine = 749;
        _SplusNVRAM.WIDTHSTRING [ 72 ]  .UpdateValue ( "2.84"  ) ; 
        __context__.SourceCodeLine = 750;
        _SplusNVRAM.WIDTHSTRING [ 73 ]  .UpdateValue ( "2.88"  ) ; 
        __context__.SourceCodeLine = 751;
        _SplusNVRAM.WIDTHSTRING [ 74 ]  .UpdateValue ( "2.92"  ) ; 
        __context__.SourceCodeLine = 752;
        _SplusNVRAM.WIDTHSTRING [ 75 ]  .UpdateValue ( "2.96"  ) ; 
        __context__.SourceCodeLine = 753;
        _SplusNVRAM.WIDTHSTRING [ 76 ]  .UpdateValue ( "3.00"  ) ; 
        __context__.SourceCodeLine = 754;
        _SplusNVRAM.WIDTHSTRING [ 77 ]  .UpdateValue ( "3.04"  ) ; 
        __context__.SourceCodeLine = 755;
        _SplusNVRAM.WIDTHSTRING [ 78 ]  .UpdateValue ( "3.08"  ) ; 
        __context__.SourceCodeLine = 756;
        _SplusNVRAM.WIDTHSTRING [ 79 ]  .UpdateValue ( "3.12"  ) ; 
        __context__.SourceCodeLine = 757;
        _SplusNVRAM.WIDTHSTRING [ 80 ]  .UpdateValue ( "3.16"  ) ; 
        __context__.SourceCodeLine = 758;
        _SplusNVRAM.WIDTHSTRING [ 81 ]  .UpdateValue ( "3.20"  ) ; 
        __context__.SourceCodeLine = 759;
        _SplusNVRAM.WIDTHSTRING [ 82 ]  .UpdateValue ( "3.24"  ) ; 
        __context__.SourceCodeLine = 760;
        _SplusNVRAM.WIDTHSTRING [ 83 ]  .UpdateValue ( "3.28"  ) ; 
        __context__.SourceCodeLine = 761;
        _SplusNVRAM.WIDTHSTRING [ 84 ]  .UpdateValue ( "3.32"  ) ; 
        __context__.SourceCodeLine = 762;
        _SplusNVRAM.WIDTHSTRING [ 85 ]  .UpdateValue ( "3.36"  ) ; 
        __context__.SourceCodeLine = 763;
        _SplusNVRAM.WIDTHSTRING [ 86 ]  .UpdateValue ( "3.40"  ) ; 
        __context__.SourceCodeLine = 764;
        _SplusNVRAM.WIDTHSTRING [ 87 ]  .UpdateValue ( "3.44"  ) ; 
        __context__.SourceCodeLine = 765;
        _SplusNVRAM.WIDTHSTRING [ 88 ]  .UpdateValue ( "3.48"  ) ; 
        __context__.SourceCodeLine = 766;
        _SplusNVRAM.WIDTHSTRING [ 89 ]  .UpdateValue ( "3.52"  ) ; 
        __context__.SourceCodeLine = 767;
        _SplusNVRAM.WIDTHSTRING [ 90 ]  .UpdateValue ( "3.56"  ) ; 
        __context__.SourceCodeLine = 768;
        _SplusNVRAM.WIDTHSTRING [ 91 ]  .UpdateValue ( "3.60"  ) ; 
        __context__.SourceCodeLine = 769;
        _SplusNVRAM.WIDTHSTRING [ 92 ]  .UpdateValue ( "3.64"  ) ; 
        __context__.SourceCodeLine = 770;
        _SplusNVRAM.WIDTHSTRING [ 93 ]  .UpdateValue ( "3.68"  ) ; 
        __context__.SourceCodeLine = 771;
        _SplusNVRAM.WIDTHSTRING [ 94 ]  .UpdateValue ( "3.72"  ) ; 
        __context__.SourceCodeLine = 772;
        _SplusNVRAM.WIDTHSTRING [ 95 ]  .UpdateValue ( "3.76"  ) ; 
        __context__.SourceCodeLine = 773;
        _SplusNVRAM.WIDTHSTRING [ 96 ]  .UpdateValue ( "3.80"  ) ; 
        __context__.SourceCodeLine = 774;
        _SplusNVRAM.WIDTHSTRING [ 97 ]  .UpdateValue ( "3.84"  ) ; 
        __context__.SourceCodeLine = 775;
        _SplusNVRAM.WIDTHSTRING [ 98 ]  .UpdateValue ( "3.88"  ) ; 
        __context__.SourceCodeLine = 776;
        _SplusNVRAM.WIDTHSTRING [ 99 ]  .UpdateValue ( "3.92"  ) ; 
        __context__.SourceCodeLine = 777;
        _SplusNVRAM.WIDTHSTRING [ 100 ]  .UpdateValue ( "3.96"  ) ; 
        __context__.SourceCodeLine = 778;
        _SplusNVRAM.WIDTHSTRING [ 101 ]  .UpdateValue ( "4.00"  ) ; 
        __context__.SourceCodeLine = 781;
        _SplusNVRAM.FREQUENCY [ 1] = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 782;
        _SplusNVRAM.FREQUENCY [ 2] = (ushort) ( 655 ) ; 
        __context__.SourceCodeLine = 783;
        _SplusNVRAM.FREQUENCY [ 3] = (ushort) ( 1310 ) ; 
        __context__.SourceCodeLine = 784;
        _SplusNVRAM.FREQUENCY [ 4] = (ushort) ( 1966 ) ; 
        __context__.SourceCodeLine = 785;
        _SplusNVRAM.FREQUENCY [ 5] = (ushort) ( 2621 ) ; 
        __context__.SourceCodeLine = 786;
        _SplusNVRAM.FREQUENCY [ 6] = (ushort) ( 3276 ) ; 
        __context__.SourceCodeLine = 787;
        _SplusNVRAM.FREQUENCY [ 7] = (ushort) ( 3932 ) ; 
        __context__.SourceCodeLine = 788;
        _SplusNVRAM.FREQUENCY [ 8] = (ushort) ( 4587 ) ; 
        __context__.SourceCodeLine = 789;
        _SplusNVRAM.FREQUENCY [ 9] = (ushort) ( 5242 ) ; 
        __context__.SourceCodeLine = 790;
        _SplusNVRAM.FREQUENCY [ 10] = (ushort) ( 5898 ) ; 
        __context__.SourceCodeLine = 791;
        _SplusNVRAM.FREQUENCY [ 11] = (ushort) ( 6553 ) ; 
        __context__.SourceCodeLine = 792;
        _SplusNVRAM.FREQUENCY [ 12] = (ushort) ( 7208 ) ; 
        __context__.SourceCodeLine = 793;
        _SplusNVRAM.FREQUENCY [ 13] = (ushort) ( 7864 ) ; 
        __context__.SourceCodeLine = 794;
        _SplusNVRAM.FREQUENCY [ 14] = (ushort) ( 8519 ) ; 
        __context__.SourceCodeLine = 795;
        _SplusNVRAM.FREQUENCY [ 15] = (ushort) ( 9174 ) ; 
        __context__.SourceCodeLine = 796;
        _SplusNVRAM.FREQUENCY [ 16] = (ushort) ( 9830 ) ; 
        __context__.SourceCodeLine = 797;
        _SplusNVRAM.FREQUENCY [ 17] = (ushort) ( 10485 ) ; 
        __context__.SourceCodeLine = 798;
        _SplusNVRAM.FREQUENCY [ 18] = (ushort) ( 11140 ) ; 
        __context__.SourceCodeLine = 799;
        _SplusNVRAM.FREQUENCY [ 19] = (ushort) ( 11796 ) ; 
        __context__.SourceCodeLine = 800;
        _SplusNVRAM.FREQUENCY [ 20] = (ushort) ( 12451 ) ; 
        __context__.SourceCodeLine = 801;
        _SplusNVRAM.FREQUENCY [ 21] = (ushort) ( 13107 ) ; 
        __context__.SourceCodeLine = 802;
        _SplusNVRAM.FREQUENCY [ 22] = (ushort) ( 13762 ) ; 
        __context__.SourceCodeLine = 803;
        _SplusNVRAM.FREQUENCY [ 23] = (ushort) ( 14417 ) ; 
        __context__.SourceCodeLine = 804;
        _SplusNVRAM.FREQUENCY [ 24] = (ushort) ( 15073 ) ; 
        __context__.SourceCodeLine = 805;
        _SplusNVRAM.FREQUENCY [ 25] = (ushort) ( 15728 ) ; 
        __context__.SourceCodeLine = 806;
        _SplusNVRAM.FREQUENCY [ 26] = (ushort) ( 16383 ) ; 
        __context__.SourceCodeLine = 807;
        _SplusNVRAM.FREQUENCY [ 27] = (ushort) ( 17039 ) ; 
        __context__.SourceCodeLine = 808;
        _SplusNVRAM.FREQUENCY [ 28] = (ushort) ( 17694 ) ; 
        __context__.SourceCodeLine = 809;
        _SplusNVRAM.FREQUENCY [ 29] = (ushort) ( 18349 ) ; 
        __context__.SourceCodeLine = 810;
        _SplusNVRAM.FREQUENCY [ 30] = (ushort) ( 19005 ) ; 
        __context__.SourceCodeLine = 811;
        _SplusNVRAM.FREQUENCY [ 31] = (ushort) ( 19660 ) ; 
        __context__.SourceCodeLine = 812;
        _SplusNVRAM.FREQUENCY [ 32] = (ushort) ( 20315 ) ; 
        __context__.SourceCodeLine = 813;
        _SplusNVRAM.FREQUENCY [ 33] = (ushort) ( 20971 ) ; 
        __context__.SourceCodeLine = 814;
        _SplusNVRAM.FREQUENCY [ 34] = (ushort) ( 21626 ) ; 
        __context__.SourceCodeLine = 815;
        _SplusNVRAM.FREQUENCY [ 35] = (ushort) ( 22281 ) ; 
        __context__.SourceCodeLine = 816;
        _SplusNVRAM.FREQUENCY [ 36] = (ushort) ( 22937 ) ; 
        __context__.SourceCodeLine = 817;
        _SplusNVRAM.FREQUENCY [ 37] = (ushort) ( 23592 ) ; 
        __context__.SourceCodeLine = 818;
        _SplusNVRAM.FREQUENCY [ 38] = (ushort) ( 24247 ) ; 
        __context__.SourceCodeLine = 819;
        _SplusNVRAM.FREQUENCY [ 39] = (ushort) ( 24903 ) ; 
        __context__.SourceCodeLine = 820;
        _SplusNVRAM.FREQUENCY [ 40] = (ushort) ( 25558 ) ; 
        __context__.SourceCodeLine = 821;
        _SplusNVRAM.FREQUENCY [ 41] = (ushort) ( 26214 ) ; 
        __context__.SourceCodeLine = 822;
        _SplusNVRAM.FREQUENCY [ 42] = (ushort) ( 26869 ) ; 
        __context__.SourceCodeLine = 823;
        _SplusNVRAM.FREQUENCY [ 43] = (ushort) ( 27524 ) ; 
        __context__.SourceCodeLine = 824;
        _SplusNVRAM.FREQUENCY [ 44] = (ushort) ( 28180 ) ; 
        __context__.SourceCodeLine = 825;
        _SplusNVRAM.FREQUENCY [ 45] = (ushort) ( 28835 ) ; 
        __context__.SourceCodeLine = 826;
        _SplusNVRAM.FREQUENCY [ 46] = (ushort) ( 29490 ) ; 
        __context__.SourceCodeLine = 827;
        _SplusNVRAM.FREQUENCY [ 47] = (ushort) ( 30146 ) ; 
        __context__.SourceCodeLine = 828;
        _SplusNVRAM.FREQUENCY [ 48] = (ushort) ( 30801 ) ; 
        __context__.SourceCodeLine = 829;
        _SplusNVRAM.FREQUENCY [ 49] = (ushort) ( 31456 ) ; 
        __context__.SourceCodeLine = 830;
        _SplusNVRAM.FREQUENCY [ 50] = (ushort) ( 32112 ) ; 
        __context__.SourceCodeLine = 831;
        _SplusNVRAM.FREQUENCY [ 51] = (ushort) ( 32767 ) ; 
        __context__.SourceCodeLine = 832;
        _SplusNVRAM.FREQUENCY [ 52] = (ushort) ( 33422 ) ; 
        __context__.SourceCodeLine = 833;
        _SplusNVRAM.FREQUENCY [ 53] = (ushort) ( 34078 ) ; 
        __context__.SourceCodeLine = 834;
        _SplusNVRAM.FREQUENCY [ 54] = (ushort) ( 34733 ) ; 
        __context__.SourceCodeLine = 835;
        _SplusNVRAM.FREQUENCY [ 55] = (ushort) ( 35388 ) ; 
        __context__.SourceCodeLine = 836;
        _SplusNVRAM.FREQUENCY [ 56] = (ushort) ( 36044 ) ; 
        __context__.SourceCodeLine = 837;
        _SplusNVRAM.FREQUENCY [ 57] = (ushort) ( 36699 ) ; 
        __context__.SourceCodeLine = 838;
        _SplusNVRAM.FREQUENCY [ 58] = (ushort) ( 37354 ) ; 
        __context__.SourceCodeLine = 839;
        _SplusNVRAM.FREQUENCY [ 59] = (ushort) ( 38010 ) ; 
        __context__.SourceCodeLine = 840;
        _SplusNVRAM.FREQUENCY [ 60] = (ushort) ( 38665 ) ; 
        __context__.SourceCodeLine = 841;
        _SplusNVRAM.FREQUENCY [ 61] = (ushort) ( 39321 ) ; 
        __context__.SourceCodeLine = 842;
        _SplusNVRAM.FREQUENCY [ 62] = (ushort) ( 39976 ) ; 
        __context__.SourceCodeLine = 843;
        _SplusNVRAM.FREQUENCY [ 63] = (ushort) ( 40631 ) ; 
        __context__.SourceCodeLine = 844;
        _SplusNVRAM.FREQUENCY [ 64] = (ushort) ( 41287 ) ; 
        __context__.SourceCodeLine = 845;
        _SplusNVRAM.FREQUENCY [ 65] = (ushort) ( 41942 ) ; 
        __context__.SourceCodeLine = 846;
        _SplusNVRAM.FREQUENCY [ 66] = (ushort) ( 42597 ) ; 
        __context__.SourceCodeLine = 847;
        _SplusNVRAM.FREQUENCY [ 67] = (ushort) ( 43253 ) ; 
        __context__.SourceCodeLine = 848;
        _SplusNVRAM.FREQUENCY [ 68] = (ushort) ( 43908 ) ; 
        __context__.SourceCodeLine = 849;
        _SplusNVRAM.FREQUENCY [ 69] = (ushort) ( 44563 ) ; 
        __context__.SourceCodeLine = 850;
        _SplusNVRAM.FREQUENCY [ 70] = (ushort) ( 45219 ) ; 
        __context__.SourceCodeLine = 851;
        _SplusNVRAM.FREQUENCY [ 71] = (ushort) ( 45874 ) ; 
        __context__.SourceCodeLine = 852;
        _SplusNVRAM.FREQUENCY [ 72] = (ushort) ( 46529 ) ; 
        __context__.SourceCodeLine = 853;
        _SplusNVRAM.FREQUENCY [ 73] = (ushort) ( 47185 ) ; 
        __context__.SourceCodeLine = 854;
        _SplusNVRAM.FREQUENCY [ 74] = (ushort) ( 47840 ) ; 
        __context__.SourceCodeLine = 855;
        _SplusNVRAM.FREQUENCY [ 75] = (ushort) ( 48495 ) ; 
        __context__.SourceCodeLine = 856;
        _SplusNVRAM.FREQUENCY [ 76] = (ushort) ( 49151 ) ; 
        __context__.SourceCodeLine = 857;
        _SplusNVRAM.FREQUENCY [ 77] = (ushort) ( 49806 ) ; 
        __context__.SourceCodeLine = 858;
        _SplusNVRAM.FREQUENCY [ 78] = (ushort) ( 50461 ) ; 
        __context__.SourceCodeLine = 859;
        _SplusNVRAM.FREQUENCY [ 79] = (ushort) ( 51117 ) ; 
        __context__.SourceCodeLine = 860;
        _SplusNVRAM.FREQUENCY [ 80] = (ushort) ( 51772 ) ; 
        __context__.SourceCodeLine = 861;
        _SplusNVRAM.FREQUENCY [ 81] = (ushort) ( 52428 ) ; 
        __context__.SourceCodeLine = 862;
        _SplusNVRAM.FREQUENCY [ 82] = (ushort) ( 53083 ) ; 
        __context__.SourceCodeLine = 863;
        _SplusNVRAM.FREQUENCY [ 83] = (ushort) ( 53738 ) ; 
        __context__.SourceCodeLine = 864;
        _SplusNVRAM.FREQUENCY [ 84] = (ushort) ( 54394 ) ; 
        __context__.SourceCodeLine = 865;
        _SplusNVRAM.FREQUENCY [ 85] = (ushort) ( 55049 ) ; 
        __context__.SourceCodeLine = 866;
        _SplusNVRAM.FREQUENCY [ 86] = (ushort) ( 55704 ) ; 
        __context__.SourceCodeLine = 867;
        _SplusNVRAM.FREQUENCY [ 87] = (ushort) ( 56360 ) ; 
        __context__.SourceCodeLine = 868;
        _SplusNVRAM.FREQUENCY [ 88] = (ushort) ( 57015 ) ; 
        __context__.SourceCodeLine = 869;
        _SplusNVRAM.FREQUENCY [ 89] = (ushort) ( 57670 ) ; 
        __context__.SourceCodeLine = 870;
        _SplusNVRAM.FREQUENCY [ 90] = (ushort) ( 58326 ) ; 
        __context__.SourceCodeLine = 871;
        _SplusNVRAM.FREQUENCY [ 91] = (ushort) ( 58981 ) ; 
        __context__.SourceCodeLine = 872;
        _SplusNVRAM.FREQUENCY [ 92] = (ushort) ( 59636 ) ; 
        __context__.SourceCodeLine = 873;
        _SplusNVRAM.FREQUENCY [ 93] = (ushort) ( 60292 ) ; 
        __context__.SourceCodeLine = 874;
        _SplusNVRAM.FREQUENCY [ 94] = (ushort) ( 60947 ) ; 
        __context__.SourceCodeLine = 875;
        _SplusNVRAM.FREQUENCY [ 95] = (ushort) ( 61602 ) ; 
        __context__.SourceCodeLine = 876;
        _SplusNVRAM.FREQUENCY [ 96] = (ushort) ( 62258 ) ; 
        __context__.SourceCodeLine = 877;
        _SplusNVRAM.FREQUENCY [ 97] = (ushort) ( 62913 ) ; 
        __context__.SourceCodeLine = 878;
        _SplusNVRAM.FREQUENCY [ 98] = (ushort) ( 63568 ) ; 
        __context__.SourceCodeLine = 879;
        _SplusNVRAM.FREQUENCY [ 99] = (ushort) ( 64224 ) ; 
        __context__.SourceCodeLine = 880;
        _SplusNVRAM.FREQUENCY [ 100] = (ushort) ( 64879 ) ; 
        __context__.SourceCodeLine = 881;
        _SplusNVRAM.FREQUENCY [ 101] = (ushort) ( 65535 ) ; 
        __context__.SourceCodeLine = 883;
        _SplusNVRAM.FREQUENCYSTRING [ 1 ]  .UpdateValue ( "20.0 Hz"  ) ; 
        __context__.SourceCodeLine = 884;
        _SplusNVRAM.FREQUENCYSTRING [ 2 ]  .UpdateValue ( "21.4 Hz"  ) ; 
        __context__.SourceCodeLine = 885;
        _SplusNVRAM.FREQUENCYSTRING [ 3 ]  .UpdateValue ( "23.0 Hz"  ) ; 
        __context__.SourceCodeLine = 886;
        _SplusNVRAM.FREQUENCYSTRING [ 4 ]  .UpdateValue ( "24.6 Hz"  ) ; 
        __context__.SourceCodeLine = 887;
        _SplusNVRAM.FREQUENCYSTRING [ 5 ]  .UpdateValue ( "26.4 Hz"  ) ; 
        __context__.SourceCodeLine = 888;
        _SplusNVRAM.FREQUENCYSTRING [ 6 ]  .UpdateValue ( "28.2 Hz"  ) ; 
        __context__.SourceCodeLine = 889;
        _SplusNVRAM.FREQUENCYSTRING [ 7 ]  .UpdateValue ( "30.3 Hz"  ) ; 
        __context__.SourceCodeLine = 890;
        _SplusNVRAM.FREQUENCYSTRING [ 8 ]  .UpdateValue ( "32.4 Hz"  ) ; 
        __context__.SourceCodeLine = 891;
        _SplusNVRAM.FREQUENCYSTRING [ 9 ]  .UpdateValue ( "34.8 Hz"  ) ; 
        __context__.SourceCodeLine = 892;
        _SplusNVRAM.FREQUENCYSTRING [ 10 ]  .UpdateValue ( "37.2 Hz"  ) ; 
        __context__.SourceCodeLine = 893;
        _SplusNVRAM.FREQUENCYSTRING [ 11 ]  .UpdateValue ( "39.9 Hz"  ) ; 
        __context__.SourceCodeLine = 894;
        _SplusNVRAM.FREQUENCYSTRING [ 12 ]  .UpdateValue ( "42.8 Hz"  ) ; 
        __context__.SourceCodeLine = 895;
        _SplusNVRAM.FREQUENCYSTRING [ 13 ]  .UpdateValue ( "45.8 Hz"  ) ; 
        __context__.SourceCodeLine = 896;
        _SplusNVRAM.FREQUENCYSTRING [ 14 ]  .UpdateValue ( "49.1 Hz"  ) ; 
        __context__.SourceCodeLine = 897;
        _SplusNVRAM.FREQUENCYSTRING [ 15 ]  .UpdateValue ( "52.6 Hz"  ) ; 
        __context__.SourceCodeLine = 898;
        _SplusNVRAM.FREQUENCYSTRING [ 16 ]  .UpdateValue ( "56.4 Hz"  ) ; 
        __context__.SourceCodeLine = 899;
        _SplusNVRAM.FREQUENCYSTRING [ 17 ]  .UpdateValue ( "60.4 Hz"  ) ; 
        __context__.SourceCodeLine = 900;
        _SplusNVRAM.FREQUENCYSTRING [ 18 ]  .UpdateValue ( "64.7 Hz"  ) ; 
        __context__.SourceCodeLine = 901;
        _SplusNVRAM.FREQUENCYSTRING [ 19 ]  .UpdateValue ( "69.3 Hz"  ) ; 
        __context__.SourceCodeLine = 902;
        _SplusNVRAM.FREQUENCYSTRING [ 20 ]  .UpdateValue ( "74.3 Hz"  ) ; 
        __context__.SourceCodeLine = 903;
        _SplusNVRAM.FREQUENCYSTRING [ 21 ]  .UpdateValue ( "79.6 Hz"  ) ; 
        __context__.SourceCodeLine = 904;
        _SplusNVRAM.FREQUENCYSTRING [ 22 ]  .UpdateValue ( "85.3 Hz"  ) ; 
        __context__.SourceCodeLine = 905;
        _SplusNVRAM.FREQUENCYSTRING [ 23 ]  .UpdateValue ( "91.4 Hz"  ) ; 
        __context__.SourceCodeLine = 906;
        _SplusNVRAM.FREQUENCYSTRING [ 24 ]  .UpdateValue ( "97.9 Hz"  ) ; 
        __context__.SourceCodeLine = 907;
        _SplusNVRAM.FREQUENCYSTRING [ 25 ]  .UpdateValue ( "105 Hz"  ) ; 
        __context__.SourceCodeLine = 908;
        _SplusNVRAM.FREQUENCYSTRING [ 26 ]  .UpdateValue ( "112 Hz"  ) ; 
        __context__.SourceCodeLine = 909;
        _SplusNVRAM.FREQUENCYSTRING [ 27 ]  .UpdateValue ( "121 Hz"  ) ; 
        __context__.SourceCodeLine = 910;
        _SplusNVRAM.FREQUENCYSTRING [ 28 ]  .UpdateValue ( "129 Hz"  ) ; 
        __context__.SourceCodeLine = 911;
        _SplusNVRAM.FREQUENCYSTRING [ 29 ]  .UpdateValue ( "138 Hz"  ) ; 
        __context__.SourceCodeLine = 912;
        _SplusNVRAM.FREQUENCYSTRING [ 30 ]  .UpdateValue ( "148 Hz"  ) ; 
        __context__.SourceCodeLine = 913;
        _SplusNVRAM.FREQUENCYSTRING [ 31 ]  .UpdateValue ( "159 Hz"  ) ; 
        __context__.SourceCodeLine = 914;
        _SplusNVRAM.FREQUENCYSTRING [ 32 ]  .UpdateValue ( "170 Hz"  ) ; 
        __context__.SourceCodeLine = 915;
        _SplusNVRAM.FREQUENCYSTRING [ 33 ]  .UpdateValue ( "182 Hz"  ) ; 
        __context__.SourceCodeLine = 916;
        _SplusNVRAM.FREQUENCYSTRING [ 34 ]  .UpdateValue ( "195 Hz"  ) ; 
        __context__.SourceCodeLine = 917;
        _SplusNVRAM.FREQUENCYSTRING [ 35 ]  .UpdateValue ( "209 Hz"  ) ; 
        __context__.SourceCodeLine = 918;
        _SplusNVRAM.FREQUENCYSTRING [ 36 ]  .UpdateValue ( "224 Hz"  ) ; 
        __context__.SourceCodeLine = 919;
        _SplusNVRAM.FREQUENCYSTRING [ 37 ]  .UpdateValue ( "240 Hz"  ) ; 
        __context__.SourceCodeLine = 920;
        _SplusNVRAM.FREQUENCYSTRING [ 38 ]  .UpdateValue ( "258 Hz"  ) ; 
        __context__.SourceCodeLine = 921;
        _SplusNVRAM.FREQUENCYSTRING [ 39 ]  .UpdateValue ( "276 Hz"  ) ; 
        __context__.SourceCodeLine = 922;
        _SplusNVRAM.FREQUENCYSTRING [ 40 ]  .UpdateValue ( "296 Hz"  ) ; 
        __context__.SourceCodeLine = 923;
        _SplusNVRAM.FREQUENCYSTRING [ 41 ]  .UpdateValue ( "317 Hz"  ) ; 
        __context__.SourceCodeLine = 924;
        _SplusNVRAM.FREQUENCYSTRING [ 42 ]  .UpdateValue ( "340 Hz"  ) ; 
        __context__.SourceCodeLine = 925;
        _SplusNVRAM.FREQUENCYSTRING [ 43 ]  .UpdateValue ( "364 Hz"  ) ; 
        __context__.SourceCodeLine = 926;
        _SplusNVRAM.FREQUENCYSTRING [ 44 ]  .UpdateValue ( "390 Hz"  ) ; 
        __context__.SourceCodeLine = 927;
        _SplusNVRAM.FREQUENCYSTRING [ 45 ]  .UpdateValue ( "418 Hz"  ) ; 
        __context__.SourceCodeLine = 928;
        _SplusNVRAM.FREQUENCYSTRING [ 46 ]  .UpdateValue ( "448 Hz"  ) ; 
        __context__.SourceCodeLine = 929;
        _SplusNVRAM.FREQUENCYSTRING [ 47 ]  .UpdateValue ( "480 Hz"  ) ; 
        __context__.SourceCodeLine = 930;
        _SplusNVRAM.FREQUENCYSTRING [ 48 ]  .UpdateValue ( "514 Hz"  ) ; 
        __context__.SourceCodeLine = 931;
        _SplusNVRAM.FREQUENCYSTRING [ 49 ]  .UpdateValue ( "551 Hz"  ) ; 
        __context__.SourceCodeLine = 932;
        _SplusNVRAM.FREQUENCYSTRING [ 50 ]  .UpdateValue ( "590 Hz"  ) ; 
        __context__.SourceCodeLine = 933;
        _SplusNVRAM.FREQUENCYSTRING [ 51 ]  .UpdateValue ( "632 Hz"  ) ; 
        __context__.SourceCodeLine = 934;
        _SplusNVRAM.FREQUENCYSTRING [ 52 ]  .UpdateValue ( "678 Hz"  ) ; 
        __context__.SourceCodeLine = 935;
        _SplusNVRAM.FREQUENCYSTRING [ 53 ]  .UpdateValue ( "726 Hz"  ) ; 
        __context__.SourceCodeLine = 936;
        _SplusNVRAM.FREQUENCYSTRING [ 54 ]  .UpdateValue ( "778 Hz"  ) ; 
        __context__.SourceCodeLine = 937;
        _SplusNVRAM.FREQUENCYSTRING [ 55 ]  .UpdateValue ( "834 Hz"  ) ; 
        __context__.SourceCodeLine = 938;
        _SplusNVRAM.FREQUENCYSTRING [ 56 ]  .UpdateValue ( "893 Hz"  ) ; 
        __context__.SourceCodeLine = 939;
        _SplusNVRAM.FREQUENCYSTRING [ 57 ]  .UpdateValue ( "957 Hz"  ) ; 
        __context__.SourceCodeLine = 940;
        _SplusNVRAM.FREQUENCYSTRING [ 58 ]  .UpdateValue ( "1.03 kHz"  ) ; 
        __context__.SourceCodeLine = 941;
        _SplusNVRAM.FREQUENCYSTRING [ 59 ]  .UpdateValue ( "1.10 kHz"  ) ; 
        __context__.SourceCodeLine = 942;
        _SplusNVRAM.FREQUENCYSTRING [ 60 ]  .UpdateValue ( "1.18 kHz"  ) ; 
        __context__.SourceCodeLine = 943;
        _SplusNVRAM.FREQUENCYSTRING [ 61 ]  .UpdateValue ( "1.26 kHz"  ) ; 
        __context__.SourceCodeLine = 944;
        _SplusNVRAM.FREQUENCYSTRING [ 62 ]  .UpdateValue ( "1.35 kHz"  ) ; 
        __context__.SourceCodeLine = 945;
        _SplusNVRAM.FREQUENCYSTRING [ 63 ]  .UpdateValue ( "1.45 kHz"  ) ; 
        __context__.SourceCodeLine = 946;
        _SplusNVRAM.FREQUENCYSTRING [ 64 ]  .UpdateValue ( "1.55 kHz"  ) ; 
        __context__.SourceCodeLine = 947;
        _SplusNVRAM.FREQUENCYSTRING [ 65 ]  .UpdateValue ( "1.66 kHz"  ) ; 
        __context__.SourceCodeLine = 948;
        _SplusNVRAM.FREQUENCYSTRING [ 66 ]  .UpdateValue ( "1.78 kHz"  ) ; 
        __context__.SourceCodeLine = 949;
        _SplusNVRAM.FREQUENCYSTRING [ 67 ]  .UpdateValue ( "1.91 kHz"  ) ; 
        __context__.SourceCodeLine = 950;
        _SplusNVRAM.FREQUENCYSTRING [ 68 ]  .UpdateValue ( "2.05 kHz"  ) ; 
        __context__.SourceCodeLine = 951;
        _SplusNVRAM.FREQUENCYSTRING [ 69 ]  .UpdateValue ( "2.19 kHz"  ) ; 
        __context__.SourceCodeLine = 952;
        _SplusNVRAM.FREQUENCYSTRING [ 70 ]  .UpdateValue ( "2.35 kHz"  ) ; 
        __context__.SourceCodeLine = 953;
        _SplusNVRAM.FREQUENCYSTRING [ 71 ]  .UpdateValue ( "2.52 kHz"  ) ; 
        __context__.SourceCodeLine = 954;
        _SplusNVRAM.FREQUENCYSTRING [ 72 ]  .UpdateValue ( "2.70 kHz"  ) ; 
        __context__.SourceCodeLine = 955;
        _SplusNVRAM.FREQUENCYSTRING [ 73 ]  .UpdateValue ( "2.89 kHz"  ) ; 
        __context__.SourceCodeLine = 956;
        _SplusNVRAM.FREQUENCYSTRING [ 74 ]  .UpdateValue ( "3.10 kHz"  ) ; 
        __context__.SourceCodeLine = 957;
        _SplusNVRAM.FREQUENCYSTRING [ 75 ]  .UpdateValue ( "3.32 kHz"  ) ; 
        __context__.SourceCodeLine = 958;
        _SplusNVRAM.FREQUENCYSTRING [ 76 ]  .UpdateValue ( "3.56 kHz"  ) ; 
        __context__.SourceCodeLine = 959;
        _SplusNVRAM.FREQUENCYSTRING [ 77 ]  .UpdateValue ( "3.81 kHz"  ) ; 
        __context__.SourceCodeLine = 960;
        _SplusNVRAM.FREQUENCYSTRING [ 78 ]  .UpdateValue ( "4.08 kHz"  ) ; 
        __context__.SourceCodeLine = 961;
        _SplusNVRAM.FREQUENCYSTRING [ 79 ]  .UpdateValue ( "4.38 kHz"  ) ; 
        __context__.SourceCodeLine = 962;
        _SplusNVRAM.FREQUENCYSTRING [ 80 ]  .UpdateValue ( "4.69 kHz"  ) ; 
        __context__.SourceCodeLine = 963;
        _SplusNVRAM.FREQUENCYSTRING [ 81 ]  .UpdateValue ( "5.02 kHz"  ) ; 
        __context__.SourceCodeLine = 964;
        _SplusNVRAM.FREQUENCYSTRING [ 82 ]  .UpdateValue ( "5.38 kHz"  ) ; 
        __context__.SourceCodeLine = 965;
        _SplusNVRAM.FREQUENCYSTRING [ 83 ]  .UpdateValue ( "5.77 kHz"  ) ; 
        __context__.SourceCodeLine = 966;
        _SplusNVRAM.FREQUENCYSTRING [ 84 ]  .UpdateValue ( "6.18 kHz"  ) ; 
        __context__.SourceCodeLine = 967;
        _SplusNVRAM.FREQUENCYSTRING [ 85 ]  .UpdateValue ( "6.62 kHz"  ) ; 
        __context__.SourceCodeLine = 968;
        _SplusNVRAM.FREQUENCYSTRING [ 86 ]  .UpdateValue ( "7.09 kHz"  ) ; 
        __context__.SourceCodeLine = 969;
        _SplusNVRAM.FREQUENCYSTRING [ 87 ]  .UpdateValue ( "7.60 kHz"  ) ; 
        __context__.SourceCodeLine = 970;
        _SplusNVRAM.FREQUENCYSTRING [ 88 ]  .UpdateValue ( "8.15 kHz"  ) ; 
        __context__.SourceCodeLine = 971;
        _SplusNVRAM.FREQUENCYSTRING [ 89 ]  .UpdateValue ( "8.73 kHz"  ) ; 
        __context__.SourceCodeLine = 972;
        _SplusNVRAM.FREQUENCYSTRING [ 90 ]  .UpdateValue ( "9.35 kHz"  ) ; 
        __context__.SourceCodeLine = 973;
        _SplusNVRAM.FREQUENCYSTRING [ 91 ]  .UpdateValue ( "10.0 kHz"  ) ; 
        __context__.SourceCodeLine = 974;
        _SplusNVRAM.FREQUENCYSTRING [ 92 ]  .UpdateValue ( "10.7 kHz"  ) ; 
        __context__.SourceCodeLine = 975;
        _SplusNVRAM.FREQUENCYSTRING [ 93 ]  .UpdateValue ( "11.5 kHz"  ) ; 
        __context__.SourceCodeLine = 976;
        _SplusNVRAM.FREQUENCYSTRING [ 94 ]  .UpdateValue ( "12.3 kHz"  ) ; 
        __context__.SourceCodeLine = 977;
        _SplusNVRAM.FREQUENCYSTRING [ 95 ]  .UpdateValue ( "13.2 kHz"  ) ; 
        __context__.SourceCodeLine = 978;
        _SplusNVRAM.FREQUENCYSTRING [ 96 ]  .UpdateValue ( "14.2 kHz"  ) ; 
        __context__.SourceCodeLine = 979;
        _SplusNVRAM.FREQUENCYSTRING [ 97 ]  .UpdateValue ( "15.2 kHz"  ) ; 
        __context__.SourceCodeLine = 980;
        _SplusNVRAM.FREQUENCYSTRING [ 98 ]  .UpdateValue ( "16.4 kHz"  ) ; 
        __context__.SourceCodeLine = 981;
        _SplusNVRAM.FREQUENCYSTRING [ 99 ]  .UpdateValue ( "17.4 kHz"  ) ; 
        __context__.SourceCodeLine = 982;
        _SplusNVRAM.FREQUENCYSTRING [ 100 ]  .UpdateValue ( "18.7 kHz"  ) ; 
        __context__.SourceCodeLine = 983;
        _SplusNVRAM.FREQUENCYSTRING [ 101 ]  .UpdateValue ( "20.0 kHz"  ) ; 
        
        
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
    _SplusNVRAM.WIDTH  = new ushort[ 102 ];
    _SplusNVRAM.FREQUENCY  = new ushort[ 102 ];
    _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    _SplusNVRAM.TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    _SplusNVRAM.NOTCH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    _SplusNVRAM.NEGATIVE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    _SplusNVRAM.BOOSTSTRING  = new CrestronString[ 102 ];
    for( uint i = 0; i < 102; i++ )
        _SplusNVRAM.BOOSTSTRING [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    _SplusNVRAM.WIDTHSTRING  = new CrestronString[ 102 ];
    for( uint i = 0; i < 102; i++ )
        _SplusNVRAM.WIDTHSTRING [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    _SplusNVRAM.FREQUENCYSTRING  = new CrestronString[ 102 ];
    for( uint i = 0; i < 102; i++ )
        _SplusNVRAM.FREQUENCYSTRING [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    BYPASS_ON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BYPASS_ON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BYPASS_ON__DOLLAR____DigitalInput__, BYPASS_ON__DOLLAR__ );
    
    BYPASS_OFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BYPASS_OFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BYPASS_OFF__DOLLAR____DigitalInput__, BYPASS_OFF__DOLLAR__ );
    
    BYPASS_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( BYPASS_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( BYPASS_FB__DOLLAR____DigitalOutput__, BYPASS_FB__DOLLAR__ );
    
    INPUT__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( INPUT__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( INPUT__DOLLAR____AnalogSerialInput__, INPUT__DOLLAR__ );
    
    BOOSTPERCENT__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( BOOSTPERCENT__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( BOOSTPERCENT__DOLLAR____AnalogSerialInput__, BOOSTPERCENT__DOLLAR__ );
    
    WIDTH__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( WIDTH__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( WIDTH__DOLLAR____AnalogSerialInput__, WIDTH__DOLLAR__ );
    
    FREQUENCY__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( FREQUENCY__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( FREQUENCY__DOLLAR____AnalogSerialInput__, FREQUENCY__DOLLAR__ );
    
    TYPE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( TYPE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( TYPE__DOLLAR____AnalogSerialInput__, TYPE__DOLLAR__ );
    
    SLOPE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( SLOPE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( SLOPE__DOLLAR____AnalogSerialInput__, SLOPE__DOLLAR__ );
    
    BOOSTPERCENT_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( BOOSTPERCENT_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( BOOSTPERCENT_FB__DOLLAR____AnalogSerialOutput__, BOOSTPERCENT_FB__DOLLAR__ );
    
    WIDTH_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( WIDTH_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( WIDTH_FB__DOLLAR____AnalogSerialOutput__, WIDTH_FB__DOLLAR__ );
    
    FREQUENCY_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( FREQUENCY_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( FREQUENCY_FB__DOLLAR____AnalogSerialOutput__, FREQUENCY_FB__DOLLAR__ );
    
    TYPE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( TYPE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TYPE_FB__DOLLAR____AnalogSerialOutput__, TYPE_FB__DOLLAR__ );
    
    SLOPE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( SLOPE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SLOPE_FB__DOLLAR____AnalogSerialOutput__, SLOPE_FB__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    BOOSTSTRING_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( BOOSTSTRING_FB__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( BOOSTSTRING_FB__DOLLAR____AnalogSerialOutput__, BOOSTSTRING_FB__DOLLAR__ );
    
    WIDTHSTRING_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( WIDTHSTRING_FB__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( WIDTHSTRING_FB__DOLLAR____AnalogSerialOutput__, WIDTHSTRING_FB__DOLLAR__ );
    
    FREQUENCYSTRING_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( FREQUENCYSTRING_FB__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( FREQUENCYSTRING_FB__DOLLAR____AnalogSerialOutput__, FREQUENCYSTRING_FB__DOLLAR__ );
    
    TYPESTRING_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TYPESTRING_FB__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TYPESTRING_FB__DOLLAR____AnalogSerialOutput__, TYPESTRING_FB__DOLLAR__ );
    
    SLOPESTRING_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SLOPESTRING_FB__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SLOPESTRING_FB__DOLLAR____AnalogSerialOutput__, SLOPESTRING_FB__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    BOOSTPERCENT__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( BOOSTPERCENT__DOLLAR___OnChange_0, false ) );
    WIDTH__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( WIDTH__DOLLAR___OnChange_1, false ) );
    FREQUENCY__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( FREQUENCY__DOLLAR___OnChange_2, false ) );
    TYPE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( TYPE__DOLLAR___OnChange_3, false ) );
    SLOPE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( SLOPE__DOLLAR___OnChange_4, false ) );
    BYPASS_ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYPASS_ON__DOLLAR___OnPush_5, false ) );
    BYPASS_OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BYPASS_OFF__DOLLAR___OnPush_6, false ) );
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_7, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_8, false ) );
    INPUT__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( INPUT__DOLLAR___OnChange_9, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_10, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_EQ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 0;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 1;
const uint BYPASS_ON__DOLLAR____DigitalInput__ = 2;
const uint BYPASS_OFF__DOLLAR____DigitalInput__ = 3;
const uint INPUT__DOLLAR____AnalogSerialInput__ = 0;
const uint BOOSTPERCENT__DOLLAR____AnalogSerialInput__ = 1;
const uint WIDTH__DOLLAR____AnalogSerialInput__ = 2;
const uint FREQUENCY__DOLLAR____AnalogSerialInput__ = 3;
const uint TYPE__DOLLAR____AnalogSerialInput__ = 4;
const uint SLOPE__DOLLAR____AnalogSerialInput__ = 5;
const uint RX__DOLLAR____AnalogSerialInput__ = 6;
const uint BYPASS_FB__DOLLAR____DigitalOutput__ = 0;
const uint BOOSTPERCENT_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint WIDTH_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint FREQUENCY_FB__DOLLAR____AnalogSerialOutput__ = 2;
const uint TYPE_FB__DOLLAR____AnalogSerialOutput__ = 3;
const uint SLOPE_FB__DOLLAR____AnalogSerialOutput__ = 4;
const uint TX__DOLLAR____AnalogSerialOutput__ = 5;
const uint BOOSTSTRING_FB__DOLLAR____AnalogSerialOutput__ = 6;
const uint WIDTHSTRING_FB__DOLLAR____AnalogSerialOutput__ = 7;
const uint FREQUENCYSTRING_FB__DOLLAR____AnalogSerialOutput__ = 8;
const uint TYPESTRING_FB__DOLLAR____AnalogSerialOutput__ = 9;
const uint SLOPESTRING_FB__DOLLAR____AnalogSerialOutput__ = 10;
const uint OBJECTID__DOLLAR____Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort ROUNDPART = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort VALUE = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort VOLUMEINPUT = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort INPUT = 0;
            [SplusStructAttribute(6, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(7, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort XOKSUBSCRIBE = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort XOKBOOST = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort SUBSCRIBE = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort ICASE = 0;
            [SplusStructAttribute(13, false, true)]
            public CrestronString TEMPSTRING;
            [SplusStructAttribute(14, false, true)]
            public ushort STATEVARBOOST = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort STATEVARFREQUENCY = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort STATEVARSUB = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort STATEVARRECEIVE = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort X = 0;
            [SplusStructAttribute(19, false, true)]
            public ushort STATEVARWIDTH = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort STATEVARSLOPE = 0;
            [SplusStructAttribute(21, false, true)]
            public ushort STATEVARTYPE = 0;
            [SplusStructAttribute(22, false, true)]
            public ushort STATEVARBYPASS = 0;
            [SplusStructAttribute(23, false, true)]
            public CrestronString NOTCH;
            [SplusStructAttribute(24, false, true)]
            public CrestronString NEGATIVE;
            [SplusStructAttribute(25, false, true)]
            public CrestronString [] BOOSTSTRING;
            [SplusStructAttribute(26, false, true)]
            public ushort [] WIDTH;
            [SplusStructAttribute(27, false, true)]
            public CrestronString [] WIDTHSTRING;
            [SplusStructAttribute(28, false, true)]
            public ushort [] FREQUENCY;
            [SplusStructAttribute(29, false, true)]
            public CrestronString [] FREQUENCYSTRING;
            
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
