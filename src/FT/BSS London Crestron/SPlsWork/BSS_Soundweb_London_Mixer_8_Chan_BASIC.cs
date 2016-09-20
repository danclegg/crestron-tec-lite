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

namespace UserModule_BSS_SOUNDWEB_LONDON_MIXER_8_CHAN_BASIC
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_MIXER_8_CHAN_BASIC : SplusObject
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
        Crestron.Logos.SplusObjects.StringInput RX__DOLLAR__;
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
            
            __context__.SourceCodeLine = 120;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 121;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 122;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 129;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 130;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 131;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 134;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 136;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 138;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object CHAN_OFFSET__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 148;
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
            
            __context__.SourceCodeLine = 152;
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
        
            
            __context__.SourceCodeLine = 154;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKFEEDBACK)  ) ) 
                { 
                __context__.SourceCodeLine = 156;
                _SplusNVRAM.XOKFEEDBACK = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 157;
                _SplusNVRAM.FEEDBACK = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 159;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)8; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 161;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
                    __context__.SourceCodeLine = 162;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 163;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( (((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                    __context__.SourceCodeLine = 164;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                    __context__.SourceCodeLine = 159;
                    } 
                
                __context__.SourceCodeLine = 167;
                _SplusNVRAM.STATEVARSUB = (ushort) ( 20001 ) ; 
                __context__.SourceCodeLine = 168;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 169;
                _SplusNVRAM.STATEVARSUB = (ushort) ( 20000 ) ; 
                __context__.SourceCodeLine = 170;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 171;
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
        
        __context__.SourceCodeLine = 178;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKFEEDBACK)  ) ) 
            { 
            __context__.SourceCodeLine = 180;
            _SplusNVRAM.XOKFEEDBACK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 181;
            _SplusNVRAM.FEEDBACK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 183;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)8; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 185;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
                __context__.SourceCodeLine = 186;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 187;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 188;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 183;
                } 
            
            __context__.SourceCodeLine = 191;
            _SplusNVRAM.STATEVARSUB = (ushort) ( 20001 ) ; 
            __context__.SourceCodeLine = 192;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 193;
            _SplusNVRAM.STATEVARSUB = (ushort) ( 20000 ) ; 
            __context__.SourceCodeLine = 194;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
            __context__.SourceCodeLine = 195;
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
        
        __context__.SourceCodeLine = 202;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((1 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 203;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 205;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 206;
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
        
        __context__.SourceCodeLine = 210;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((1 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 211;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 213;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 214;
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
        
        __context__.SourceCodeLine = 219;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((2 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 220;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 222;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 223;
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
        
        __context__.SourceCodeLine = 227;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((2 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 228;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 230;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 231;
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
        
        __context__.SourceCodeLine = 236;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((3 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 237;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 239;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 240;
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
        
        __context__.SourceCodeLine = 244;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((3 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 245;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 247;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 248;
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
        
        __context__.SourceCodeLine = 253;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((4 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 254;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 256;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 257;
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
        
        __context__.SourceCodeLine = 261;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((4 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 262;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 264;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 265;
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
        
        __context__.SourceCodeLine = 270;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((5 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 271;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 273;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 274;
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
        
        __context__.SourceCodeLine = 278;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((5 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 279;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 281;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 282;
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
        
        __context__.SourceCodeLine = 288;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((6 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 289;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 291;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 292;
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
        
        __context__.SourceCodeLine = 296;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((6 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 297;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 299;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 300;
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
        
        __context__.SourceCodeLine = 304;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((7 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 305;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 307;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 308;
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
        
        __context__.SourceCodeLine = 312;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((7 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 313;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 315;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 316;
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
        
        __context__.SourceCodeLine = 320;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((8 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 321;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 323;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 324;
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
        
        __context__.SourceCodeLine = 328;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((8 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) ) ; 
        __context__.SourceCodeLine = 329;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 331;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 332;
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
        
        __context__.SourceCodeLine = 337;
        _SplusNVRAM.STATEVAR = (ushort) ( 20001 ) ; 
        __context__.SourceCodeLine = 338;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 340;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 341;
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
        
        __context__.SourceCodeLine = 345;
        _SplusNVRAM.STATEVAR = (ushort) ( 20001 ) ; 
        __context__.SourceCodeLine = 346;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 348;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 349;
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
        
        __context__.SourceCodeLine = 356;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN1_VOL != CHAN1_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 358;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN1_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 360;
                _SplusNVRAM.XOKCHAN1_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 361;
                _SplusNVRAM.STATEVAR = (ushort) ( (((1 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 362;
                _SplusNVRAM.CHAN1_VOL = (ushort) ( CHAN1_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 363;
                CHAN1_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN1_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 364;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN1_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 365;
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
        
        __context__.SourceCodeLine = 371;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN2_VOL != CHAN2_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 373;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN2_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 375;
                _SplusNVRAM.XOKCHAN2_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 376;
                _SplusNVRAM.CHAN2_VOL = (ushort) ( CHAN2_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 377;
                CHAN2_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN2_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 378;
                _SplusNVRAM.STATEVAR = (ushort) ( (((2 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 379;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN2_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 380;
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
        
        __context__.SourceCodeLine = 387;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN3_VOL != CHAN3_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 389;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN3_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 391;
                _SplusNVRAM.XOKCHAN3_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 392;
                _SplusNVRAM.CHAN3_VOL = (ushort) ( CHAN3_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 393;
                CHAN3_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN3_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 394;
                _SplusNVRAM.STATEVAR = (ushort) ( (((3 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 395;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN3_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 396;
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
        
        __context__.SourceCodeLine = 402;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN4_VOL != CHAN4_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 404;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN4_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 406;
                _SplusNVRAM.XOKCHAN4_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 407;
                _SplusNVRAM.CHAN4_VOL = (ushort) ( CHAN4_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 408;
                CHAN4_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN4_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 409;
                _SplusNVRAM.STATEVAR = (ushort) ( (((4 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 410;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN4_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 411;
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
        
        __context__.SourceCodeLine = 417;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN5_VOL != CHAN5_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 419;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN5_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 421;
                _SplusNVRAM.XOKCHAN5_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 422;
                _SplusNVRAM.CHAN5_VOL = (ushort) ( CHAN5_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 423;
                CHAN5_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN5_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 424;
                _SplusNVRAM.STATEVAR = (ushort) ( (((5 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 425;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN5_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 426;
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
        
        __context__.SourceCodeLine = 432;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN6_VOL != CHAN6_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 434;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN6_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 436;
                _SplusNVRAM.XOKCHAN6_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 437;
                _SplusNVRAM.CHAN6_VOL = (ushort) ( CHAN6_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 438;
                CHAN6_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN6_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 439;
                _SplusNVRAM.STATEVAR = (ushort) ( (((6 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 440;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN6_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 441;
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
        
        __context__.SourceCodeLine = 447;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN7_VOL != CHAN7_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 449;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN7_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 451;
                _SplusNVRAM.XOKCHAN7_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 452;
                _SplusNVRAM.CHAN7_VOL = (ushort) ( CHAN7_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 453;
                CHAN7_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN7_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 454;
                _SplusNVRAM.STATEVAR = (ushort) ( (((7 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 455;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN7_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 456;
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
        
        __context__.SourceCodeLine = 462;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CHAN8_VOL != CHAN8_VOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 464;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKCHAN8_VOL)  ) ) 
                { 
                __context__.SourceCodeLine = 466;
                _SplusNVRAM.XOKCHAN8_VOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 467;
                _SplusNVRAM.CHAN8_VOL = (ushort) ( CHAN8_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 468;
                CHAN8_VOL_FB__DOLLAR__  .Value = (ushort) ( CHAN8_VOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 469;
                _SplusNVRAM.STATEVAR = (ushort) ( (((8 + _SplusNVRAM.OFFSET) - 1) * 100) ) ; 
                __context__.SourceCodeLine = 470;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHAN8_VOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 471;
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
        
        __context__.SourceCodeLine = 478;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.MASTERVOL != MASTERVOL__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 480;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKMASTERVOL)  ) ) 
                { 
                __context__.SourceCodeLine = 482;
                _SplusNVRAM.XOKMASTERVOL = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 483;
                _SplusNVRAM.MASTERVOL = (ushort) ( MASTERVOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 484;
                MASTERVOL_FB__DOLLAR__  .Value = (ushort) ( MASTERVOL__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 485;
                _SplusNVRAM.STATEVAR = (ushort) ( 20000 ) ; 
                __context__.SourceCodeLine = 486;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( MASTERVOL__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 487;
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
        
        __context__.SourceCodeLine = 494;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 496;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 497;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 499;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 501;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 502;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 504;
                        _SplusNVRAM.SV = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 506;
                        if ( Functions.TestForTrue  ( ( Mod( _SplusNVRAM.SV , 100 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 508;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((1 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                {
                                __context__.SourceCodeLine = 509;
                                CHAN1_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 510;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((2 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 511;
                                    CHAN2_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 512;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((3 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 513;
                                        CHAN3_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 514;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((4 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 515;
                                            CHAN4_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 516;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((5 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 517;
                                                CHAN5_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                }
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 518;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((6 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 519;
                                                    CHAN6_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                    }
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 520;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((7 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 521;
                                                        CHAN7_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                        }
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 522;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (((((8 + _SplusNVRAM.OFFSET) - 1) * 100) + 1) == _SplusNVRAM.SV))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 523;
                                                            CHAN8_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                                            }
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 524;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (20001 == _SplusNVRAM.SV))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 525;
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
                            __context__.SourceCodeLine = 530;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((1 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                { 
                                __context__.SourceCodeLine = 532;
                                _SplusNVRAM.CHAN1_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 533;
                                CHAN1_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN1_VOL ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 535;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((2 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 537;
                                    _SplusNVRAM.CHAN2_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 538;
                                    CHAN2_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN2_VOL ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 540;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((3 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 542;
                                        _SplusNVRAM.CHAN3_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        __context__.SourceCodeLine = 543;
                                        CHAN3_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN3_VOL ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 545;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((4 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 547;
                                            _SplusNVRAM.CHAN4_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                            __context__.SourceCodeLine = 548;
                                            CHAN4_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN4_VOL ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 550;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((5 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 552;
                                                _SplusNVRAM.CHAN5_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                __context__.SourceCodeLine = 553;
                                                CHAN5_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN5_VOL ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 555;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((6 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 557;
                                                    _SplusNVRAM.CHAN6_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                    __context__.SourceCodeLine = 558;
                                                    CHAN6_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN6_VOL ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 560;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((7 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 562;
                                                        _SplusNVRAM.CHAN7_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                        __context__.SourceCodeLine = 563;
                                                        CHAN7_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN7_VOL ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 565;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((((8 + _SplusNVRAM.OFFSET) - 1) * 100) == _SplusNVRAM.SV))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 567;
                                                            _SplusNVRAM.CHAN8_VOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                            __context__.SourceCodeLine = 568;
                                                            CHAN8_VOL_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.CHAN8_VOL ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 570;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (20000 == _SplusNVRAM.SV))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 572;
                                                                _SplusNVRAM.MASTERVOL = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                                                __context__.SourceCodeLine = 573;
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
                    
                    __context__.SourceCodeLine = 578;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 497;
                } 
            
            __context__.SourceCodeLine = 581;
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
        
        __context__.SourceCodeLine = 593;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 594;
        _SplusNVRAM.OFFSET = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 595;
        _SplusNVRAM.XOKFEEDBACK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 596;
        _SplusNVRAM.XOKMASTERVOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 597;
        _SplusNVRAM.XOKCHAN1_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 598;
        _SplusNVRAM.XOKCHAN2_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 599;
        _SplusNVRAM.XOKCHAN3_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 600;
        _SplusNVRAM.XOKCHAN4_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 601;
        _SplusNVRAM.XOKCHAN5_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 602;
        _SplusNVRAM.XOKCHAN6_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 603;
        _SplusNVRAM.XOKCHAN7_VOL = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 604;
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
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
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

public UserModuleClass_BSS_SOUNDWEB_LONDON_MIXER_8_CHAN_BASIC ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


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
            public ushort XOKCHAN1_VOL = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort XOKCHAN2_VOL = 0;
            [SplusStructAttribute(21, false, true)]
            public ushort XOKCHAN3_VOL = 0;
            [SplusStructAttribute(22, false, true)]
            public ushort XOKCHAN4_VOL = 0;
            [SplusStructAttribute(23, false, true)]
            public ushort XOKCHAN5_VOL = 0;
            [SplusStructAttribute(24, false, true)]
            public ushort XOKCHAN6_VOL = 0;
            [SplusStructAttribute(25, false, true)]
            public ushort XOKCHAN7_VOL = 0;
            [SplusStructAttribute(26, false, true)]
            public ushort XOKCHAN8_VOL = 0;
            [SplusStructAttribute(27, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(28, false, true)]
            public ushort VOLUME = 0;
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
