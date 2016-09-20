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

namespace UserModule_BSS_SOUNDWEB_LONDON_ANALOG_TELEPHONE_INPUT_CARD
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_ANALOG_TELEPHONE_INPUT_CARD : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput UNSUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput METER_SUBSCRIBE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_1__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_2__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_3__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_4__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_5__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_6__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_7__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_8__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_9__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_0__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_PAUSE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_DELETE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_REDIAL__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_INTERNATIONAL_PLUS__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_BACKSPACE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_FLASH__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON___POUND____DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput BUTTON_ASTERISK__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput HANG_UP__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput DIAL__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput TOGGLE_DIAL_HANG_UP__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput TX_MUTEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput TX_MUTEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput TX_MUTETOGGLE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput RX_MUTEON__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput RX_MUTEOFF__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalInput RX_MUTETOGGLE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SPEED_STORE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SPEED_DIAL__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput AUTO_ANSWER__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput TX_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput RX_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput DTMF_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput DIAL_TONE_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput RING_GAIN__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput INCOMING_CALL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput HOOK_STATUS_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput TX_MUTE_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput RX_MUTE_FB__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SPEED_DIAL_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput AUTO_ANSWER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput TX_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput TX_METER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput RX_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput RX_METER_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput DTMF_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput DIAL_TONE_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput RING_GAIN_FB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PHONE_NUMBER_FB__DOLLAR__;
        UShortParameter METER_RATE__DOLLAR__;
        StringParameter CARD__DOLLAR__;
        private CrestronString ITOVOLUMEPERCENT (  SplusExecutionContext __context__, ushort INT ) 
            { 
            
            __context__.SourceCodeLine = 226;
            _SplusNVRAM.VOLUME = (ushort) ( ((INT * 100) / 65535) ) ; 
            __context__.SourceCodeLine = 227;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( "\u0000" + Functions.Chr (  (int) ( _SplusNVRAM.VOLUME ) ) + "\u0000\u0000"  ) ; 
            __context__.SourceCodeLine = 228;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        private ushort VOLUMEPERCENTTOI (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            ushort FRACTION = 0;
            
            
            __context__.SourceCodeLine = 235;
            FRACTION = (ushort) ( ((Byte( STR , (int)( 3 ) ) * 256) + Byte( STR , (int)( 4 ) )) ) ; 
            __context__.SourceCodeLine = 236;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FRACTION > 32767 ))  ) ) 
                { 
                __context__.SourceCodeLine = 237;
                _SplusNVRAM.VOLUME = (ushort) ( (((Byte( STR , (int)( 2 ) ) + 1) * 65535) / 100) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 240;
                _SplusNVRAM.VOLUME = (ushort) ( ((Byte( STR , (int)( 2 ) ) * 65535) / 100) ) ; 
                } 
            
            __context__.SourceCodeLine = 242;
            _SplusNVRAM.RETURNI = (ushort) ( _SplusNVRAM.VOLUME ) ; 
            __context__.SourceCodeLine = 244;
            return (ushort)( _SplusNVRAM.RETURNI) ; 
            
            }
            
        private ushort WORDTOI (  SplusExecutionContext __context__, CrestronString SSOURCESTRING , ushort IHIGHBYTE , ushort ILOWBYTE ) 
            { 
            ushort IWORD = 0;
            
            
            __context__.SourceCodeLine = 250;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( SSOURCESTRING , (int)( IHIGHBYTE ) ) != 65535) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( SSOURCESTRING , (int)( ILOWBYTE ) ) != 65535) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 251;
                IWORD = (ushort) ( ((Byte( SSOURCESTRING , (int)( IHIGHBYTE ) ) * 256) + Byte( SSOURCESTRING , (int)( ILOWBYTE ) )) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 253;
                IWORD = (ushort) ( 65535 ) ; 
                }
            
            __context__.SourceCodeLine = 254;
            return (ushort)( IWORD) ; 
            
            }
            
        private CrestronString BYTETOSTRING (  SplusExecutionContext __context__, ushort CONVERT ) 
            { 
            CrestronString NUMBER;
            NUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            
            __context__.SourceCodeLine = 259;
            NUMBER  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 260;
            switch ((int)CONVERT)
            
                { 
                case 0 : 
                
                    { 
                    __context__.SourceCodeLine = 262;
                    NUMBER  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 263;
                    break ; 
                    } 
                
                goto case 1 ;
                case 1 : 
                
                    { 
                    __context__.SourceCodeLine = 266;
                    NUMBER  .UpdateValue ( "1"  ) ; 
                    __context__.SourceCodeLine = 267;
                    break ; 
                    } 
                
                goto case 2 ;
                case 2 : 
                
                    { 
                    __context__.SourceCodeLine = 270;
                    NUMBER  .UpdateValue ( "2"  ) ; 
                    __context__.SourceCodeLine = 271;
                    break ; 
                    } 
                
                goto case 3 ;
                case 3 : 
                
                    { 
                    __context__.SourceCodeLine = 274;
                    NUMBER  .UpdateValue ( "3"  ) ; 
                    __context__.SourceCodeLine = 275;
                    break ; 
                    } 
                
                goto case 4 ;
                case 4 : 
                
                    { 
                    __context__.SourceCodeLine = 278;
                    NUMBER  .UpdateValue ( "4"  ) ; 
                    __context__.SourceCodeLine = 279;
                    break ; 
                    } 
                
                goto case 5 ;
                case 5 : 
                
                    { 
                    __context__.SourceCodeLine = 282;
                    NUMBER  .UpdateValue ( "5"  ) ; 
                    __context__.SourceCodeLine = 283;
                    break ; 
                    } 
                
                goto case 6 ;
                case 6 : 
                
                    { 
                    __context__.SourceCodeLine = 286;
                    NUMBER  .UpdateValue ( "6"  ) ; 
                    __context__.SourceCodeLine = 287;
                    break ; 
                    } 
                
                goto case 7 ;
                case 7 : 
                
                    { 
                    __context__.SourceCodeLine = 290;
                    NUMBER  .UpdateValue ( "7"  ) ; 
                    __context__.SourceCodeLine = 291;
                    break ; 
                    } 
                
                goto case 8 ;
                case 8 : 
                
                    { 
                    __context__.SourceCodeLine = 294;
                    NUMBER  .UpdateValue ( "8"  ) ; 
                    __context__.SourceCodeLine = 295;
                    break ; 
                    } 
                
                goto case 9 ;
                case 9 : 
                
                    { 
                    __context__.SourceCodeLine = 298;
                    NUMBER  .UpdateValue ( "9"  ) ; 
                    __context__.SourceCodeLine = 299;
                    break ; 
                    } 
                
                goto case 10 ;
                case 10 : 
                
                    { 
                    __context__.SourceCodeLine = 302;
                    NUMBER  .UpdateValue ( "#"  ) ; 
                    __context__.SourceCodeLine = 303;
                    break ; 
                    } 
                
                goto case 11 ;
                case 11 : 
                
                    { 
                    __context__.SourceCodeLine = 306;
                    NUMBER  .UpdateValue ( "*"  ) ; 
                    __context__.SourceCodeLine = 307;
                    break ; 
                    } 
                
                goto case 12 ;
                case 12 : 
                
                    { 
                    __context__.SourceCodeLine = 310;
                    NUMBER  .UpdateValue ( ","  ) ; 
                    __context__.SourceCodeLine = 311;
                    break ; 
                    } 
                
                goto case 13 ;
                case 13 : 
                
                    { 
                    __context__.SourceCodeLine = 314;
                    NUMBER  .UpdateValue ( "+"  ) ; 
                    __context__.SourceCodeLine = 315;
                    break ; 
                    } 
                
                goto case 14 ;
                case 14 : 
                
                    { 
                    __context__.SourceCodeLine = 318;
                    NUMBER  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 319;
                    break ; 
                    } 
                
                goto case 15 ;
                case 15 : 
                
                    { 
                    __context__.SourceCodeLine = 322;
                    NUMBER  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 323;
                    break ; 
                    } 
                
                break;
                } 
                
            
            __context__.SourceCodeLine = 326;
            return ( NUMBER ) ; 
            
            }
            
        private CrestronString BYTESTOSTRING (  SplusExecutionContext __context__, ushort INTHIGH , ushort INTLOW ) 
            { 
            ushort MASK = 0;
            
            CrestronString NUMBER;
            NUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            
            __context__.SourceCodeLine = 332;
            MASK = (ushort) ( 15 ) ; 
            __context__.SourceCodeLine = 334;
            MakeString ( NUMBER , "{0}{1}{2}{3}{4}{5}{6}{7}", BYTETOSTRING (  __context__ , (ushort)( (Crestron.Logos.SplusLibrary.Functions.RotateRight( (ushort)INTHIGH , 12 ) & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (Crestron.Logos.SplusLibrary.Functions.RotateRight( (ushort)INTHIGH , 8 ) & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (Crestron.Logos.SplusLibrary.Functions.RotateRight( (ushort)INTHIGH , 4 ) & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (INTHIGH & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (Crestron.Logos.SplusLibrary.Functions.RotateRight( (ushort)INTLOW , 12 ) & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (Crestron.Logos.SplusLibrary.Functions.RotateRight( (ushort)INTLOW , 8 ) & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (Crestron.Logos.SplusLibrary.Functions.RotateRight( (ushort)INTLOW , 4 ) & MASK) )) , BYTETOSTRING (  __context__ , (ushort)( (INTLOW & MASK) )) ) ; 
            __context__.SourceCodeLine = 335;
            return ( NUMBER ) ; 
            
            }
            
        object SUBSCRIBE__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 347;
                if ( Functions.TestForTrue  ( ( UNSUBSCRIBE__DOLLAR__  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 348;
                    Print( "ERROR the subscribe and unSubscribe signals should never be set high at the same time or serious errors can occur") ; 
                    }
                
                __context__.SourceCodeLine = 349;
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
            
            
            __context__.SourceCodeLine = 351;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 353;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 354;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0067\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 355;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 356;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0066\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 357;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 358;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0065\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 359;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 360;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u0064\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 361;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 362;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 363;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 364;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 365;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 366;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u007A\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 367;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 368;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u007C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 369;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 370;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u007E\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 371;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 372;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u008D\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 373;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 374;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0090\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 375;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 376;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0092\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 377;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 378;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0094\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 379;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 380;
                MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0093\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 381;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 382;
                _SplusNVRAM.SUBSCRIBE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 383;
                _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 387;
                Print( "Subscribtions were not sent for the telephone input card please try again") ; 
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
        
        __context__.SourceCodeLine = 395;
        if ( Functions.TestForTrue  ( ( SUBSCRIBE__DOLLAR__  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 396;
            Print( "ERROR the subscribe and unSubscribe signals should never be set high at the same time or serious errors can occur") ; 
            }
        
        __context__.SourceCodeLine = 397;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKSUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 399;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 400;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u0067\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 401;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 402;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u0066\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 403;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 404;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u0065\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 405;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 406;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u0064\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 407;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 408;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 409;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 410;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 411;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 412;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u007A\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 413;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 414;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u007C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 415;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 416;
            MakeString ( TX__DOLLAR__ , "\u008A\u0000\u0000\u0003{0}\u0000\u007E\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 417;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 418;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u008D\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 419;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 420;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0090\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 421;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 422;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0092\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 423;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 424;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0094\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 425;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 426;
            MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0093\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 427;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 428;
            _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 429;
            _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
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
        
        __context__.SourceCodeLine = 435;
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
        
            
            __context__.SourceCodeLine = 437;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u008E\u0000\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) ) ; 
            __context__.SourceCodeLine = 438;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 439;
            MakeString ( TX__DOLLAR__ , "\u008E\u0000\u0000\u0003{0}\u0000\u0091\u0000\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) ) ; 
            __context__.SourceCodeLine = 440;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 442;
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
        
        __context__.SourceCodeLine = 450;
        MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u008E\u0000\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) ) ; 
        __context__.SourceCodeLine = 451;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 452;
        MakeString ( TX__DOLLAR__ , "\u008F\u0000\u0000\u0003{0}\u0000\u0091\u0000\u0000{1}{2}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) METER_RATE__DOLLAR__  .Value ) ) ) ) ; 
        __context__.SourceCodeLine = 453;
        Functions.ProcessLogic ( ) ; 
        __context__.SourceCodeLine = 455;
        _SplusNVRAM.METER_SUBSCRIBE = (ushort) ( METER_SUBSCRIBE__DOLLAR__  .Value ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUTO_ANSWER__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 462;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( AUTO_ANSWER__DOLLAR__  .UshortValue < 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( AUTO_ANSWER__DOLLAR__  .UshortValue > 10 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 464;
            Print( "error auto_answer for the telephone input card must be between 0-10.") ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 467;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u007C\u0000\u0000\u0000{1}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( AUTO_ANSWER__DOLLAR__  .UshortValue ) ) ) ; 
            __context__.SourceCodeLine = 468;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 470;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u007C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 471;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TX_GAIN__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 477;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TX_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.TX_GAIN))  ) ) 
            { 
            __context__.SourceCodeLine = 479;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKTX_GAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 480;
                _SplusNVRAM.XOKTX_GAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 481;
                _SplusNVRAM.TX_GAIN = (ushort) ( TX_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 482;
                TX_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.TX_GAIN ) ; 
                __context__.SourceCodeLine = 483;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u008D{1}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( TX_GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 484;
                _SplusNVRAM.XOKTX_GAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX_GAIN__DOLLAR___OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 490;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RX_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.RX_GAIN))  ) ) 
            { 
            __context__.SourceCodeLine = 492;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKRX_GAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 493;
                _SplusNVRAM.XOKRX_GAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 494;
                _SplusNVRAM.RX_GAIN = (ushort) ( RX_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 495;
                RX_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.RX_GAIN ) ; 
                __context__.SourceCodeLine = 496;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0090{1}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( RX_GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 497;
                _SplusNVRAM.XOKRX_GAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DTMF_GAIN__DOLLAR___OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 503;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DTMF_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.DTMF_GAIN))  ) ) 
            { 
            __context__.SourceCodeLine = 505;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKDTMF_GAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 506;
                _SplusNVRAM.XOKDTMF_GAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 507;
                _SplusNVRAM.DTMF_GAIN = (ushort) ( DTMF_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 508;
                DTMF_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.DTMF_GAIN ) ; 
                __context__.SourceCodeLine = 509;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0092{1}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( DTMF_GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 510;
                _SplusNVRAM.XOKDTMF_GAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIAL_TONE_GAIN__DOLLAR___OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 516;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIAL_TONE_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.DIAL_TONE_GAIN))  ) ) 
            { 
            __context__.SourceCodeLine = 518;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKDIAL_TONE_GAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 519;
                _SplusNVRAM.XOKDIAL_TONE_GAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 520;
                _SplusNVRAM.DIAL_TONE_GAIN = (ushort) ( DIAL_TONE_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 521;
                DIAL_TONE_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.DIAL_TONE_GAIN ) ; 
                __context__.SourceCodeLine = 522;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0094{1}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( DIAL_TONE_GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 523;
                _SplusNVRAM.XOKDIAL_TONE_GAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RING_GAIN__DOLLAR___OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 529;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (RING_GAIN__DOLLAR__  .UshortValue != _SplusNVRAM.RING_GAIN))  ) ) 
            { 
            __context__.SourceCodeLine = 531;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOKRING_GAIN)  ) ) 
                { 
                __context__.SourceCodeLine = 532;
                _SplusNVRAM.XOKRING_GAIN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 533;
                _SplusNVRAM.RING_GAIN = (ushort) ( RING_GAIN__DOLLAR__  .UshortValue ) ; 
                __context__.SourceCodeLine = 534;
                RING_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.RING_GAIN ) ; 
                __context__.SourceCodeLine = 535;
                MakeString ( TX__DOLLAR__ , "\u008D\u0000\u0000\u0003{0}\u0000\u0093{1}\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , ITOVOLUMEPERCENT (  __context__ , (ushort)( RING_GAIN__DOLLAR__  .UshortValue )) ) ; 
                __context__.SourceCodeLine = 536;
                _SplusNVRAM.XOKRING_GAIN = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_1__DOLLAR___OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 545;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0069\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 546;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0069\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_2__DOLLAR___OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 550;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006A\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 551;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006A\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_3__DOLLAR___OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 555;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006B\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 556;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006B\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_4__DOLLAR___OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 560;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006C\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 561;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_5__DOLLAR___OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 565;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006D\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 566;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006D\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_6__DOLLAR___OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 570;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006E\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 571;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006E\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_7__DOLLAR___OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 575;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006F\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 576;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u006F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_8__DOLLAR___OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 580;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0070\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 581;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0070\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_9__DOLLAR___OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 585;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0071\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 586;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0071\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_0__DOLLAR___OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 590;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0068\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 591;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0068\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HANG_UP__DOLLAR___OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 596;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u007F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIAL__DOLLAR___OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 600;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u007F\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TOGGLE_DIAL_HANG_UP__DOLLAR___OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 604;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0079\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 605;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0079\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_PAUSE__DOLLAR___OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 609;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0074\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 610;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0074\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_DELETE__DOLLAR___OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 614;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0076\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 615;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0076\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_REDIAL__DOLLAR___OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 619;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0078\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 620;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0078\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_INTERNATIONAL_PLUS__DOLLAR___OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 624;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0075\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 625;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0075\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_BACKSPACE__DOLLAR___OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 629;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0077\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 630;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0077\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_FLASH__DOLLAR___OnPush_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 634;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u007B\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 635;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u007B\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON___POUND____DOLLAR___OnPush_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 639;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0072\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 640;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0072\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BUTTON_ASTERISK__DOLLAR___OnPush_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 644;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0073\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 645;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u0073\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TX_MUTEON__DOLLAR___OnPush_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 650;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 651;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 653;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 654;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TX_MUTEOFF__DOLLAR___OnPush_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 659;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 660;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 662;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 663;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TX_MUTETOGGLE__DOLLAR___OnPush_33 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 668;
        if ( Functions.TestForTrue  ( ( TX_MUTE_FB__DOLLAR__  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 669;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 670;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 672;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 673;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 677;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 678;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 680;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008C\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 681;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX_MUTEON__DOLLAR___OnPush_34 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 687;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 688;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 690;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 691;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX_MUTEOFF__DOLLAR___OnPush_35 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 696;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 697;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
            { 
            __context__.SourceCodeLine = 699;
            MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 700;
            Functions.ProcessLogic ( ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX_MUTETOGGLE__DOLLAR___OnPush_36 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 705;
        if ( Functions.TestForTrue  ( ( RX_MUTE_FB__DOLLAR__  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 706;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 707;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 709;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 710;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 714;
            MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 715;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.SUBSCRIBE)  ) ) 
                { 
                __context__.SourceCodeLine = 717;
                MakeString ( TX__DOLLAR__ , "\u0089\u0000\u0000\u0003{0}\u0000\u008F\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 718;
                Functions.ProcessLogic ( ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SPEED_STORE__DOLLAR___OnPush_37 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 725;
        _SplusNVRAM.XSAVE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 726;
        _SplusNVRAM.STATEVARSAVE = (ushort) ( (((_SplusNVRAM.XSAVE - 1) * 7) + 204) ) ; 
        __context__.SourceCodeLine = 727;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSAVE ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSAVE ) ) ) ) ; 
        __context__.SourceCodeLine = 728;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARSAVE ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARSAVE ) ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SPEED_DIAL__DOLLAR___OnPush_38 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 732;
        _SplusNVRAM.XDIAL = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 733;
        _SplusNVRAM.STATEVARDIAL = (ushort) ( (((_SplusNVRAM.XDIAL - 1) * 7) + 205) ) ; 
        __context__.SourceCodeLine = 734;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0001\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARDIAL ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARDIAL ) ) ) ) ; 
        __context__.SourceCodeLine = 735;
        MakeString ( TX__DOLLAR__ , "\u0088\u0000\u0000\u0003{0}{1}{2}\u0000\u0000\u0000\u0000\u0003\u0003\u0003\u0003\u0003", CARD__DOLLAR__ , Functions.Chr (  (int) ( Functions.High( (ushort) _SplusNVRAM.STATEVARDIAL ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) _SplusNVRAM.STATEVARDIAL ) ) ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_39 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort TEMP = 0;
        
        
        __context__.SourceCodeLine = 749;
        if ( Functions.TestForTrue  ( ( _SplusNVRAM.XOK)  ) ) 
            { 
            __context__.SourceCodeLine = 751;
            _SplusNVRAM.XOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 752;
            while ( Functions.TestForTrue  ( ( Functions.Length( RX__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 754;
                TEMP = (ushort) ( Functions.Find( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 755;
                if ( Functions.TestForTrue  ( ( TEMP)  ) ) 
                    { 
                    __context__.SourceCodeLine = 757;
                    TEMP = (ushort) ( (TEMP + 5) ) ; 
                    __context__.SourceCodeLine = 758;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( RX__DOLLAR__ , (int)( TEMP ) , (int)( 1 ) ) == "\u0003"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 759;
                        _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 762;
                        _SplusNVRAM.TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u0003\u0003\u0003\u0003\u0003" , RX__DOLLAR__ )  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 764;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == "\u0000\u0000\u0000") ) || Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 6 ) , (int)( 3 ) ) == CARD__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 766;
                        switch ((int)WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 9 ) , (ushort)( 10 ) ))
                        
                            { 
                            case 100 : 
                            
                                { 
                                __context__.SourceCodeLine = 770;
                                if ( Functions.TestForTrue  ( ( _SplusNVRAM.MAINREC3)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 771;
                                    _SplusNVRAM.MAINREC3 = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 772;
                                    PHONE_NUMBER_FB__DOLLAR__  .UpdateValue ( _SplusNVRAM.MAINSTR3 + BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 775;
                                    PHONE_NUMBER_FB__DOLLAR__  .UpdateValue ( BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 777;
                                break ; 
                                } 
                            
                            goto case 101 ;
                            case 101 : 
                            
                                { 
                                __context__.SourceCodeLine = 781;
                                _SplusNVRAM.MAINREC3 = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 782;
                                if ( Functions.TestForTrue  ( ( _SplusNVRAM.MAINREC2)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 783;
                                    _SplusNVRAM.MAINREC2 = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 784;
                                    _SplusNVRAM.MAINSTR3  .UpdateValue ( _SplusNVRAM.MAINSTR2 + BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 787;
                                    _SplusNVRAM.MAINSTR3  .UpdateValue ( BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 789;
                                break ; 
                                } 
                            
                            goto case 102 ;
                            case 102 : 
                            
                                { 
                                __context__.SourceCodeLine = 793;
                                _SplusNVRAM.MAINREC2 = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 794;
                                if ( Functions.TestForTrue  ( ( _SplusNVRAM.MAINREC1)  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 795;
                                    _SplusNVRAM.MAINREC1 = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 796;
                                    _SplusNVRAM.MAINSTR2  .UpdateValue ( _SplusNVRAM.MAINSTR1 + BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 799;
                                    _SplusNVRAM.MAINSTR2  .UpdateValue ( BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 801;
                                break ; 
                                } 
                            
                            goto case 103 ;
                            case 103 : 
                            
                                { 
                                __context__.SourceCodeLine = 805;
                                _SplusNVRAM.MAINREC1 = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 806;
                                _SplusNVRAM.MAINSTR1  .UpdateValue ( BYTESTOSTRING (  __context__ , (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 11 ) , (ushort)( 12 ) ) ), (ushort)( WORDTOI( __context__ , _SplusNVRAM.TEMPSTRING , (ushort)( 13 ) , (ushort)( 14 ) ) ))  ) ; 
                                __context__.SourceCodeLine = 807;
                                break ; 
                                } 
                            
                            goto case 122 ;
                            case 122 : 
                            
                                { 
                                __context__.SourceCodeLine = 811;
                                INCOMING_CALL_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                __context__.SourceCodeLine = 812;
                                break ; 
                                } 
                            
                            goto case 124 ;
                            case 124 : 
                            
                                { 
                                __context__.SourceCodeLine = 817;
                                AUTO_ANSWER_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                __context__.SourceCodeLine = 818;
                                break ; 
                                } 
                            
                            goto case 126 ;
                            case 126 : 
                            
                                { 
                                __context__.SourceCodeLine = 822;
                                HOOK_STATUS_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                __context__.SourceCodeLine = 823;
                                break ; 
                                } 
                            
                            goto case 140 ;
                            case 140 : 
                            
                                { 
                                __context__.SourceCodeLine = 827;
                                TX_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                __context__.SourceCodeLine = 828;
                                break ; 
                                } 
                            
                            goto case 141 ;
                            case 141 : 
                            
                                { 
                                __context__.SourceCodeLine = 832;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 833;
                                TX_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 834;
                                break ; 
                                } 
                            
                            goto case 142 ;
                            case 142 : 
                            
                                { 
                                __context__.SourceCodeLine = 838;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 839;
                                TX_METER_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 840;
                                break ; 
                                } 
                            
                            goto case 143 ;
                            case 143 : 
                            
                                { 
                                __context__.SourceCodeLine = 844;
                                RX_MUTE_FB__DOLLAR__  .Value = (ushort) ( Byte( _SplusNVRAM.TEMPSTRING , (int)( 14 ) ) ) ; 
                                __context__.SourceCodeLine = 845;
                                break ; 
                                } 
                            
                            goto case 144 ;
                            case 144 : 
                            
                                { 
                                __context__.SourceCodeLine = 849;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 850;
                                RX_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 851;
                                break ; 
                                } 
                            
                            goto case 145 ;
                            case 145 : 
                            
                                { 
                                __context__.SourceCodeLine = 855;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 856;
                                RX_METER_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 857;
                                break ; 
                                } 
                            
                            goto case 146 ;
                            case 146 : 
                            
                                { 
                                __context__.SourceCodeLine = 861;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 862;
                                DTMF_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 863;
                                break ; 
                                } 
                            
                            goto case 147 ;
                            case 147 : 
                            
                                { 
                                __context__.SourceCodeLine = 867;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 868;
                                RING_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 869;
                                break ; 
                                } 
                            
                            goto case 148 ;
                            case 148 : 
                            
                                { 
                                __context__.SourceCodeLine = 873;
                                _SplusNVRAM.VOLUMEINPUT = (ushort) ( VOLUMEPERCENTTOI( __context__ , Functions.Mid( _SplusNVRAM.TEMPSTRING , (int)( 11 ) , (int)( 4 ) ) ) ) ; 
                                __context__.SourceCodeLine = 874;
                                DIAL_TONE_GAIN_FB__DOLLAR__  .Value = (ushort) ( _SplusNVRAM.VOLUMEINPUT ) ; 
                                __context__.SourceCodeLine = 875;
                                break ; 
                                } 
                            
                            break;
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 879;
                    Functions.ClearBuffer ( _SplusNVRAM.TEMPSTRING ) ; 
                    } 
                
                __context__.SourceCodeLine = 752;
                } 
            
            __context__.SourceCodeLine = 882;
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
        
        __context__.SourceCodeLine = 900;
        _SplusNVRAM.XOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 901;
        _SplusNVRAM.XOKRING_GAIN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 902;
        _SplusNVRAM.XOKDTMF_GAIN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 903;
        _SplusNVRAM.XOKDIAL_TONE_GAIN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 904;
        _SplusNVRAM.XOKTX_GAIN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 905;
        _SplusNVRAM.XOKRX_GAIN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 906;
        _SplusNVRAM.XOKSUBSCRIBE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 907;
        _SplusNVRAM.SUBSCRIBE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 909;
        _SplusNVRAM.MAINREC1 = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 910;
        _SplusNVRAM.MAINREC2 = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 911;
        _SplusNVRAM.MAINREC3 = (ushort) ( 0 ) ; 
        
        
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
    _SplusNVRAM.MAINSTR1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    _SplusNVRAM.MAINSTR2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    _SplusNVRAM.MAINSTR3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
    
    SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( SUBSCRIBE__DOLLAR____DigitalInput__, SUBSCRIBE__DOLLAR__ );
    
    UNSUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( UNSUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( UNSUBSCRIBE__DOLLAR____DigitalInput__, UNSUBSCRIBE__DOLLAR__ );
    
    METER_SUBSCRIBE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( METER_SUBSCRIBE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( METER_SUBSCRIBE__DOLLAR____DigitalInput__, METER_SUBSCRIBE__DOLLAR__ );
    
    BUTTON_1__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_1__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_1__DOLLAR____DigitalInput__, BUTTON_1__DOLLAR__ );
    
    BUTTON_2__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_2__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_2__DOLLAR____DigitalInput__, BUTTON_2__DOLLAR__ );
    
    BUTTON_3__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_3__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_3__DOLLAR____DigitalInput__, BUTTON_3__DOLLAR__ );
    
    BUTTON_4__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_4__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_4__DOLLAR____DigitalInput__, BUTTON_4__DOLLAR__ );
    
    BUTTON_5__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_5__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_5__DOLLAR____DigitalInput__, BUTTON_5__DOLLAR__ );
    
    BUTTON_6__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_6__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_6__DOLLAR____DigitalInput__, BUTTON_6__DOLLAR__ );
    
    BUTTON_7__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_7__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_7__DOLLAR____DigitalInput__, BUTTON_7__DOLLAR__ );
    
    BUTTON_8__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_8__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_8__DOLLAR____DigitalInput__, BUTTON_8__DOLLAR__ );
    
    BUTTON_9__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_9__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_9__DOLLAR____DigitalInput__, BUTTON_9__DOLLAR__ );
    
    BUTTON_0__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_0__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_0__DOLLAR____DigitalInput__, BUTTON_0__DOLLAR__ );
    
    BUTTON_PAUSE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_PAUSE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_PAUSE__DOLLAR____DigitalInput__, BUTTON_PAUSE__DOLLAR__ );
    
    BUTTON_DELETE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_DELETE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_DELETE__DOLLAR____DigitalInput__, BUTTON_DELETE__DOLLAR__ );
    
    BUTTON_REDIAL__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_REDIAL__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_REDIAL__DOLLAR____DigitalInput__, BUTTON_REDIAL__DOLLAR__ );
    
    BUTTON_INTERNATIONAL_PLUS__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_INTERNATIONAL_PLUS__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_INTERNATIONAL_PLUS__DOLLAR____DigitalInput__, BUTTON_INTERNATIONAL_PLUS__DOLLAR__ );
    
    BUTTON_BACKSPACE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_BACKSPACE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_BACKSPACE__DOLLAR____DigitalInput__, BUTTON_BACKSPACE__DOLLAR__ );
    
    BUTTON_FLASH__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_FLASH__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_FLASH__DOLLAR____DigitalInput__, BUTTON_FLASH__DOLLAR__ );
    
    BUTTON___POUND____DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON___POUND____DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON___POUND____DOLLAR____DigitalInput__, BUTTON___POUND____DOLLAR__ );
    
    BUTTON_ASTERISK__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( BUTTON_ASTERISK__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( BUTTON_ASTERISK__DOLLAR____DigitalInput__, BUTTON_ASTERISK__DOLLAR__ );
    
    HANG_UP__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( HANG_UP__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( HANG_UP__DOLLAR____DigitalInput__, HANG_UP__DOLLAR__ );
    
    DIAL__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( DIAL__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( DIAL__DOLLAR____DigitalInput__, DIAL__DOLLAR__ );
    
    TOGGLE_DIAL_HANG_UP__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( TOGGLE_DIAL_HANG_UP__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( TOGGLE_DIAL_HANG_UP__DOLLAR____DigitalInput__, TOGGLE_DIAL_HANG_UP__DOLLAR__ );
    
    TX_MUTEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( TX_MUTEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( TX_MUTEON__DOLLAR____DigitalInput__, TX_MUTEON__DOLLAR__ );
    
    TX_MUTEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( TX_MUTEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( TX_MUTEOFF__DOLLAR____DigitalInput__, TX_MUTEOFF__DOLLAR__ );
    
    TX_MUTETOGGLE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( TX_MUTETOGGLE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( TX_MUTETOGGLE__DOLLAR____DigitalInput__, TX_MUTETOGGLE__DOLLAR__ );
    
    RX_MUTEON__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( RX_MUTEON__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( RX_MUTEON__DOLLAR____DigitalInput__, RX_MUTEON__DOLLAR__ );
    
    RX_MUTEOFF__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( RX_MUTEOFF__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( RX_MUTEOFF__DOLLAR____DigitalInput__, RX_MUTEOFF__DOLLAR__ );
    
    RX_MUTETOGGLE__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalInput( RX_MUTETOGGLE__DOLLAR____DigitalInput__, this );
    m_DigitalInputList.Add( RX_MUTETOGGLE__DOLLAR____DigitalInput__, RX_MUTETOGGLE__DOLLAR__ );
    
    SPEED_STORE__DOLLAR__ = new InOutArray<DigitalInput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        SPEED_STORE__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SPEED_STORE__DOLLAR____DigitalInput__ + i, SPEED_STORE__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( SPEED_STORE__DOLLAR____DigitalInput__ + i, SPEED_STORE__DOLLAR__[i+1] );
    }
    
    SPEED_DIAL__DOLLAR__ = new InOutArray<DigitalInput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        SPEED_DIAL__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SPEED_DIAL__DOLLAR____DigitalInput__ + i, SPEED_DIAL__DOLLAR____DigitalInput__, this );
        m_DigitalInputList.Add( SPEED_DIAL__DOLLAR____DigitalInput__ + i, SPEED_DIAL__DOLLAR__[i+1] );
    }
    
    INCOMING_CALL_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( INCOMING_CALL_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( INCOMING_CALL_FB__DOLLAR____DigitalOutput__, INCOMING_CALL_FB__DOLLAR__ );
    
    HOOK_STATUS_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( HOOK_STATUS_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( HOOK_STATUS_FB__DOLLAR____DigitalOutput__, HOOK_STATUS_FB__DOLLAR__ );
    
    TX_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( TX_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( TX_MUTE_FB__DOLLAR____DigitalOutput__, TX_MUTE_FB__DOLLAR__ );
    
    RX_MUTE_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.DigitalOutput( RX_MUTE_FB__DOLLAR____DigitalOutput__, this );
    m_DigitalOutputList.Add( RX_MUTE_FB__DOLLAR____DigitalOutput__, RX_MUTE_FB__DOLLAR__ );
    
    SPEED_DIAL_FB__DOLLAR__ = new InOutArray<DigitalOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        SPEED_DIAL_FB__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SPEED_DIAL_FB__DOLLAR____DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SPEED_DIAL_FB__DOLLAR____DigitalOutput__ + i, SPEED_DIAL_FB__DOLLAR__[i+1] );
    }
    
    AUTO_ANSWER__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( AUTO_ANSWER__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( AUTO_ANSWER__DOLLAR____AnalogSerialInput__, AUTO_ANSWER__DOLLAR__ );
    
    TX_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( TX_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( TX_GAIN__DOLLAR____AnalogSerialInput__, TX_GAIN__DOLLAR__ );
    
    RX_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( RX_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( RX_GAIN__DOLLAR____AnalogSerialInput__, RX_GAIN__DOLLAR__ );
    
    DTMF_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( DTMF_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( DTMF_GAIN__DOLLAR____AnalogSerialInput__, DTMF_GAIN__DOLLAR__ );
    
    DIAL_TONE_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( DIAL_TONE_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( DIAL_TONE_GAIN__DOLLAR____AnalogSerialInput__, DIAL_TONE_GAIN__DOLLAR__ );
    
    RING_GAIN__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogInput( RING_GAIN__DOLLAR____AnalogSerialInput__, this );
    m_AnalogInputList.Add( RING_GAIN__DOLLAR____AnalogSerialInput__, RING_GAIN__DOLLAR__ );
    
    AUTO_ANSWER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( AUTO_ANSWER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AUTO_ANSWER_FB__DOLLAR____AnalogSerialOutput__, AUTO_ANSWER_FB__DOLLAR__ );
    
    TX_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( TX_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TX_GAIN_FB__DOLLAR____AnalogSerialOutput__, TX_GAIN_FB__DOLLAR__ );
    
    TX_METER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( TX_METER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TX_METER_FB__DOLLAR____AnalogSerialOutput__, TX_METER_FB__DOLLAR__ );
    
    RX_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( RX_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RX_GAIN_FB__DOLLAR____AnalogSerialOutput__, RX_GAIN_FB__DOLLAR__ );
    
    RX_METER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( RX_METER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RX_METER_FB__DOLLAR____AnalogSerialOutput__, RX_METER_FB__DOLLAR__ );
    
    DTMF_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( DTMF_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DTMF_GAIN_FB__DOLLAR____AnalogSerialOutput__, DTMF_GAIN_FB__DOLLAR__ );
    
    DIAL_TONE_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( DIAL_TONE_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DIAL_TONE_GAIN_FB__DOLLAR____AnalogSerialOutput__, DIAL_TONE_GAIN_FB__DOLLAR__ );
    
    RING_GAIN_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.AnalogOutput( RING_GAIN_FB__DOLLAR____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RING_GAIN_FB__DOLLAR____AnalogSerialOutput__, RING_GAIN_FB__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    PHONE_NUMBER_FB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PHONE_NUMBER_FB__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( PHONE_NUMBER_FB__DOLLAR____AnalogSerialOutput__, PHONE_NUMBER_FB__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 400, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    METER_RATE__DOLLAR__ = new UShortParameter( METER_RATE__DOLLAR____Parameter__, this );
    m_ParameterList.Add( METER_RATE__DOLLAR____Parameter__, METER_RATE__DOLLAR__ );
    
    CARD__DOLLAR__ = new StringParameter( CARD__DOLLAR____Parameter__, this );
    m_ParameterList.Add( CARD__DOLLAR____Parameter__, CARD__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_1___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_1___CallbackFn );
    
    SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUBSCRIBE__DOLLAR___OnPush_0, false ) );
    UNSUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( UNSUBSCRIBE__DOLLAR___OnPush_1, false ) );
    METER_SUBSCRIBE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( METER_SUBSCRIBE__DOLLAR___OnPush_2, false ) );
    METER_SUBSCRIBE__DOLLAR__.OnDigitalRelease.Add( new InputChangeHandlerWrapper( METER_SUBSCRIBE__DOLLAR___OnRelease_3, false ) );
    AUTO_ANSWER__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( AUTO_ANSWER__DOLLAR___OnChange_4, false ) );
    TX_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( TX_GAIN__DOLLAR___OnChange_5, false ) );
    RX_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( RX_GAIN__DOLLAR___OnChange_6, false ) );
    DTMF_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( DTMF_GAIN__DOLLAR___OnChange_7, false ) );
    DIAL_TONE_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( DIAL_TONE_GAIN__DOLLAR___OnChange_8, false ) );
    RING_GAIN__DOLLAR__.OnAnalogChange.Add( new InputChangeHandlerWrapper( RING_GAIN__DOLLAR___OnChange_9, false ) );
    BUTTON_1__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_1__DOLLAR___OnPush_10, false ) );
    BUTTON_2__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_2__DOLLAR___OnPush_11, false ) );
    BUTTON_3__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_3__DOLLAR___OnPush_12, false ) );
    BUTTON_4__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_4__DOLLAR___OnPush_13, false ) );
    BUTTON_5__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_5__DOLLAR___OnPush_14, false ) );
    BUTTON_6__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_6__DOLLAR___OnPush_15, false ) );
    BUTTON_7__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_7__DOLLAR___OnPush_16, false ) );
    BUTTON_8__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_8__DOLLAR___OnPush_17, false ) );
    BUTTON_9__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_9__DOLLAR___OnPush_18, false ) );
    BUTTON_0__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_0__DOLLAR___OnPush_19, false ) );
    HANG_UP__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( HANG_UP__DOLLAR___OnPush_20, false ) );
    DIAL__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIAL__DOLLAR___OnPush_21, false ) );
    TOGGLE_DIAL_HANG_UP__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( TOGGLE_DIAL_HANG_UP__DOLLAR___OnPush_22, false ) );
    BUTTON_PAUSE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_PAUSE__DOLLAR___OnPush_23, false ) );
    BUTTON_DELETE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_DELETE__DOLLAR___OnPush_24, false ) );
    BUTTON_REDIAL__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_REDIAL__DOLLAR___OnPush_25, false ) );
    BUTTON_INTERNATIONAL_PLUS__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_INTERNATIONAL_PLUS__DOLLAR___OnPush_26, false ) );
    BUTTON_BACKSPACE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_BACKSPACE__DOLLAR___OnPush_27, false ) );
    BUTTON_FLASH__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_FLASH__DOLLAR___OnPush_28, false ) );
    BUTTON___POUND____DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON___POUND____DOLLAR___OnPush_29, false ) );
    BUTTON_ASTERISK__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( BUTTON_ASTERISK__DOLLAR___OnPush_30, false ) );
    TX_MUTEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( TX_MUTEON__DOLLAR___OnPush_31, false ) );
    TX_MUTEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( TX_MUTEOFF__DOLLAR___OnPush_32, false ) );
    TX_MUTETOGGLE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( TX_MUTETOGGLE__DOLLAR___OnPush_33, false ) );
    RX_MUTEON__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( RX_MUTEON__DOLLAR___OnPush_34, false ) );
    RX_MUTEOFF__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( RX_MUTEOFF__DOLLAR___OnPush_35, false ) );
    RX_MUTETOGGLE__DOLLAR__.OnDigitalPush.Add( new InputChangeHandlerWrapper( RX_MUTETOGGLE__DOLLAR___OnPush_36, false ) );
    for( uint i = 0; i < 16; i++ )
        SPEED_STORE__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SPEED_STORE__DOLLAR___OnPush_37, false ) );
        
    for( uint i = 0; i < 16; i++ )
        SPEED_DIAL__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SPEED_DIAL__DOLLAR___OnPush_38, false ) );
        
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_39, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BSS_SOUNDWEB_LONDON_ANALOG_TELEPHONE_INPUT_CARD ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_1___Callback;


const uint SUBSCRIBE__DOLLAR____DigitalInput__ = 0;
const uint UNSUBSCRIBE__DOLLAR____DigitalInput__ = 1;
const uint METER_SUBSCRIBE__DOLLAR____DigitalInput__ = 2;
const uint BUTTON_1__DOLLAR____DigitalInput__ = 3;
const uint BUTTON_2__DOLLAR____DigitalInput__ = 4;
const uint BUTTON_3__DOLLAR____DigitalInput__ = 5;
const uint BUTTON_4__DOLLAR____DigitalInput__ = 6;
const uint BUTTON_5__DOLLAR____DigitalInput__ = 7;
const uint BUTTON_6__DOLLAR____DigitalInput__ = 8;
const uint BUTTON_7__DOLLAR____DigitalInput__ = 9;
const uint BUTTON_8__DOLLAR____DigitalInput__ = 10;
const uint BUTTON_9__DOLLAR____DigitalInput__ = 11;
const uint BUTTON_0__DOLLAR____DigitalInput__ = 12;
const uint BUTTON_PAUSE__DOLLAR____DigitalInput__ = 13;
const uint BUTTON_DELETE__DOLLAR____DigitalInput__ = 14;
const uint BUTTON_REDIAL__DOLLAR____DigitalInput__ = 15;
const uint BUTTON_INTERNATIONAL_PLUS__DOLLAR____DigitalInput__ = 16;
const uint BUTTON_BACKSPACE__DOLLAR____DigitalInput__ = 17;
const uint BUTTON_FLASH__DOLLAR____DigitalInput__ = 18;
const uint BUTTON___POUND____DOLLAR____DigitalInput__ = 19;
const uint BUTTON_ASTERISK__DOLLAR____DigitalInput__ = 20;
const uint HANG_UP__DOLLAR____DigitalInput__ = 21;
const uint DIAL__DOLLAR____DigitalInput__ = 22;
const uint TOGGLE_DIAL_HANG_UP__DOLLAR____DigitalInput__ = 23;
const uint TX_MUTEON__DOLLAR____DigitalInput__ = 24;
const uint TX_MUTEOFF__DOLLAR____DigitalInput__ = 25;
const uint TX_MUTETOGGLE__DOLLAR____DigitalInput__ = 26;
const uint RX_MUTEON__DOLLAR____DigitalInput__ = 27;
const uint RX_MUTEOFF__DOLLAR____DigitalInput__ = 28;
const uint RX_MUTETOGGLE__DOLLAR____DigitalInput__ = 29;
const uint SPEED_STORE__DOLLAR____DigitalInput__ = 30;
const uint SPEED_DIAL__DOLLAR____DigitalInput__ = 46;
const uint AUTO_ANSWER__DOLLAR____AnalogSerialInput__ = 0;
const uint TX_GAIN__DOLLAR____AnalogSerialInput__ = 1;
const uint RX_GAIN__DOLLAR____AnalogSerialInput__ = 2;
const uint DTMF_GAIN__DOLLAR____AnalogSerialInput__ = 3;
const uint DIAL_TONE_GAIN__DOLLAR____AnalogSerialInput__ = 4;
const uint RING_GAIN__DOLLAR____AnalogSerialInput__ = 5;
const uint RX__DOLLAR____AnalogSerialInput__ = 6;
const uint INCOMING_CALL_FB__DOLLAR____DigitalOutput__ = 0;
const uint HOOK_STATUS_FB__DOLLAR____DigitalOutput__ = 1;
const uint TX_MUTE_FB__DOLLAR____DigitalOutput__ = 2;
const uint RX_MUTE_FB__DOLLAR____DigitalOutput__ = 3;
const uint SPEED_DIAL_FB__DOLLAR____DigitalOutput__ = 4;
const uint AUTO_ANSWER_FB__DOLLAR____AnalogSerialOutput__ = 0;
const uint TX_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 1;
const uint TX_METER_FB__DOLLAR____AnalogSerialOutput__ = 2;
const uint RX_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 3;
const uint RX_METER_FB__DOLLAR____AnalogSerialOutput__ = 4;
const uint DTMF_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 5;
const uint DIAL_TONE_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 6;
const uint RING_GAIN_FB__DOLLAR____AnalogSerialOutput__ = 7;
const uint TX__DOLLAR____AnalogSerialOutput__ = 8;
const uint PHONE_NUMBER_FB__DOLLAR____AnalogSerialOutput__ = 9;
const uint METER_RATE__DOLLAR____Parameter__ = 10;
const uint CARD__DOLLAR____Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort XOK = 0;
            [SplusStructAttribute(1, false, true)]
            public CrestronString TEMPSTRING;
            [SplusStructAttribute(2, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(3, false, true)]
            public ushort RETURNI = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort SUBSCRIBE = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort XOKSUBSCRIBE = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort METER_SUBSCRIBE = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort XSAVE = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort XDIAL = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort STATEVARVALUE = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort STATEVARPHANTOM = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort STATEVARRECEIVE = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort STATEVARSAVE = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort STATEVARDIAL = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort VOLUMEINPUT = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort VOLUME = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort TX_GAIN = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort XOKTX_GAIN = 0;
            [SplusStructAttribute(19, false, true)]
            public ushort RX_GAIN = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort XOKRX_GAIN = 0;
            [SplusStructAttribute(21, false, true)]
            public ushort DTMF_GAIN = 0;
            [SplusStructAttribute(22, false, true)]
            public ushort XOKDTMF_GAIN = 0;
            [SplusStructAttribute(23, false, true)]
            public ushort DIAL_TONE_GAIN = 0;
            [SplusStructAttribute(24, false, true)]
            public ushort XOKDIAL_TONE_GAIN = 0;
            [SplusStructAttribute(25, false, true)]
            public ushort RING_GAIN = 0;
            [SplusStructAttribute(26, false, true)]
            public ushort XOKRING_GAIN = 0;
            [SplusStructAttribute(27, false, true)]
            public ushort MAINREC1 = 0;
            [SplusStructAttribute(28, false, true)]
            public ushort MAINREC2 = 0;
            [SplusStructAttribute(29, false, true)]
            public ushort MAINREC3 = 0;
            [SplusStructAttribute(30, false, true)]
            public CrestronString MAINSTR1;
            [SplusStructAttribute(31, false, true)]
            public CrestronString MAINSTR2;
            [SplusStructAttribute(32, false, true)]
            public CrestronString MAINSTR3;
            
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
