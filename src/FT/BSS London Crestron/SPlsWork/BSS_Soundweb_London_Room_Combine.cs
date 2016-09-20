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

namespace UserModule_BSS_SOUNDWEB_LONDON_ROOM_COMBINE
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_ROOM_COMBINE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_FEEDBACK__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput DISABLE_FEEDBACK__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SOURCEMUTE_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> BGM_MUTE_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MASTERMUTE_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PARTITION__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHAN_OFFSET__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> SOURCEGAIN_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> BGM_GAIN_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> MASTERGAIN_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> BGM_INPUT_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> GROUP_RM__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SOURCEMUTE_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> BGM_MUTE_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MASTERMUTE_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PARTITION_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SOURCEGAIN_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> BGM_GAIN_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> MASTERGAIN_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> BGM_INPUT_RM_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> GROUP_RM_FB__DOLLAR__;
        UShortParameter MAX_ROOMS__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 170;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 171;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 172;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 180;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 181;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 182;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 185;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 187;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 189;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object CHAN_OFFSET__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 199;
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
            
            __context__.SourceCodeLine = 205;
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
        
            
            __context__.SourceCodeLine = 207;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKFEEDBACK)  ) ) 
                { 
                __context__.SourceCodeLine = 209;
                _SplusNVRAM.XOKFEEDBACK = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 210;
                _SplusNVRAM.FEEDBACK = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 212;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)MAX_ROOMS__DOLLAR__  .Value; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 214;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 256) ) ; 
                    __context__.SourceCodeLine = 215;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 216;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 258) ) ; 
                    __context__.SourceCodeLine = 217;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 218;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 254) ) ; 
                    __context__.SourceCodeLine = 219;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 221;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 255) ) ; 
                    __context__.SourceCodeLine = 222;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                    __context__.SourceCodeLine = 223;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 257) ) ; 
                    __context__.SourceCodeLine = 224;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                    __context__.SourceCodeLine = 225;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 252) ) ; 
                    __context__.SourceCodeLine = 226;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                    __context__.SourceCodeLine = 228;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 259) ) ; 
                    __context__.SourceCodeLine = 229;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 231;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) ) ; 
                    __context__.SourceCodeLine = 232;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 234;
                    _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 250) ) ; 
                    __context__.SourceCodeLine = 235;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                    __context__.SourceCodeLine = 212;
                    } 
                
                __context__.SourceCodeLine = 237;
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
        
        __context__.SourceCodeLine = 244;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKFEEDBACK)  ) ) 
            { 
            __context__.SourceCodeLine = 246;
            _SplusNVRAM.XOKFEEDBACK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 247;
            _SplusNVRAM.FEEDBACK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 249;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)MAX_ROOMS__DOLLAR__  .Value; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 251;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 256) ) ; 
                __context__.SourceCodeLine = 252;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 253;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 258) ) ; 
                __context__.SourceCodeLine = 254;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 255;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 254) ) ; 
                __context__.SourceCodeLine = 256;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 258;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 255) ) ; 
                __context__.SourceCodeLine = 259;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 260;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 257) ) ; 
                __context__.SourceCodeLine = 261;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 262;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 252) ) ; 
                __context__.SourceCodeLine = 263;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , "\u0000\u0000\u0000\u0000" ) ; 
                __context__.SourceCodeLine = 265;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 259) ) ; 
                __context__.SourceCodeLine = 266;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 268;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) ) ; 
                __context__.SourceCodeLine = 269;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 271;
                _SplusNVRAM.STATEVARSUB = (ushort) ( ((((_SplusNVRAM.I + _SplusNVRAM.OFFSET) - 1) * 50) + 250) ) ; 
                __context__.SourceCodeLine = 272;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 249;
                } 
            
            __context__.SourceCodeLine = 274;
            _SplusNVRAM.XOKFEEDBACK = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOURCEMUTE_RM__DOLLAR___OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 281;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 282;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 256) ) ; 
        __context__.SourceCodeLine = 284;
        if ( Functions.TestForTrue  ( ( SOURCEMUTE_RM_FB__DOLLAR__[ _SplusNVRAM.X ] .Value)  ) ) 
            {
            __context__.SourceCodeLine = 285;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 287;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        __context__.SourceCodeLine = 289;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 290;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BGM_MUTE_RM__DOLLAR___OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 307;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 308;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 258) ) ; 
        __context__.SourceCodeLine = 310;
        if ( Functions.TestForTrue  ( ( BGM_MUTE_RM_FB__DOLLAR__[ _SplusNVRAM.X ] .Value)  ) ) 
            {
            __context__.SourceCodeLine = 311;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 313;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
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

object MASTERMUTE_RM__DOLLAR___OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 333;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 334;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 254) ) ; 
        __context__.SourceCodeLine = 336;
        if ( Functions.TestForTrue  ( ( MASTERMUTE_RM_FB__DOLLAR__[ _SplusNVRAM.X ] .Value)  ) ) 
            {
            __context__.SourceCodeLine = 337;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 339;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        __context__.SourceCodeLine = 341;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 342;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOURCEGAIN_RM__DOLLAR___OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 359;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 361;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.SOURCEGAIN[ _SplusNVRAM.X ] != SOURCEGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 363;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSOURCEGAIN[ _SplusNVRAM.X ])  ) ) 
                { 
                __context__.SourceCodeLine = 365;
                _SplusNVRAM.XOKSOURCEGAIN [ _SplusNVRAM.X] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 366;
                _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 255) ) ; 
                __context__.SourceCodeLine = 367;
                _SplusNVRAM.SOURCEGAIN [ _SplusNVRAM.X] = (ushort) ( SOURCEGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 368;
                SOURCEGAIN_RM_FB__DOLLAR__ [ _SplusNVRAM.X]  .Value = (ushort) ( SOURCEGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 369;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( SOURCEGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue )) ) ; 
                __context__.SourceCodeLine = 370;
                _SplusNVRAM.XOKSOURCEGAIN [ _SplusNVRAM.X] = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BGM_GAIN_RM__DOLLAR___OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 377;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 379;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.BGM_GAIN[ _SplusNVRAM.X ] != BGM_GAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 381;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKBGM_GAIN[ _SplusNVRAM.X ])  ) ) 
                { 
                __context__.SourceCodeLine = 383;
                _SplusNVRAM.XOKBGM_GAIN [ _SplusNVRAM.X] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 384;
                _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 257) ) ; 
                __context__.SourceCodeLine = 385;
                _SplusNVRAM.BGM_GAIN [ _SplusNVRAM.X] = (ushort) ( BGM_GAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 386;
                BGM_GAIN_RM_FB__DOLLAR__ [ _SplusNVRAM.X]  .Value = (ushort) ( BGM_GAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 387;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( BGM_GAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue )) ) ; 
                __context__.SourceCodeLine = 388;
                _SplusNVRAM.XOKBGM_GAIN [ _SplusNVRAM.X] = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MASTERGAIN_RM__DOLLAR___OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 395;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 397;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.MASTERGAIN[ _SplusNVRAM.X ] != MASTERGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 399;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKMASTERGAIN[ _SplusNVRAM.X ])  ) ) 
                { 
                __context__.SourceCodeLine = 401;
                _SplusNVRAM.XOKMASTERGAIN [ _SplusNVRAM.X] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 402;
                _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 252) ) ; 
                __context__.SourceCodeLine = 403;
                _SplusNVRAM.MASTERGAIN [ _SplusNVRAM.X] = (ushort) ( MASTERGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 404;
                MASTERGAIN_RM_FB__DOLLAR__ [ _SplusNVRAM.X]  .Value = (ushort) ( MASTERGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 405;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( MASTERGAIN_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue )) ) ; 
                __context__.SourceCodeLine = 406;
                _SplusNVRAM.XOKMASTERGAIN [ _SplusNVRAM.X] = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BGM_INPUT_RM__DOLLAR___OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 414;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 415;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 259) ) ; 
        __context__.SourceCodeLine = 417;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( BGM_INPUT_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ) ) ; 
        __context__.SourceCodeLine = 419;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 420;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PARTITION__DOLLAR___OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 425;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 426;
        _SplusNVRAM.STATEVAR = (ushort) ( ((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) ) ; 
        __context__.SourceCodeLine = 428;
        if ( Functions.TestForTrue  ( ( PARTITION_FB__DOLLAR__[ _SplusNVRAM.X ] .Value)  ) ) 
            {
            __context__.SourceCodeLine = 429;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 431;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        __context__.SourceCodeLine = 433;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 434;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GROUP_RM__DOLLAR___OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 439;
        _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 440;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.X + _SplusNVRAM.OFFSET) - 1) * 50) + 250) ) ; 
        __context__.SourceCodeLine = 442;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( GROUP_RM__DOLLAR__[ _SplusNVRAM.X ] .UshortValue ) ) ) ; 
        __context__.SourceCodeLine = 444;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.FEEDBACK)  ) ) 
            {
            __context__.SourceCodeLine = 445;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 452;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 454;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 455;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 457;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 459;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 460;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 462;
                        _SplusNVRAM.SV = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 464;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SV < 49 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 465;
                            PARTITION_FB__DOLLAR__ [ ((_SplusNVRAM.SV + 1) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 466;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SV > 249 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 468;
                                _SplusNVRAM.SV_MOD = (ushort) ( Mod( _SplusNVRAM.SV , 50 ) ) ; 
                                __context__.SourceCodeLine = 470;
                                
                                    {
                                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)_SplusNVRAM.SV_MOD);
                                    
                                        { 
                                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 472;
                                            GROUP_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 200) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 473;
                                            SOURCEMUTE_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 206) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 474;
                                            BGM_MUTE_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 208) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 475;
                                            MASTERMUTE_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 204) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 478;
                                            _SplusNVRAM.SOURCEGAIN [ (((_SplusNVRAM.SV - 205) / 50) - _SplusNVRAM.OFFSET)] = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                            __context__.SourceCodeLine = 479;
                                            SOURCEGAIN_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 205) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( _SplusNVRAM.SOURCEGAIN[ (((_SplusNVRAM.SV - 205) / 50) - _SplusNVRAM.OFFSET) ] ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 483;
                                            _SplusNVRAM.BGM_GAIN [ (((_SplusNVRAM.SV - 207) / 50) - _SplusNVRAM.OFFSET)] = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                            __context__.SourceCodeLine = 484;
                                            BGM_GAIN_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 207) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( _SplusNVRAM.BGM_GAIN[ (((_SplusNVRAM.SV - 207) / 50) - _SplusNVRAM.OFFSET) ] ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 488;
                                            _SplusNVRAM.MASTERGAIN [ (((_SplusNVRAM.SV - 202) / 50) - _SplusNVRAM.OFFSET)] = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                            __context__.SourceCodeLine = 489;
                                            MASTERGAIN_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 202) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( _SplusNVRAM.MASTERGAIN[ (((_SplusNVRAM.SV - 202) / 50) - _SplusNVRAM.OFFSET) ] ) ; 
                                            } 
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                                            { 
                                            __context__.SourceCodeLine = 493;
                                            BGM_INPUT_RM_FB__DOLLAR__ [ (((_SplusNVRAM.SV - 209) / 50) - _SplusNVRAM.OFFSET)]  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                            } 
                                        
                                        } 
                                        
                                    }
                                    
                                
                                } 
                            
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 498;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 455;
                } 
            
            __context__.SourceCodeLine = 501;
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
        
        __context__.SourceCodeLine = 521;
        _SplusNVRAM.FEEDBACK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 523;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 524;
        _SplusNVRAM.OFFSET = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 525;
        _SplusNVRAM.XOKFEEDBACK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 526;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)8; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 528;
            _SplusNVRAM.XOKSOURCEGAIN [ _SplusNVRAM.I] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 526;
            } 
        
        __context__.SourceCodeLine = 530;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)8; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__2) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__2) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__2) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__2) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 532;
            _SplusNVRAM.XOKBGM_GAIN [ _SplusNVRAM.I] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 530;
            } 
        
        __context__.SourceCodeLine = 534;
        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__3 = (ushort)8; 
        int __FN_FORSTEP_VAL__3 = (int)1; 
        for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__3) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__3) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__3) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__3) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__3) 
            { 
            __context__.SourceCodeLine = 536;
            _SplusNVRAM.XOKMASTERGAIN [ _SplusNVRAM.I] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 534;
            } 
        
        
        
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
    _SplusNVRAM.SOURCEGAIN  = new ushort[ 9 ];
    _SplusNVRAM.BGM_GAIN  = new ushort[ 9 ];
    _SplusNVRAM.MASTERGAIN  = new ushort[ 9 ];
    _SplusNVRAM.XOKSOURCEGAIN  = new ushort[ 9 ];
    _SplusNVRAM.XOKBGM_GAIN  = new ushort[ 9 ];
    _SplusNVRAM.XOKMASTERGAIN  = new ushort[ 9 ];
    _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    _SplusNVRAM.TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    
    ENABLE_FEEDBACK__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_FEEDBACK__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_FEEDBACK__DOLLAR____DigitalInput__, ENABLE_FEEDBACK__DOLLAR__ );
    
    DISABLE_FEEDBACK__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( DISABLE_FEEDBACK__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( DISABLE_FEEDBACK__DOLLAR____DigitalInput__, DISABLE_FEEDBACK__DOLLAR__ );
    
    SOURCEMUTE_RM__DOLLAR__ = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        SOURCEMUTE_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SOURCEMUTE_RM__DOLLAR____DigitalInput__ + i, SOURCEMUTE_RM__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( SOURCEMUTE_RM__DOLLAR____DigitalInput__ + i, SOURCEMUTE_RM__DOLLAR__[i+1] );
    }
    
    BGM_MUTE_RM__DOLLAR__ = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        BGM_MUTE_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( BGM_MUTE_RM__DOLLAR____DigitalInput__ + i, BGM_MUTE_RM__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( BGM_MUTE_RM__DOLLAR____DigitalInput__ + i, BGM_MUTE_RM__DOLLAR__[i+1] );
    }
    
    MASTERMUTE_RM__DOLLAR__ = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        MASTERMUTE_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MASTERMUTE_RM__DOLLAR____DigitalInput__ + i, MASTERMUTE_RM__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( MASTERMUTE_RM__DOLLAR____DigitalInput__ + i, MASTERMUTE_RM__DOLLAR__[i+1] );
    }
    
    PARTITION__DOLLAR__ = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        PARTITION__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PARTITION__DOLLAR____DigitalInput__ + i, PARTITION__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( PARTITION__DOLLAR____DigitalInput__ + i, PARTITION__DOLLAR__[i+1] );
    }
    
    SOURCEMUTE_RM_FB__DOLLAR__ = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        SOURCEMUTE_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCEMUTE_RM_FB__DOLLAR____DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SOURCEMUTE_RM_FB__DOLLAR____DigitalOutput__ + i, SOURCEMUTE_RM_FB__DOLLAR__[i+1] );
    }
    
    BGM_MUTE_RM_FB__DOLLAR__ = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        BGM_MUTE_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( BGM_MUTE_RM_FB__DOLLAR____DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( BGM_MUTE_RM_FB__DOLLAR____DigitalOutput__ + i, BGM_MUTE_RM_FB__DOLLAR__[i+1] );
    }
    
    MASTERMUTE_RM_FB__DOLLAR__ = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        MASTERMUTE_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MASTERMUTE_RM_FB__DOLLAR____DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MASTERMUTE_RM_FB__DOLLAR____DigitalOutput__ + i, MASTERMUTE_RM_FB__DOLLAR__[i+1] );
    }
    
    PARTITION_FB__DOLLAR__ = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        PARTITION_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PARTITION_FB__DOLLAR____DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PARTITION_FB__DOLLAR____DigitalOutput__ + i, PARTITION_FB__DOLLAR__[i+1] );
    }
    
    CHAN_OFFSET__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHAN_OFFSET__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHAN_OFFSET__DOLLAR____AnalogSerialInput__, CHAN_OFFSET__DOLLAR__ );
    
    SOURCEGAIN_RM__DOLLAR__ = new InOutArray<AnalogInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        SOURCEGAIN_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( SOURCEGAIN_RM__DOLLAR____AnalogSerialInput__ + i, SOURCEGAIN_RM__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( SOURCEGAIN_RM__DOLLAR____AnalogSerialInput__ + i, SOURCEGAIN_RM__DOLLAR__[i+1] );
    }
    
    BGM_GAIN_RM__DOLLAR__ = new InOutArray<AnalogInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        BGM_GAIN_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( BGM_GAIN_RM__DOLLAR____AnalogSerialInput__ + i, BGM_GAIN_RM__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( BGM_GAIN_RM__DOLLAR____AnalogSerialInput__ + i, BGM_GAIN_RM__DOLLAR__[i+1] );
    }
    
    MASTERGAIN_RM__DOLLAR__ = new InOutArray<AnalogInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        MASTERGAIN_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( MASTERGAIN_RM__DOLLAR____AnalogSerialInput__ + i, MASTERGAIN_RM__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( MASTERGAIN_RM__DOLLAR____AnalogSerialInput__ + i, MASTERGAIN_RM__DOLLAR__[i+1] );
    }
    
    BGM_INPUT_RM__DOLLAR__ = new InOutArray<AnalogInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        BGM_INPUT_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( BGM_INPUT_RM__DOLLAR____AnalogSerialInput__ + i, BGM_INPUT_RM__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( BGM_INPUT_RM__DOLLAR____AnalogSerialInput__ + i, BGM_INPUT_RM__DOLLAR__[i+1] );
    }
    
    GROUP_RM__DOLLAR__ = new InOutArray<AnalogInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        GROUP_RM__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( GROUP_RM__DOLLAR____AnalogSerialInput__ + i, GROUP_RM__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( GROUP_RM__DOLLAR____AnalogSerialInput__ + i, GROUP_RM__DOLLAR__[i+1] );
    }
    
    SOURCEGAIN_RM_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        SOURCEGAIN_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCEGAIN_RM_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SOURCEGAIN_RM_FB__DOLLAR____AnalogSerialOutput__ + i, SOURCEGAIN_RM_FB__DOLLAR__[i+1] );
    }
    
    BGM_GAIN_RM_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        BGM_GAIN_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( BGM_GAIN_RM_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( BGM_GAIN_RM_FB__DOLLAR____AnalogSerialOutput__ + i, BGM_GAIN_RM_FB__DOLLAR__[i+1] );
    }
    
    MASTERGAIN_RM_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        MASTERGAIN_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( MASTERGAIN_RM_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( MASTERGAIN_RM_FB__DOLLAR____AnalogSerialOutput__ + i, MASTERGAIN_RM_FB__DOLLAR__[i+1] );
    }
    
    BGM_INPUT_RM_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        BGM_INPUT_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( BGM_INPUT_RM_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( BGM_INPUT_RM_FB__DOLLAR____AnalogSerialOutput__ + i, BGM_INPUT_RM_FB__DOLLAR__[i+1] );
    }
    
    GROUP_RM_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        GROUP_RM_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( GROUP_RM_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( GROUP_RM_FB__DOLLAR____AnalogSerialOutput__ + i, GROUP_RM_FB__DOLLAR__[i+1] );
    }
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    MAX_ROOMS__DOLLAR__ = new UShortParameter( MAX_ROOMS__DOLLAR____Parameter__, this );
    m_ParameterList.Add( MAX_ROOMS__DOLLAR____Parameter__, MAX_ROOMS__DOLLAR__ );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    CHAN_OFFSET__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHAN_OFFSET__DOLLAR___OnChange_0, false ) );
    ENABLE_FEEDBACK__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLE_FEEDBACK__DOLLAR___OnPush_1, false ) );
    DISABLE_FEEDBACK__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISABLE_FEEDBACK__DOLLAR___OnPush_2, false ) );
    for( uint i = 0; i < 8; i++ )
        SOURCEMUTE_RM__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCEMUTE_RM__DOLLAR___OnPush_3, false ) );
        
    for( uint i = 0; i < 8; i++ )
        BGM_MUTE_RM__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( BGM_MUTE_RM__DOLLAR___OnPush_4, false ) );
        
    for( uint i = 0; i < 8; i++ )
        MASTERMUTE_RM__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MASTERMUTE_RM__DOLLAR___OnPush_5, false ) );
        
    for( uint i = 0; i < 8; i++ )
        SOURCEGAIN_RM__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( SOURCEGAIN_RM__DOLLAR___OnChange_6, false ) );
        
    for( uint i = 0; i < 8; i++ )
        BGM_GAIN_RM__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( BGM_GAIN_RM__DOLLAR___OnChange_7, false ) );
        
    for( uint i = 0; i < 8; i++ )
        MASTERGAIN_RM__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( MASTERGAIN_RM__DOLLAR___OnChange_8, false ) );
        
    for( uint i = 0; i < 8; i++ )
        BGM_INPUT_RM__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( BGM_INPUT_RM__DOLLAR___OnChange_9, false ) );
        
    for( uint i = 0; i < 8; i++ )
        PARTITION__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PARTITION__DOLLAR___OnPush_10, false ) );
        
    for( uint i = 0; i < 8; i++ )
        GROUP_RM__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( GROUP_RM__DOLLAR___OnChange_11, false ) );
        
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_12, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_ROOM_COMBINE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint ENABLE_FEEDBACK__DOLLAR____DigitalInput__ = 0;
const uint DISABLE_FEEDBACK__DOLLAR____DigitalInput__ = 1;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint SOURCEMUTE_RM__DOLLAR____DigitalInput__ = 2;
const uint BGM_MUTE_RM__DOLLAR____DigitalInput__ = 10;
const uint MASTERMUTE_RM__DOLLAR____DigitalInput__ = 18;
const uint PARTITION__DOLLAR____DigitalInput__ = 26;
const uint CHAN_OFFSET__DOLLAR____AnalogSerialInput__ = 1;
const uint SOURCEGAIN_RM__DOLLAR____AnalogSerialInput__ = 2;
const uint BGM_GAIN_RM__DOLLAR____AnalogSerialInput__ = 10;
const uint MASTERGAIN_RM__DOLLAR____AnalogSerialInput__ = 18;
const uint BGM_INPUT_RM__DOLLAR____AnalogSerialInput__ = 26;
const uint GROUP_RM__DOLLAR____AnalogSerialInput__ = 34;
const uint SOURCEMUTE_RM_FB__DOLLAR____DigitalOutput__ = 0;
const uint BGM_MUTE_RM_FB__DOLLAR____DigitalOutput__ = 8;
const uint MASTERMUTE_RM_FB__DOLLAR____DigitalOutput__ = 16;
const uint PARTITION_FB__DOLLAR____DigitalOutput__ = 24;
const uint SOURCEGAIN_RM_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint BGM_GAIN_RM_FB__DOLLAR____AnalogSerialOutput__ = 9;
const uint MASTERGAIN_RM_FB__DOLLAR____AnalogSerialOutput__ = 17;
const uint BGM_INPUT_RM_FB__DOLLAR____AnalogSerialOutput__ = 25;
const uint GROUP_RM_FB__DOLLAR____AnalogSerialOutput__ = 33;
const uint MAX_ROOMS__DOLLAR____Parameter__ = 10;
const uint OBJECTID__DOLLAR____Parameter__ = 11;

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
            public ushort SV_MOD = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort STATEVARGAIN = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort STATEVARSUB = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort STATEVARUNSUB = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort X = 0;
            [SplusStructAttribute(9, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(10, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort [] SOURCEGAIN;
            [SplusStructAttribute(12, false, true)]
            public ushort [] BGM_GAIN;
            [SplusStructAttribute(13, false, true)]
            public ushort [] MASTERGAIN;
            [SplusStructAttribute(14, false, true)]
            public ushort [] XOKSOURCEGAIN;
            [SplusStructAttribute(15, false, true)]
            public ushort [] XOKBGM_GAIN;
            [SplusStructAttribute(16, false, true)]
            public ushort [] XOKMASTERGAIN;
            [SplusStructAttribute(17, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort XOKFEEDBACK = 0;
            [SplusStructAttribute(19, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(21, false, true)]
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
