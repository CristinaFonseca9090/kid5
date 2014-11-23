' Options:
'Date: 2014-11-23 00:23:10
'Version: 1
'BaseUrl: http://localhost:56500
'
'''MakePartial: True
'''MakeVirtual: True
'''MakeDataContractsExtensible: False
'''AddReturnMarker: True
'''AddDescriptionAsComments: True
'''AddDataContractAttributes: False
'''AddIndexesToDataMembers: False
'''AddResponseStatus: False
'''AddImplicitVersion: 
'''InitializeCollections: True
'''AddDefaultXmlNamespace: http://schemas.servicestack.net/types

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports ServiceStack
Imports ServiceStack.DataAnnotations
Imports Test.ServiceModel
Imports Test.ServiceModel.Types
Imports Test.ServiceInterface

Namespace Global

    Namespace Test.ServiceInterface

        Public Partial Class Account
            Public Overridable Property Name As String
        End Class

        Public Partial Class CustomUserSession
            Inherits AuthUserSession
            <DataMember>
            Public Overridable Property CustomName As String

            <DataMember>
            Public Overridable Property CustomInfo As String
        End Class

        <Route("/image-draw/{Name}")>
        Public Partial Class DrawImage
            Implements IReturn(Of DrawImage)
            Public Overridable Property Name As String
            Public Overridable Property Format As String
            Public Overridable Property Width As Nullable(Of Integer)
            Public Overridable Property Height As Nullable(Of Integer)
            Public Overridable Property FontSize As Nullable(Of Integer)
            Public Overridable Property Foreground As String
            Public Overridable Property Background As String
        End Class

        Public Partial Class GetAccount
            Implements IReturn(Of Account)
            Public Overridable Property Account As String
        End Class

        Public Partial Class GetProject
            Implements IReturn(Of Project)
            Public Overridable Property Account As String
            Public Overridable Property Project As String
        End Class

        <Route("/session")>
        Public Partial Class GetSession
            Implements IReturn(Of GetSessionResponse)
        End Class

        Public Partial Class GetSessionResponse
            Public Overridable Property Result As CustomUserSession
            Public Overridable Property UnAuthInfo As UnAuthInfo
            Public Overridable Property ResponseStatus As ResponseStatus
        End Class

        <Route("/image-bytes")>
        Public Partial Class ImageAsBytes
            Public Overridable Property Format As String
        End Class

        <Route("/image-custom")>
        Public Partial Class ImageAsCustomResult
            Public Overridable Property Format As String
        End Class

        <Route("/image-file")>
        Public Partial Class ImageAsFile
            Public Overridable Property Format As String
        End Class

        <Route("/image-redirect")>
        Public Partial Class ImageAsRedirect
            Public Overridable Property Format As String
        End Class

        <Route("/image-stream")>
        Public Partial Class ImageAsStream
            Public Overridable Property Format As String
        End Class

        <Route("/image-response")>
        Public Partial Class ImageWriteToResponse
            Public Overridable Property Format As String
        End Class

        <Route("/ping")>
        Public Partial Class Ping
            Implements IReturn(Of Ping)
        End Class

        Public Partial Class PingResponse
            Public Sub New()
                Responses = New Dictionary(Of String, ResponseStatus)
            End Sub

            Public Overridable Property Responses As Dictionary(Of String, ResponseStatus)
            Public Overridable Property ResponseStatus As ResponseStatus
        End Class

        Public Partial Class Project
            Public Overridable Property Account As String
            Public Overridable Property Name As String
        End Class

        <Route("/{Path*}")>
        Public Partial Class RootPathRoutes
            Public Overridable Property Path As String
        End Class

        Public Partial Class UnAuthInfo
            Public Overridable Property CustomInfo As String
        End Class

        <Route("/session/edit/{CustomName}")>
        Public Partial Class UpdateSession
            Implements IReturn(Of GetSessionResponse)
            Public Overridable Property CustomName As String
        End Class
    End Namespace

    Namespace Test.ServiceModel

        '''<Summary>
        '''AllowedAttributes Description
        '''</Summary>
        <Route("/allowed-attributes", "GET")>
        <ApiResponse(400, "Your request was not understood")>
        <Api("AllowedAttributes Description")>
        <DataContract>
        Public Partial Class AllowedAttributes
            <[Default](5)>
            <Required>
            Public Overridable Property Id As Integer

            <DataMember(Name:="Aliased")>
            <ApiMember(ParameterType:="path", Description:="Range Description", DataType:="double", IsRequired:=true)>
            Public Overridable Property Range As Double

            <StringLength(20)>
            <Meta("Foo", "Bar")>
            <References(GetType(Hello))>
            Public Overridable Property Name As String
        End Class

        Public Partial Class EmptyClass
        End Class

        <Flags>
        Public Enum EnumFlags
            Value1 = 1
            Value2 = 2
            Value3 = 4
        End Enum

        Public Enum EnumType
            Value1
            Value2
        End Enum

        <Route("/hello/{Name}")>
        Public Partial Class Hello
            Implements IReturn(Of Hello)
            Public Overridable Property Name As String
        End Class

        Public Partial Class HelloAllTypes
            Implements IReturn(Of HelloAllTypes)
            Public Overridable Property Name As String
            Public Overridable Property AllTypes As AllTypes
            Public Overridable Property AllCollectionTypes As AllCollectionTypes
        End Class

        Public Partial Class HelloAllTypesResponse
            Public Overridable Property Result As String
            Public Overridable Property AllTypes As AllTypes
            Public Overridable Property AllCollectionTypes As AllCollectionTypes
        End Class

        '''<Summary>
        '''Description on HelloAll type
        '''</Summary>
        <DataContract>
        Public Partial Class HelloAnnotated
            Implements IReturn(Of HelloAnnotatedResponse)
            <DataMember>
            Public Overridable Property Name As String
        End Class

        '''<Summary>
        '''Description on HelloAllResponse type
        '''</Summary>
        <DataContract>
        Public Partial Class HelloAnnotatedResponse
            <DataMember>
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloBase(Of T)
            Public Sub New()
                Items = New List(Of T)
                Counts = New List(Of Integer)
            End Sub

            Public Overridable Property Items As List(Of T)
            Public Overridable Property Counts As List(Of Integer)
        End Class

        Public Partial Class HelloInterface
            Public Overridable Property Poco As IPoco
            Public Overridable Property EmptyInterface As IEmptyInterface
            Public Overridable Property EmptyClass As EmptyClass
        End Class

        Public Partial Class HelloResponse
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloString
            Public Overridable Property Name As String
        End Class

        Public Partial Class HelloVoid
            Public Overridable Property Name As String
        End Class

        Public Partial Class HelloWithAlternateReturnResponse
            Inherits HelloWithReturnResponse
            Public Overridable Property AltResult As String
        End Class

        <DataContract>
        Public Partial Class HelloWithDataContract
            Implements IReturn(Of HelloWithDataContract)
            <DataMember(Name:="name", Order:=1, IsRequired:=true, EmitDefaultValue:=false)>
            Public Overridable Property Name As String

            <DataMember(Name:="id", Order:=2, EmitDefaultValue:=false)>
            Public Overridable Property Id As Integer
        End Class

        <DataContract>
        Public Partial Class HelloWithDataContractResponse
            <DataMember(Name:="result", Order:=1, IsRequired:=true, EmitDefaultValue:=false)>
            Public Overridable Property Result As String
        End Class

        '''<Summary>
        '''Description on HelloWithDescription type
        '''</Summary>
        Public Partial Class HelloWithDescription
            Implements IReturn(Of HelloWithDescription)
            Public Overridable Property Name As String
        End Class

        '''<Summary>
        '''Description on HelloWithDescriptionResponse type
        '''</Summary>
        Public Partial Class HelloWithDescriptionResponse
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloWithEnum
            Public Overridable Property EnumProp As EnumType
            Public Overridable Property NullableEnumProp As Nullable(Of EnumType)
            Public Overridable Property EnumFlags As EnumFlags
        End Class

        Public Partial Class HelloWithGenericInheritance
            Inherits HelloBase(Of Poco)
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloWithGenericInheritance2
            Inherits HelloBase(Of Hello)
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloWithInheritance
            Inherits HelloBase
            Implements IReturn(Of HelloWithInheritance)
            Public Overridable Property Name As String
        End Class

        Public Partial Class HelloWithInheritanceResponse
            Inherits HelloResponseBase
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloWithListInheritance
            Inherits List(Of InheritedItem)
        End Class

        Public Partial Class HelloWithNestedClass
            Implements IReturn(Of HelloResponse)
            Public Overridable Property Name As String
            Public Overridable Property NestedClassProp As NestedClass

            Public Partial Class NestedClass
                Public Overridable Property Value As String
            End Class
        End Class

        Public Partial Class HelloWithNestedInheritance
            Inherits HelloBase(Of HelloWithNestedInheritance.Item)

            Public Partial Class Item
                Public Overridable Property Value As String
            End Class
        End Class

        Public Partial Class HelloWithReturn
            Implements IReturn(Of HelloWithAlternateReturnResponse)
            Public Overridable Property Name As String
        End Class

        <Route("/helloroute")>
        Public Partial Class HelloWithRoute
            Implements IReturn(Of HelloWithRoute)
            Public Overridable Property Name As String
        End Class

        Public Partial Class HelloWithRouteResponse
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloWithType
            Implements IReturn(Of HelloWithType)
            Public Overridable Property Name As String
        End Class

        Public Partial Class HelloWithTypeResponse
            Public Overridable Property Result As HelloType
        End Class

        Public Interface IEmptyInterface
        End Interface

        Public Partial Class InheritedItem
            Public Overridable Property Name As String
        End Class

        Public Interface IPoco
            Property Name As String
        End Interface

        <Route("/requires-role")>
        Public Partial Class RequiresRole
            Implements IReturn(Of RequiresRole)
        End Class

        Public Partial Class RequiresRoleResponse
            Public Overridable Property Result As String
            Public Overridable Property ResponseStatus As ResponseStatus
        End Class

        Public Partial Class RestrictedAttributes
            Public Overridable Property Id As Integer
            Public Overridable Property Name As String
            Public Overridable Property Hello As Hello
        End Class
    End Namespace

    Namespace Test.ServiceModel.Types

        Public Partial Class AllCollectionTypes
            Public Sub New()
                IntArray = New Integer(){}
                IntList = New List(Of Integer)
                StringArray = New String(){}
                StringList = New List(Of String)
                PocoArray = New Poco(){}
                PocoList = New List(Of Poco)
            End Sub

            Public Overridable Property IntArray As Integer()
            Public Overridable Property IntList As List(Of Integer)
            Public Overridable Property StringArray As String()
            Public Overridable Property StringList As List(Of String)
            Public Overridable Property PocoArray As Poco()
            Public Overridable Property PocoList As List(Of Poco)
        End Class

        Public Partial Class AllTypes
            Public Sub New()
                StringList = New List(Of String)
                StringArray = New String(){}
                StringMap = New Dictionary(Of String, String)
                IntStringMap = New Dictionary(Of Integer, String)
            End Sub

            Public Overridable Property Id As Integer
            Public Overridable Property NullableId As Nullable(Of Integer)
            Public Overridable Property [Byte] As Byte
            Public Overridable Property [Short] As Short
            Public Overridable Property Int As Integer
            Public Overridable Property [Long] As Long
            Public Overridable Property [UShort] As UInt16
            Public Overridable Property UInt As UInt32
            Public Overridable Property [ULong] As UInt64
            Public Overridable Property Float As Single
            Public Overridable Property [Double] As Double
            Public Overridable Property [Decimal] As Decimal
            Public Overridable Property [String] As String
            Public Overridable Property DateTime As Date
            Public Overridable Property TimeSpan As TimeSpan
            Public Overridable Property NullableDateTime As Nullable(Of Date)
            Public Overridable Property NullableTimeSpan As Nullable(Of TimeSpan)
            Public Overridable Property StringList As List(Of String)
            Public Overridable Property StringArray As String()
            Public Overridable Property StringMap As Dictionary(Of String, String)
            Public Overridable Property IntStringMap As Dictionary(Of Integer, String)
            Public Overridable Property SubType As SubType
        End Class

        Public Partial Class HelloBase
            Public Overridable Property Id As Integer
        End Class

        Public Partial Class HelloResponseBase
            Public Overridable Property RefId As Integer
        End Class

        Public Partial Class HelloType
            Public Overridable Property Result As String
        End Class

        Public Partial Class HelloWithReturnResponse
            Public Overridable Property Result As String
        End Class

        Public Partial Class Poco
            Public Overridable Property Name As String
        End Class

        Public Partial Class SubType
            Public Overridable Property Id As Integer
            Public Overridable Property Name As String
        End Class
    End Namespace
End Namespace

