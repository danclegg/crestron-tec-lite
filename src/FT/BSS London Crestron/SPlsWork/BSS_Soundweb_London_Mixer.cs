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

namespace UserModule_BSS_SOUNDWEB_LONDON_MIXER
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_MIXER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput MUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNMUTE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput POLARITYON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput POLARITYOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP1ON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP2ON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP3ON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP4ON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP1OFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP2OFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP3OFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput ROUTETOGROUP4OFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput SOLOON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput SOLOOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput PAN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput INPUT__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> AUX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput POLARITY_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ROUTETOGROUP1_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ROUTETOGROUP2_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ROUTETOGROUP3_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ROUTETOGROUP4_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput SOLO_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput PAN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AUX_FB__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 150;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 151;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 152;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 160;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 161;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 162;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 165;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 167;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 169;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object MUTE__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 180;
                _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 1) ) ; 
                __context__.SourceCodeLine = 181;
                MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                __context__.SourceCodeLine = 183;
                if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 185;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                    __context__.SourceCodeLine = 186;
                    Functions.ProcessLogic ( ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object UNMUTE__DOLLAR___OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 193;
            _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 1) ) ; 
            __context__.SourceCodeLine = 194;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 196;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 198;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                __context__.SourceCodeLine = 199;
                Functions.ProcessLogic ( ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object POLARITYON__DOLLAR___OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 206;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 3) ) ; 
        __context__.SourceCodeLine = 207;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 209;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 211;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 212;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLARITYOFF__DOLLAR___OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 219;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 3) ) ; 
        __context__.SourceCodeLine = 220;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 222;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 224;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 225;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOLOON__DOLLAR___OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 232;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 4) ) ; 
        __context__.SourceCodeLine = 233;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 235;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 237;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 238;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOLOOFF__DOLLAR___OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 245;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 4) ) ; 
        __context__.SourceCodeLine = 246;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 248;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 250;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 251;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP1ON__DOLLAR___OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 259;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 1) - 1) ) ; 
        __context__.SourceCodeLine = 260;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 262;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 264;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 265;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP2ON__DOLLAR___OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 271;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 2) - 1) ) ; 
        __context__.SourceCodeLine = 272;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 274;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 276;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 277;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP3ON__DOLLAR___OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 283;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 3) - 1) ) ; 
        __context__.SourceCodeLine = 284;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 286;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 288;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 289;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP4ON__DOLLAR___OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 295;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 4) - 1) ) ; 
        __context__.SourceCodeLine = 296;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 298;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 300;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 301;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP1OFF__DOLLAR___OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 307;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 1) - 1) ) ; 
        __context__.SourceCodeLine = 308;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 310;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 312;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 313;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP2OFF__DOLLAR___OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 319;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 2) - 1) ) ; 
        __context__.SourceCodeLine = 320;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 322;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 324;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 325;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP3OFF__DOLLAR___OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 332;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 3) - 1) ) ; 
        __context__.SourceCodeLine = 333;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 335;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 337;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 338;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP4OFF__DOLLAR___OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 345;
        _SplusNVRAM.STATEVAR = (ushort) ( (((((_SplusNVRAM.INPUT - 1) * 100) + 40) + 4) - 1) ) ; 
        __context__.SourceCodeLine = 346;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 348;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 350;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 351;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GAIN__DOLLAR___OnChange_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 359;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.VOLUMEINPUT != GAIN__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 361;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 363;
                _SplusNVRAM.XOKGAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 364;
                _SplusNVRAM.STATEVAR = (ushort) ( ((_SplusNVRAM.INPUT - 1) * 100) ) ; 
                __context__.SourceCodeLine = 365;
                _SplusNVRAM.VOLUMEINPUT = (ushort) ( GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 366;
                GAIN_FB__DOLLAR__  .Value = (ushort) ( GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 368;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 369;
                _SplusNVRAM.XOKGAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PAN__DOLLAR___OnChange_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 379;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 2) ) ; 
        __context__.SourceCodeLine = 380;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( PAN__DOLLAR__  .UshortValue )) ) ; 
        __context__.SourceCodeLine = 382;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 384;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 385;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUX__DOLLAR___OnChange_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 392;
        _SplusNVRAM.XAUX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 393;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.INPUT - 1) * 100) + 20) + (_SplusNVRAM.XAUX - 1)) ) ; 
        __context__.SourceCodeLine = 394;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( AUX__DOLLAR__[ _SplusNVRAM.XAUX ] .UshortValue )) ) ; 
        __context__.SourceCodeLine = 396;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 398;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 399;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUBSCRIBE__DOLLAR___OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 407;
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
        
            
            __context__.SourceCodeLine = 409;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 411;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 412;
                _SplusNVRAM.XSUBSCRIBE = (ushort) ( ((_SplusNVRAM.INPUT - 1) * 100) ) ; 
                __context__.SourceCodeLine = 413;
                _SplusNVRAM.STATEVARSUB = (ushort) ( _SplusNVRAM.XSUBSCRIBE ) ; 
                __context__.SourceCodeLine = 414;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 415;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 417;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 1) ) ; 
                __context__.SourceCodeLine = 418;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 419;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 421;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 2) ) ; 
                __context__.SourceCodeLine = 422;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 423;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 425;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 3) ) ; 
                __context__.SourceCodeLine = 426;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 427;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 429;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 20) ) ; 
                __context__.SourceCodeLine = 430;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 431;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 433;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 21) ) ; 
                __context__.SourceCodeLine = 434;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 435;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 437;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 22) ) ; 
                __context__.SourceCodeLine = 438;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 439;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 441;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 23) ) ; 
                __context__.SourceCodeLine = 442;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 443;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 445;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 40) ) ; 
                __context__.SourceCodeLine = 446;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 447;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 449;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 41) ) ; 
                __context__.SourceCodeLine = 450;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 451;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 453;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 42) ) ; 
                __context__.SourceCodeLine = 454;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 455;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 457;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 43) ) ; 
                __context__.SourceCodeLine = 458;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 459;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 461;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 4) ) ; 
                __context__.SourceCodeLine = 462;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 463;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 465;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 5) ) ; 
                __context__.SourceCodeLine = 466;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 467;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 469;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 6) ) ; 
                __context__.SourceCodeLine = 470;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 471;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 473;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 7) ) ; 
                __context__.SourceCodeLine = 474;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 475;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 477;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 478;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object UNSUBSCRIBE__DOLLAR___OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 487;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 489;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 490;
            _SplusNVRAM.XUNSUBSCRIBE = (ushort) ( ((_SplusNVRAM.INPUT - 1) * 100) ) ; 
            __context__.SourceCodeLine = 491;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( _SplusNVRAM.XUNSUBSCRIBE ) ; 
            __context__.SourceCodeLine = 492;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 493;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 495;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 1) ) ; 
            __context__.SourceCodeLine = 496;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 497;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 499;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 2) ) ; 
            __context__.SourceCodeLine = 500;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 501;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 503;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 3) ) ; 
            __context__.SourceCodeLine = 504;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 505;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 507;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 20) ) ; 
            __context__.SourceCodeLine = 508;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 509;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 511;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 21) ) ; 
            __context__.SourceCodeLine = 512;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 513;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 515;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 22) ) ; 
            __context__.SourceCodeLine = 516;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 517;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 519;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 23) ) ; 
            __context__.SourceCodeLine = 520;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 521;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 523;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 40) ) ; 
            __context__.SourceCodeLine = 524;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 525;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 527;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 41) ) ; 
            __context__.SourceCodeLine = 528;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 529;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 531;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 42) ) ; 
            __context__.SourceCodeLine = 532;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 533;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 535;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 43) ) ; 
            __context__.SourceCodeLine = 536;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 537;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 539;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 4) ) ; 
            __context__.SourceCodeLine = 540;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 541;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 543;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 544;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT__DOLLAR___OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 550;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INPUT__DOLLAR__  .UshortValue > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 551;
            _SplusNVRAM.INPUT = (ushort) ( INPUT__DOLLAR__  .UshortValue ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 554;
            _SplusNVRAM.INPUT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 555;
            Print( "error input for the automixer cannot be 0. set to default of 1") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 568;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 570;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 571;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 573;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 575;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 576;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 578;
                        _SplusNVRAM.RXSV = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 579;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((_SplusNVRAM.RXSV / 100) == (_SplusNVRAM.INPUT - 1)))  ) ) 
                            { 
                            __context__.SourceCodeLine = 581;
                            
                                {
                                int __SPLS_TMPVAR__SWTCH_1__ = ((int)Mod( _SplusNVRAM.RXSV , 100 ));
                                
                                    { 
                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                                        { 
                                        __context__.SourceCodeLine = 585;
                                        _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        __context__.SourceCodeLine = 586;
                                        GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                        } 
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 588;
                                        MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 589;
                                        PAN_FB__DOLLAR__  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 590;
                                        POLARITY_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 20) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 591;
                                        AUX_FB__DOLLAR__ [ 1]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 21) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 592;
                                        AUX_FB__DOLLAR__ [ 2]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 22) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 593;
                                        AUX_FB__DOLLAR__ [ 3]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 23) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 594;
                                        AUX_FB__DOLLAR__ [ 4]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 40) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 595;
                                        ROUTETOGROUP1_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 41) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 596;
                                        ROUTETOGROUP2_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 42) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 597;
                                        ROUTETOGROUP3_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 43) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 598;
                                        ROUTETOGROUP4_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 599;
                                        SOLO_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    } 
                                    
                                }
                                
                            
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 603;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 571;
                } 
            
            __context__.SourceCodeLine = 606;
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
        
        __context__.SourceCodeLine = 626;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 627;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 628;
        _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 629;
        _SplusNVRAM.XOKGAIN = (ushort) ( 1 ) ; 
        
        
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
    
    MUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( MUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( MUTE__DOLLAR____DigitalInput__, MUTE__DOLLAR__ );
    
    UNMUTE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNMUTE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNMUTE__DOLLAR____DigitalInput__, UNMUTE__DOLLAR__ );
    
    POLARITYON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( POLARITYON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( POLARITYON__DOLLAR____DigitalInput__, POLARITYON__DOLLAR__ );
    
    POLARITYOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( POLARITYOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( POLARITYOFF__DOLLAR____DigitalInput__, POLARITYOFF__DOLLAR__ );
    
    ROUTETOGROUP1ON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP1ON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP1ON__DOLLAR____DigitalInput__, ROUTETOGROUP1ON__DOLLAR__ );
    
    ROUTETOGROUP2ON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP2ON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP2ON__DOLLAR____DigitalInput__, ROUTETOGROUP2ON__DOLLAR__ );
    
    ROUTETOGROUP3ON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP3ON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP3ON__DOLLAR____DigitalInput__, ROUTETOGROUP3ON__DOLLAR__ );
    
    ROUTETOGROUP4ON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP4ON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP4ON__DOLLAR____DigitalInput__, ROUTETOGROUP4ON__DOLLAR__ );
    
    ROUTETOGROUP1OFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP1OFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP1OFF__DOLLAR____DigitalInput__, ROUTETOGROUP1OFF__DOLLAR__ );
    
    ROUTETOGROUP2OFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP2OFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP2OFF__DOLLAR____DigitalInput__, ROUTETOGROUP2OFF__DOLLAR__ );
    
    ROUTETOGROUP3OFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP3OFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP3OFF__DOLLAR____DigitalInput__, ROUTETOGROUP3OFF__DOLLAR__ );
    
    ROUTETOGROUP4OFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( ROUTETOGROUP4OFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( ROUTETOGROUP4OFF__DOLLAR____DigitalInput__, ROUTETOGROUP4OFF__DOLLAR__ );
    
    SOLOON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SOLOON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SOLOON__DOLLAR____DigitalInput__, SOLOON__DOLLAR__ );
    
    SOLOOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SOLOOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SOLOOFF__DOLLAR____DigitalInput__, SOLOOFF__DOLLAR__ );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( MUTE_FB__DOLLAR____DigitalOutput__, MUTE_FB__DOLLAR__ );
    
    POLARITY_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( POLARITY_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( POLARITY_FB__DOLLAR____DigitalOutput__, POLARITY_FB__DOLLAR__ );
    
    ROUTETOGROUP1_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( ROUTETOGROUP1_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( ROUTETOGROUP1_FB__DOLLAR____DigitalOutput__, ROUTETOGROUP1_FB__DOLLAR__ );
    
    ROUTETOGROUP2_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( ROUTETOGROUP2_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( ROUTETOGROUP2_FB__DOLLAR____DigitalOutput__, ROUTETOGROUP2_FB__DOLLAR__ );
    
    ROUTETOGROUP3_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( ROUTETOGROUP3_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( ROUTETOGROUP3_FB__DOLLAR____DigitalOutput__, ROUTETOGROUP3_FB__DOLLAR__ );
    
    ROUTETOGROUP4_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( ROUTETOGROUP4_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( ROUTETOGROUP4_FB__DOLLAR____DigitalOutput__, ROUTETOGROUP4_FB__DOLLAR__ );
    
    SOLO_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( SOLO_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( SOLO_FB__DOLLAR____DigitalOutput__, SOLO_FB__DOLLAR__ );
    
    GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( GAIN__DOLLAR____AnalogSerialInput__, GAIN__DOLLAR__ );
    
    PAN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( PAN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( PAN__DOLLAR____AnalogSerialInput__, PAN__DOLLAR__ );
    
    INPUT__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( INPUT__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( INPUT__DOLLAR____AnalogSerialInput__, INPUT__DOLLAR__ );
    
    AUX__DOLLAR__ = new InOutArray<AnalogInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        AUX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( AUX__DOLLAR____AnalogSerialInput__ + i, AUX__DOLLAR____AnalogSerialInput__, this );
        m_AnalogInputList.Add( AUX__DOLLAR____AnalogSerialInput__ + i, AUX__DOLLAR__[i+1] );
    }
    
    GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( GAIN_FB__DOLLAR____AnalogSerialOutput__, GAIN_FB__DOLLAR__ );
    
    PAN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( PAN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( PAN_FB__DOLLAR____AnalogSerialOutput__, PAN_FB__DOLLAR__ );
    
    AUX_FB__DOLLAR__ = new InOutArray<AnalogOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        AUX_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( AUX_FB__DOLLAR____AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( AUX_FB__DOLLAR____AnalogSerialOutput__ + i, AUX_FB__DOLLAR__[i+1] );
    }
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    OBJECTID__DOLLAR__ = new StringParameter( OBJECTID__DOLLAR____Parameter__, this );
    m_ParameterList.Add( OBJECTID__DOLLAR____Parameter__, OBJECTID__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    
    MUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( MUTE__DOLLAR___OnPush_0, false ) );
    UNMUTE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNMUTE__DOLLAR___OnPush_1, false ) );
    POLARITYON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLARITYON__DOLLAR___OnPush_2, false ) );
    POLARITYOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLARITYOFF__DOLLAR___OnPush_3, false ) );
    SOLOON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOLOON__DOLLAR___OnPush_4, false ) );
    SOLOOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOLOOFF__DOLLAR___OnPush_5, false ) );
    ROUTETOGROUP1ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP1ON__DOLLAR___OnPush_6, false ) );
    ROUTETOGROUP2ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP2ON__DOLLAR___OnPush_7, false ) );
    ROUTETOGROUP3ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP3ON__DOLLAR___OnPush_8, false ) );
    ROUTETOGROUP4ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP4ON__DOLLAR___OnPush_9, false ) );
    ROUTETOGROUP1OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP1OFF__DOLLAR___OnPush_10, false ) );
    ROUTETOGROUP2OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP2OFF__DOLLAR___OnPush_11, false ) );
    ROUTETOGROUP3OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP3OFF__DOLLAR___OnPush_12, false ) );
    ROUTETOGROUP4OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP4OFF__DOLLAR___OnPush_13, false ) );
    GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( GAIN__DOLLAR___OnChange_14, false ) );
    PAN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( PAN__DOLLAR___OnChange_15, false ) );
    for( uint i = 0; i < 4; i++ )
        AUX__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( AUX__DOLLAR___OnChange_16, false ) );
        
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_17, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_18, false ) );
    INPUT__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( INPUT__DOLLAR___OnChange_19, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_20, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_MIXER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;


const uint MUTE__DOLLAR____DigitalInput__ = 0;
const uint UNMUTE__DOLLAR____DigitalInput__ = 1;
const uint POLARITYON__DOLLAR____DigitalInput__ = 2;
const uint POLARITYOFF__DOLLAR____DigitalInput__ = 3;
const uint ROUTETOGROUP1ON__DOLLAR____DigitalInput__ = 4;
const uint ROUTETOGROUP2ON__DOLLAR____DigitalInput__ = 5;
const uint ROUTETOGROUP3ON__DOLLAR____DigitalInput__ = 6;
const uint ROUTETOGROUP4ON__DOLLAR____DigitalInput__ = 7;
const uint ROUTETOGROUP1OFF__DOLLAR____DigitalInput__ = 8;
const uint ROUTETOGROUP2OFF__DOLLAR____DigitalInput__ = 9;
const uint ROUTETOGROUP3OFF__DOLLAR____DigitalInput__ = 10;
const uint ROUTETOGROUP4OFF__DOLLAR____DigitalInput__ = 11;
const uint SOLOON__DOLLAR____DigitalInput__ = 12;
const uint SOLOOFF__DOLLAR____DigitalInput__ = 13;
const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 14;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 15;
const uint GAIN__DOLLAR____AnalogSerialInput__ = 0;
const uint PAN__DOLLAR____AnalogSerialInput__ = 1;
const uint INPUT__DOLLAR____AnalogSerialInput__ = 2;
const uint RX__DOLLAR____AnalogSerialInput__ = 3;
const uint AUX__DOLLAR____AnalogSerialInput__ = 4;
const uint MUTE_FB__DOLLAR____DigitalOutput__ = 0;
const uint POLARITY_FB__DOLLAR____DigitalOutput__ = 1;
const uint ROUTETOGROUP1_FB__DOLLAR____DigitalOutput__ = 2;
const uint ROUTETOGROUP2_FB__DOLLAR____DigitalOutput__ = 3;
const uint ROUTETOGROUP3_FB__DOLLAR____DigitalOutput__ = 4;
const uint ROUTETOGROUP4_FB__DOLLAR____DigitalOutput__ = 5;
const uint SOLO_FB__DOLLAR____DigitalOutput__ = 6;
const uint GAIN_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint PAN_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint TX__DOLLAR____AnalogSerialOutput__ = 2;
const uint AUX_FB__DOLLAR____AnalogSerialOutput__ = 3;
const uint OBJECTID__DOLLAR____Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort STATEVAR = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort STATEVARSUB = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort STATEVARUNSUB = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort SUBSCRIBE = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort XROUTE = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort XAUX = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort XSUBSCRIBE = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort XUNSUBSCRIBE = 0;
            [SplusStructAttribute(8, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(9, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort VOLUMEINPUT = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort RXSV = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort XOKSUBSCRIBE = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort XOKGAIN = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort INPUT = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(17, false, true)]
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
