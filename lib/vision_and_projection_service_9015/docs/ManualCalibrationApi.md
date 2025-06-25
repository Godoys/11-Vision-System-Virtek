# VisionAndProjectionService.Swagger.Api.ManualCalibrationApi

All URIs are relative to *http://localhost:9015*

 Method                                                                                                                                                                         | HTTP request                                               | Description                                               
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------|-----------------------------------------------------------
 [**CoreLaserServiceCreateManualTargetAlignmentEngineRequest**](ManualCalibrationApi.md#corelaserservicecreatemanualtargetalignmentenginerequest)                               | **POST** /CreateManualTargetAlignmentEngineRequest         | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceCreateManualTargetAlignmentEngineRequestForSingleTarget**](ManualCalibrationApi.md#corelaserservicecreatemanualtargetalignmentenginerequestforsingletarget) | **POST** /CreateManualTargetAlignmentEngineForSingleTarget | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandleAcceptLocateTarget**](ManualCalibrationApi.md#corelaserservicehandleacceptlocatetarget)                                                               | **POST** /HandleAcceptLocateTarget                         | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandleCancelManualCalibration**](ManualCalibrationApi.md#corelaserservicehandlecancelmanualcalibration)                                                     | **POST** /HandleCancelManualCalibration                    | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandleMoveCursorAbsoluteRequest**](ManualCalibrationApi.md#corelaserservicehandlemovecursorabsoluterequest)                                                 | **POST** /HandleMoveCursorAbsoluteRequest                  | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandleMoveCursorRelativeRequest**](ManualCalibrationApi.md#corelaserservicehandlemovecursorrelativerequest)                                                 | **POST** /HandleMoveCursorRelativeRequest                  | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandlePredictTargetsRequest**](ManualCalibrationApi.md#corelaserservicehandlepredicttargetsrequest)                                                         | **POST** /HandlePredictTargetsRequest                      | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandleRejectLocateTarget**](ManualCalibrationApi.md#corelaserservicehandlerejectlocatetarget)                                                               | **POST** /HandleRejectLocateTarget                         | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceHandleSkipLocateTarget**](ManualCalibrationApi.md#corelaserservicehandleskiplocatetarget)                                                                   | **POST** /HandleSkipLocateTarget                           | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceLockTargetConfiguration**](ManualCalibrationApi.md#corelaserservicelocktargetconfiguration)                                                                 | **POST** /LockTargetConfiguration                          | Saves target scan and target exclusion to the Work Order. 
 [**CoreLaserServiceStartManualCalibration**](ManualCalibrationApi.md#corelaserservicestartmanualcalibration)                                                                   | **POST** /StartManualCalibration                           | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceUpdateTargetCollection**](ManualCalibrationApi.md#corelaserserviceupdatetargetcollection)                                                                   | **POST** /UpdateTargetCollection                           | See \&quot;Manual Calibration\&quot; in Integrators Guide 
 [**CoreLaserServiceUpdateTargetInModel**](ManualCalibrationApi.md#corelaserserviceupdatetargetinmodel)                                                                         | **POST** /UpdateTargetInModel                              | Update the certification target type                      
 [**CoreLaserServiceUpdateTargetListType**](ManualCalibrationApi.md#corelaserserviceupdatetargetlisttype)                                                                       | **POST** /UpdateTargetListType                             | See \&quot;Manual Calibration\&quot; in Integrators Guide 

<a name="corelaserservicecreatemanualtargetalignmentenginerequest"></a>

# **CoreLaserServiceCreateManualTargetAlignmentEngineRequest**

> ResultDtoManualAlignmentEngineResultDto CoreLaserServiceCreateManualTargetAlignmentEngineRequest (
> ClientProjectorInfoDto clientProjectorInfo)

See \"Manual Calibration\" in Integrators Guide

This call will fail if the projector being requested for calibration is already being used for a manual calibration from
another client. In this case, the client should assume calibration is cancelled.  <example>
ClientProjectorInfoDto { ClientId (string, required), ProjectorSerial (string,
required)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCreateManualTargetAlignmentEngineRequestExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | the client and the projector to be calibrated

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDtoManualAlignmentEngineResultDto result = apiInstance.CoreLaserServiceCreateManualTargetAlignmentEngineRequest(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceCreateManualTargetAlignmentEngineRequest: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                    | Type                                                    | Description                                   | Notes 
-------------------------|---------------------------------------------------------|-----------------------------------------------|-------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md) | the client and the projector to be calibrated |

### Return type

[**ResultDtoManualAlignmentEngineResultDto**](ResultDtoManualAlignmentEngineResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicecreatemanualtargetalignmentenginerequestforsingletarget"></a>

# **CoreLaserServiceCreateManualTargetAlignmentEngineRequestForSingleTarget**

> ResultDtoManualAlignmentEngineResultDto CoreLaserServiceCreateManualTargetAlignmentEngineRequestForSingleTarget (
> ClientProjectorTargetInfoDto clientProjectorTargetInfo)

See \"Manual Calibration\" in Integrators Guide

This call will fail if the projector being requested for calibration is already being used for calibration. In this
case, the client should assume calibration is cancelled.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCreateManualTargetAlignmentEngineRequestForSingleTargetExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientProjectorTargetInfo = new ClientProjectorTargetInfoDto(); // ClientProjectorTargetInfoDto | the client, target, and the projector to be calibrated

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDtoManualAlignmentEngineResultDto result = apiInstance.CoreLaserServiceCreateManualTargetAlignmentEngineRequestForSingleTarget(clientProjectorTargetInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceCreateManualTargetAlignmentEngineRequestForSingleTarget: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                          | Type                                                                | Description                                            | Notes 
-------------------------------|---------------------------------------------------------------------|--------------------------------------------------------|-------
 **clientProjectorTargetInfo** | [**ClientProjectorTargetInfoDto**](ClientProjectorTargetInfoDto.md) | the client, target, and the projector to be calibrated |

### Return type

[**ResultDtoManualAlignmentEngineResultDto**](ResultDtoManualAlignmentEngineResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandleacceptlocatetarget"></a>

# **CoreLaserServiceHandleAcceptLocateTarget**

> ResultDto CoreLaserServiceHandleAcceptLocateTarget (ClientInfoDto clientInfo)

See \"Manual Calibration\" in Integrators Guide

<example>              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleAcceptLocateTargetExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | the client currently doing manual calibration

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandleAcceptLocateTarget(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandleAcceptLocateTarget: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                   | Notes 
----------------|---------------------------------------|-----------------------------------------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) | the client currently doing manual calibration |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandlecancelmanualcalibration"></a>

# **CoreLaserServiceHandleCancelManualCalibration**

> ResultDto CoreLaserServiceHandleCancelManualCalibration (ClientInfoDto clientInfo)

See \"Manual Calibration\" in Integrators Guide

<example>              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleCancelManualCalibrationExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | the client currently doing manual calibration

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandleCancelManualCalibration(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandleCancelManualCalibration: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                   | Notes 
----------------|---------------------------------------|-----------------------------------------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) | the client currently doing manual calibration |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandlemovecursorabsoluterequest"></a>

# **CoreLaserServiceHandleMoveCursorAbsoluteRequest**

> ResultDto CoreLaserServiceHandleMoveCursorAbsoluteRequest (MoveCursorDto moveCursor)

See \"Manual Calibration\" in Integrators Guide

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleMoveCursorAbsoluteRequestExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var moveCursor = new MoveCursorDto(); // MoveCursorDto | the move cursor data to be used, the (X, Y) are the absolute position move to

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandleMoveCursorAbsoluteRequest(moveCursor);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandleMoveCursorAbsoluteRequest: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                                                   | Notes 
----------------|---------------------------------------|-------------------------------------------------------------------------------|-------
 **moveCursor** | [**MoveCursorDto**](MoveCursorDto.md) | the move cursor data to be used, the (X, Y) are the absolute position move to |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandlemovecursorrelativerequest"></a>

# **CoreLaserServiceHandleMoveCursorRelativeRequest**

> ResultDto CoreLaserServiceHandleMoveCursorRelativeRequest (MoveCursorDto moveCursor)

See \"Manual Calibration\" in Integrators Guide

<example>              MoveCursorDto {                  ClientInfo (ClientInfoDto, required),                  X (double, required),                  Y (double, required)              }              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleMoveCursorRelativeRequestExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var moveCursor = new MoveCursorDto(); // MoveCursorDto | the move cursor data to be used, the (X, Y) are the relative movement delta

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandleMoveCursorRelativeRequest(moveCursor);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandleMoveCursorRelativeRequest: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                                                 | Notes 
----------------|---------------------------------------|-----------------------------------------------------------------------------|-------
 **moveCursor** | [**MoveCursorDto**](MoveCursorDto.md) | the move cursor data to be used, the (X, Y) are the relative movement delta |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandlepredicttargetsrequest"></a>

# **CoreLaserServiceHandlePredictTargetsRequest**

> ResultDto CoreLaserServiceHandlePredictTargetsRequest (ClientInfoDto clientInfo)

See \"Manual Calibration\" in Integrators Guide

<example>              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandlePredictTargetsRequestExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | the client currently doing manual calibration

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandlePredictTargetsRequest(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandlePredictTargetsRequest: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                   | Notes 
----------------|---------------------------------------|-----------------------------------------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) | the client currently doing manual calibration |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandlerejectlocatetarget"></a>

# **CoreLaserServiceHandleRejectLocateTarget**

> ResultDto CoreLaserServiceHandleRejectLocateTarget (ClientInfoDto clientInfo)

See \"Manual Calibration\" in Integrators Guide

<example>              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }                 </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleRejectLocateTargetExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | the client currently doing manual calibration

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandleRejectLocateTarget(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandleRejectLocateTarget: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                   | Notes 
----------------|---------------------------------------|-----------------------------------------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) | the client currently doing manual calibration |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandleskiplocatetarget"></a>

# **CoreLaserServiceHandleSkipLocateTarget**

> ResultDto CoreLaserServiceHandleSkipLocateTarget (ClientInfoDto clientInfo)

See \"Manual Calibration\" in Integrators Guide

<example>              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleSkipLocateTargetExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | the client currently doing manual calibration

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceHandleSkipLocateTarget(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceHandleSkipLocateTarget: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                  | Description                                   | Notes 
----------------|---------------------------------------|-----------------------------------------------|-------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md) | the client currently doing manual calibration |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicelocktargetconfiguration"></a>

# **CoreLaserServiceLockTargetConfiguration**

> ResultDto CoreLaserServiceLockTargetConfiguration (TargetOrderedListDto targetOrderedList)

Saves target scan and target exclusion to the Work Order.

Same as the \"Lock Configuration\" button in the Projector Panel &gt; Targets Tab alignment controls. Saves target scans
and target enable/disable status to the Work Order; without this, the target information including saved target location
will revert to what was saved last in the Work Order when the Work Order is reopened. * TargetOrderedNameList - DO NOT
USE  <example>               TargetOrderedListDto { ClientInfo (ClientInfoDto, required), ProjectorSerial (string,
required), TargetOrderedNameList (Array[string])               } ClientInfoDto { ClientId (string, required),
OriginatingClientGuid (string, optional), Type (string, optional)               }               </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceLockTargetConfigurationExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var targetOrderedList = new TargetOrderedListDto(); // TargetOrderedListDto | 

            try
            {
                // Saves target scan and target exclusion to the Work Order.
                ResultDto result = apiInstance.CoreLaserServiceLockTargetConfiguration(targetOrderedList);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceLockTargetConfiguration: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                  | Type                                                | Description | Notes 
-----------------------|-----------------------------------------------------|-------------|-------
 **targetOrderedList** | [**TargetOrderedListDto**](TargetOrderedListDto.md) |             |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicestartmanualcalibration"></a>

# **CoreLaserServiceStartManualCalibration**

> ResultDtoBoolean CoreLaserServiceStartManualCalibration (StartManualCalibrationDto calibrationInfo)

See \"Manual Calibration\" in Integrators Guide

This call will fail if the projector being requested for calibration is already being used for calibration. In this
case, the client should assume calibration is cancelled.  <example>              StartManualCalibrationDto { ClientId (
string, required), ProjectorSerial (string, required), ScanOnlyMissedTargets (boolean,
required)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceStartManualCalibrationExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var calibrationInfo = new StartManualCalibrationDto(); // StartManualCalibrationDto | 

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDtoBoolean result = apiInstance.CoreLaserServiceStartManualCalibration(calibrationInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceStartManualCalibration: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                | Type                                                          | Description | Notes 
---------------------|---------------------------------------------------------------|-------------|-------
 **calibrationInfo** | [**StartManualCalibrationDto**](StartManualCalibrationDto.md) |             |

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceupdatetargetcollection"></a>

# **CoreLaserServiceUpdateTargetCollection**

> ResultDto CoreLaserServiceUpdateTargetCollection (UpdateTargetCollectionDto updateTargetCollection)

See \"Manual Calibration\" in Integrators Guide

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceUpdateTargetCollectionExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var updateTargetCollection = new UpdateTargetCollectionDto(); // UpdateTargetCollectionDto | the projector &amp; Targets Information

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceUpdateTargetCollection(updateTargetCollection);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceUpdateTargetCollection: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                       | Type                                                          | Description                                 | Notes 
----------------------------|---------------------------------------------------------------|---------------------------------------------|-------
 **updateTargetCollection** | [**UpdateTargetCollectionDto**](UpdateTargetCollectionDto.md) | the projector &amp;amp; Targets Information |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceupdatetargetinmodel"></a>

# **CoreLaserServiceUpdateTargetInModel**

> ResultDto CoreLaserServiceUpdateTargetInModel (UpdateTargetListInModelDto updateTargetInModel)

Update the certification target type

**ClientInfo** the client information  **TargetNameList* the list of the targets to update  **Certification** - true to
change to certification

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceUpdateTargetInModelExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var updateTargetInModel = new UpdateTargetListInModelDto(); // UpdateTargetListInModelDto | the projector &amp; Target Information

            try
            {
                // Update the certification target type
                ResultDto result = apiInstance.CoreLaserServiceUpdateTargetInModel(updateTargetInModel);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceUpdateTargetInModel: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                    | Type                                                            | Description                                | Notes 
-------------------------|-----------------------------------------------------------------|--------------------------------------------|-------
 **updateTargetInModel** | [**UpdateTargetListInModelDto**](UpdateTargetListInModelDto.md) | the projector &amp;amp; Target Information |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceupdatetargetlisttype"></a>

# **CoreLaserServiceUpdateTargetListType**

> ResultDto CoreLaserServiceUpdateTargetListType (UpdateTargetListTypeDto updateTargetListType)

See \"Manual Calibration\" in Integrators Guide

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceUpdateTargetListTypeExample
    {
        public void main()
        {
            var apiInstance = new ManualCalibrationApi();
            var updateTargetListType = new UpdateTargetListTypeDto(); // UpdateTargetListTypeDto | the projector &amp; Target Information

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDto result = apiInstance.CoreLaserServiceUpdateTargetListType(updateTargetListType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ManualCalibrationApi.CoreLaserServiceUpdateTargetListType: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                     | Type                                                      | Description                                | Notes 
--------------------------|-----------------------------------------------------------|--------------------------------------------|-------
 **updateTargetListType** | [**UpdateTargetListTypeDto**](UpdateTargetListTypeDto.md) | the projector &amp;amp; Target Information |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

