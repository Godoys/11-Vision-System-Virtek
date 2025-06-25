# VisionAndProjectionService.Swagger.Api.ToolOperationApi

All URIs are relative to *http://localhost:9015*

 Method                                                                                                             | HTTP request                          | Description                                                                              
--------------------------------------------------------------------------------------------------------------------|---------------------------------------|------------------------------------------------------------------------------------------
 [**CoreLaserServiceCloseTool**](ToolOperationApi.md#corelaserserviceclosetool)                                     | **POST** /CloseTool                   | Closes the Work Order.                                                                   
 [**CoreLaserServiceCloseToolExtended**](ToolOperationApi.md#corelaserserviceclosetoolextended)                     | **POST** /CloseToolExtended           | Closes the Work Order.                                                                   
 [**CoreLaserServiceGetWorkOrderAlignmentStatus**](ToolOperationApi.md#corelaserservicegetworkorderalignmentstatus) | **POST** /GetWorkOrderAlignmentStatus | Returns detailed alignment information for ALL projectors (in use with this Work Order). 
 [**CoreLaserServiceOpenTool**](ToolOperationApi.md#corelaserserviceopentool)                                       | **POST** /OpenTool                    | Opens the specified Work Order.                                                          

<a name="corelaserserviceclosetool"></a>

# **CoreLaserServiceCloseTool**

> ResultDto CoreLaserServiceCloseTool (ClientInfoDto clientInfo)

Closes the Work Order.

Closes the Work Order associated with ClientID.  <example>                  ClientInfoDto { ClientId (string, required),
OriginatingClientGuid (string, optional), Type (string, optional)                  }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCloseToolExample
    {
        public void main()
        {
            var apiInstance = new ToolOperationApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | Stores clientID

            try
            {
                // Closes the Work Order.
                ResultDto result = apiInstance.CoreLaserServiceCloseTool(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToolOperationApi.CoreLaserServiceCloseTool: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description     | Notes 
----------------|---------------------------------------|-----------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) | Stores clientID |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceclosetoolextended"></a>

# **CoreLaserServiceCloseToolExtended**

> ResultDto CoreLaserServiceCloseToolExtended (CloseToolDto closeToolDto)

Closes the Work Order.

Closes the Work Order associated with the CloseToolDto.  <example>                  CloseToolDto { ClientInfo (
ClientInfoDto, required), ImageOperation(bool, optional)                  }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCloseToolExtendedExample
    {
        public void main()
        {
            var apiInstance = new ToolOperationApi();
            var closeToolDto = new CloseToolDto(); // CloseToolDto | Stores the CloseToolDto data

            try
            {
                // Closes the Work Order.
                ResultDto result = apiInstance.CoreLaserServiceCloseToolExtended(closeToolDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToolOperationApi.CoreLaserServiceCloseToolExtended: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name             | Type                                | Description                  | Notes 
------------------|-------------------------------------|------------------------------|-------
 **closeToolDto** | [**CloseToolDto**](CloseToolDto.md) | Stores the CloseToolDto data |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetworkorderalignmentstatus"></a>

# **CoreLaserServiceGetWorkOrderAlignmentStatus**

> ResultDtoWorkOrderAlignmentDetailsDto CoreLaserServiceGetWorkOrderAlignmentStatus (ClientIdDto clientIdInfo)

Returns detailed alignment information for ALL projectors (in use with this Work Order).

Same thing as `/GetCalibrationDetail`, but returns a collection of CalibrationDetailDto objects, one for every projector
in use with this Work Order.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetWorkOrderAlignmentStatusExample
    {
        public void main()
        {
            var apiInstance = new ToolOperationApi();
            var clientIdInfo = new ClientIdDto(); // ClientIdDto | client id info DTO

            try
            {
                // Returns detailed alignment information for ALL projectors (in use with this Work Order).
                ResultDtoWorkOrderAlignmentDetailsDto result = apiInstance.CoreLaserServiceGetWorkOrderAlignmentStatus(clientIdInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToolOperationApi.CoreLaserServiceGetWorkOrderAlignmentStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name             | Type                              | Description        | Notes 
------------------|-----------------------------------|--------------------|-------
 **clientIdInfo** | [**ClientIdDto**](ClientIdDto.md) | client id info DTO |

### Return type

[**ResultDtoWorkOrderAlignmentDetailsDto**](ResultDtoWorkOrderAlignmentDetailsDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceopentool"></a>

# **CoreLaserServiceOpenTool**

> ResultDto CoreLaserServiceOpenTool (OpenToolDto openTool)

Opens the specified Work Order.

Opens the named Work Order in the specified Work Cell (optional), along with other parameters in the
OpenToolDto:    <example>                  { \"ClientInfo\": { \"ClientId\": \"string\", \"OriginatingClientGuid\":
\"string\", \"Type\": \"Passive\" }, \"WorkOrderName\": \"string\", \"PartSerial\": \"string\", \"WorkCellName\":
\"string\", \"LaserScanned\": true, \"ProjectionViewIsLaserScanned\": true, \"PerformStartupCalibration\": true,
\"ProjectorsToExcludeOnStartupCalibration\": [                     { \"Serial\": \"string\", \"FirmwareLoadStatusCode\": \"Succeed\", \"FirmwareLoadStatusMessage\": \"string\" }                     ],
\"ResumeProjection\": true, \"SetAllTargetsToCertification\": true, \"ClientConfigurationProfileName\":
\"string\" }                                      </example>    * **WorkOrderName** - Work Order name is derived from
its folder name (this is what is shown in Iris Client)  * **PartSerial** - Part Serial Number, Only if EnablePartSerial
configurations is set. if the PartSerial Number does not exist a new Part Serial will be created for that work Order * *
*WorkCellName** - The Work Cell name to use WITH this work order (See \"Work Cells\" in the Iris Administrator Guide).
This requires at least one Work Cell to be configured in the local system. All connected projectors will initially be
included in the Work Cell. To exclude any of the projectors from the Work Cell, use
ProjectorsToExcludeOnStartupCalibration below; if WorkCellName is not specified, perhaps because no Work Cell is
defined, changing the projectors used is still to be done through ExcludeProjector. * **LaserScanned** - if `true`
attempts an Automatic Alignment/FlashAlign to the Work Order tool once opened. * ProjectionViewIsLaserScanned - not
currently used * PerformStartupCalibration - not currently used * ProjectorsToExcludeOnStartupCalibration - a collection
of projectors (ClientProjectorInfoDto) that will be excluded from the specified WorkCellName (if any) - as though
manually excluded in Iris Client or using /ExcludeProjector - from the Work Order; if no WorkCellName is provided this
parameter is ignored. Use projector serial numbers; Familiar or Friendly names are not supported. * ResumeProjection -
not currently used (use /PauseProjection and /ResumeProjection)  * SetAllTargetsToCertification - not currently used *
ClientConfigurationProfileName - An optional parameter. A configuration profile name to identify which configuration
profile the server will use to load work order files. Server will use the client baseline default configuration values
if this parameter is empty.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceOpenToolExample
    {
        public void main()
        {
            var apiInstance = new ToolOperationApi();
            var openTool = new OpenToolDto(); // OpenToolDto | openTool parameters

            try
            {
                // Opens the specified Work Order.
                ResultDto result = apiInstance.CoreLaserServiceOpenTool(openTool);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToolOperationApi.CoreLaserServiceOpenTool: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description         | Notes 
--------------|-----------------------------------|---------------------|-------
 **openTool** | [**OpenToolDto**](OpenToolDto.md) | openTool parameters |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

