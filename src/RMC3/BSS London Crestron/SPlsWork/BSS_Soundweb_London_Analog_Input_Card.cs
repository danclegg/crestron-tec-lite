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

namespace UserModule_BSS_SOUNDWEB_LONDON_ANALOG_INPUT_CARD
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_ANALOG_INPUT_CARD : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput METER_SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_1_PHANTOMSWITCHON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_2_PHANTOMSWITCHON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_3_PHANTOMSWITCHON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_4_PHANTOMSWITCHON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_1_MUTEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_1_MUTEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_1_MUTETOGGLE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_2_MUTEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_2_MUTEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_2_MUTETOGGLE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_3_MUTEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_3_MUTEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_3_MUTETOGGLE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_4_MUTEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_4_MUTEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput CHANNEL_4_MUTETOGGLE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_1_REFERENCE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_1_ATTACK__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_1_RELEASE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_1_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_2_REFERENCE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_2_ATTACK__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_2_RELEASE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_2_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_3_REFERENCE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_3_ATTACK__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_3_RELEASE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_3_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_4_REFERENCE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_4_ATTACK__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_4_RELEASE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_4_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_1_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_2_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_3_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput CHANNEL_4_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_1_METER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_1_REFERENCE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_1_ATTACK_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_1_RELEASE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_1_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_2_METER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_2_REFERENCE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_2_ATTACK_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_2_RELEASE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_2_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_3_METER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_3_REFERENCE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_3_ATTACK_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_3_RELEASE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_3_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_4_METER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_4_REFERENCE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_4_ATTACK_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_4_RELEASE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_4_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        UShortParameter METERRATE__DOLLAR__;
        UShortParameter CARD__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 238;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 239;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 240;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 247;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 248;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 249;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 252;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 254;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 256;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        private ushort WORDTOI (  SplusExecutionContext __context__, CrestronString SSOURCESTRING , ushort IHIGHBYTE , ushort ILOWBYTE ) 
            { 
            ushort IWORD = 0;
            
            
            __context__.SourceCodeLine = 263;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SSOURCESTRING , (int)( IHIGHBYTE ) ) != 65535) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( SSOURCESTRING , (int)( ILOWBYTE ) ) != 65535) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 264;
                IWORD = (ushort) ( ((Byte( SSOURCESTRING , (int)( IHIGHBYTE ) ) * 256) + Byte( SSOURCESTRING , (int)( ILOWBYTE ) )) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 266;
                IWORD = (ushort) ( 65535 ) ; 
                }
            
            __context__.SourceCodeLine = 267;
            return (ushort)( IWORD) ; 
            
            }
            
        object SUBSCRIBE__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 279;
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
            
            
            __context__.SourceCodeLine = 281;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 283;
                _SplusNVRAM.XSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 284;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)4; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 286;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 1) ) ) ) ; 
                    __context__.SourceCodeLine = 287;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 288;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 2) ) ) ) ; 
                    __context__.SourceCodeLine = 289;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 290;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 3) ) ) ) ; 
                    __context__.SourceCodeLine = 291;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 292;
                    MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 4) ) ) ) ; 
                    __context__.SourceCodeLine = 293;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 294;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 5) ) ) ) ; 
                    __context__.SourceCodeLine = 295;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 296;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (208 + (_SplusNVRAM.I - 1)) ) ) ) ; 
                    __context__.SourceCodeLine = 297;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 284;
                    } 
                
                __context__.SourceCodeLine = 300;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 301;
                _SplusNVRAM.XSUBSCRIBE = (ushort) ( 1 ) ; 
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
        
        __context__.SourceCodeLine = 310;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 312;
            _SplusNVRAM.XSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 313;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)4; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 315;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 1) ) ) ) ; 
                __context__.SourceCodeLine = 316;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 317;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 2) ) ) ) ; 
                __context__.SourceCodeLine = 318;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 319;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 3) ) ) ) ; 
                __context__.SourceCodeLine = 320;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 321;
                MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 4) ) ) ) ; 
                __context__.SourceCodeLine = 322;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 323;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 5) ) ) ) ; 
                __context__.SourceCodeLine = 324;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 325;
                MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (208 + (_SplusNVRAM.I - 1)) ) ) ) ; 
                __context__.SourceCodeLine = 326;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 313;
                } 
            
            __context__.SourceCodeLine = 329;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 330;
            _SplusNVRAM.XSUBSCRIBE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object METER_SUBSCRIBE__DOLLAR___OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 337;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_1__" , 20 , __SPLS_TMPVAR__WAITLABEL_1___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_1___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 339;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)4; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 341;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000{2}{3}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 0) ) ) , Functions.Chr (  (int) ( Functions.High( (ushort) METERRATE__DOLLAR__  .Value ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) METERRATE__DOLLAR__  .Value ) ) ) ) ; 
                __context__.SourceCodeLine = 342;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 339;
                } 
            
            __context__.SourceCodeLine = 345;
            _SplusNVRAM.METER_SUBSCRIBE = (ushort) ( METER_SUBSCRIBE__DOLLAR__  .Value ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object METER_SUBSCRIBE__DOLLAR___OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 354;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)4; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 356;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000{2}{3}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( (((_SplusNVRAM.I - 1) * 6) + 0) ) ) , Functions.Chr (  (int) ( Functions.High( (ushort) METERRATE__DOLLAR__  .Value ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) METERRATE__DOLLAR__  .Value ) ) ) ) ; 
            __context__.SourceCodeLine = 357;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 354;
            } 
        
        __context__.SourceCodeLine = 360;
        _SplusNVRAM.METER_SUBSCRIBE = (ushort) ( METER_SUBSCRIBE__DOLLAR__  .Value ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_REFERENCE__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 367;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 369;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_1_REFERENCE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 371;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_1_REFERENCE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 372;
            CHANNEL_1_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 373;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_1_REFERENCE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_ATTACK__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 381;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 383;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_1_ATTACK__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 385;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_1_ATTACK__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 386;
            CHANNEL_1_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 387;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_1_ATTACK__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_RELEASE__DOLLAR___OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 395;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 397;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_1_RELEASE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 399;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_1_RELEASE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 400;
            CHANNEL_1_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 401;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_1_RELEASE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_GAIN__DOLLAR___OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 409;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN1)  ) ) 
            { 
            __context__.SourceCodeLine = 411;
            _SplusNVRAM.XOKGAIN1 = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 412;
            _SplusNVRAM.STATEVARVALUE = (ushort) ( 4 ) ; 
            __context__.SourceCodeLine = 414;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_1_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
                { 
                __context__.SourceCodeLine = 416;
                _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_1_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 417;
                CHANNEL_1_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
                __context__.SourceCodeLine = 418;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_1_GAIN__DOLLAR__  .UshortValue )) ) ; 
                } 
            
            __context__.SourceCodeLine = 420;
            _SplusNVRAM.XOKGAIN1 = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_REFERENCE__DOLLAR___OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 428;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 7 ) ; 
        __context__.SourceCodeLine = 430;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_2_REFERENCE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 432;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_2_REFERENCE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 433;
            CHANNEL_2_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 434;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_2_REFERENCE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_ATTACK__DOLLAR___OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 441;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 8 ) ; 
        __context__.SourceCodeLine = 443;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_2_ATTACK__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 445;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_2_ATTACK__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 446;
            CHANNEL_2_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 447;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_2_ATTACK__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_RELEASE__DOLLAR___OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 455;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 9 ) ; 
        __context__.SourceCodeLine = 457;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_2_RELEASE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 459;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_2_RELEASE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 460;
            CHANNEL_2_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 461;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_2_RELEASE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_GAIN__DOLLAR___OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 468;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN2)  ) ) 
            { 
            __context__.SourceCodeLine = 470;
            _SplusNVRAM.XOKGAIN2 = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 472;
            _SplusNVRAM.STATEVARVALUE = (ushort) ( 10 ) ; 
            __context__.SourceCodeLine = 474;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_2_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
                { 
                __context__.SourceCodeLine = 476;
                _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_2_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 477;
                CHANNEL_2_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
                __context__.SourceCodeLine = 478;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_2_GAIN__DOLLAR__  .UshortValue )) ) ; 
                } 
            
            __context__.SourceCodeLine = 480;
            _SplusNVRAM.XOKGAIN2 = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_REFERENCE__DOLLAR___OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 488;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 13 ) ; 
        __context__.SourceCodeLine = 490;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_3_REFERENCE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 492;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_3_REFERENCE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 493;
            CHANNEL_3_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 494;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_3_REFERENCE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_ATTACK__DOLLAR___OnChange_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 502;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 14 ) ; 
        __context__.SourceCodeLine = 504;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_3_ATTACK__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 506;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_3_ATTACK__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 507;
            CHANNEL_3_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 508;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_3_ATTACK__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_RELEASE__DOLLAR___OnChange_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 516;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 15 ) ; 
        __context__.SourceCodeLine = 518;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_3_RELEASE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 520;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_3_RELEASE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 521;
            CHANNEL_3_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 522;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_3_RELEASE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_GAIN__DOLLAR___OnChange_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 529;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN3)  ) ) 
            { 
            __context__.SourceCodeLine = 531;
            _SplusNVRAM.XOKGAIN3 = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 533;
            _SplusNVRAM.STATEVARVALUE = (ushort) ( 16 ) ; 
            __context__.SourceCodeLine = 535;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_3_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
                { 
                __context__.SourceCodeLine = 537;
                _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_3_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 538;
                CHANNEL_3_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
                __context__.SourceCodeLine = 539;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_3_GAIN__DOLLAR__  .UshortValue )) ) ; 
                } 
            
            __context__.SourceCodeLine = 541;
            _SplusNVRAM.XOKGAIN3 = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_REFERENCE__DOLLAR___OnChange_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 549;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 19 ) ; 
        __context__.SourceCodeLine = 551;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_4_REFERENCE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 553;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_4_REFERENCE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 554;
            CHANNEL_4_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 555;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_4_REFERENCE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_ATTACK__DOLLAR___OnChange_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 563;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 20 ) ; 
        __context__.SourceCodeLine = 565;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_4_ATTACK__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 567;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_4_ATTACK__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 568;
            CHANNEL_4_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 569;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_4_ATTACK__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_RELEASE__DOLLAR___OnChange_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 577;
        _SplusNVRAM.STATEVARVALUE = (ushort) ( 21 ) ; 
        __context__.SourceCodeLine = 579;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_4_RELEASE__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
            { 
            __context__.SourceCodeLine = 581;
            _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_4_RELEASE__DOLLAR__  .UshortValue ) ; 
            __context__.SourceCodeLine = 582;
            CHANNEL_4_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
            __context__.SourceCodeLine = 583;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_4_RELEASE__DOLLAR__  .UshortValue )) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_GAIN__DOLLAR___OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 590;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN4)  ) ) 
            { 
            __context__.SourceCodeLine = 592;
            _SplusNVRAM.XOKGAIN4 = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 594;
            _SplusNVRAM.STATEVARVALUE = (ushort) ( 22 ) ; 
            __context__.SourceCodeLine = 596;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CHANNEL_4_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ]))  ) ) 
                { 
                __context__.SourceCodeLine = 598;
                _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARVALUE] = (ushort) ( CHANNEL_4_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 599;
                CHANNEL_4_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARVALUE ] ) ; 
                __context__.SourceCodeLine = 600;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARVALUE ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( CHANNEL_4_GAIN__DOLLAR__  .UshortValue )) ) ; 
                } 
            
            __context__.SourceCodeLine = 602;
            _SplusNVRAM.XOKGAIN4 = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_PHANTOMSWITCHON__DOLLAR___OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 613;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 614;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 615;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 617;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 618;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR___OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 625;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 5 ) ; 
        __context__.SourceCodeLine = 626;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 628;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 630;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 631;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_PHANTOMSWITCHON__DOLLAR___OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 638;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 11 ) ; 
        __context__.SourceCodeLine = 639;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 640;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 642;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 643;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR___OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 650;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 11 ) ; 
        __context__.SourceCodeLine = 651;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 653;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 655;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 656;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_PHANTOMSWITCHON__DOLLAR___OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 663;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 17 ) ; 
        __context__.SourceCodeLine = 664;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 665;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 667;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 668;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR___OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 675;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 17 ) ; 
        __context__.SourceCodeLine = 676;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 678;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 680;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 681;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_PHANTOMSWITCHON__DOLLAR___OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 688;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 23 ) ; 
        __context__.SourceCodeLine = 689;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 690;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 692;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 693;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR___OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 700;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 23 ) ; 
        __context__.SourceCodeLine = 701;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 703;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 705;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0000{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 706;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_MUTEON__DOLLAR___OnPush_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 711;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 208 ) ; 
        __context__.SourceCodeLine = 712;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 714;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 716;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 717;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_MUTEOFF__DOLLAR___OnPush_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 723;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 208 ) ; 
        __context__.SourceCodeLine = 724;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 726;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 728;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 729;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_1_MUTETOGGLE__DOLLAR___OnPush_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 735;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 208 ) ; 
        __context__.SourceCodeLine = 736;
        if ( Functions.TestForTrue  ( ( CHANNEL_1_MUTE_FB__DOLLAR__  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 738;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 740;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 742;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 743;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 748;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 750;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 752;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 753;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_MUTEON__DOLLAR___OnPush_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 759;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 209 ) ; 
        __context__.SourceCodeLine = 760;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 762;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 764;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 765;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_MUTEOFF__DOLLAR___OnPush_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 771;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 209 ) ; 
        __context__.SourceCodeLine = 772;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 774;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 776;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 777;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_2_MUTETOGGLE__DOLLAR___OnPush_33 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 783;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 209 ) ; 
        __context__.SourceCodeLine = 784;
        if ( Functions.TestForTrue  ( ( CHANNEL_2_MUTE_FB__DOLLAR__  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 786;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 788;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 790;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 791;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 796;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 798;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 800;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 801;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_MUTEON__DOLLAR___OnPush_34 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 807;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 210 ) ; 
        __context__.SourceCodeLine = 808;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 810;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 812;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 813;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_MUTEOFF__DOLLAR___OnPush_35 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 819;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 210 ) ; 
        __context__.SourceCodeLine = 820;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 822;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 824;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 825;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_3_MUTETOGGLE__DOLLAR___OnPush_36 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 830;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 210 ) ; 
        __context__.SourceCodeLine = 831;
        if ( Functions.TestForTrue  ( ( CHANNEL_3_MUTE_FB__DOLLAR__  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 833;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 835;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 837;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 838;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 843;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 845;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 847;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 848;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_MUTEON__DOLLAR___OnPush_37 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 854;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 211 ) ; 
        __context__.SourceCodeLine = 855;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 857;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 859;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 860;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_MUTEOFF__DOLLAR___OnPush_38 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 865;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 211 ) ; 
        __context__.SourceCodeLine = 866;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
        __context__.SourceCodeLine = 868;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 870;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 871;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_4_MUTETOGGLE__DOLLAR___OnPush_39 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 876;
        _SplusNVRAM.STATEVARPHANTOM = (ushort) ( 211 ) ; 
        __context__.SourceCodeLine = 877;
        if ( Functions.TestForTrue  ( ( CHANNEL_4_MUTE_FB__DOLLAR__  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 879;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 881;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 883;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 884;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 889;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
            __context__.SourceCodeLine = 891;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 893;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003\u0000\u0000{0}\u0007{1}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", Functions.Chr (  (int) ( CARD__DOLLAR__  .Value ) ) , Functions.Chr (  (int) ( _SplusNVRAM.STATEVARPHANTOM ) ) ) ; 
                __context__.SourceCodeLine = 894;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_40 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort FIRST = 0;
        
        ushort SECOND = 0;
        
        
        __context__.SourceCodeLine = 912;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 914;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 915;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 917;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 919;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 920;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 2 ) ) == "\u0000\u0000") ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( _SplusNVRAM.TEMPSTRING , (int)( 8 ) ) == CARD__DOLLAR__  .Value) )) ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 922;
                        _SplusNVRAM.STATEVARRECEIVE = (ushort) ( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 9 ) , (ushort)( 10 ) ) ) ; 
                        __context__.SourceCodeLine = 924;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.STATEVARRECEIVE == 2000) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.STATEVARRECEIVE == 2001) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.STATEVARRECEIVE == 2002) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.STATEVARRECEIVE == 2003) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 926;
                            switch ((int)_SplusNVRAM.STATEVARRECEIVE)
                            
                                { 
                                case 2000 : 
                                
                                    { 
                                    __context__.SourceCodeLine = 930;
                                    CHANNEL_1_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    __context__.SourceCodeLine = 931;
                                    break ; 
                                    } 
                                
                                goto case 2001 ;
                                case 2001 : 
                                
                                    { 
                                    __context__.SourceCodeLine = 935;
                                    CHANNEL_2_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    __context__.SourceCodeLine = 936;
                                    break ; 
                                    } 
                                
                                goto case 2002 ;
                                case 2002 : 
                                
                                    { 
                                    __context__.SourceCodeLine = 940;
                                    CHANNEL_3_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    __context__.SourceCodeLine = 941;
                                    break ; 
                                    } 
                                
                                goto case 2003 ;
                                case 2003 : 
                                
                                    { 
                                    __context__.SourceCodeLine = 945;
                                    CHANNEL_4_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                    __context__.SourceCodeLine = 946;
                                    break ; 
                                    } 
                                
                                break;
                                } 
                                
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 950;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( _SplusNVRAM.STATEVARRECEIVE , 6 ) == 5))  ) ) 
                                { 
                                __context__.SourceCodeLine = 952;
                                if ( Functions.TestForTrue  ( ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 954;
                                    FIRST = (ushort) ( ((_SplusNVRAM.STATEVARRECEIVE / 6) + 5) ) ; 
                                    __context__.SourceCodeLine = 955;
                                    SECOND = (ushort) ( ((_SplusNVRAM.STATEVARRECEIVE / 6) + 1) ) ; 
                                    __context__.SourceCodeLine = 956;
                                    
                                        {
                                        int __SPLS_TMPVAR__SWTCH_1__ = ((int)FIRST);
                                        
                                            { 
                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 958;
                                                CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 959;
                                                CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 960;
                                                CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 961;
                                                CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 962;
                                                CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 963;
                                                CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 964;
                                                CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 965;
                                                CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            } 
                                            
                                        }
                                        
                                    
                                    __context__.SourceCodeLine = 967;
                                    
                                        {
                                        int __SPLS_TMPVAR__SWTCH_2__ = ((int)SECOND);
                                        
                                            { 
                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 969;
                                                CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 970;
                                                CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 971;
                                                CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 972;
                                                CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 973;
                                                CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 974;
                                                CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 975;
                                                CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 976;
                                                CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            } 
                                            
                                        }
                                        
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 981;
                                    FIRST = (ushort) ( ((_SplusNVRAM.STATEVARRECEIVE / 6) + 1) ) ; 
                                    __context__.SourceCodeLine = 982;
                                    SECOND = (ushort) ( ((_SplusNVRAM.STATEVARRECEIVE / 6) + 5) ) ; 
                                    __context__.SourceCodeLine = 983;
                                    
                                        {
                                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)FIRST);
                                        
                                            { 
                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 985;
                                                CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 986;
                                                CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 987;
                                                CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 988;
                                                CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 5) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 989;
                                                CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 6) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 990;
                                                CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 7) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 991;
                                                CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 8) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 992;
                                                CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            } 
                                            
                                        }
                                        
                                    
                                    __context__.SourceCodeLine = 994;
                                    
                                        {
                                        int __SPLS_TMPVAR__SWTCH_4__ = ((int)SECOND);
                                        
                                            { 
                                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 996;
                                                CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 997;
                                                CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 998;
                                                CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 4) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 999;
                                                CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 1000;
                                                CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 6) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 1001;
                                                CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 7) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 1002;
                                                CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 8) ) ) ) 
                                                {
                                                __context__.SourceCodeLine = 1003;
                                                CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__  .Value = (ushort) ( 1 ) ; 
                                                }
                                            
                                            } 
                                            
                                        }
                                        
                                    
                                    } 
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1010;
                                _SplusNVRAM.VOLUMEINPUT [ _SplusNVRAM.STATEVARRECEIVE] = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 1012;
                                
                                    {
                                    int __SPLS_TMPVAR__SWTCH_5__ = ((int)_SplusNVRAM.STATEVARRECEIVE);
                                    
                                        { 
                                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 0) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1014;
                                            CHANNEL_1_METER_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1015;
                                            CHANNEL_1_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1016;
                                            CHANNEL_1_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 3) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1017;
                                            CHANNEL_1_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 4) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1018;
                                            CHANNEL_1_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 6) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1020;
                                            CHANNEL_2_METER_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 7) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1021;
                                            CHANNEL_2_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 8) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1022;
                                            CHANNEL_2_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 9) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1023;
                                            CHANNEL_2_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 10) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1024;
                                            CHANNEL_2_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 12) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1026;
                                            CHANNEL_3_METER_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 13) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1027;
                                            CHANNEL_3_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 14) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1028;
                                            CHANNEL_3_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 15) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1029;
                                            CHANNEL_3_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 16) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1030;
                                            CHANNEL_3_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 18) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1032;
                                            CHANNEL_4_METER_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 19) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1033;
                                            CHANNEL_4_REFERENCE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 20) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1034;
                                            CHANNEL_4_ATTACK_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 21) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1035;
                                            CHANNEL_4_RELEASE_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 22) ) ) ) 
                                            {
                                            __context__.SourceCodeLine = 1036;
                                            CHANNEL_4_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT[ _SplusNVRAM.STATEVARRECEIVE ] ) ; 
                                            }
                                        
                                        } 
                                        
                                    }
                                    
                                
                                } 
                            
                            }
                        
                        } 
                    
                    __context__.SourceCodeLine = 1042;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 915;
                } 
            
            __context__.SourceCodeLine = 1045;
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
        
        __context__.SourceCodeLine = 1064;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1065;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1066;
        _SplusNVRAM.XSUBSCRIBE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1067;
        _SplusNVRAM.XOKGAIN1 = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1068;
        _SplusNVRAM.XOKGAIN2 = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1069;
        _SplusNVRAM.XOKGAIN3 = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1070;
        _SplusNVRAM.XOKGAIN4 = (ushort) ( 1 ) ; 
        
        
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
    _SplusNVRAM.VOLUMEINPUT  = new ushort[ 41 ];
    _SplusNVRAM.TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    METER_SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( METER_SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( METER_SUBSCRIBE__DOLLAR____DigitalInput__, METER_SUBSCRIBE__DOLLAR__ );
    
    CHANNEL_1_PHANTOMSWITCHON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_1_PHANTOMSWITCHON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_1_PHANTOMSWITCHON__DOLLAR____DigitalInput__, CHANNEL_1_PHANTOMSWITCHON__DOLLAR__ );
    
    CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR__ );
    
    CHANNEL_2_PHANTOMSWITCHON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_2_PHANTOMSWITCHON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_2_PHANTOMSWITCHON__DOLLAR____DigitalInput__, CHANNEL_2_PHANTOMSWITCHON__DOLLAR__ );
    
    CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR__ );
    
    CHANNEL_3_PHANTOMSWITCHON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_3_PHANTOMSWITCHON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_3_PHANTOMSWITCHON__DOLLAR____DigitalInput__, CHANNEL_3_PHANTOMSWITCHON__DOLLAR__ );
    
    CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR__ );
    
    CHANNEL_4_PHANTOMSWITCHON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_4_PHANTOMSWITCHON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_4_PHANTOMSWITCHON__DOLLAR____DigitalInput__, CHANNEL_4_PHANTOMSWITCHON__DOLLAR__ );
    
    CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__, CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR__ );
    
    CHANNEL_1_MUTEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_1_MUTEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_1_MUTEON__DOLLAR____DigitalInput__, CHANNEL_1_MUTEON__DOLLAR__ );
    
    CHANNEL_1_MUTEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_1_MUTEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_1_MUTEOFF__DOLLAR____DigitalInput__, CHANNEL_1_MUTEOFF__DOLLAR__ );
    
    CHANNEL_1_MUTETOGGLE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_1_MUTETOGGLE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_1_MUTETOGGLE__DOLLAR____DigitalInput__, CHANNEL_1_MUTETOGGLE__DOLLAR__ );
    
    CHANNEL_2_MUTEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_2_MUTEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_2_MUTEON__DOLLAR____DigitalInput__, CHANNEL_2_MUTEON__DOLLAR__ );
    
    CHANNEL_2_MUTEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_2_MUTEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_2_MUTEOFF__DOLLAR____DigitalInput__, CHANNEL_2_MUTEOFF__DOLLAR__ );
    
    CHANNEL_2_MUTETOGGLE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_2_MUTETOGGLE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_2_MUTETOGGLE__DOLLAR____DigitalInput__, CHANNEL_2_MUTETOGGLE__DOLLAR__ );
    
    CHANNEL_3_MUTEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_3_MUTEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_3_MUTEON__DOLLAR____DigitalInput__, CHANNEL_3_MUTEON__DOLLAR__ );
    
    CHANNEL_3_MUTEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_3_MUTEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_3_MUTEOFF__DOLLAR____DigitalInput__, CHANNEL_3_MUTEOFF__DOLLAR__ );
    
    CHANNEL_3_MUTETOGGLE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_3_MUTETOGGLE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_3_MUTETOGGLE__DOLLAR____DigitalInput__, CHANNEL_3_MUTETOGGLE__DOLLAR__ );
    
    CHANNEL_4_MUTEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_4_MUTEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_4_MUTEON__DOLLAR____DigitalInput__, CHANNEL_4_MUTEON__DOLLAR__ );
    
    CHANNEL_4_MUTEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_4_MUTEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_4_MUTEOFF__DOLLAR____DigitalInput__, CHANNEL_4_MUTEOFF__DOLLAR__ );
    
    CHANNEL_4_MUTETOGGLE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( CHANNEL_4_MUTETOGGLE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( CHANNEL_4_MUTETOGGLE__DOLLAR____DigitalInput__, CHANNEL_4_MUTETOGGLE__DOLLAR__ );
    
    CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR__ );
    
    CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR__ );
    
    CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR__ );
    
    CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR__ );
    
    CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR__ );
    
    CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR__ );
    
    CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__, CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR__ );
    
    CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__, CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR__ );
    
    CHANNEL_1_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_1_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_1_MUTE_FB__DOLLAR____DigitalOutput__, CHANNEL_1_MUTE_FB__DOLLAR__ );
    
    CHANNEL_2_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_2_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_2_MUTE_FB__DOLLAR____DigitalOutput__, CHANNEL_2_MUTE_FB__DOLLAR__ );
    
    CHANNEL_3_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_3_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_3_MUTE_FB__DOLLAR____DigitalOutput__, CHANNEL_3_MUTE_FB__DOLLAR__ );
    
    CHANNEL_4_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_4_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( CHANNEL_4_MUTE_FB__DOLLAR____DigitalOutput__, CHANNEL_4_MUTE_FB__DOLLAR__ );
    
    CHANNEL_1_REFERENCE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_1_REFERENCE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_1_REFERENCE__DOLLAR____AnalogSerialInput__, CHANNEL_1_REFERENCE__DOLLAR__ );
    
    CHANNEL_1_ATTACK__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_1_ATTACK__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_1_ATTACK__DOLLAR____AnalogSerialInput__, CHANNEL_1_ATTACK__DOLLAR__ );
    
    CHANNEL_1_RELEASE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_1_RELEASE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_1_RELEASE__DOLLAR____AnalogSerialInput__, CHANNEL_1_RELEASE__DOLLAR__ );
    
    CHANNEL_1_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_1_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_1_GAIN__DOLLAR____AnalogSerialInput__, CHANNEL_1_GAIN__DOLLAR__ );
    
    CHANNEL_2_REFERENCE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_2_REFERENCE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_2_REFERENCE__DOLLAR____AnalogSerialInput__, CHANNEL_2_REFERENCE__DOLLAR__ );
    
    CHANNEL_2_ATTACK__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_2_ATTACK__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_2_ATTACK__DOLLAR____AnalogSerialInput__, CHANNEL_2_ATTACK__DOLLAR__ );
    
    CHANNEL_2_RELEASE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_2_RELEASE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_2_RELEASE__DOLLAR____AnalogSerialInput__, CHANNEL_2_RELEASE__DOLLAR__ );
    
    CHANNEL_2_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_2_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_2_GAIN__DOLLAR____AnalogSerialInput__, CHANNEL_2_GAIN__DOLLAR__ );
    
    CHANNEL_3_REFERENCE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_3_REFERENCE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_3_REFERENCE__DOLLAR____AnalogSerialInput__, CHANNEL_3_REFERENCE__DOLLAR__ );
    
    CHANNEL_3_ATTACK__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_3_ATTACK__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_3_ATTACK__DOLLAR____AnalogSerialInput__, CHANNEL_3_ATTACK__DOLLAR__ );
    
    CHANNEL_3_RELEASE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_3_RELEASE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_3_RELEASE__DOLLAR____AnalogSerialInput__, CHANNEL_3_RELEASE__DOLLAR__ );
    
    CHANNEL_3_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_3_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_3_GAIN__DOLLAR____AnalogSerialInput__, CHANNEL_3_GAIN__DOLLAR__ );
    
    CHANNEL_4_REFERENCE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_4_REFERENCE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_4_REFERENCE__DOLLAR____AnalogSerialInput__, CHANNEL_4_REFERENCE__DOLLAR__ );
    
    CHANNEL_4_ATTACK__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_4_ATTACK__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_4_ATTACK__DOLLAR____AnalogSerialInput__, CHANNEL_4_ATTACK__DOLLAR__ );
    
    CHANNEL_4_RELEASE__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_4_RELEASE__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_4_RELEASE__DOLLAR____AnalogSerialInput__, CHANNEL_4_RELEASE__DOLLAR__ );
    
    CHANNEL_4_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_4_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_4_GAIN__DOLLAR____AnalogSerialInput__, CHANNEL_4_GAIN__DOLLAR__ );
    
    CHANNEL_1_METER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_1_METER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_1_METER_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_1_METER_FB__DOLLAR__ );
    
    CHANNEL_1_REFERENCE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_1_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_1_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_1_REFERENCE_FB__DOLLAR__ );
    
    CHANNEL_1_ATTACK_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_1_ATTACK_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_1_ATTACK_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_1_ATTACK_FB__DOLLAR__ );
    
    CHANNEL_1_RELEASE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_1_RELEASE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_1_RELEASE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_1_RELEASE_FB__DOLLAR__ );
    
    CHANNEL_1_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_1_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_1_GAIN_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_1_GAIN_FB__DOLLAR__ );
    
    CHANNEL_2_METER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_2_METER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_2_METER_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_2_METER_FB__DOLLAR__ );
    
    CHANNEL_2_REFERENCE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_2_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_2_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_2_REFERENCE_FB__DOLLAR__ );
    
    CHANNEL_2_ATTACK_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_2_ATTACK_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_2_ATTACK_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_2_ATTACK_FB__DOLLAR__ );
    
    CHANNEL_2_RELEASE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_2_RELEASE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_2_RELEASE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_2_RELEASE_FB__DOLLAR__ );
    
    CHANNEL_2_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_2_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_2_GAIN_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_2_GAIN_FB__DOLLAR__ );
    
    CHANNEL_3_METER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_3_METER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_3_METER_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_3_METER_FB__DOLLAR__ );
    
    CHANNEL_3_REFERENCE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_3_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_3_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_3_REFERENCE_FB__DOLLAR__ );
    
    CHANNEL_3_ATTACK_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_3_ATTACK_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_3_ATTACK_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_3_ATTACK_FB__DOLLAR__ );
    
    CHANNEL_3_RELEASE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_3_RELEASE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_3_RELEASE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_3_RELEASE_FB__DOLLAR__ );
    
    CHANNEL_3_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_3_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_3_GAIN_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_3_GAIN_FB__DOLLAR__ );
    
    CHANNEL_4_METER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_4_METER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_4_METER_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_4_METER_FB__DOLLAR__ );
    
    CHANNEL_4_REFERENCE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_4_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_4_REFERENCE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_4_REFERENCE_FB__DOLLAR__ );
    
    CHANNEL_4_ATTACK_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_4_ATTACK_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_4_ATTACK_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_4_ATTACK_FB__DOLLAR__ );
    
    CHANNEL_4_RELEASE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_4_RELEASE_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_4_RELEASE_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_4_RELEASE_FB__DOLLAR__ );
    
    CHANNEL_4_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_4_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_4_GAIN_FB__DOLLAR____AnalogSerialOutput__, CHANNEL_4_GAIN_FB__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    METERRATE__DOLLAR__ = new UShortParameter( METERRATE__DOLLAR____Parameter__, this );
    m_ParameterList.Add( METERRATE__DOLLAR____Parameter__, METERRATE__DOLLAR__ );
    
    CARD__DOLLAR__ = new UShortParameter( CARD__DOLLAR____Parameter__, this );
    m_ParameterList.Add( CARD__DOLLAR____Parameter__, CARD__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_1___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_1___CallbackFn );
    
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_0, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_1, false ) );
    METER_SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( METER_SUBSCRIBE__DOLLAR___OnPush_2, false ) );
    METER_SUBSCRIBE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( METER_SUBSCRIBE__DOLLAR___OnRelease_3, false ) );
    CHANNEL_1_REFERENCE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_1_REFERENCE__DOLLAR___OnChange_4, false ) );
    CHANNEL_1_ATTACK__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_1_ATTACK__DOLLAR___OnChange_5, false ) );
    CHANNEL_1_RELEASE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_1_RELEASE__DOLLAR___OnChange_6, false ) );
    CHANNEL_1_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_1_GAIN__DOLLAR___OnChange_7, false ) );
    CHANNEL_2_REFERENCE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_2_REFERENCE__DOLLAR___OnChange_8, false ) );
    CHANNEL_2_ATTACK__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_2_ATTACK__DOLLAR___OnChange_9, false ) );
    CHANNEL_2_RELEASE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_2_RELEASE__DOLLAR___OnChange_10, false ) );
    CHANNEL_2_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_2_GAIN__DOLLAR___OnChange_11, false ) );
    CHANNEL_3_REFERENCE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_3_REFERENCE__DOLLAR___OnChange_12, false ) );
    CHANNEL_3_ATTACK__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_3_ATTACK__DOLLAR___OnChange_13, false ) );
    CHANNEL_3_RELEASE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_3_RELEASE__DOLLAR___OnChange_14, false ) );
    CHANNEL_3_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_3_GAIN__DOLLAR___OnChange_15, false ) );
    CHANNEL_4_REFERENCE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_4_REFERENCE__DOLLAR___OnChange_16, false ) );
    CHANNEL_4_ATTACK__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_4_ATTACK__DOLLAR___OnChange_17, false ) );
    CHANNEL_4_RELEASE__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_4_RELEASE__DOLLAR___OnChange_18, false ) );
    CHANNEL_4_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_4_GAIN__DOLLAR___OnChange_19, false ) );
    CHANNEL_1_PHANTOMSWITCHON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_1_PHANTOMSWITCHON__DOLLAR___OnPush_20, false ) );
    CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR___OnPush_21, false ) );
    CHANNEL_2_PHANTOMSWITCHON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_2_PHANTOMSWITCHON__DOLLAR___OnPush_22, false ) );
    CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR___OnPush_23, false ) );
    CHANNEL_3_PHANTOMSWITCHON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_3_PHANTOMSWITCHON__DOLLAR___OnPush_24, false ) );
    CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR___OnPush_25, false ) );
    CHANNEL_4_PHANTOMSWITCHON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_4_PHANTOMSWITCHON__DOLLAR___OnPush_26, false ) );
    CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR___OnPush_27, false ) );
    CHANNEL_1_MUTEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_1_MUTEON__DOLLAR___OnPush_28, false ) );
    CHANNEL_1_MUTEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_1_MUTEOFF__DOLLAR___OnPush_29, false ) );
    CHANNEL_1_MUTETOGGLE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_1_MUTETOGGLE__DOLLAR___OnPush_30, false ) );
    CHANNEL_2_MUTEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_2_MUTEON__DOLLAR___OnPush_31, false ) );
    CHANNEL_2_MUTEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_2_MUTEOFF__DOLLAR___OnPush_32, false ) );
    CHANNEL_2_MUTETOGGLE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_2_MUTETOGGLE__DOLLAR___OnPush_33, false ) );
    CHANNEL_3_MUTEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_3_MUTEON__DOLLAR___OnPush_34, false ) );
    CHANNEL_3_MUTEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_3_MUTEOFF__DOLLAR___OnPush_35, false ) );
    CHANNEL_3_MUTETOGGLE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_3_MUTETOGGLE__DOLLAR___OnPush_36, false ) );
    CHANNEL_4_MUTEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_4_MUTEON__DOLLAR___OnPush_37, false ) );
    CHANNEL_4_MUTEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_4_MUTEOFF__DOLLAR___OnPush_38, false ) );
    CHANNEL_4_MUTETOGGLE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHANNEL_4_MUTETOGGLE__DOLLAR___OnPush_39, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_40, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_ANALOG_INPUT_CARD ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_1___Callback;


const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 0;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 1;
const uint METER_SUBSCRIBE__DOLLAR____DigitalInput__ = 2;
const uint CHANNEL_1_PHANTOMSWITCHON__DOLLAR____DigitalInput__ = 3;
const uint CHANNEL_1_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__ = 4;
const uint CHANNEL_2_PHANTOMSWITCHON__DOLLAR____DigitalInput__ = 5;
const uint CHANNEL_2_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__ = 6;
const uint CHANNEL_3_PHANTOMSWITCHON__DOLLAR____DigitalInput__ = 7;
const uint CHANNEL_3_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__ = 8;
const uint CHANNEL_4_PHANTOMSWITCHON__DOLLAR____DigitalInput__ = 9;
const uint CHANNEL_4_PHANTOMSWITCHOFF__DOLLAR____DigitalInput__ = 10;
const uint CHANNEL_1_MUTEON__DOLLAR____DigitalInput__ = 11;
const uint CHANNEL_1_MUTEOFF__DOLLAR____DigitalInput__ = 12;
const uint CHANNEL_1_MUTETOGGLE__DOLLAR____DigitalInput__ = 13;
const uint CHANNEL_2_MUTEON__DOLLAR____DigitalInput__ = 14;
const uint CHANNEL_2_MUTEOFF__DOLLAR____DigitalInput__ = 15;
const uint CHANNEL_2_MUTETOGGLE__DOLLAR____DigitalInput__ = 16;
const uint CHANNEL_3_MUTEON__DOLLAR____DigitalInput__ = 17;
const uint CHANNEL_3_MUTEOFF__DOLLAR____DigitalInput__ = 18;
const uint CHANNEL_3_MUTETOGGLE__DOLLAR____DigitalInput__ = 19;
const uint CHANNEL_4_MUTEON__DOLLAR____DigitalInput__ = 20;
const uint CHANNEL_4_MUTEOFF__DOLLAR____DigitalInput__ = 21;
const uint CHANNEL_4_MUTETOGGLE__DOLLAR____DigitalInput__ = 22;
const uint CHANNEL_1_REFERENCE__DOLLAR____AnalogSerialInput__ = 0;
const uint CHANNEL_1_ATTACK__DOLLAR____AnalogSerialInput__ = 1;
const uint CHANNEL_1_RELEASE__DOLLAR____AnalogSerialInput__ = 2;
const uint CHANNEL_1_GAIN__DOLLAR____AnalogSerialInput__ = 3;
const uint CHANNEL_2_REFERENCE__DOLLAR____AnalogSerialInput__ = 4;
const uint CHANNEL_2_ATTACK__DOLLAR____AnalogSerialInput__ = 5;
const uint CHANNEL_2_RELEASE__DOLLAR____AnalogSerialInput__ = 6;
const uint CHANNEL_2_GAIN__DOLLAR____AnalogSerialInput__ = 7;
const uint CHANNEL_3_REFERENCE__DOLLAR____AnalogSerialInput__ = 8;
const uint CHANNEL_3_ATTACK__DOLLAR____AnalogSerialInput__ = 9;
const uint CHANNEL_3_RELEASE__DOLLAR____AnalogSerialInput__ = 10;
const uint CHANNEL_3_GAIN__DOLLAR____AnalogSerialInput__ = 11;
const uint CHANNEL_4_REFERENCE__DOLLAR____AnalogSerialInput__ = 12;
const uint CHANNEL_4_ATTACK__DOLLAR____AnalogSerialInput__ = 13;
const uint CHANNEL_4_RELEASE__DOLLAR____AnalogSerialInput__ = 14;
const uint CHANNEL_4_GAIN__DOLLAR____AnalogSerialInput__ = 15;
const uint RX__DOLLAR____AnalogSerialInput__ = 16;
const uint CHANNEL_1_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__ = 0;
const uint CHANNEL_1_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__ = 1;
const uint CHANNEL_2_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__ = 2;
const uint CHANNEL_2_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__ = 3;
const uint CHANNEL_3_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__ = 4;
const uint CHANNEL_3_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__ = 5;
const uint CHANNEL_4_PHANTOMSWITCHON_FB__DOLLAR____DigitalOutput__ = 6;
const uint CHANNEL_4_PHANTOMSWITCHOFF_FB__DOLLAR____DigitalOutput__ = 7;
const uint CHANNEL_1_MUTE_FB__DOLLAR____DigitalOutput__ = 8;
const uint CHANNEL_2_MUTE_FB__DOLLAR____DigitalOutput__ = 9;
const uint CHANNEL_3_MUTE_FB__DOLLAR____DigitalOutput__ = 10;
const uint CHANNEL_4_MUTE_FB__DOLLAR____DigitalOutput__ = 11;
const uint CHANNEL_1_METER_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint CHANNEL_1_REFERENCE_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint CHANNEL_1_ATTACK_FB__DOLLAR____AnalogSerialOutput__ = 2;
const uint CHANNEL_1_RELEASE_FB__DOLLAR____AnalogSerialOutput__ = 3;
const uint CHANNEL_1_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 4;
const uint CHANNEL_2_METER_FB__DOLLAR____AnalogSerialOutput__ = 5;
const uint CHANNEL_2_REFERENCE_FB__DOLLAR____AnalogSerialOutput__ = 6;
const uint CHANNEL_2_ATTACK_FB__DOLLAR____AnalogSerialOutput__ = 7;
const uint CHANNEL_2_RELEASE_FB__DOLLAR____AnalogSerialOutput__ = 8;
const uint CHANNEL_2_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 9;
const uint CHANNEL_3_METER_FB__DOLLAR____AnalogSerialOutput__ = 10;
const uint CHANNEL_3_REFERENCE_FB__DOLLAR____AnalogSerialOutput__ = 11;
const uint CHANNEL_3_ATTACK_FB__DOLLAR____AnalogSerialOutput__ = 12;
const uint CHANNEL_3_RELEASE_FB__DOLLAR____AnalogSerialOutput__ = 13;
const uint CHANNEL_3_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 14;
const uint CHANNEL_4_METER_FB__DOLLAR____AnalogSerialOutput__ = 15;
const uint CHANNEL_4_REFERENCE_FB__DOLLAR____AnalogSerialOutput__ = 16;
const uint CHANNEL_4_ATTACK_FB__DOLLAR____AnalogSerialOutput__ = 17;
const uint CHANNEL_4_RELEASE_FB__DOLLAR____AnalogSerialOutput__ = 18;
const uint CHANNEL_4_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 19;
const uint TX__DOLLAR____AnalogSerialOutput__ = 20;
const uint METERRATE__DOLLAR____Parameter__ = 10;
const uint CARD__DOLLAR____Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort XOKGAIN1 = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort XOKGAIN2 = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort XOKGAIN3 = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort XOKGAIN4 = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort XSUBSCRIBE = 0;
            [SplusStructAttribute(6, false, true)]
            public CrestronString TEMPSTRING;
            [SplusStructAttribute(7, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(8, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort SUBSCRIBE = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort METER_SUBSCRIBE = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort XVALUE = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort XPHANTOM = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort STATEVARVALUE = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort STATEVARPHANTOM = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort STATEVARRECEIVE = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort [] VOLUMEINPUT;
            
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
