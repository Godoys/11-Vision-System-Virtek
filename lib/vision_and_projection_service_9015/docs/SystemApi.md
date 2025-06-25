# VisionAndProjectionService.Swagger.Api.SystemApi

All URIs are relative to *http://localhost:9015*

 Method                                                                                                    | HTTP request                        | Description                                                                                                                
-----------------------------------------------------------------------------------------------------------|-------------------------------------|----------------------------------------------------------------------------------------------------------------------------
 [**CoreLaserServiceConnectClient**](SystemApi.md#corelaserserviceconnectclient)                           | **POST** /ConnectClient             | Registers this client with the Virtek Server.                                                                              
 [**CoreLaserServiceDisconnectAllClients**](SystemApi.md#corelaserservicedisconnectallclients)             | **POST** /DisconnectAllClients      | Disconnects ALL existing clients from the Virtek Server.                                                                   
 [**CoreLaserServiceDisconnectClient**](SystemApi.md#corelaserservicedisconnectclient)                     | **POST** /DisconnectClient          | De-registers this client with the Virtek Server and clears resources allocated  if applicable.                             
 [**CoreLaserServiceExcludeProjector**](SystemApi.md#corelaserserviceexcludeprojector)                     | **POST** /ExcludeProjector          | Exclude or Include the specified projector from/in the Work Order.                                                         
 [**CoreLaserServiceGetAvailableProjectors**](SystemApi.md#corelaserservicegetavailableprojectors)         | **GET** /GetAvailableProjectors     | Returns a list of all laser projectors visible to the Vision and Projection  Service.                                      
 [**CoreLaserServiceGetConnectedClientIDs**](SystemApi.md#corelaserservicegetconnectedclientids)           | **POST** /GetConnectedClientIDs     | Get all the currently connected clients to the Server.                                                                     
 [**CoreLaserServiceGetCurrentClients**](SystemApi.md#corelaserservicegetcurrentclients)                   | **GET** /GetCurrentClients          | Lists all clients currently known to Virtek Server                                                                         
 [**CoreLaserServiceGetExcludedProjectors**](SystemApi.md#corelaserservicegetexcludedprojectors)           | **POST** /GetExcludedProjectors     | Returns a list of projectors Excluded from this Client&#39;s Work Order.                                                   
 [**CoreLaserServiceGetProjectionConfiguration**](SystemApi.md#corelaserservicegetprojectionconfiguration) | **GET** /GetProjectionConfiguration | Retrieves a selection of projection quality/accuracy parameters in use by the system.                                      
 [**CoreLaserServiceGetProjectorDescriptors**](SystemApi.md#corelaserservicegetprojectordescriptors)       | **POST** /GetProjectorDescriptors   | Returns a collection of laser projector descriptors for all laser projectors visible to the Vision and Projection Service. 
 [**CoreLaserServiceGetVersion**](SystemApi.md#corelaserservicegetversion)                                 | **GET** /GetVersion                 | Returns the version of the service                                                                                         
 [**CoreLaserServiceIsProjectorKnown**](SystemApi.md#corelaserserviceisprojectorknown)                     | **POST** /IsProjectorKnown          | Check if the projector exists and is connected.                                                                            
 [**CoreLaserServiceSendHeartBeat**](SystemApi.md#corelaserservicesendheartbeat)                           | **POST** /SendHeartBeat             | Sends a heartbeat to Virtek Server; active clients which don&#39;t, will have projection paused, then be disconnected.     

<a name="corelaserserviceconnectclient"></a>

# **CoreLaserServiceConnectClient**

> ResultDto CoreLaserServiceConnectClient (ClientInfoDto clientInfo)

Registers this client with the Virtek Server.

Registers this client, uniquely identified by \"OriginatingClientGuid\" as part of the client session named by
\"ClientId\". If an active client has already initialized the session under that ClientId, this client is registered to
use the same resources (Work Order, projectors, Work Cell, etc.)   Attempting to connect a second active client to the
session ClientId will return an error. Active clients must send keep-alive messages every 2 minutes - see
`/SendHeartBeat`. Passive clients do not have to send keep-alive messages. There is no restriction on the number of
passive clients that can connect to a session. /DisconnectClient must be called for each client to release resources.
i.e. Each passive client as well as the active client Each client can provide an additional identifier,
OriginatingClientGUID which should be unique to each client (and it doesn't have to be an actual GUID it can be any
unique string); the API will not complain if this parameter is not unique, however in the system / Work Order logs that
record activity, you will not be able to differentiate between API client actions unless they are. In order for
Reflection to work, OriginatingClientGUID must be unique (OriginatingClientGUID is used to determine which clients to
send update events to.)    All clients that share ClientID MUST be open prior to opening the Work Order or doing
anything else to the Work Order, otherwise, echo/reflection synchronization can't be guaranteed.    <example>
ClientInfoDto { ClientId (string, required), OriginatingClientGuid (string, optional), Type (string,
optional)                 } // example:                ClientInfoDto { \"Client1\",
\"2D668C86-07A3-4C5A-8BEF-DF161A0F50A0\", \"Passive\" }               </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceConnectClientExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | 

            try
            {
                // Registers this client with the Virtek Server.
                ResultDto result = apiInstance.CoreLaserServiceConnectClient(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceConnectClient: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description | Notes 
----------------|---------------------------------------|-------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) |             |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicedisconnectallclients"></a>

# **CoreLaserServiceDisconnectAllClients**

> ResultDto CoreLaserServiceDisconnectAllClients ()

Disconnects ALL existing clients from the Virtek Server.

Forces a disconnect of all clients (active or passive) from the system; all Work Orders are closed, all projectors, Work
Cells and system resources are freed. Any open Iris Client will register a disconnection from the Virtek Server in the
Messages tab and show as Unconnected (RED) in the Connection Status Indicator.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceDisconnectAllClientsExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();

            try
            {
                // Disconnects ALL existing clients from the Virtek Server.
                ResultDto result = apiInstance.CoreLaserServiceDisconnectAllClients();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceDisconnectAllClients: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicedisconnectclient"></a>

# **CoreLaserServiceDisconnectClient**

> ResultDto CoreLaserServiceDisconnectClient (ClientInfoDto clientInfo)

De-registers this client with the Virtek Server and clears resources allocated if applicable.

If this client is passive, and the session's active client remains open (and responding with heartbeats), then the
session resources will remain allocated. Once the last client closes for a specified ClientID, the system will close any
associated Work Order, files, and frees any other system resources (projector reservations, etc.) as required. If an
active client terminates abnormally, eventually the lack of keep-alive messages will cause the server to pause
projection and eventually attempt cleanup; If a passive client never calls /DisconnectClient, the server may never
perform cleanup - this may manifest in projectors that are strangely unavailable or are unresponsive, or work orders
that are unavailable for opening or editing. - in this case, restarting the services will be required in Virtek Server
Manager. For proper clean up of resources, /DisconnectClient must be called for each client that has connected to the
server. To find which clients are connected to the server, use /GetCurrentClients.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceDisconnectClientExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | 

            try
            {
                // De-registers this client with the Virtek Server and clears resources allocated  if applicable.
                ResultDto result = apiInstance.CoreLaserServiceDisconnectClient(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceDisconnectClient: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description | Notes 
----------------|---------------------------------------|-------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) |             |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceexcludeprojector"></a>

# **CoreLaserServiceExcludeProjector**

> ResultDtoListProjectorTargetDto CoreLaserServiceExcludeProjector (ExcludeProjectorDto excludeProjector)

Exclude or Include the specified projector from/in the Work Order.

Changes the inclusion or exclusion of a projector from the Work Order associated with this client. * Exclude: if true,
excludes the projector specified by Serial. If false, includes it in the Work Order. As a convenience, returns
additional target scan information which may be ignored.      <example>               ExcludeProjectorDto { ClientInfo (
ClientInfoDto, required), ProjectorSerial (string, required), Exclude (boolean, required)                 }
ClientInfoDto { ClientId (string, required), OriginatingClientGuid (string, optional), Type (string,
optional)               }               </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceExcludeProjectorExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var excludeProjector = new ExcludeProjectorDto(); // ExcludeProjectorDto | client information

            try
            {
                // Exclude or Include the specified projector from/in the Work Order.
                ResultDtoListProjectorTargetDto result = apiInstance.CoreLaserServiceExcludeProjector(excludeProjector);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceExcludeProjector: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                 | Type                                              | Description        | Notes 
----------------------|---------------------------------------------------|--------------------|-------
 **excludeProjector** | [**ExcludeProjectorDto**](ExcludeProjectorDto.md) | client information |

### Return type

[**ResultDtoListProjectorTargetDto**](ResultDtoListProjectorTargetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetavailableprojectors"></a>

# **CoreLaserServiceGetAvailableProjectors**

> ResultDtoListProjectorInfoDto CoreLaserServiceGetAvailableProjectors ()

Returns a list of all laser projectors visible to the Vision and Projection Service.

Dumps a list of all laser projectors which respond to the Vision and Projection service (based on network scanning
parameters in Virtek Server Manager). Will only show serial numbers and corresponding firmware load status. Use
`/GetProjectorDescriptors` to return actual details of the laser projectors available in the system.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetAvailableProjectorsExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();

            try
            {
                // Returns a list of all laser projectors visible to the Vision and Projection  Service.
                ResultDtoListProjectorInfoDto result = apiInstance.CoreLaserServiceGetAvailableProjectors();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetAvailableProjectors: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoListProjectorInfoDto**](ResultDtoListProjectorInfoDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetconnectedclientids"></a>

# **CoreLaserServiceGetConnectedClientIDs**

> ResultDtoListString CoreLaserServiceGetConnectedClientIDs ()

Get all the currently connected clients to the Server.

Returns a list of all client sessions named (\"ClientIds\") connected to Virtek Server. These ClientIds are used to
specify a particular Work Order (including projectors, Work Cell etc.) session in other methods.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetConnectedClientIDsExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();

            try
            {
                // Get all the currently connected clients to the Server.
                ResultDtoListString result = apiInstance.CoreLaserServiceGetConnectedClientIDs();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetConnectedClientIDs: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoListString**](ResultDtoListString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetcurrentclients"></a>

# **CoreLaserServiceGetCurrentClients**

> ResultDtoListClientDataDto CoreLaserServiceGetCurrentClients ()

Lists all clients currently known to Virtek Server

Returns a collection (ClientInfoDto/ClientDataDto) of all clients currently known/connected to the service. * **Status
** - Activated - (active clients only) it is still sending heartbeats aka its alive; Inactivated - (active clients
only) - failed heartbeat keep alives - projection is paused. * **CurrentWorkOrder** - the name of the Work Order, if any
associated with this client. Note, this is not the same as ClientID, which may be common amongst all clients working on
that Work Order. * **ConfigurationProfileName** - the name of the client's configuration profile name.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetCurrentClientsExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();

            try
            {
                // Lists all clients currently known to Virtek Server
                ResultDtoListClientDataDto result = apiInstance.CoreLaserServiceGetCurrentClients();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetCurrentClients: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoListClientDataDto**](ResultDtoListClientDataDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetexcludedprojectors"></a>

# **CoreLaserServiceGetExcludedProjectors**

> ResultDtoListString CoreLaserServiceGetExcludedProjectors (ClientIdDto clientId)

Returns a list of projectors Excluded from this Client's Work Order.

Return a list of those projectors which have been previously (either by Work Cell definition or manually via Iris Client
or API call - `/ExcludeProjector`) excluded from this Work Order.  <example>              ClientIdDto { ClientId (
string, required)                }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetExcludedProjectorsExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var clientId = new ClientIdDto(); // ClientIdDto | 

            try
            {
                // Returns a list of projectors Excluded from this Client's Work Order.
                ResultDtoListString result = apiInstance.CoreLaserServiceGetExcludedProjectors(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetExcludedProjectors: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description | Notes 
--------------|-----------------------------------|-------------|-------
 **clientId** | [**ClientIdDto**](ClientIdDto.md) |             |

### Return type

[**ResultDtoListString**](ResultDtoListString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectionconfiguration"></a>

# **CoreLaserServiceGetProjectionConfiguration**

> ResultDtoServiceProjectionConfigurationDto CoreLaserServiceGetProjectionConfiguration ()

Retrieves a selection of projection quality/accuracy parameters in use by the system.

* **PartIntersectionToleranceMM**: When creating geometry from input points(from files), two points are considered the
  same if they are less than this distance apart (\"heals\" two different polygons together); how close a point is to a
  line before it is considered to intersect the line. * **EnableCrosshairProjections:**:  When enabled (true) projection
  clients will overlay surface planar crosshairs over top of circular features (including holes). Configured by default
  in Virtek Server Manager &gt; Iris Client &gt; Projection Options \"Project Crosshairs\"; note this does not reflect
  whether or not crosshairs are actively being projected, as the Operator can enable/disable this in Iris Client &gt;
  Options &gt; \"Project circle crosshairs\" * **DisplayCrosshairProjections:** When enabled (true) shows the location
  of crosshair projections in the Iris CAD model view; regardless of whether their (laser) projection is enabled by
  default (see EnableCrosshairProjections above) or is currently activated by Iris Client &gt; Options &gt; project
  circle crosshairs. * BreakIntersectingPolygons - Internal use only * **CrosshairRadiusFitToleranceMillimeters** - how
  far from \"circular\" a circle point can be before it is no longer considered a circle (for crosshair purposes)  * *
  *CrosshairCoplanarDeviationAngleTolerance** - how flat points on a circle have to be before it is no longer considered
  a circle (for crosshair purposes)  * **CrosshairMinimumNumberOfPointsInCircle** - a circle (for crosshair purposes)
  has to have at least this many points * **ImageErrorTolerance** - the fundamental accuracy parameter; the laser is
  guaranteed to never sweep further away than this from nominal; lower values will result in slower laser sweeps and
  higher flicker * **TextErrorTolerance** - same as above but for Projected Text; lower values = sharper text characters
  but with more flicker * **FocusToleranceFactor** - how accurate Focus Of Attention projections are vs. normal,
  specified as an ImageErrorTolerance multiplier - e.g. 10x more accurate, specify 0.1 for this parameter * *
  *ObjectFocus** - when true, Focus of Attention reduces focus to polygons, entities overlapping the retro; when false,
  Focus of Attention is a circular radius around the retro hit * **FocusCheckPeriodMilliseconds** - Focus of Attention -
  how frequently FoA checks for persistence of the retro material * **FocusTrackPeriodMilliseconds** - Laser octagon
  cursor - how frequently the laser octagon tracking checks for retro presence * IsFoaDetailedDebugging - Internal use
  only * **ShiftTranslationMillimetres** - distance projection will be shifted in mm. * **ShiftRotationDegrees** -
  number of degrees projection will be rotated Some of these parameters can be modified via API while the system is
  running. See `/UpdateServerConfiguration`.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectionConfigurationExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();

            try
            {
                // Retrieves a selection of projection quality/accuracy parameters in use by the system.
                ResultDtoServiceProjectionConfigurationDto result = apiInstance.CoreLaserServiceGetProjectionConfiguration();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetProjectionConfiguration: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoServiceProjectionConfigurationDto**](ResultDtoServiceProjectionConfigurationDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectordescriptors"></a>

# **CoreLaserServiceGetProjectorDescriptors**

> ResultDtoListProjectorDescriptorDto CoreLaserServiceGetProjectorDescriptors (ClientIdDto clientId)

Returns a collection of laser projector descriptors for all laser projectors visible to the Vision and Projection
Service.

For each projector visible to the Vision and Projection service (See `/GetAvailableProjectors`), dumps a collection of
attributes such as Familiar/Friendly Name(s), Calibration and Alignment status.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectorDescriptorsExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var clientId = new ClientIdDto(); // ClientIdDto | 

            try
            {
                // Returns a collection of laser projector descriptors for all laser projectors visible to the Vision and Projection Service.
                ResultDtoListProjectorDescriptorDto result = apiInstance.CoreLaserServiceGetProjectorDescriptors(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetProjectorDescriptors: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description | Notes 
--------------|-----------------------------------|-------------|-------
 **clientId** | [**ClientIdDto**](ClientIdDto.md) |             |

### Return type

[**ResultDtoListProjectorDescriptorDto**](ResultDtoListProjectorDescriptorDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetversion"></a>

# **CoreLaserServiceGetVersion**

> ResultDtoApiVersionDto CoreLaserServiceGetVersion ()

Returns the version of the service

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetVersionExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();

            try
            {
                // Returns the version of the service
                ResultDtoApiVersionDto result = apiInstance.CoreLaserServiceGetVersion();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceGetVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoApiVersionDto**](ResultDtoApiVersionDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceisprojectorknown"></a>

# **CoreLaserServiceIsProjectorKnown**

> ResultDtoBoolean CoreLaserServiceIsProjectorKnown (ClientProjectorInfoDto clientProjectorInfo)

Check if the projector exists and is connected.

IsProjectorKnown checks the state of a projector client pair, if the client and projector are connected return true in
the payload at the beginning of client connection.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceIsProjectorKnownExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Check if the projector exists and is connected.
                ResultDtoBoolean result = apiInstance.CoreLaserServiceIsProjectorKnown(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceIsProjectorKnown: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                    | Type                                                    | Description | Notes 
-------------------------|---------------------------------------------------------|-------------|-------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md) |             |

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicesendheartbeat"></a>

# **CoreLaserServiceSendHeartBeat**

> ResultDto CoreLaserServiceSendHeartBeat (ClientIdDto clientId)

Sends a heartbeat to Virtek Server; active clients which don't, will have projection paused, then be disconnected.

This is only required of active clients (see \"Active/Passive Clients and ClientID\" in Integration Guide)  * On first
connection of an active client, Virtek Server monitors for periodic heartbeats from the client in liu of any actual
commands. * If none are received after 2 minutes, Virtek Server pauses projection for that client but will resume
projection if it receives any subsequent heartbeat. * If no heartbeat is received after 30 minutes all session resources
for the active client are released as though the Client had disconnected/closed.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceSendHeartBeatExample
    {
        public void main()
        {
            var apiInstance = new SystemApi();
            var clientId = new ClientIdDto(); // ClientIdDto | 

            try
            {
                // Sends a heartbeat to Virtek Server; active clients which don't, will have projection paused, then be disconnected.
                ResultDto result = apiInstance.CoreLaserServiceSendHeartBeat(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SystemApi.CoreLaserServiceSendHeartBeat: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description | Notes 
--------------|-----------------------------------|-------------|-------
 **clientId** | [**ClientIdDto**](ClientIdDto.md) |             |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

