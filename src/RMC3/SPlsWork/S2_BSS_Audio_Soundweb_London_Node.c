#include "TypeDefs.h"
#include "Globals.h"
#include "FnctList.h"
#include "Library.h"
#include "SimplSig.h"
#include "S2_BSS_Audio_Soundweb_London_Node.h"

FUNCTION_MAIN( S2_BSS_Audio_Soundweb_London_Node );
EVENT_HANDLER( S2_BSS_Audio_Soundweb_London_Node );
DEFINE_ENTRYPOINT( S2_BSS_Audio_Soundweb_London_Node );


static void S2_BSS_Audio_Soundweb_London_Node__SEND ( struct StringHdr_s* __STR1 ) 
    { 
    /* Begin local function variable declarations */
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__, sizeof( "" ) );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    
    short __FN_FOREND_VAL__1; 
    short __FN_FORINIT_VAL__1; 
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__, 65535 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1, 65535 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    
    CheckStack( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    SET_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__, "" );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__, 65535 );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__1, 65535 );
    
    
    /* End local function variable declarations */
    
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 126 );
    Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM = 0; 
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 127 );
    FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    ,2 , "%s"  ,  LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ )    )  ; 
    FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )   ,2 , "%s"  , __FN_DST_STR__ ) ; 
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 128 );
    __FN_FOREND_VAL__1 = Len( LOCAL_STRING_STRUCT( __STR1  )  ); 
    __FN_FORINIT_VAL__1 = 1; 
    for( Nvram->S2_BSS_Audio_Soundweb_London_Node.__I = 1; (__FN_FORINIT_VAL__1 > 0)  ? ((short)Nvram->S2_BSS_Audio_Soundweb_London_Node.__I  <= __FN_FOREND_VAL__1 ) : ((short)Nvram->S2_BSS_Audio_Soundweb_London_Node.__I  >= __FN_FOREND_VAL__1) ; Nvram->S2_BSS_Audio_Soundweb_London_Node.__I  += __FN_FORINIT_VAL__1) 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 130 );
        Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM = (Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM ^ Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I )); 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 131 );
        if ( (((((Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ) == 2) || (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ) == 3)) || (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ) == 6)) || (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ) == 21)) || (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ) == 27))) 
            { 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 133 );
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,5 , "%s\x1B""%s"  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )  , Chr (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ) + 128))  )  ; 
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
            } 
        
        else 
            { 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 137 );
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,4 , "%s%s"  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )  , Chr (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR1  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__I ))  )  ; 
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
            } 
        
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 128 );
        } 
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 140 );
    if ( (((((Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM == 2) || (Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM == 3)) || (Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM == 6)) || (Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM == 21)) || (Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM == 27))) 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 142 );
        if( ObtainStringOutputSemaphore( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ) == 0 ) {
        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GENERIC_STRING_OUTPUT( S2_BSS_Audio_Soundweb_London_Node )  ,7 , "\x02""%s\x1B""%s\x03"""  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )  , Chr (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , (Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM + 128))  )  ; 
        SetSerial( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), __S2_BSS_Audio_Soundweb_London_Node_COMTX$_STRING_OUTPUT, GENERIC_STRING_OUTPUT( S2_BSS_Audio_Soundweb_London_Node ) );
        ReleaseStringOutputSemaphore( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); }
        
        ; 
        } 
    
    else 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 146 );
        if( ObtainStringOutputSemaphore( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ) == 0 ) {
        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GENERIC_STRING_OUTPUT( S2_BSS_Audio_Soundweb_London_Node )  ,6 , "\x02""%s%s\x03"""  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING  )  , Chr (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , Nvram->S2_BSS_Audio_Soundweb_London_Node.__CHECKSUM)  )  ; 
        SetSerial( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), __S2_BSS_Audio_Soundweb_London_Node_COMTX$_STRING_OUTPUT, GENERIC_STRING_OUTPUT( S2_BSS_Audio_Soundweb_London_Node ) );
        ReleaseStringOutputSemaphore( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); }
        
        ; 
        } 
    
    
    S2_BSS_Audio_Soundweb_London_Node_Exit__SEND:
/* Begin Free local function variables */
    FREE_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ );
    FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__ );
    FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__1 );
    /* End Free local function variables */
    
    }
    
static struct StringHdr_s* S2_BSS_Audio_Soundweb_London_Node__RECEIVE ( struct StringHdr_s*  __FN_DSTRET_STR__  , struct StringHdr_s* __STR2 ) 
    { 
    /* Begin local function variable declarations */
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__, sizeof( "" ) );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    
    short __FN_FOREND_VAL__1; 
    short __FN_FORINIT_VAL__1; 
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__, 65535 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1, 65535 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    
    CheckStack( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    SET_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__, "" );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__, 65535 );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__1, 65535 );
    
    
    /* End local function variable declarations */
    
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 153 );
    FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    ,2 , "%s"  ,  LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ )    )  ; 
    FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )   ,2 , "%s"  , __FN_DST_STR__ ) ; 
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 154 );
    __FN_FOREND_VAL__1 = Len( LOCAL_STRING_STRUCT( __STR2  )  ); 
    __FN_FORINIT_VAL__1 = 1; 
    for( Nvram->S2_BSS_Audio_Soundweb_London_Node.__J = 1; (__FN_FORINIT_VAL__1 > 0)  ? ((short)Nvram->S2_BSS_Audio_Soundweb_London_Node.__J  <= __FN_FOREND_VAL__1 ) : ((short)Nvram->S2_BSS_Audio_Soundweb_London_Node.__J  >= __FN_FOREND_VAL__1) ; Nvram->S2_BSS_Audio_Soundweb_London_Node.__J  += __FN_FORINIT_VAL__1) 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 156 );
        if ( (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR2  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__J ) == 27)) 
            { 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 158 );
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,4 , "%s%s"  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )  ,  Chr (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR2  )  , (Nvram->S2_BSS_Audio_Soundweb_London_Node.__J + 1) ) - 128))  )  ; 
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 159 );
            Nvram->S2_BSS_Audio_Soundweb_London_Node.__J = (Nvram->S2_BSS_Audio_Soundweb_London_Node.__J + 1); 
            } 
        
        else 
            { 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 163 );
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,4 , "%s%s"  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )  ,  Chr (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , LOCAL_STRING_STRUCT( __STR2  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__J ))  )  ; 
            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
            } 
        
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 154 );
        } 
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 166 );
    while ( (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )  , 1 ) == 6)) 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 168 );
        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,2 , "%s"  , Right ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )  , (Len( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )  ) - 1))  )  ; 
        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 166 );
        } 
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 170 );
    FormatString( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ),  __FN_DSTRET_STR__, 2, "%s", ( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING  )  ) );
    goto S2_BSS_Audio_Soundweb_London_Node_Exit__RECEIVE ; 
    
    S2_BSS_Audio_Soundweb_London_Node_Exit__RECEIVE:
/* Begin Free local function variables */
    FREE_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ );
    FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__ );
    FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__1 );
    /* End Free local function variables */
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 214 );
    return __FN_DSTRET_STR__; 
    }
    
DEFINE_INDEPENDENT_EVENTHANDLER( S2_BSS_Audio_Soundweb_London_Node, 00000 /*modulesTx$*/ )

    {
    /* Begin local function variable declarations */
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__, sizeof( "\x03""\x03""\x03""\x03""\x03""" ) );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__, 1000 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1, 1000 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__2, 1000 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__2 );
    
    SAVE_GLOBAL_POINTERS ;
    CheckStack( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    SET_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__, "\x03""\x03""\x03""\x03""\x03""" );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__, 1000 );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__1, 1000 );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__2 );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__2, 1000 );
    
    
    /* End local function variable declarations */
    
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 216 );
    if ( Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK1) 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 218 );
        Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK1 = 0; 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 219 );
        while ( Len( GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )  )) 
            { 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 221 );
            Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1 = Find( LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ )  , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )  , 1 , 1 ); 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 222 );
            Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER2 = (Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1 + 5); 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 223 );
            if ( (Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER2 <= Len( GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )  ))) 
                { 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 225 );
                while ( (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )  , Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER2 ) == 3)) 
                    { 
                    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 227 );
                    Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1 = (Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1 + 1); 
                    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 228 );
                    Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER2 = (Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER2 + 1); 
                    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 229 );
                    if ( (Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER2 > Len( GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )  ))) 
                        { 
                        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 231 );
                        break ; 
                        } 
                    
                    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 225 );
                    } 
                
                } 
            
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 235 );
            if ( Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1) 
                { 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 237 );
                Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1 = (Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1 + 4); 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 238 );
                FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__2 )    ,2 , "%s"  , Remove ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , Mid ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )  , 1, Nvram->S2_BSS_Audio_Soundweb_London_Node.__MARKER1) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$  )    , 1  )  )  ; 
                FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )   ,2 , "%s"  , __FN_DST_STR__2 ) ; 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 239 );
                FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__2 )    ,6 , "%s%s%s"  , Left ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )  , 1) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __NODE$  )  , Right ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )  , (Len( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )  ) - 3))  )  ; 
                FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )   ,2 , "%s"  , __FN_DST_STR__2 ) ; 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 240 );
                S2_BSS_Audio_Soundweb_London_Node__SEND (  (struct StringHdr_s* )  Left ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )  , (Len( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )  ) - 5)) ) ; 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 241 );
                ClearBuffer ( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1  )  ) ; 
                } 
            
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 219 );
            } 
        
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 244 );
        Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK1 = 1; 
        } 
    
    
    S2_BSS_Audio_Soundweb_London_Node_Exit__Event_0:
    /* Begin Free local function variables */
FREE_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ );
FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__ );
FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__1 );
FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__2 );
/* End Free local function variables */
RESTORE_GLOBAL_POINTERS ;

}

DEFINE_INDEPENDENT_EVENTHANDLER( S2_BSS_Audio_Soundweb_London_Node, 00001 /*comRx$*/ )

    {
    /* Begin local function variable declarations */
    
    unsigned short  __SDUMP; 
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__, sizeof( "\x06""" ) );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_1__, sizeof( "\x03""" ) );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_1__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_2__, sizeof( "\x03""\x03""\x03""\x03""" ) );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_2__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__, 1000 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    
    CREATE_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1, 1000 );
    DECLARE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    
    SAVE_GLOBAL_POINTERS ;
    CheckStack( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_0__ );
    SET_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__, "\x06""" );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_1__ );
    SET_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_1__, "\x03""" );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __SPLS_TMPVAR__LOCALSTR_2__ );
    SET_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_2__, "\x03""\x03""\x03""\x03""" );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__ );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__, 1000 );
    
    ALLOCATE_LOCAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __FN_DST_STR__1 );
    INITIALIZE_LOCAL_STRING_STRUCT( __FN_DST_STR__1, 1000 );
    
    
    /* End local function variable declarations */
    
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 252 );
    if ( Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK2) 
        { 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 254 );
        Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK2 = 0; 
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 255 );
        while ( Len( GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )  )) 
            { 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 257 );
            if ( (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )  , 1 ) == 6)) 
                { 
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 259 );
                FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,2 , "%s"  , Remove ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    ,  LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ )   , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )    , 1  )  )  ; 
                FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING2  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
                } 
            
            else 
                {
                UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 261 );
                if ( (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )  , 1 ) == 2)) 
                    { 
                    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 263 );
                    if ( Find( LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_1__ )  , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )  , 1 , 1 )) 
                        { 
                        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 265 );
                        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,2 , "%s"  , Remove ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    ,  LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_1__ )   , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )    , 1  )  )  ; 
                        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING2  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
                        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 272 );
                        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ,  LOCAL_STRING_STRUCT( __FN_DST_STR__1 )    ,2 , "%s"  , S2_BSS_Audio_Soundweb_London_Node__RECEIVE (  LOCAL_STRING_STRUCT( __FN_DST_STR__ )    ,  (struct StringHdr_s* )  NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING2  )  )  )  ; 
                        FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING3  )   ,2 , "%s"  , __FN_DST_STR__1 ) ; 
                        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 274 );
                        if ( ((Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING3  )  , 3 ) == Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __NODE$  )  , 1 )) && (Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING3  )  , 4 ) == Byte( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __NODE$  )  , 2 )))) 
                            {
                            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 275 );
                            if( ObtainStringOutputSemaphore( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ) == 0 ) {
                            FormatString ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) , GENERIC_STRING_OUTPUT( S2_BSS_Audio_Soundweb_London_Node )  ,4 , "%s%s"  , NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING3  )  ,   LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_2__ )    )  ; 
                            SetSerial( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), __S2_BSS_Audio_Soundweb_London_Node_MODULESRX$_STRING_OUTPUT, GENERIC_STRING_OUTPUT( S2_BSS_Audio_Soundweb_London_Node ) );
                            ReleaseStringOutputSemaphore( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); }
                            
                            ; 
                            }
                        
                        } 
                    
                    } 
                
                else 
                    { 
                    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 280 );
                    __SDUMP = Getc( GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __COMRX$  )  ); 
                    } 
                
                }
            
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 283 );
            ClearBuffer ( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING2  )  ) ; 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 284 );
            ClearBuffer ( NVRAM_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING3  )  ) ; 
            UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 255 );
            } 
        
        UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 286 );
        Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK2 = 1; 
        } 
    
    
    S2_BSS_Audio_Soundweb_London_Node_Exit__Event_1:
    /* Begin Free local function variables */
FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__ );
FREE_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_0__ );
FREE_LOCAL_STRING_STRUCT( __FN_DST_STR__1 );
FREE_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_1__ );
FREE_LOCAL_STRING_STRUCT( __SPLS_TMPVAR__LOCALSTR_2__ );
/* End Free local function variables */
RESTORE_GLOBAL_POINTERS ;

}


    
    

/********************************************************************************
  Constructor
********************************************************************************/

/********************************************************************************
  Destructor
********************************************************************************/

/********************************************************************************
  static void ProcessDigitalEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessDigitalEvent( struct Signal_s *Signal )
{
    switch ( Signal->SignalNumber )
    {
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  static void ProcessAnalogEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessAnalogEvent( struct Signal_s *Signal )
{
    switch ( Signal->SignalNumber )
    {
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  static void ProcessStringEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessStringEvent( struct Signal_s *Signal )
{
    if ( UPDATE_INPUT_STRING( S2_BSS_Audio_Soundweb_London_Node ) == 1 ) return ;
    
    switch ( Signal->SignalNumber )
    {
        case __S2_BSS_Audio_Soundweb_London_Node_COMRX$_BUFFER_INPUT :
            SAFESPAWN_EVENTHANDLER( S2_BSS_Audio_Soundweb_London_Node, 00001 /*comRx$*/, 0 );
            break;
            
        case __S2_BSS_Audio_Soundweb_London_Node_MODULESTX$_BUFFER_INPUT :
            SAFESPAWN_EVENTHANDLER( S2_BSS_Audio_Soundweb_London_Node, 00000 /*modulesTx$*/, 0 );
            break;
            
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  static void ProcessSocketConnectEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessSocketConnectEvent( struct Signal_s *Signal )
{
    switch ( Signal->SignalNumber )
    {
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  static void ProcessSocketDisconnectEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessSocketDisconnectEvent( struct Signal_s *Signal )
{
    switch ( Signal->SignalNumber )
    {
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  static void ProcessSocketReceiveEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessSocketReceiveEvent( struct Signal_s *Signal )
{
    if ( UPDATE_INPUT_STRING( S2_BSS_Audio_Soundweb_London_Node ) == 1 ) return ;
    
    switch ( Signal->SignalNumber )
    {
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  static void ProcessSocketStatusEvent( struct Signal_s *Signal )
********************************************************************************/
static void ProcessSocketStatusEvent( struct Signal_s *Signal )
{
    switch ( Signal->SignalNumber )
    {
        default :
            SetSymbolEventStart ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ) ); 
            break ;
        
    }
}

/********************************************************************************
  EVENT_HANDLER( S2_BSS_Audio_Soundweb_London_Node )
********************************************************************************/
EVENT_HANDLER( S2_BSS_Audio_Soundweb_London_Node )
    {
    SAVE_GLOBAL_POINTERS ;
    switch ( Signal->Type )
        {
        case e_SIGNAL_TYPE_DIGITAL :
            ProcessDigitalEvent( Signal );
            break ;
        case e_SIGNAL_TYPE_ANALOG :
            ProcessAnalogEvent( Signal );
            break ;
        case e_SIGNAL_TYPE_STRING :
            ProcessStringEvent( Signal );
            break ;
        case e_SIGNAL_TYPE_CONNECT :
            ProcessSocketConnectEvent( Signal );
            break ;
        case e_SIGNAL_TYPE_DISCONNECT :
            ProcessSocketDisconnectEvent( Signal );
            break ;
        case e_SIGNAL_TYPE_RECEIVE :
            ProcessSocketReceiveEvent( Signal );
            break ;
        case e_SIGNAL_TYPE_STATUS :
            ProcessSocketStatusEvent( Signal );
            break ;
        }
        
    RESTORE_GLOBAL_POINTERS ;
    
    }
    
/********************************************************************************
  FUNCTION_MAIN( S2_BSS_Audio_Soundweb_London_Node )
********************************************************************************/
FUNCTION_MAIN( S2_BSS_Audio_Soundweb_London_Node )
{
    /* Begin local function variable declarations */
    
    SAVE_GLOBAL_POINTERS ;
    SET_INSTANCE_POINTER ( S2_BSS_Audio_Soundweb_London_Node );
    
    
    /* End local function variable declarations */
    
    
    INITIALIZE_GLOBAL_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __COMRX$, e_INPUT_TYPE_BUFFER, __S2_BSS_Audio_Soundweb_London_Node_COMRX$_BUFFER_MAX_LEN );
    REGISTER_GLOBAL_INPUT_STRING ( S2_BSS_Audio_Soundweb_London_Node, __COMRX$, __S2_BSS_Audio_Soundweb_London_Node_COMRX$_BUFFER_INPUT );
    INITIALIZE_GLOBAL_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$, e_INPUT_TYPE_BUFFER, __S2_BSS_Audio_Soundweb_London_Node_MODULESTX$_BUFFER_MAX_LEN );
    REGISTER_GLOBAL_INPUT_STRING ( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$, __S2_BSS_Audio_Soundweb_London_Node_MODULESTX$_BUFFER_INPUT );
    
    InitStringParamStruct ( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), GLOBAL_STRING_STRUCT( S2_BSS_Audio_Soundweb_London_Node, __NODE$ ) , e_INPUT_TYPE_STRING_PARAMETER, __S2_BSS_Audio_Soundweb_London_Node_NODE$_STRING_PARAMETER, __S2_BSS_Audio_Soundweb_London_Node_NODE$_PARAM_MAX_LEN, NAME_AS_STRING( __NODE$ ) );
    INITIALIZE_NVRAM_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING1, e_INPUT_TYPE_NONE, __S2_BSS_Audio_Soundweb_London_Node_TEMPSTRING1_STRING_MAX_LEN );
    INITIALIZE_NVRAM_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __SENDSTRING, e_INPUT_TYPE_NONE, __S2_BSS_Audio_Soundweb_London_Node_SENDSTRING_STRING_MAX_LEN );
    INITIALIZE_NVRAM_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING2, e_INPUT_TYPE_NONE, __S2_BSS_Audio_Soundweb_London_Node_TEMPSTRING2_STRING_MAX_LEN );
    INITIALIZE_NVRAM_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __TEMPSTRING3, e_INPUT_TYPE_NONE, __S2_BSS_Audio_Soundweb_London_Node_TEMPSTRING3_STRING_MAX_LEN );
    INITIALIZE_NVRAM_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, __RECEIVESTRING, e_INPUT_TYPE_NONE, __S2_BSS_Audio_Soundweb_London_Node_RECEIVESTRING_STRING_MAX_LEN );
    INITIALIZE_GLOBAL_STRING_STRUCT ( S2_BSS_Audio_Soundweb_London_Node, sGenericOutStr, e_INPUT_TYPE_NONE, GENERIC_STRING_OUTPUT_LEN );
    
    
    REGISTER_GLOBAL_INPUT_STRING ( S2_BSS_Audio_Soundweb_London_Node, __COMRX$, __S2_BSS_Audio_Soundweb_London_Node_COMRX$_BUFFER_INPUT );
    REGISTER_GLOBAL_INPUT_STRING ( S2_BSS_Audio_Soundweb_London_Node, __MODULESTX$, __S2_BSS_Audio_Soundweb_London_Node_MODULESTX$_BUFFER_INPUT );
    
    
    
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 306 );
    Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK1 = 1; 
    UpdateSourceCodeLine( INSTANCE_PTR( S2_BSS_Audio_Soundweb_London_Node ), 307 );
    Nvram->S2_BSS_Audio_Soundweb_London_Node.__XOK2 = 1; 
    
    S2_BSS_Audio_Soundweb_London_Node_Exit__MAIN:/* Begin Free local function variables */
    /* End Free local function variables */
    
    RESTORE_GLOBAL_POINTERS ;
    return 0 ;
    }
