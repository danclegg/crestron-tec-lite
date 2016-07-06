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

namespace UserModule_SONY4KIPCONTROL
{
    public class UserModuleClass_SONY4KIPCONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CLIENTCONNECTED;
        Crestron.Logos.SplusObjects.DigitalInput SWITCHTOHDMI1;
        Crestron.Logos.SplusObjects.DigitalInput SWITCHTOHDMI2;
        Crestron.Logos.SplusObjects.DigitalInput SWITCHTOHDMI3;
        Crestron.Logos.SplusObjects.DigitalInput SWITCHTOHDMI4;
        Crestron.Logos.SplusObjects.BufferInput CLIENTBUFFER;
        Crestron.Logos.SplusObjects.DigitalOutput _CLIENTCONNECTED;
        Crestron.Logos.SplusObjects.StringOutput TRANSMIT;
        SplusTcpClient CLIENT;
        CrestronString REPORTINGHOST;
        CrestronString REPORTINGHOSTIP;
        CrestronString INPUT1;
        CrestronString INPUT2;
        CrestronString INPUT3;
        CrestronString INPUT4;
        CrestronString INPUT5;
        CrestronString INPUT6;
        CrestronString INPUT7;
        CrestronString COMMAND;
        CrestronString MESSAGE;
        ushort REPORTINGHOSTPORT = 0;
        private void LOG (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 170;
            Print( "\r\n{0}", MSG ) ; 
            
            }
            
        private void ERROR (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 175;
            LOG (  __context__ , MSG) ; 
            
            }
            
        private void SEND (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 181;
            Functions.SocketSend ( CLIENT , MSG ) ; 
            
            }
            
        private void BUILDHTTPMESSAGE (  SplusExecutionContext __context__, CrestronString ACTION ) 
            { 
            short DST = 0;
            short MNUM = 0;
            short YNUM = 0;
            short DNUM = 0;
            short CONTENTLENGTH = 0;
            
            int PORTNUMBER = 0;
            
            CrestronString TIMESTAMP;
            TIMESTAMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            
            CrestronString DATESTR;
            DATESTR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            
            CrestronString TIMESTR;
            TIMESTR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            
            CrestronString HEADER1;
            CrestronString HEADER2;
            CrestronString HEADER3;
            CrestronString HEADER4;
            CrestronString HEADER5;
            CrestronString HEADER6;
            CrestronString HEADER7;
            HEADER1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER6  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER7  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            CrestronString INNERMSG1;
            CrestronString INNERMSG2;
            CrestronString INNERMSG3;
            INNERMSG1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            INNERMSG2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            INNERMSG3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            CrestronString CLSTRING;
            CLSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            ushort SPACEPOSITION = 0;
            
            
            __context__.SourceCodeLine = 195;
            _CLIENTCONNECTED  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 197;
            MNUM = (short) ( Functions.GetMonthNum() ) ; 
            __context__.SourceCodeLine = 198;
            YNUM = (short) ( Functions.GetYearNum() ) ; 
            __context__.SourceCodeLine = 199;
            DNUM = (short) ( Functions.GetDateNum() ) ; 
            __context__.SourceCodeLine = 201;
            DATESTR  .UpdateValue ( Functions.ItoA (  (int) ( YNUM ) ) + "-" + Functions.ItoA (  (int) ( MNUM ) ) + "-" + Functions.ItoA (  (int) ( DNUM ) )  ) ; 
            __context__.SourceCodeLine = 202;
            TIMESTR  .UpdateValue ( Functions.Time ( )  ) ; 
            __context__.SourceCodeLine = 203;
            DST = (short) ( Functions.GetDst() ) ; 
            __context__.SourceCodeLine = 206;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 207;
                TIMESTAMP  .UpdateValue ( DATESTR + "T" + TIMESTR + "-0600"  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 208;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DST == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 209;
                    TIMESTAMP  .UpdateValue ( DATESTR + "T" + TIMESTR + "-0700"  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 213;
            INNERMSG1  .UpdateValue ( "{\"address\":\"10.5.34.127\",\"command\":\"" + ACTION + "\"}"  ) ; 
            __context__.SourceCodeLine = 214;
            CONTENTLENGTH = (short) ( ((Functions.Length( INNERMSG1 ) + Functions.Length( INNERMSG2 )) + Functions.Length( INNERMSG3 )) ) ; 
            __context__.SourceCodeLine = 215;
            CLSTRING  .UpdateValue ( Functions.ItoA (  (int) ( CONTENTLENGTH ) )  ) ; 
            __context__.SourceCodeLine = 217;
            HEADER1  .UpdateValue ( "POST /byuoitav-sony-control-microservice/0.1/command HTTP/1.1" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 218;
            HEADER2  .UpdateValue ( "Host: " + REPORTINGHOST + ":" + Functions.ItoA (  (int) ( REPORTINGHOSTPORT ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 220;
            HEADER4  .UpdateValue ( "Content-Length: " + CLSTRING + "\r\n"  ) ; 
            __context__.SourceCodeLine = 221;
            HEADER5  .UpdateValue ( "Content-type: application/json" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 222;
            HEADER6  .UpdateValue ( "Authorization: Bearer b8dbb5d5547f10b7fc7c559fafa43ceb" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 223;
            HEADER7  .UpdateValue ( "Accept: application/json" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 225;
            Print( "{0}", HEADER1 ) ; 
            __context__.SourceCodeLine = 226;
            Print( "{0}", HEADER2 ) ; 
            __context__.SourceCodeLine = 228;
            Print( "{0}", HEADER4 ) ; 
            __context__.SourceCodeLine = 229;
            Print( "{0}", HEADER5 ) ; 
            __context__.SourceCodeLine = 230;
            Print( "{0}", HEADER6 ) ; 
            __context__.SourceCodeLine = 231;
            Print( "{0}", HEADER7 ) ; 
            __context__.SourceCodeLine = 232;
            Print( "{0}", "\r\n" ) ; 
            __context__.SourceCodeLine = 233;
            Print( "{0}", INNERMSG1 ) ; 
            __context__.SourceCodeLine = 235;
            SEND (  __context__ , HEADER1) ; 
            __context__.SourceCodeLine = 236;
            SEND (  __context__ , HEADER2) ; 
            __context__.SourceCodeLine = 238;
            SEND (  __context__ , HEADER4) ; 
            __context__.SourceCodeLine = 239;
            SEND (  __context__ , HEADER5) ; 
            __context__.SourceCodeLine = 240;
            SEND (  __context__ , HEADER6) ; 
            __context__.SourceCodeLine = 241;
            SEND (  __context__ , HEADER7) ; 
            __context__.SourceCodeLine = 242;
            SEND (  __context__ , "\r\n") ; 
            __context__.SourceCodeLine = 243;
            SEND (  __context__ , INNERMSG1) ; 
            
            }
            
        object SWITCHTOHDMI1_OnRelease_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 256;
                BUILDHTTPMESSAGE (  __context__ , "AAAAAgAAABoAAABaAw==") ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SWITCHTOHDMI2_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 261;
            BUILDHTTPMESSAGE (  __context__ , "AAAAAgAAABoAAABbAw==") ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SWITCHTOHDMI3_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 266;
        BUILDHTTPMESSAGE (  __context__ , "AAAAAgAAABoAAABcAw==") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SWITCHTOHDMI4_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 271;
        BUILDHTTPMESSAGE (  __context__ , "AAAAAgAAABoAAABdAw==") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENTCONNECTED_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 276;
        STATUS = (short) ( Functions.SocketConnectClient( CLIENT , REPORTINGHOST , (ushort)( REPORTINGHOSTPORT ) , (ushort)( 0 ) ) ) ; 
        __context__.SourceCodeLine = 279;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 280;
            Print( "Error connecting socket to address {0} on port  {1:d}", REPORTINGHOST , (short)REPORTINGHOSTPORT) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENTCONNECTED_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 288;
        STATUS = (short) ( Functions.SocketDisconnectClient( CLIENT ) ) ; 
        __context__.SourceCodeLine = 290;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 291;
            Print( "Error disconnecting socket to address {0} on port {1:d}", REPORTINGHOST , (short)REPORTINGHOSTPORT) ; 
            }
        
        __context__.SourceCodeLine = 292;
        _CLIENTCONNECTED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENT_OnSocketConnect_6 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        short LOCALSTATUS = 0;
        short PORTNUMBER = 0;
        
        
        __context__.SourceCodeLine = 304;
        Print( "OnConnect: input buffer size is: {0:d}\r\n", (short)Functions.Length( CLIENT.SocketRxBuf )) ; 
        __context__.SourceCodeLine = 306;
        LOCALSTATUS = (short) ( Functions.SocketGetRemoteIPAddress( CLIENT , ref REPORTINGHOST ) ) ; 
        __context__.SourceCodeLine = 307;
        PORTNUMBER = (short) ( Functions.SocketGetPortNumber( CLIENT ) ) ; 
        __context__.SourceCodeLine = 309;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOCALSTATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 310;
            Print( "Error getting remote ip address. {0:d}\r\n", (short)LOCALSTATUS) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 311;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( PORTNUMBER < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 312;
                Print( "Error getting client port number. {0:d}\r\n", (int)REPORTINGHOSTPORT) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 314;
                Print( "OnConnect: Connected to port {0:d} on address {1}\r\n", (int)REPORTINGHOSTPORT, REPORTINGHOST ) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketDisconnect_7 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 320;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CLIENTCONNECTED  .Value == 0))  ) ) 
            {
            __context__.SourceCodeLine = 321;
            Print( "Socket disconnected remotely") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 323;
            Print( "Local socket disconnect complete.") ; 
            }
        
        __context__.SourceCodeLine = 325;
        _CLIENTCONNECTED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketReceive_8 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 331;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( CLIENT.SocketRxBuf ) < 256 ))  ) ) 
            {
            __context__.SourceCodeLine = 332;
            Print( "Rx: {0}", CLIENT .  SocketRxBuf ) ; 
            }
        
        __context__.SourceCodeLine = 334;
        Functions.ClearBuffer ( CLIENT .  SocketRxBuf ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketStatus_9 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 341;
        STATUS = (short) ( __SocketInfo__.SocketStatus ) ; 
        __context__.SourceCodeLine = 342;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)STATUS);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 346;
                    LOG (  __context__ , "SOCKET STATUS: Not Connected") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 351;
                    LOG (  __context__ , "SOCKET STATUS: Waiting for Connection") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 355;
                    LOG (  __context__ , "SOCKET STATUS: Connected") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 359;
                    LOG (  __context__ , "SOCKET STATUS: Connection Failed") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 364;
                    LOG (  __context__ , "SOCKET STATUS: Connection Broken Remotely") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 369;
                    LOG (  __context__ , "SOCKET STATUS: Connection Broken Locally") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 374;
                    LOG (  __context__ , "SOCKET STATUS: Performing DNS Lookup") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 378;
                    LOG (  __context__ , "SOCKET STATUS: DNS Lookup Failed") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 383;
                    LOG (  __context__ , "SOCKET STATUS: DNS Name Resolved") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 1 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 387;
                    LOG (  __context__ , "SOCKET STATUS: Client, Server or UDP variable not a TCP/IP or UDP variable.") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 2 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 392;
                    LOG (  __context__ , "SOCKET STATUS: Could not create the connection task") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 3 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 397;
                    LOG (  __context__ , "SOCKET STATUS: Could not resolve address") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 4 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 402;
                    LOG (  __context__ , "SOCKET STATUS: Port not in range of 0-65535.") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 5 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 407;
                    LOG (  __context__ , "SOCKET STATUS: No connection has been established") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 6 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 411;
                    LOG (  __context__ , "SOCKET STATUS: Not enough room in string parameter to hold IP address.") ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 416;
                    LOG (  __context__ , "Socket Status Undefined") ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 418;
        ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 436;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 438;
        REPORTINGHOST  .UpdateValue ( "api.byu.edu"  ) ; 
        __context__.SourceCodeLine = 440;
        REPORTINGHOSTPORT = (ushort) ( 443 ) ; 
        __context__.SourceCodeLine = 441;
        INPUT1  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 442;
        INPUT2  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 443;
        INPUT3  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 444;
        INPUT4  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 445;
        INPUT5  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 446;
        INPUT6  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 447;
        INPUT7  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 448;
        COMMAND  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 449;
        _CLIENTCONNECTED  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    REPORTINGHOST  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 60, this );
    REPORTINGHOSTIP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT6  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT7  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    COMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    MESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
    CLIENT  = new SplusTcpClient ( 1024, this );
    
    CLIENTCONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( CLIENTCONNECTED__DigitalInput__, this );
    m_DigitalInputList.Add( CLIENTCONNECTED__DigitalInput__, CLIENTCONNECTED );
    
    SWITCHTOHDMI1 = new Crestron.Logos.SplusObjects.DigitalInput( SWITCHTOHDMI1__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCHTOHDMI1__DigitalInput__, SWITCHTOHDMI1 );
    
    SWITCHTOHDMI2 = new Crestron.Logos.SplusObjects.DigitalInput( SWITCHTOHDMI2__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCHTOHDMI2__DigitalInput__, SWITCHTOHDMI2 );
    
    SWITCHTOHDMI3 = new Crestron.Logos.SplusObjects.DigitalInput( SWITCHTOHDMI3__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCHTOHDMI3__DigitalInput__, SWITCHTOHDMI3 );
    
    SWITCHTOHDMI4 = new Crestron.Logos.SplusObjects.DigitalInput( SWITCHTOHDMI4__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCHTOHDMI4__DigitalInput__, SWITCHTOHDMI4 );
    
    _CLIENTCONNECTED = new Crestron.Logos.SplusObjects.DigitalOutput( _CLIENTCONNECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( _CLIENTCONNECTED__DigitalOutput__, _CLIENTCONNECTED );
    
    TRANSMIT = new Crestron.Logos.SplusObjects.StringOutput( TRANSMIT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TRANSMIT__AnalogSerialOutput__, TRANSMIT );
    
    CLIENTBUFFER = new Crestron.Logos.SplusObjects.BufferInput( CLIENTBUFFER__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( CLIENTBUFFER__AnalogSerialInput__, CLIENTBUFFER );
    
    
    SWITCHTOHDMI1.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SWITCHTOHDMI1_OnRelease_0, false ) );
    SWITCHTOHDMI2.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SWITCHTOHDMI2_OnRelease_1, false ) );
    SWITCHTOHDMI3.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SWITCHTOHDMI3_OnRelease_2, false ) );
    SWITCHTOHDMI4.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SWITCHTOHDMI4_OnRelease_3, false ) );
    CLIENTCONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLIENTCONNECTED_OnPush_4, false ) );
    CLIENTCONNECTED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CLIENTCONNECTED_OnRelease_5, false ) );
    CLIENT.OnSocketConnect.Add( new SocketHandlerWrapper( CLIENT_OnSocketConnect_6, true ) );
    CLIENT.OnSocketDisconnect.Add( new SocketHandlerWrapper( CLIENT_OnSocketDisconnect_7, false ) );
    CLIENT.OnSocketReceive.Add( new SocketHandlerWrapper( CLIENT_OnSocketReceive_8, false ) );
    CLIENT.OnSocketStatus.Add( new SocketHandlerWrapper( CLIENT_OnSocketStatus_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SONY4KIPCONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CLIENTCONNECTED__DigitalInput__ = 0;
const uint SWITCHTOHDMI1__DigitalInput__ = 1;
const uint SWITCHTOHDMI2__DigitalInput__ = 2;
const uint SWITCHTOHDMI3__DigitalInput__ = 3;
const uint SWITCHTOHDMI4__DigitalInput__ = 4;
const uint CLIENTBUFFER__AnalogSerialInput__ = 0;
const uint _CLIENTCONNECTED__DigitalOutput__ = 0;
const uint TRANSMIT__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
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
