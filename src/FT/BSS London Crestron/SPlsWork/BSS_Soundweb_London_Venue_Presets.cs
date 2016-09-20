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

namespace UserModule_BSS_SOUNDWEB_LONDON_VENUE_PRESETS
{
    public class UserModuleClass_BSS_SOUNDWEB_LONDON_VENUE_PRESETS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RECALLPRESET__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        private void SEND (  SplusExecutionContext __context__, CrestronString STR ) 
            { 
            
            __context__.SourceCodeLine = 124;
            _SplusNVRAM.CHECKSUM = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 125;
            _SplusNVRAM.SENDSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 126;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( STR ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 128;
                _SplusNVRAM.CHECKSUM = (ushort) ( (_SplusNVRAM.CHECKSUM ^ Byte( STR , (int)( _SplusNVRAM.I ) )) ) ; 
                __context__.SourceCodeLine = 129;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( STR , (int)( _SplusNVRAM.I ) ) == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR , (int)( _SplusNVRAM.I ) ) == 3) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR , (int)( _SplusNVRAM.I ) ) == 6) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR , (int)( _SplusNVRAM.I ) ) == 21) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( STR , (int)( _SplusNVRAM.I ) ) == 27) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 131;
                    MakeString ( _SplusNVRAM.SENDSTRING , "{0}\u001B{1}", _SplusNVRAM.SENDSTRING , Functions.Chr (  (int) ( (Byte( STR , (int)( _SplusNVRAM.I ) ) + 128) ) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 135;
                    MakeString ( _SplusNVRAM.SENDSTRING , "{0}{1}", _SplusNVRAM.SENDSTRING , Functions.Chr (  (int) ( Byte( STR , (int)( _SplusNVRAM.I ) ) ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 126;
                } 
            
            __context__.SourceCodeLine = 138;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.CHECKSUM == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.CHECKSUM == 3) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.CHECKSUM == 6) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.CHECKSUM == 21) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.CHECKSUM == 27) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 140;
                MakeString ( TX__DOLLAR__ , "\u0002{0}\u001B{1}\u0003", _SplusNVRAM.SENDSTRING , Functions.Chr (  (int) ( (_SplusNVRAM.CHECKSUM + 128) ) ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 144;
                MakeString ( TX__DOLLAR__ , "\u0002{0}{1}\u0003", _SplusNVRAM.SENDSTRING , Functions.Chr (  (int) ( _SplusNVRAM.CHECKSUM ) ) ) ; 
                } 
            
            
            }
            
        private CrestronString ITOSTRING (  SplusExecutionContext __context__, ushort INT , ushort SIZE ) 
            { 
            
            __context__.SourceCodeLine = 151;
            _SplusNVRAM.RETURNSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 152;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INT <= 255 ))  ) ) 
                { 
                __context__.SourceCodeLine = 154;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(SIZE - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 156;
                    _SplusNVRAM.RETURNSTRING  .UpdateValue ( _SplusNVRAM.RETURNSTRING + "\u0000"  ) ; 
                    __context__.SourceCodeLine = 154;
                    } 
                
                __context__.SourceCodeLine = 158;
                _SplusNVRAM.RETURNSTRING  .UpdateValue ( _SplusNVRAM.RETURNSTRING + Functions.Chr (  (int) ( INT ) )  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 162;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)(SIZE - 2); 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__2) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__2) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__2) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__2) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 164;
                    _SplusNVRAM.RETURNSTRING  .UpdateValue ( _SplusNVRAM.RETURNSTRING + "\u0000"  ) ; 
                    __context__.SourceCodeLine = 162;
                    } 
                
                __context__.SourceCodeLine = 166;
                _SplusNVRAM.RETURNSTRING  .UpdateValue ( _SplusNVRAM.RETURNSTRING + Functions.Chr (  (int) ( Functions.High( (ushort) INT ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) INT ) ) )  ) ; 
                } 
            
            __context__.SourceCodeLine = 168;
            return ( _SplusNVRAM.RETURNSTRING ) ; 
            
            }
            
        object RECALLPRESET__DOLLAR___OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 178;
                _SplusNVRAM.X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 179;
                MakeString ( _SplusNVRAM.COMMAND , "\u008B{0}", ITOSTRING (  __context__ , (ushort)( _SplusNVRAM.X ), (ushort)( 4 )) ) ; 
                __context__.SourceCodeLine = 180;
                SEND (  __context__ , _SplusNVRAM.COMMAND) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
        _SplusNVRAM.COMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
        _SplusNVRAM.SENDSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        
        RECALLPRESET__DOLLAR__ = new InOutArray<DigitalInput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            RECALLPRESET__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RECALLPRESET__DOLLAR____DigitalInput__ + i, RECALLPRESET__DOLLAR____DigitalInput__, this );
            m_DigitalInputList.Add( RECALLPRESET__DOLLAR____DigitalInput__ + i, RECALLPRESET__DOLLAR__[i+1] );
        }
        
        TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
        
        
        for( uint i = 0; i < 100; i++ )
            RECALLPRESET__DOLLAR__[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALLPRESET__DOLLAR___OnPush_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_BSS_SOUNDWEB_LONDON_VENUE_PRESETS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RECALLPRESET__DOLLAR____DigitalInput__ = 0;
    const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort X = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(2, false, true)]
            public CrestronString RETURNSTRING;
            [SplusStructAttribute(3, false, true)]
            public CrestronString COMMAND;
            [SplusStructAttribute(4, false, true)]
            public ushort CHECKSUM = 0;
            [SplusStructAttribute(5, false, true)]
            public CrestronString SENDSTRING;
            
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
