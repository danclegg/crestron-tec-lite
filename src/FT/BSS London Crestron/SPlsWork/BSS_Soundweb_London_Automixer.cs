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

namespace UserModule_BSS_SOUNDWEB_LONDON_AUTOMIXER
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_AUTOMIXER : SplusObject
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
        Crestron.Logos.SplusObjects.DigitalInput OVERRIDEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput OVERRIDEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput AUTOON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput AUTOOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput PAN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput OFFGAIN__DOLLAR__;
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
        Crestron.Logos.SplusObjects.DigitalOutput OVERRIDE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput AUTO_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput PAN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput OFFGAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> AUX_FB__DOLLAR__;
        StringParameter OBJECTID__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 157;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 158;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 159;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 167;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 168;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 169;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 172;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 174;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 176;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        object MUTE__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 189;
                _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 1) ) ; 
                __context__.SourceCodeLine = 190;
                MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                __context__.SourceCodeLine = 192;
                if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 194;
                    MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                    __context__.SourceCodeLine = 195;
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
            
            __context__.SourceCodeLine = 203;
            _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 1) ) ; 
            __context__.SourceCodeLine = 204;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 206;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 208;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                __context__.SourceCodeLine = 209;
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
        
        __context__.SourceCodeLine = 216;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 3) ) ; 
        __context__.SourceCodeLine = 217;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 219;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 221;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 222;
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
        
        __context__.SourceCodeLine = 230;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 3) ) ; 
        __context__.SourceCodeLine = 231;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 233;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 235;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 236;
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
        
        __context__.SourceCodeLine = 244;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 4) ) ; 
        __context__.SourceCodeLine = 245;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 247;
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

object SOLOOFF__DOLLAR___OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 259;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 4) ) ; 
        __context__.SourceCodeLine = 260;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
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

object OVERRIDEON__DOLLAR___OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 273;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 5) ) ; 
        __context__.SourceCodeLine = 274;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 276;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 279;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 280;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OVERRIDEOFF__DOLLAR___OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 288;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 5) ) ; 
        __context__.SourceCodeLine = 289;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 291;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 294;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 295;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUTOON__DOLLAR___OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 303;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 7) ) ; 
        __context__.SourceCodeLine = 304;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 306;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 308;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 309;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUTOOFF__DOLLAR___OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 317;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 7) ) ; 
        __context__.SourceCodeLine = 318;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 320;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 322;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 323;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP1ON__DOLLAR___OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 331;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 40) ) ; 
        __context__.SourceCodeLine = 332;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 334;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 336;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 337;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP2ON__DOLLAR___OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 343;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 41) ) ; 
        __context__.SourceCodeLine = 344;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 346;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 348;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 349;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP3ON__DOLLAR___OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 355;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 42) ) ; 
        __context__.SourceCodeLine = 356;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 358;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 360;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 361;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP4ON__DOLLAR___OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 367;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 43) ) ; 
        __context__.SourceCodeLine = 368;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 370;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 372;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 373;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP1OFF__DOLLAR___OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 379;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 40) ) ; 
        __context__.SourceCodeLine = 380;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 382;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 384;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 385;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP2OFF__DOLLAR___OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 391;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 41) ) ; 
        __context__.SourceCodeLine = 392;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 394;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 396;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 397;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP3OFF__DOLLAR___OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 404;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 42) ) ; 
        __context__.SourceCodeLine = 405;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 407;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 409;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 410;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROUTETOGROUP4OFF__DOLLAR___OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 417;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 43) ) ; 
        __context__.SourceCodeLine = 418;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
        __context__.SourceCodeLine = 420;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 422;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 423;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GAIN__DOLLAR___OnChange_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 433;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.VOLUMEINPUT != GAIN__DOLLAR__  .UshortValue))  ) ) 
            { 
            __context__.SourceCodeLine = 435;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKGAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 437;
                _SplusNVRAM.XOKGAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 438;
                _SplusNVRAM.STATEVAR = (ushort) ( ((_SplusNVRAM.INPUT - 1) * 100) ) ; 
                __context__.SourceCodeLine = 439;
                _SplusNVRAM.VOLUMEINPUT = (ushort) ( GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 440;
                GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                __context__.SourceCodeLine = 442;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 443;
                _SplusNVRAM.XOKGAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PAN__DOLLAR___OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 452;
        _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 2) ) ; 
        __context__.SourceCodeLine = 453;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( PAN__DOLLAR__  .UshortValue )) ) ; 
        __context__.SourceCodeLine = 455;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 457;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 458;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OFFGAIN__DOLLAR___OnChange_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 466;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKOFFGAIN)  ) ) 
            { 
            __context__.SourceCodeLine = 468;
            _SplusNVRAM.XOKOFFGAIN = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 469;
            _SplusNVRAM.STATEVAR = (ushort) ( (((_SplusNVRAM.INPUT - 1) * 100) + 6) ) ; 
            __context__.SourceCodeLine = 470;
            MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( OFFGAIN__DOLLAR__  .UshortValue )) ) ; 
            __context__.SourceCodeLine = 472;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 474;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
                __context__.SourceCodeLine = 475;
                Functions.ProcessLogic ( ) ; 
                } 
            
            __context__.SourceCodeLine = 478;
            _SplusNVRAM.XOKOFFGAIN = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUX__DOLLAR___OnChange_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 485;
        _SplusNVRAM.XAUX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 486;
        _SplusNVRAM.STATEVAR = (ushort) ( ((((_SplusNVRAM.INPUT - 1) * 100) + 20) + (_SplusNVRAM.XAUX - 1)) ) ; 
        __context__.SourceCodeLine = 488;
        MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}{1}{2}{3}\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) , ITOVOLUMEPERCENT (  __context__ , (ushort)( AUX__DOLLAR__[ _SplusNVRAM.XAUX ] .UshortValue )) ) ; 
        __context__.SourceCodeLine = 490;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 492;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVAR ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVAR ) ) ) ) ; 
            __context__.SourceCodeLine = 493;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUBSCRIBE__DOLLAR___OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 501;
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
        
            
            __context__.SourceCodeLine = 503;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 505;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 506;
                _SplusNVRAM.XSUBSCRIBE = (ushort) ( ((_SplusNVRAM.INPUT - 1) * 100) ) ; 
                __context__.SourceCodeLine = 507;
                _SplusNVRAM.STATEVARSUB = (ushort) ( _SplusNVRAM.XSUBSCRIBE ) ; 
                __context__.SourceCodeLine = 508;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 509;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 511;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 1) ) ; 
                __context__.SourceCodeLine = 512;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 513;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 515;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 2) ) ; 
                __context__.SourceCodeLine = 516;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 517;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 519;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 3) ) ; 
                __context__.SourceCodeLine = 520;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 521;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 523;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 20) ) ; 
                __context__.SourceCodeLine = 526;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 527;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 529;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 21) ) ; 
                __context__.SourceCodeLine = 530;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 531;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 533;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 22) ) ; 
                __context__.SourceCodeLine = 534;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 535;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 537;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 23) ) ; 
                __context__.SourceCodeLine = 538;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 539;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 541;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 40) ) ; 
                __context__.SourceCodeLine = 542;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 543;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 545;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 41) ) ; 
                __context__.SourceCodeLine = 546;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 547;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 549;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 42) ) ; 
                __context__.SourceCodeLine = 550;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 551;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 553;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 43) ) ; 
                __context__.SourceCodeLine = 554;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 555;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 557;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 4) ) ; 
                __context__.SourceCodeLine = 558;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 559;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 561;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 5) ) ; 
                __context__.SourceCodeLine = 562;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 563;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 565;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 6) ) ; 
                __context__.SourceCodeLine = 566;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 567;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 569;
                _SplusNVRAM.STATEVARSUB = (ushort) ( (_SplusNVRAM.XSUBSCRIBE + 7) ) ; 
                __context__.SourceCodeLine = 570;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSUB ) ) ) ) ; 
                __context__.SourceCodeLine = 571;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 573;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 574;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object UNSUBSCRIBE__DOLLAR___OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 581;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 583;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 585;
            _SplusNVRAM.XUNSUBSCRIBE = (ushort) ( ((_SplusNVRAM.INPUT - 1) * 100) ) ; 
            __context__.SourceCodeLine = 586;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( _SplusNVRAM.XUNSUBSCRIBE ) ; 
            __context__.SourceCodeLine = 587;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 588;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 590;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 1) ) ; 
            __context__.SourceCodeLine = 591;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 592;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 594;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 2) ) ; 
            __context__.SourceCodeLine = 595;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 596;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 598;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 3) ) ; 
            __context__.SourceCodeLine = 599;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 600;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 602;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 20) ) ; 
            __context__.SourceCodeLine = 603;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 604;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 606;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 21) ) ; 
            __context__.SourceCodeLine = 607;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 608;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 610;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 22) ) ; 
            __context__.SourceCodeLine = 611;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 612;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 614;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 23) ) ; 
            __context__.SourceCodeLine = 615;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 616;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 618;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 40) ) ; 
            __context__.SourceCodeLine = 619;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 620;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 622;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 41) ) ; 
            __context__.SourceCodeLine = 623;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 624;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 626;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 42) ) ; 
            __context__.SourceCodeLine = 627;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 628;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 630;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 43) ) ; 
            __context__.SourceCodeLine = 631;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 632;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 634;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 4) ) ; 
            __context__.SourceCodeLine = 635;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 636;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 638;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 5) ) ; 
            __context__.SourceCodeLine = 639;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 640;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 642;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 6) ) ; 
            __context__.SourceCodeLine = 643;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 644;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 646;
            _SplusNVRAM.STATEVARUNSUB = (ushort) ( (_SplusNVRAM.XUNSUBSCRIBE + 7) ) ; 
            __context__.SourceCodeLine = 647;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", OBJECTID__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARUNSUB ) ) ) ) ; 
            __context__.SourceCodeLine = 648;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 650;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 651;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT__DOLLAR___OnChange_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 658;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INPUT__DOLLAR__  .UshortValue > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 659;
            _SplusNVRAM.INPUT = (ushort) ( INPUT__DOLLAR__  .UshortValue ) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 662;
            _SplusNVRAM.INPUT = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 663;
            Print( "error input for the automixer cannot be 0. set to default of 1") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 676;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 678;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 679;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 681;
                if ( Functions.TestForTrue  ( ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 683;
                    _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 684;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == OBJECTID__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 686;
                        Print( "input = {0:d}", (short)_SplusNVRAM.INPUT) ; 
                        __context__.SourceCodeLine = 687;
                        _SplusNVRAM.RXSV = (ushort) ( ((Byte( _SplusNVRAM.TEMPSTRING , (int)( 9 ) ) * 256) + Byte( _SplusNVRAM.TEMPSTRING , (int)( 10 ) )) ) ; 
                        __context__.SourceCodeLine = 688;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((_SplusNVRAM.RXSV / 100) == (_SplusNVRAM.INPUT - 1)))  ) ) 
                            { 
                            __context__.SourceCodeLine = 690;
                            
                                {
                                int __SPLS_TMPVAR__SWTCH_1__ = ((int)Mod( _SplusNVRAM.RXSV , 100 ));
                                
                                    { 
                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                                        { 
                                        __context__.SourceCodeLine = 694;
                                        _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        __context__.SourceCodeLine = 695;
                                        GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                        } 
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 697;
                                        MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 698;
                                        PAN_FB__DOLLAR__  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 699;
                                        POLARITY_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 20) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 700;
                                        AUX_FB__DOLLAR__ [ 1]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 21) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 701;
                                        AUX_FB__DOLLAR__ [ 2]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 22) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 702;
                                        AUX_FB__DOLLAR__ [ 3]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 23) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 703;
                                        AUX_FB__DOLLAR__ [ 4]  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 40) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 704;
                                        ROUTETOGROUP1_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 41) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 705;
                                        ROUTETOGROUP2_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 42) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 706;
                                        ROUTETOGROUP3_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 43) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 707;
                                        ROUTETOGROUP4_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 708;
                                        SOLO_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 709;
                                        OVERRIDE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 710;
                                        OFFGAIN_FB__DOLLAR__  .Value = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                        }
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                                        {
                                        __context__.SourceCodeLine = 711;
                                        AUTO_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                        }
                                    
                                    } 
                                    
                                }
                                
                            
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 715;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 679;
                } 
            
            __context__.SourceCodeLine = 718;
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
        
        __context__.SourceCodeLine = 738;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 739;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 741;
        _SplusNVRAM.XOKGAIN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 742;
        _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 743;
        _SplusNVRAM.XOKOFFGAIN = (ushort) ( 1 ) ; 
        
        
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
    
    OVERRIDEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( OVERRIDEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( OVERRIDEON__DOLLAR____DigitalInput__, OVERRIDEON__DOLLAR__ );
    
    OVERRIDEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( OVERRIDEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( OVERRIDEOFF__DOLLAR____DigitalInput__, OVERRIDEOFF__DOLLAR__ );
    
    AUTOON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( AUTOON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( AUTOON__DOLLAR____DigitalInput__, AUTOON__DOLLAR__ );
    
    AUTOOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( AUTOOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( AUTOOFF__DOLLAR____DigitalInput__, AUTOOFF__DOLLAR__ );
    
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
    
    OVERRIDE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( OVERRIDE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( OVERRIDE_FB__DOLLAR____DigitalOutput__, OVERRIDE_FB__DOLLAR__ );
    
    AUTO_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( AUTO_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( AUTO_FB__DOLLAR____DigitalOutput__, AUTO_FB__DOLLAR__ );
    
    GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( GAIN__DOLLAR____AnalogSerialInput__, GAIN__DOLLAR__ );
    
    PAN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( PAN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( PAN__DOLLAR____AnalogSerialInput__, PAN__DOLLAR__ );
    
    OFFGAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( OFFGAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( OFFGAIN__DOLLAR____AnalogSerialInput__, OFFGAIN__DOLLAR__ );
    
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
    
    OFFGAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( OFFGAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( OFFGAIN_FB__DOLLAR____AnalogSerialOutput__, OFFGAIN_FB__DOLLAR__ );
    
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
    OVERRIDEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( OVERRIDEON__DOLLAR___OnPush_6, false ) );
    OVERRIDEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( OVERRIDEOFF__DOLLAR___OnPush_7, false ) );
    AUTOON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUTOON__DOLLAR___OnPush_8, false ) );
    AUTOOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUTOOFF__DOLLAR___OnPush_9, false ) );
    ROUTETOGROUP1ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP1ON__DOLLAR___OnPush_10, false ) );
    ROUTETOGROUP2ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP2ON__DOLLAR___OnPush_11, false ) );
    ROUTETOGROUP3ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP3ON__DOLLAR___OnPush_12, false ) );
    ROUTETOGROUP4ON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP4ON__DOLLAR___OnPush_13, false ) );
    ROUTETOGROUP1OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP1OFF__DOLLAR___OnPush_14, false ) );
    ROUTETOGROUP2OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP2OFF__DOLLAR___OnPush_15, false ) );
    ROUTETOGROUP3OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP3OFF__DOLLAR___OnPush_16, false ) );
    ROUTETOGROUP4OFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTETOGROUP4OFF__DOLLAR___OnPush_17, false ) );
    GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( GAIN__DOLLAR___OnChange_18, false ) );
    PAN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( PAN__DOLLAR___OnChange_19, false ) );
    OFFGAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( OFFGAIN__DOLLAR___OnChange_20, false ) );
    for( uint i = 0; i < 4; i++ )
        AUX__DOLLAR__[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( AUX__DOLLAR___OnChange_21, false ) );
        
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_22, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_23, false ) );
    INPUT__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( INPUT__DOLLAR___OnChange_24, false ) );
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_25, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_AUTOMIXER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


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
const uint OVERRIDEON__DOLLAR____DigitalInput__ = 14;
const uint OVERRIDEOFF__DOLLAR____DigitalInput__ = 15;
const uint AUTOON__DOLLAR____DigitalInput__ = 16;
const uint AUTOOFF__DOLLAR____DigitalInput__ = 17;
const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 18;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 19;
const uint GAIN__DOLLAR____AnalogSerialInput__ = 0;
const uint PAN__DOLLAR____AnalogSerialInput__ = 1;
const uint OFFGAIN__DOLLAR____AnalogSerialInput__ = 2;
const uint INPUT__DOLLAR____AnalogSerialInput__ = 3;
const uint RX__DOLLAR____AnalogSerialInput__ = 4;
const uint AUX__DOLLAR____AnalogSerialInput__ = 5;
const uint MUTE_FB__DOLLAR____DigitalOutput__ = 0;
const uint POLARITY_FB__DOLLAR____DigitalOutput__ = 1;
const uint ROUTETOGROUP1_FB__DOLLAR____DigitalOutput__ = 2;
const uint ROUTETOGROUP2_FB__DOLLAR____DigitalOutput__ = 3;
const uint ROUTETOGROUP3_FB__DOLLAR____DigitalOutput__ = 4;
const uint ROUTETOGROUP4_FB__DOLLAR____DigitalOutput__ = 5;
const uint SOLO_FB__DOLLAR____DigitalOutput__ = 6;
const uint OVERRIDE_FB__DOLLAR____DigitalOutput__ = 7;
const uint AUTO_FB__DOLLAR____DigitalOutput__ = 8;
const uint GAIN_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint PAN_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint OFFGAIN_FB__DOLLAR____AnalogSerialOutput__ = 2;
const uint TX__DOLLAR____AnalogSerialOutput__ = 3;
const uint AUX_FB__DOLLAR____AnalogSerialOutput__ = 4;
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
            public ushort INPUT = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(10, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(11, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort XOKGAIN = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort XOKOFFGAIN = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort XOKSUBSCRIBE = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort VOLUMEINPUT = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort RXSV = 0;
            [SplusStructAttribute(18, false, true)]
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
