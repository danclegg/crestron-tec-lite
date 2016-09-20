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

namespace UserModule_BSS_SOUNDWEB_LONDON_N_GAIN_8_CHAN_BASIC
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_N_GAIN_8_CHAN_BASIC : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_FEEDBACK__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput DISABLE_FEEDBACK__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN1_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN2_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN3_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN4_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN5_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN6_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN7_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHAN8_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput MASTEROUT_MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN_OFFSET__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN1_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN2_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN3_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN4_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN5_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN6_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN7_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN8_VOL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput MASTERVOL__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN1_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN2_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN3_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN4_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN5_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN6_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN7_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHAN8_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput MASTEROUT_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN1_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN2_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN3_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN4_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN5_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN6_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN7_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHAN8_VOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput MASTERVOL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 121;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 122;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 123;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 130;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 131;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 132;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 135;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 137;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 139;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object CHAN_OFFSET__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 147;
                _SplusNVRAM.OFFSET = (ushort) ( (CHAN_OFFSET__DOLLAR__  .UshortValue * 8) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ENABLE_FEEDBACK__DOLLAR___OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 151;
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
        
            
            __context__.SourceCodeLine = 153;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKFEEDBACK)  ) ) 
                { 
                __context__.SourceCodeLine = 155;
                _SplusNVRAM.XOKFEEDBACK = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 156;
                _SplusNVRAM.FEEDBACK = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 158;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)8; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 160;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( (((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
                    __context__.SourceCodeLine = 161;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 162;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) ) ; 
                    __context__.SourceCodeLine = 163;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                    __context__.SourceCodeLine = 158;
                    } 
                
                __context__.SourceCodeLine = 166;
                _SplusNVRAM.STATEVARSUB = (ushort) ( 97 ) ; 
                __context__.SourceCodeLine = 167;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 168;
                _SplusNVRAM.STATEVARSUB = (ushort) ( 96 ) ; 
                __context__.SourceCodeLine = 169;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 170;
                _SplusNVRAM.XOKFEEDBACK = (ushort) ( 1 ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object DISABLE_FEEDBACK__DOLLAR___OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 177;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKFEEDBACK)  ) ) 
            { 
            __context__.SourceCodeLine = 179;
            _SplusNVRAM.XOKFEEDBACK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 180;
            _SplusNVRAM.FEEDBACK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 182;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)8; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 184;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
                __context__.SourceCodeLine = 185;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 186;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 187;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 182;
                } 
            
            __context__.SourceCodeLine = 190;
            _SplusNVRAM.STATEVARSUB = (ushort) ( 97 ) ; 
            __context__.SourceCodeLine = 191;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 192;
            _SplusNVRAM.STATEVARSUB = (ushort) ( 96 ) ; 
            __context__.SourceCodeLine = 193;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
            __context__.SourceCodeLine = 194;
            _SplusNVRAM.XOKFEEDBACK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN1_MUTE__DOLLAR___OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 201;
        _SplusNVRAM.STATEVAR = (ushort) ( (((1 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 202;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 204;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 205;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN1_MUTE__DOLLAR___OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 209;
        _SplusNVRAM.STATEVAR = (ushort) ( (((1 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 210;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 212;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 213;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN2_MUTE__DOLLAR___OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 218;
        _SplusNVRAM.STATEVAR = (ushort) ( (((2 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 219;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 221;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 222;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN2_MUTE__DOLLAR___OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 226;
        _SplusNVRAM.STATEVAR = (ushort) ( (((2 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 227;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 229;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 230;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN3_MUTE__DOLLAR___OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 235;
        _SplusNVRAM.STATEVAR = (ushort) ( (((3 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 236;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 238;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 239;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN3_MUTE__DOLLAR___OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 243;
        _SplusNVRAM.STATEVAR = (ushort) ( (((3 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 244;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 246;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 247;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN4_MUTE__DOLLAR___OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 252;
        _SplusNVRAM.STATEVAR = (ushort) ( (((4 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 253;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 255;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 256;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN4_MUTE__DOLLAR___OnRelease_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 260;
        _SplusNVRAM.STATEVAR = (ushort) ( (((4 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 261;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 263;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 264;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN5_MUTE__DOLLAR___OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 269;
        _SplusNVRAM.STATEVAR = (ushort) ( (((5 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 270;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 272;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 273;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN5_MUTE__DOLLAR___OnRelease_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 277;
        _SplusNVRAM.STATEVAR = (ushort) ( (((5 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 278;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 280;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 281;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN6_MUTE__DOLLAR___OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 287;
        _SplusNVRAM.STATEVAR = (ushort) ( (((6 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 288;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 290;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 291;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN6_MUTE__DOLLAR___OnRelease_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 295;
        _SplusNVRAM.STATEVAR = (ushort) ( (((6 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 296;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 298;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 299;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN7_MUTE__DOLLAR___OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 303;
        _SplusNVRAM.STATEVAR = (ushort) ( (((7 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 304;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 306;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 307;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN7_MUTE__DOLLAR___OnRelease_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 311;
        _SplusNVRAM.STATEVAR = (ushort) ( (((7 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 312;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 314;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 315;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN8_MUTE__DOLLAR___OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 319;
        _SplusNVRAM.STATEVAR = (ushort) ( (((8 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 320;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 322;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 323;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN8_MUTE__DOLLAR___OnRelease_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 327;
        _SplusNVRAM.STATEVAR = (ushort) ( (((8 + _SplusNVRAM.OFFSET) - 1) + 32) ) ; 
        __context__.SourceCodeLine = 328;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 330;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 331;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MASTEROUT_MUTE__DOLLAR___OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 336;
        _SplusNVRAM.STATEVAR = (ushort) ( 97 ) ; 
        __context__.SourceCodeLine = 337;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 339;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 340;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MASTEROUT_MUTE__DOLLAR___OnRelease_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 344;
        _SplusNVRAM.STATEVAR = (ushort) ( 97 ) ; 
        __context__.SourceCodeLine = 345;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 347;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 348;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN1_VOL__DOLLAR___OnChange_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 355;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN1_VOL != CHAN1_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 357;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN1_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 359;
                _SplusNVRAM.XOKCHAN1_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 360;
                _SplusNVRAM.STATEVAR = (ushort) ( ((1 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 361;
                _SplusNVRAM.CHAN1_VOL = (ushort) ( CHAN1_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 362;
                CHAN1_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN1_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 363;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN1_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 364;
                _SplusNVRAM.XOKCHAN1_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN2_VOL__DOLLAR___OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 370;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN2_VOL != CHAN2_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 372;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN2_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 374;
                _SplusNVRAM.XOKCHAN2_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 375;
                _SplusNVRAM.CHAN2_VOL = (ushort) ( CHAN2_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 376;
                CHAN2_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN2_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 377;
                _SplusNVRAM.STATEVAR = (ushort) ( ((2 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 378;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN2_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 379;
                _SplusNVRAM.XOKCHAN2_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN3_VOL__DOLLAR___OnChange_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 386;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN3_VOL != CHAN3_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 388;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN3_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 390;
                _SplusNVRAM.XOKCHAN3_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 391;
                _SplusNVRAM.CHAN3_VOL = (ushort) ( CHAN3_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 392;
                CHAN3_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN3_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 393;
                _SplusNVRAM.STATEVAR = (ushort) ( ((3 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 394;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN3_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 395;
                _SplusNVRAM.XOKCHAN3_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN4_VOL__DOLLAR___OnChange_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 401;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN4_VOL != CHAN4_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 403;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN4_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 405;
                _SplusNVRAM.XOKCHAN4_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 406;
                _SplusNVRAM.CHAN4_VOL = (ushort) ( CHAN4_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 407;
                CHAN4_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN4_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 408;
                _SplusNVRAM.STATEVAR = (ushort) ( ((4 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 409;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN4_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 410;
                _SplusNVRAM.XOKCHAN4_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN5_VOL__DOLLAR___OnChange_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 416;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN5_VOL != CHAN5_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 418;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN5_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 420;
                _SplusNVRAM.XOKCHAN5_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 421;
                _SplusNVRAM.CHAN5_VOL = (ushort) ( CHAN5_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 422;
                CHAN5_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN5_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 423;
                _SplusNVRAM.STATEVAR = (ushort) ( ((5 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 424;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN5_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 425;
                _SplusNVRAM.XOKCHAN5_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN6_VOL__DOLLAR___OnChange_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 431;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN6_VOL != CHAN6_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 433;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN6_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 435;
                _SplusNVRAM.XOKCHAN6_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 436;
                _SplusNVRAM.CHAN6_VOL = (ushort) ( CHAN6_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 437;
                CHAN6_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN6_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 438;
                _SplusNVRAM.STATEVAR = (ushort) ( ((6 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 439;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN6_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 440;
                _SplusNVRAM.XOKCHAN6_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN7_VOL__DOLLAR___OnChange_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 446;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN7_VOL != CHAN7_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 448;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN7_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 450;
                _SplusNVRAM.XOKCHAN7_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 451;
                _SplusNVRAM.CHAN7_VOL = (ushort) ( CHAN7_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 452;
                CHAN7_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN7_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 453;
                _SplusNVRAM.STATEVAR = (ushort) ( ((7 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 454;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN7_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 455;
                _SplusNVRAM.XOKCHAN7_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHAN8_VOL__DOLLAR___OnChange_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 461;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN8_VOL != CHAN8_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 463;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN8_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 465;
                _SplusNVRAM.XOKCHAN8_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 466;
                _SplusNVRAM.CHAN8_VOL = (ushort) ( CHAN8_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 467;
                CHAN8_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN8_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 468;
                _SplusNVRAM.STATEVAR = (ushort) ( ((8 + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 469;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN8_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 470;
                _SplusNVRAM.XOKCHAN8_VOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MASTERVOL__DOLLAR___OnChange_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 477;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.MASTERVOL != MASTERVOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 479;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKMASTERVOL)  ) ) 
                { 
                __context__.SourceCodeLine = 481;
                _SplusNVRAM.XOKMASTERVOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 482;
                _SplusNVRAM.MASTERVOL = (ushort) ( MASTERVOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 483;
                MASTERVOL_FB__DOLLAR__  .Value = (ushort) ( MASTERVOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 484;
                _SplusNVRAM.STATEVAR = (ushort) ( 96 ) ; 
                __context__.SourceCodeLine = 485;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( MASTERVOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 486;
                _SplusNVRAM.XOKMASTERVOL = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 493;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 495;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 496;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 498;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 500;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 501;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 503;
                        _SplusNVRAM.SV = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 505;
                        if ( Functions.TestForTrue  ( ( (Functions.BoolToInt ( _SplusNVRAM.SV >= 32 ) & Functions.BoolToInt (_SplusNVRAM.SV != 96)))  ) ) 
                            { 
                            __context__.SourceCodeLine = 507;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((1 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                {
                                __context__.SourceCodeLine = 508;
                                CHAN1_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 509;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((2 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 510;
                                    CHAN2_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 511;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((3 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 512;
                                        CHAN3_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 513;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((4 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 514;
                                            CHAN4_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 515;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((5 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 516;
                                                CHAN5_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 517;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((6 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 518;
                                                    CHAN6_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 519;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((7 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 520;
                                                        CHAN7_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 521;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((8 + _SplusNVRAM.OFFSET) - 1) + 32) == _SplusNVRAM.SV))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 522;
                                                            CHAN8_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 523;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (97 == _SplusNVRAM.SV))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 524;
                                                                MASTEROUT_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                                }
                                                            
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 529;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((1 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                { 
                                __context__.SourceCodeLine = 531;
                                _SplusNVRAM.CHAN1_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 532;
                                CHAN1_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN1_VOL ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 534;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((2 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 536;
                                    _SplusNVRAM.CHAN2_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 537;
                                    CHAN2_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN2_VOL ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 539;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((3 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 541;
                                        _SplusNVRAM.CHAN3_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        __context__.SourceCodeLine = 542;
                                        CHAN3_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN3_VOL ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 544;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((4 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 546;
                                            _SplusNVRAM.CHAN4_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                            __context__.SourceCodeLine = 547;
                                            CHAN4_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN4_VOL ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 549;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((5 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 551;
                                                _SplusNVRAM.CHAN5_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                __context__.SourceCodeLine = 552;
                                                CHAN5_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN5_VOL ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 554;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((6 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 556;
                                                    _SplusNVRAM.CHAN6_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                    __context__.SourceCodeLine = 557;
                                                    CHAN6_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN6_VOL ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 559;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((7 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 561;
                                                        _SplusNVRAM.CHAN7_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                        __context__.SourceCodeLine = 562;
                                                        CHAN7_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN7_VOL ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 564;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((8 + _SplusNVRAM.OFFSET) - 1) == _SplusNVRAM.SV))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 566;
                                                            _SplusNVRAM.CHAN8_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                            __context__.SourceCodeLine = 567;
                                                            CHAN8_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN8_VOL ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 569;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (96 == _SplusNVRAM.SV))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 571;
                                                                _SplusNVRAM.MASTERVOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                                __context__.SourceCodeLine = 572;
                                                                MASTERVOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.MASTERVOL ) ; 
                                                                } 
                                                            
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 577;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 496;
                } 
            
            __context__.SourceCodeLine = 580;
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
        
        __context__.SourceCodeLine = 592;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 593;
        _SplusNVRAM.OFFSET = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 594;
        _SplusNVRAM.XOKFEEDBACK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 595;
        _SplusNVRAM.XOKMASTERVOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 596;
        _SplusNVRAM.XOKCHAN1_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 597;
        _SplusNVRAM.XOKCHAN2_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 598;
        _SplusNVRAM.XOKCHAN3_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 599;
        _SplusNVRAM.XOKCHAN4_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 600;
        _SplusNVRAM.XOKCHAN5_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 601;
        _SplusNVRAM.XOKCHAN6_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 602;
        _SplusNVRAM.XOKCHAN7_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 603;
        _SplusNVRAM.XOKCHAN8_VOL = (ushort) ( 1 ) ; 
        
        
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
    _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    _SplusNVRAM.TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    
    ENABLE_FEEDBACK__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_FEEDBACK__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_FEEDBACK__DOLLAR____DigitalInput__, ENABLE_FEEDBACK__DOLLAR__ );
    
    DISABLE_FEEDBACK__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( DISABLE_FEEDBACK__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( DISABLE_FEEDBACK__DOLLAR____DigitalInput__, DISABLE_FEEDBACK__DOLLAR__ );
    
    CHAN1_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN1_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN1_MUTE__DOLLAR____DigitalInput__, CHAN1_MUTE__DOLLAR__ );
    
    CHAN2_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN2_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN2_MUTE__DOLLAR____DigitalInput__, CHAN2_MUTE__DOLLAR__ );
    
    CHAN3_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN3_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN3_MUTE__DOLLAR____DigitalInput__, CHAN3_MUTE__DOLLAR__ );
    
    CHAN4_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN4_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN4_MUTE__DOLLAR____DigitalInput__, CHAN4_MUTE__DOLLAR__ );
    
    CHAN5_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN5_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN5_MUTE__DOLLAR____DigitalInput__, CHAN5_MUTE__DOLLAR__ );
    
    CHAN6_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN6_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN6_MUTE__DOLLAR____DigitalInput__, CHAN6_MUTE__DOLLAR__ );
    
    CHAN7_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN7_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN7_MUTE__DOLLAR____DigitalInput__, CHAN7_MUTE__DOLLAR__ );
    
    CHAN8_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHAN8_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHAN8_MUTE__DOLLAR____DigitalInput__, CHAN8_MUTE__DOLLAR__ );
    
    MASTEROUT_MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( MASTEROUT_MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( MASTEROUT_MUTE__DOLLAR____DigitalInput__, MASTEROUT_MUTE__DOLLAR__ );
    
    CHAN1_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN1_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN1_MUTE_FB__DOLLAR____DigitalOutput__, CHAN1_MUTE_FB__DOLLAR__ );
    
    CHAN2_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN2_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN2_MUTE_FB__DOLLAR____DigitalOutput__, CHAN2_MUTE_FB__DOLLAR__ );
    
    CHAN3_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN3_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN3_MUTE_FB__DOLLAR____DigitalOutput__, CHAN3_MUTE_FB__DOLLAR__ );
    
    CHAN4_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN4_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN4_MUTE_FB__DOLLAR____DigitalOutput__, CHAN4_MUTE_FB__DOLLAR__ );
    
    CHAN5_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN5_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN5_MUTE_FB__DOLLAR____DigitalOutput__, CHAN5_MUTE_FB__DOLLAR__ );
    
    CHAN6_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN6_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN6_MUTE_FB__DOLLAR____DigitalOutput__, CHAN6_MUTE_FB__DOLLAR__ );
    
    CHAN7_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN7_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN7_MUTE_FB__DOLLAR____DigitalOutput__, CHAN7_MUTE_FB__DOLLAR__ );
    
    CHAN8_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHAN8_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHAN8_MUTE_FB__DOLLAR____DigitalOutput__, CHAN8_MUTE_FB__DOLLAR__ );
    
    MASTEROUT_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( MASTEROUT_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( MASTEROUT_MUTE_FB__DOLLAR____DigitalOutput__, MASTEROUT_MUTE_FB__DOLLAR__ );
    
    CHAN_OFFSET__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_OFFSET__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN_OFFSET__DOLLAR____AnalogSerialInput__, CHAN_OFFSET__DOLLAR__ );
    
    CHAN1_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN1_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN1_VOL__DOLLAR____AnalogSerialInput__, CHAN1_VOL__DOLLAR__ );
    
    CHAN2_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN2_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN2_VOL__DOLLAR____AnalogSerialInput__, CHAN2_VOL__DOLLAR__ );
    
    CHAN3_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN3_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN3_VOL__DOLLAR____AnalogSerialInput__, CHAN3_VOL__DOLLAR__ );
    
    CHAN4_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN4_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN4_VOL__DOLLAR____AnalogSerialInput__, CHAN4_VOL__DOLLAR__ );
    
    CHAN5_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN5_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN5_VOL__DOLLAR____AnalogSerialInput__, CHAN5_VOL__DOLLAR__ );
    
    CHAN6_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN6_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN6_VOL__DOLLAR____AnalogSerialInput__, CHAN6_VOL__DOLLAR__ );
    
    CHAN7_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN7_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN7_VOL__DOLLAR____AnalogSerialInput__, CHAN7_VOL__DOLLAR__ );
    
    CHAN8_VOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN8_VOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN8_VOL__DOLLAR____AnalogSerialInput__, CHAN8_VOL__DOLLAR__ );
    
    MASTERVOL__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( MASTERVOL__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( MASTERVOL__DOLLAR____AnalogSerialInput__, MASTERVOL__DOLLAR__ );
    
    CHAN1_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN1_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN1_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN1_VOL_FB__DOLLAR__ );
    
    CHAN2_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN2_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN2_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN2_VOL_FB__DOLLAR__ );
    
    CHAN3_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN3_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN3_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN3_VOL_FB__DOLLAR__ );
    
    CHAN4_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN4_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN4_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN4_VOL_FB__DOLLAR__ );
    
    CHAN5_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN5_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN5_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN5_VOL_FB__DOLLAR__ );
    
    CHAN6_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN6_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN6_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN6_VOL_FB__DOLLAR__ );
    
    CHAN7_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN7_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN7_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN7_VOL_FB__DOLLAR__ );
    
    CHAN8_VOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHAN8_VOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHAN8_VOL_FB__DOLLAR____AnalogSerialOutput__, CHAN8_VOL_FB__DOLLAR__ );
    
    MASTERVOL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( MASTERVOL_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( MASTERVOL_FB__DOLLAR____AnalogSerialOutput__, MASTERVOL_FB__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    CHAN_OFFSET__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_OFFSET__DOLLAR___OnChange_0, false ) );
    ENABLE_FEEDBACK__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLE_FEEDBACK__DOLLAR___OnPush_1, false ) );
    DISABLE_FEEDBACK__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISABLE_FEEDBACK__DOLLAR___OnPush_2, false ) );
    CHAN1_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN1_MUTE__DOLLAR___OnPush_3, false ) );
    CHAN1_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN1_MUTE__DOLLAR___OnRelease_4, false ) );
    CHAN2_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN2_MUTE__DOLLAR___OnPush_5, false ) );
    CHAN2_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN2_MUTE__DOLLAR___OnRelease_6, false ) );
    CHAN3_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN3_MUTE__DOLLAR___OnPush_7, false ) );
    CHAN3_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN3_MUTE__DOLLAR___OnRelease_8, false ) );
    CHAN4_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN4_MUTE__DOLLAR___OnPush_9, false ) );
    CHAN4_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN4_MUTE__DOLLAR___OnRelease_10, false ) );
    CHAN5_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN5_MUTE__DOLLAR___OnPush_11, false ) );
    CHAN5_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN5_MUTE__DOLLAR___OnRelease_12, false ) );
    CHAN6_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN6_MUTE__DOLLAR___OnPush_13, false ) );
    CHAN6_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN6_MUTE__DOLLAR___OnRelease_14, false ) );
    CHAN7_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN7_MUTE__DOLLAR___OnPush_15, false ) );
    CHAN7_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN7_MUTE__DOLLAR___OnRelease_16, false ) );
    CHAN8_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHAN8_MUTE__DOLLAR___OnPush_17, false ) );
    CHAN8_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CHAN8_MUTE__DOLLAR___OnRelease_18, false ) );
    MASTEROUT_MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( MASTEROUT_MUTE__DOLLAR___OnPush_19, false ) );
    MASTEROUT_MUTE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( MASTEROUT_MUTE__DOLLAR___OnRelease_20, false ) );
    CHAN1_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN1_VOL__DOLLAR___OnChange_21, false ) );
    CHAN2_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN2_VOL__DOLLAR___OnChange_22, false ) );
    CHAN3_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN3_VOL__DOLLAR___OnChange_23, false ) );
    CHAN4_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN4_VOL__DOLLAR___OnChange_24, false ) );
    CHAN5_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN5_VOL__DOLLAR___OnChange_25, false ) );
    CHAN6_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN6_VOL__DOLLAR___OnChange_26, false ) );
    CHAN7_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN7_VOL__DOLLAR___OnChange_27, false ) );
    CHAN8_VOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN8_VOL__DOLLAR___OnChange_28, false ) );
    MASTERVOL__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( MASTERVOL__DOLLAR___OnChange_29, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_30, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_N_GAIN_8_CHAN_BASIC ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint ENABLE_FEEDBACK__DOLLAR____DigitalInput__ = 0;
const uint DISABLE_FEEDBACK__DOLLAR____DigitalInput__ = 1;
const uint CHAN1_MUTE__DOLLAR____DigitalInput__ = 2;
const uint CHAN2_MUTE__DOLLAR____DigitalInput__ = 3;
const uint CHAN3_MUTE__DOLLAR____DigitalInput__ = 4;
const uint CHAN4_MUTE__DOLLAR____DigitalInput__ = 5;
const uint CHAN5_MUTE__DOLLAR____DigitalInput__ = 6;
const uint CHAN6_MUTE__DOLLAR____DigitalInput__ = 7;
const uint CHAN7_MUTE__DOLLAR____DigitalInput__ = 8;
const uint CHAN8_MUTE__DOLLAR____DigitalInput__ = 9;
const uint MASTEROUT_MUTE__DOLLAR____DigitalInput__ = 10;
const uint CHAN_OFFSET__DOLLAR____AnalogSerialInput__ = 0;
const uint CHAN1_VOL__DOLLAR____AnalogSerialInput__ = 1;
const uint CHAN2_VOL__DOLLAR____AnalogSerialInput__ = 2;
const uint CHAN3_VOL__DOLLAR____AnalogSerialInput__ = 3;
const uint CHAN4_VOL__DOLLAR____AnalogSerialInput__ = 4;
const uint CHAN5_VOL__DOLLAR____AnalogSerialInput__ = 5;
const uint CHAN6_VOL__DOLLAR____AnalogSerialInput__ = 6;
const uint CHAN7_VOL__DOLLAR____AnalogSerialInput__ = 7;
const uint CHAN8_VOL__DOLLAR____AnalogSerialInput__ = 8;
const uint MASTERVOL__DOLLAR____AnalogSerialInput__ = 9;
const uint RX__DOLLAR____AnalogSerialInput__ = 10;
const uint CHAN1_MUTE_FB__DOLLAR____DigitalOutput__ = 0;
const uint CHAN2_MUTE_FB__DOLLAR____DigitalOutput__ = 1;
const uint CHAN3_MUTE_FB__DOLLAR____DigitalOutput__ = 2;
const uint CHAN4_MUTE_FB__DOLLAR____DigitalOutput__ = 3;
const uint CHAN5_MUTE_FB__DOLLAR____DigitalOutput__ = 4;
const uint CHAN6_MUTE_FB__DOLLAR____DigitalOutput__ = 5;
const uint CHAN7_MUTE_FB__DOLLAR____DigitalOutput__ = 6;
const uint CHAN8_MUTE_FB__DOLLAR____DigitalOutput__ = 7;
const uint MASTEROUT_MUTE_FB__DOLLAR____DigitalOutput__ = 8;
const uint CHAN1_VOL_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint CHAN2_VOL_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint CHAN3_VOL_FB__DOLLAR____AnalogSerialOutput__ = 2;
const uint CHAN4_VOL_FB__DOLLAR____AnalogSerialOutput__ = 3;
const uint CHAN5_VOL_FB__DOLLAR____AnalogSerialOutput__ = 4;
const uint CHAN6_VOL_FB__DOLLAR____AnalogSerialOutput__ = 5;
const uint CHAN7_VOL_FB__DOLLAR____AnalogSerialOutput__ = 6;
const uint CHAN8_VOL_FB__DOLLAR____AnalogSerialOutput__ = 7;
const uint MASTERVOL_FB__DOLLAR____AnalogSerialOutput__ = 8;
const uint TX__DOLLAR____AnalogSerialOutput__ = 9;
const uint OBJECTID__DOLLAR____Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort OFFSET = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort FEEDBACK = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort STATEVAR = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort SV = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort STATEVARSUB = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort STATEVARUNSUB = 0;
            [SplusStructAttribute(6, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(7, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort CHAN1_VOL = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort CHAN2_VOL = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort CHAN3_VOL = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort CHAN4_VOL = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort CHAN5_VOL = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort CHAN6_VOL = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort CHAN7_VOL = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort CHAN8_VOL = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort MASTERVOL = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort XOKFEEDBACK = 0;
            [SplusStructAttribute(19, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(21, false, true)]
            public ushort XOKCHAN1_VOL = 0;
            [SplusStructAttribute(22, false, true)]
            public ushort XOKCHAN2_VOL = 0;
            [SplusStructAttribute(23, false, true)]
            public ushort XOKCHAN3_VOL = 0;
            [SplusStructAttribute(24, false, true)]
            public ushort XOKCHAN4_VOL = 0;
            [SplusStructAttribute(25, false, true)]
            public ushort XOKCHAN5_VOL = 0;
            [SplusStructAttribute(26, false, true)]
            public ushort XOKCHAN6_VOL = 0;
            [SplusStructAttribute(27, false, true)]
            public ushort XOKCHAN7_VOL = 0;
            [SplusStructAttribute(28, false, true)]
            public ushort XOKCHAN8_VOL = 0;
            [SplusStructAttribute(29, false, true)]
            public ushort XOKMASTERVOL = 0;
            [SplusStructAttribute(30, false, true)]
            public CrestronString TEMPSTRING;
            
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
